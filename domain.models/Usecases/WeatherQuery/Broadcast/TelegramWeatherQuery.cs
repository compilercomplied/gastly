using domain.models.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace domain.models.Usecases.WeatherQuery.Broadcast
{

  public class TelegramWeatherQuery
  {

    public TelegramWeatherQuery(WeatherLocationQueryRes data)
    {

      Header = BuildHeader();
      DayInfo = BuildDayInfo(data.Temperature, data.Humidity);
      Morning = BuildDaySegment(data.Morning, WeatherResources.Broadcast_Morning_Displayname);
      Afternoon = BuildDaySegment(data.Afternoon, WeatherResources.Broadcast_Afternoon_Displayname);
      Evening = BuildDaySegment(data.Evening, WeatherResources.Broadcast_Evening_Displayname);

    }

    public readonly string Header;
    public readonly string DayInfo;

    public readonly string Morning;
    public readonly string Afternoon;
    public readonly string Evening;


    public override string ToString()
    {
      return Header
        + $"\n{DayInfo}"
        + (!string.IsNullOrEmpty(Morning)   ? $"\n{Morning}"    : string.Empty)
        + (!string.IsNullOrEmpty(Afternoon) ? $"\n{Afternoon}"  : string.Empty)
        + (!string.IsNullOrEmpty(Evening)   ? $"\n{Evening}"    : string.Empty);
    }

    string BuildHeader()
    { 
      var tz = TimeZoneInfo.FindSystemTimeZoneById("Central European Standard Time");
      var now = TimeZoneInfo.ConvertTime(DateTime.UtcNow, tz);

      return $"<b>{now.ToString("dddd dd, MMMM")}</b>";
    }

    string BuildDayInfo(WLQTemperature temp, WLQHumidity hum)
    {
      return $"{temp.Min}-{temp.Max} C°"
        + $"\n{hum.Min}-{hum.Max}% 💧";
    }

    string BuildDaySegment(WLQDay data, string displayname)
    {

      string icon = data.RainfallProbability switch
      {
        var x when (x >= 50 && x < 90)  => "🌧",
        var x when (x >= 90)            => "🌧🌧",
        _                               => string.Empty,
      };

      return $"<code>{displayname}</code> {icon} ({data.RainfallProbability}%)";

    }

  }

}
