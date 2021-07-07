using domain.configuration.Constants.Environment;
using System;

namespace domain.configuration.BroadcastClients
{
  public class TelegramBroadcastConfiguration
  {
    public TelegramBroadcastConfiguration() 
    {

      BaseUrl = EnvHelper.UnwrapEnvVar(Telegram.URL);
      Token = EnvHelper.UnwrapEnvVar(Telegram.TOKEN);
      ChatID = EnvHelper.UnwrapEnvVar(Telegram.CHAT_ID);

    }

    public string BaseUrl { get; set; }
    public string Token { get; set; }
    public string ChatID { get; set; }
  }
}
