using domain.configuration.BroadcastClients;
using domain.contracts.Broadcast;
using infra.extensions.http;
using Microsoft.Extensions.Logging;
using System;
using System.Net.Http;

namespace infra.broadcast.Clients.Telegram
{

  public partial class TelegramBroadcast 
    : BaseSafeHttpClient<TelegramBroadcast>, IBroadcastClient
  {

    readonly TelegramBroadcastConfiguration _config;

    readonly string sendPath = "sendMessage";

    public TelegramBroadcast(HttpClient client, ILogger<TelegramBroadcast> logger)
      :base(client, logger)
    {

      _config = new TelegramBroadcastConfiguration();

    }
    string BuildSendCorePath()
    {
      return $"{Uri.EscapeDataString($"bot{_config.Token}")}/{sendPath}?chat_id={_config.ChatID}";
    }

  }

}
