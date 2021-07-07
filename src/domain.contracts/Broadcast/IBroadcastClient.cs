using domain.models.Usecases.WeatherQuery;
using System.Threading.Tasks;

namespace domain.contracts.Broadcast
{

  public interface IBroadcastClient
  {

    Task<bool> WeatherAlert(WeatherLocationQueryRes data);

  }

}
