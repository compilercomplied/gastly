using domain.contracts.Broadcast;
using domain.contracts.HttpClients;
using domain.extensions.Core.Result;
using domain.models.Usecases.WeatherQuery;
using System.Threading.Tasks;

namespace domain.usecases.Usecases
{

  #region aliases
  using WeatherLocationResult = Result<WeatherLocationQueryRes>;
  #endregion aliases

  public class WeatherQueryUC
  {

    readonly IWeatherClient _weatherClient;
    readonly IBroadcastClient _broadcastClient;

    public WeatherQueryUC(IWeatherClient weather, IBroadcastClient broadcast)
    {

      _weatherClient = weather;
      _broadcastClient = broadcast;

    }


    public async Task<WeatherLocationResult> QueryLocation(WeatherLocationQueryReq req)
    {

      var result = await _weatherClient.QueryLocation(req);

      if (result.IsSuccess)
        await _broadcastClient.WeatherAlert(result.Value);

      return result;

    }

  }

}
