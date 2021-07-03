using domain.configuration.HttpClients;
using domain.contracts.HttpClients;
using infra.http.Clients.Aemet;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace application.builder.Injection.Extensions
{

  public static partial class DomainInjection
  {

    public static IServiceCollection AddDomainHttpClients(this IServiceCollection services)
    {


      var cfg = new AemetConfiguration();

      services.AddHttpClient<IWeatherClient, AemetClient>(client => 
      {

        client.BaseAddress = new Uri(cfg.BaseUrl);

        client.DefaultRequestHeaders.Add(
          "api_key",
          cfg.Token
        );

      });

      return services;

    }

  }

}
