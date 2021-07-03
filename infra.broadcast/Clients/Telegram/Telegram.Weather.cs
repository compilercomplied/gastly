using domain.models.Usecases.WeatherQuery;
using domain.models.Usecases.WeatherQuery.Broadcast;
using System;
using System.Threading.Tasks;

namespace infra.broadcast.Clients.Telegram
{

  public partial class TelegramBroadcast
  {

    public async Task<bool> WeatherAlert(WeatherLocationQueryRes data)
    {

      string path = BuildSendCorePath();

      var message = new TelegramWeatherQuery(data);
      var encodedMessage = Uri.EscapeDataString(message.ToString());

      var encodedPath = $"{path}&text={encodedMessage}&parse_mode=HTML";

      var result = await SafeGetAsync(encodedPath.ToString());

      return result.IsSuccessStatusCode;

    }

  }

}
