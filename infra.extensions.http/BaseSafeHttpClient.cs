using domain.extensions.Core.Result;
using Microsoft.Extensions.Logging;
using System;
using System.Net;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace infra.extensions.http
{

  public abstract class BaseSafeHttpClient<T>
  {

    protected readonly HttpClient _client;
    protected readonly ILogger<T> _logger;

    public BaseSafeHttpClient(HttpClient client, ILogger<T> logger) 
    {

      _client = client;
      _logger = logger;

    }

    protected async Task<HttpResponseMessage> SafeGetAsync(string path) 
    { 

      try
      {
        return await _client.GetAsync(path);
      }
      catch (Exception ex)
      {
        _logger.LogError($"{ex.Message}");

        HttpResponseMessage errorResponse = new HttpResponseMessage
        {
          StatusCode = HttpStatusCode.ServiceUnavailable,
          Content = new StringContent(ex.Message),
        };

        return errorResponse;

      }

    }

    protected async Task<Result<U>> HandleResponse<U>(HttpResponseMessage resp)
    {
      return resp.IsSuccessStatusCode
        ? await HandleSuccess<U>(resp)
        : await HandleError<U>(resp);
    }

    async Task<Result<TPayload>> HandleSuccess<TPayload>(HttpResponseMessage response)
    {

      var content = await response.Content.ReadAsStringAsync();
      var resp = JsonSerializer.Deserialize<TPayload>(content);

      return Result<TPayload>.OK(resp);

    }

    async Task<Result<TPayload>> HandleError<TPayload>(HttpResponseMessage response)
    {

      var content = await response.Content.ReadAsStringAsync();
      _logger.LogError($"HTTP{(int)response.StatusCode} - {content}");

      return Result<TPayload>.FAIL(content);

    }

  }

}
