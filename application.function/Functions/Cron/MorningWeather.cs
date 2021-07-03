using domain.models.Usecases.WeatherQuery;
using domain.usecases.Usecases;
using Microsoft.Azure.WebJobs;
using System.Threading.Tasks;

namespace application.function.Functions.Cron
{

  public class MorningWeather
  {

    readonly WeatherQueryUC _weatherUC;

    public MorningWeather(WeatherQueryUC weatherUC)
    {
      _weatherUC = weatherUC;
    }

    [FunctionName("MorningWeather")]
    public async Task Run(
      [TimerTrigger("0 30 5 * * *")] TimerInfo myTimer
    )
    {

      var query = new WeatherLocationQueryReq { LocationID = "33044" };

      await _weatherUC.QueryLocation(query);

    }

  }

}
