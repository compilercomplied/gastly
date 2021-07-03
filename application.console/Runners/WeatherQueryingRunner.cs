using domain.models.Usecases.WeatherQuery;
using domain.usecases.Usecases;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace application.console.Runners
{
  public class WeatherQueryingRunner : IRunner
  {

    readonly IServiceProvider _services;
    readonly ILogger<WeatherQueryingRunner> _logger;

    public WeatherQueryingRunner(IServiceProvider services, ILogger<WeatherQueryingRunner> logger)
    {
      _services = services;
      _logger = logger;
    }

    public async Task Run()
    {

      using (var scope = _services.CreateScope())
      {
        var uc = scope.ServiceProvider.GetService<WeatherQueryUC>();
        var data = new WeatherLocationQueryReq { LocationID = "33044" };

        var result = await uc.QueryLocation(data);
        _logger.LogInformation($"Success: {result.IsSuccess}");
      }

    }

  }

}
