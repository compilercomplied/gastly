using domain.extensions.Core.Result;
using domain.models.Usecases.WeatherQuery.Aemet;
using System.Threading.Tasks;

namespace infra.http.Clients.Aemet
{

  public partial class AemetClient
  {

    async Task<string> GetWrapperData(string path)
    {

      var clientResponse = await SafeGetAsync(path);

      var result = await HandleResponse<AemetResponseWrapper>(clientResponse);

      var wrapper = result.Unwrap();

      // double check; AEMET's service wrongly returns a 200 while wrapping
      // the actual http status within the payload
      if ((wrapper?.Status ?? -1) != 200) 
        throw new OperationException("Malformed AEMET request");


      return wrapper.Data.Replace(_config.BaseUrl, string.Empty);

    }

  }

}
