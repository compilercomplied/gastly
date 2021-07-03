using domain.configuration.BroadcastClients;
using domain.contracts.Broadcast;
using infra.broadcast.Clients.Telegram;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace application.builder.Injection.Extensions
{

  public static partial class DomainInjection
  {

    public static IServiceCollection AddDomainBroadcastClients(this IServiceCollection services)
    {

      var cfg = new TelegramBroadcastConfiguration();

      services.AddHttpClient<IBroadcastClient, TelegramBroadcast>(client => 
      {
        client.BaseAddress = new Uri(cfg.BaseUrl);
      });

      return services;

    }

  }

}
