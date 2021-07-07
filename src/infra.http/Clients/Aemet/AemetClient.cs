using AutoMapper;
using domain.configuration.HttpClients;
using domain.contracts.HttpClients;
using domain.extensions.Core.Result;
using infra.extensions.http;
using Microsoft.Extensions.Logging;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace infra.http.Clients.Aemet
{

  public partial class AemetClient 
    : BaseSafeHttpClient<AemetClient>, IWeatherClient
  {
    readonly AemetConfiguration _config;
    readonly IMapper _mapper;

    readonly string DayQueryLocationPath =
      "/opendata/api/prediccion/especifica/municipio/diaria/{0}";

    public AemetClient(
      HttpClient client, 
      ILogger<AemetClient> logger, 
      IMapper mapper
    ) :base(client, logger) 
    {

      _config = new AemetConfiguration();
      _mapper = mapper;

    }

    async new Task<Result<U>> HandleResponse<U>(HttpResponseMessage resp)
    {
      return resp.IsSuccessStatusCode
        ? await HandleSuccess<U>(resp)
        : await HandleError<U>(resp);
    }

    async Task<Result<TPayload>> HandleSuccess<TPayload>(HttpResponseMessage response)
    {

      byte[] raw = await response.Content.ReadAsByteArrayAsync();
      string rawJson = Encoding.Default.GetString(raw);

      var resp = JsonSerializer.Deserialize<TPayload>(rawJson);

      return Result<TPayload>.OK(resp);

    }

    async Task<Result<TPayload>> HandleError<TPayload>(HttpResponseMessage response)
    {

      byte[] raw = await response.Content.ReadAsByteArrayAsync();
      string payload = Encoding.Default.GetString(raw);

      _logger.LogError($"HTTP{(int)response.StatusCode} - {payload}");

      return Result<TPayload>.FAIL(payload);

    }

  }

}
