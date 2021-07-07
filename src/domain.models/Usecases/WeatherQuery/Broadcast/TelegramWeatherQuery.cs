using domain.models.Resources;
using infra.patches;
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
      return Header + "\n"
        + (!string.IsNullOrEmpty(Morning)   ? $"\n{Morning}"    : string.Empty)
        + (!string.IsNullOrEmpty(Afternoon) ? $"\n{Afternoon}"  : string.Empty)
        + (!string.IsNullOrEmpty(Evening)   ? $"\n{Evening}"    : string.Empty)
        +$"\n\n{DayInfo}";
    }

    string BuildHeader()
    { 

      var now = TimeZoneInfo
        .ConvertTime(DateTime.UtcNow, TZWrapper.GetLocalTZ());

      return $"<b>{now.ToString("dddd dd, MMMM")}</b>";

    }

    string BuildDayInfo(WLQTemperature temp, WLQHumidity hum)
    {
      return $"🌡 {temp.Min}/{temp.Max} °C\n"
        + $"💧 {hum.Min}/{hum.Max}%";
    }

    string BuildDaySegment(WLQDay data, string displayname)
    {

      string icon = data.Weather switch
      {
        WeatherStatus.Sunny     => @"☀️",
        WeatherStatus.Cloudy    => @"🌤",
        WeatherStatus.Overcast  => @"☁️",
        WeatherStatus.Storm     => @"⚡️",

        WeatherStatus.CloudyRain    => @"🌦",
        WeatherStatus.OvercastRain  => @"🌧",
        WeatherStatus.StormRain     => @"⛈",

        WeatherStatus.CloudySnow    => @"❄️",
        WeatherStatus.OvercastSnow  => @"🌨",

        _ => "🙉",
      };

      string displayRainfall = data.RainfallProbability < 10
        ? $"0{data.RainfallProbability}"
        : data.RainfallProbability.ToString();

      string displayTemperature = 
        FormatDisplayTemperature(data.ExpectedTemperature);

      string displayHumidity = FormatDisplayHumidity(data.Humidity);

      return
        $"{icon} <i>{displayRainfall}%</i><code> |=|{displayTemperature}°C|=|{displayHumidity}</code>";

    }

    string FormatDisplayHumidity(decimal humidity)
    {

      if (humidity >= 100)      return $"{humidity}%";
      else if (humidity >= 10)  return $" {humidity}%";
      else                      return $" {humidity} %";

    }

    string FormatDisplayTemperature(decimal? temperature)
    {
      if (!temperature.HasValue) return " ? ";

      string result = (temperature < 10 && temperature > -10)
        ? $"0{temperature}"
        : temperature.ToString();

      return result;
      
    }

  }

}
