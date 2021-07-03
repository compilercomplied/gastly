using application.builder.Injection.Extensions;
using application.console.Runners;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Threading.Tasks;

namespace application.console
{

  class Program
  {

    static Task Main(string[] args)
    {

      using IHost host = CreateHostBuilder(args).Build();
      return host.RunAsync();

    }

    static IHostBuilder CreateHostBuilder(string[] args) => Host
      .CreateDefaultBuilder(args)
      .ConfigureServices((_, services) => 
      {
        services.AddSingleton<IHostedService, ConsoleService>();
        services.AddSingleton<IRunner, WeatherQueryingRunner>();
        services.AddSingleton<IServiceProvider>(sp => sp);
        services.BuildDependencyTree(); 
      });

  }

}
