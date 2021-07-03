using domain.extensions.Core.Result;
using domain.models.Usecases.WeatherQuery;
using System.Threading.Tasks;

namespace domain.contracts.HttpClients
{

  #region aliases
  using WeatherLocationResult = Result<WeatherLocationQueryRes>;
  #endregion aliases

  public interface IWeatherClient
  {

    Task<WeatherLocationResult> QueryLocation(WeatherLocationQueryReq req);

  }

}
