
namespace domain.models.Usecases.WeatherQuery.Aemet
{

  public class WeatherStatusAemetConverter
  {

    public readonly WeatherStatus WeatherStatus;

    public WeatherStatusAemetConverter(string value)
    {

      WeatherStatus = value switch
      {

        #region dry
        var arg when
          arg == "11"   ||  // Despejado
          arg == "11n"  ||  // Despejado noche
          arg == "12"   ||  // Poco nuboso
          arg == "12n"  ||  // Poco nuboso noche
          arg == "13"   ||  // Intervalos nubosos
          arg == "13n"  ||  // Intervalos nubosos noche
          arg == "17"   ||  // Nubes altas
          arg == "17n"  ||  // Nubes altas noche
          arg == "81"   ||  // Niebla
          arg == "82"   ||  // Bruma
          arg == "83"       // Calma
            => WeatherStatus.Sunny,  

        var arg when
          arg == "14"   ||  // Nuboso
          arg == "14n"      // Nuboso noche
            => WeatherStatus.Cloudy,

        var arg when
          arg == "15"   ||  // Muy nuboso
          arg == "16"       // Cubierto
            => WeatherStatus.Overcast,

        var arg when
          arg == "51"   ||  // Intervalos nubosos con tormenta
          arg == "51n"  ||  // Intervalos nubosos con tormenta noche
          arg == "52"   ||  // Nuboso con tormenta
          arg == "52n"  ||  // Nuboso con tormenta noche
          arg == "53"   ||  // Muy nuboso con tormenta
          arg == "54"       // Cubierto con tormenta
            => WeatherStatus.Storm,
        #endregion dry

        #region rain
        var arg when
          arg == "23"   ||  // Intervalos nubosos con lluvia
          arg == "23n"  ||  // Intervalos nubosos con lluvia noche
          arg == "24"   ||  // Nuboso con lluvia
          arg == "24n"  ||  // Nuboso con lluvia noche
          arg == "43"   ||  // Intervalos nubosos con lluvia escasa
          arg == "43n"  ||  // Intervalos nubosos con lluvia escasa noche
          arg == "44"   ||  // Nuboso con lluvia escasa
          arg == "44n"      // Nuboso con lluvia escasa noche
            => WeatherStatus.CloudyRain,

        var arg when
          arg == "25"   ||  // Muy nuboso con lluvia
          arg == "26"   ||  // Muy nuboso con lluvia
          arg == "45"   ||  // Muy nuboso con lluvia escasa
          arg == "46"   ||  // Cubierto con lluvia escasa
          arg == "53"   ||  // Muy nuboso con tormenta
          arg == "54"       // Cubierto con tormenta
            => WeatherStatus.OvercastRain,

        var arg when

          arg == "61"   ||  // Intervalos nubosos con tormenta y lluvia escasa
          arg == "61n"  ||  // Intervalos nubosos con tormenta y lluvia escasa noche
          arg == "63"   ||  // Muy nuboso con tormenta y lluvia escasa
          arg == "64"   ||  // Cubierto con tormenta y lluvia escasa
          arg == "62"   ||  // Nuboso con tormenta y lluvia escasa
          arg == "62n"      // Nuboso con tormenta y lluvia escasa noche
            => WeatherStatus.StormRain,
        #endregion rain

        #region snow
        var arg when
          arg == "33"   ||  // Intervalos nubosos con nieve
          arg == "33n"  ||  // Intervalos nubosos con nieve noche
          arg == "34"   ||  // Nuboso con nieve
          arg == "34n"  ||  // Nuboso con nieve noche
          arg == "71"   ||  // Intervalos nubosos con nieve escasa
          arg == "71n"  ||  // Intervalos nubosos con nieve escasa noche
          arg == "72"   ||  // Nuboso con nieve escasa
          arg == "72n"      // Nuboso con nieve escasa noche
            => WeatherStatus.CloudySnow,

        var arg when
          arg == "35"   ||  // Muy nuboso con nieve
          arg == "36"   ||  // Cubierto con nieve
          arg == "73"   ||  // Muy nuboso con nieve escasa
          arg == "74"       // Cubierto con nieve escasa
            => WeatherStatus.OvercastSnow,
        #endregion snow

        _ => WeatherStatus.Unknown,

      };

    }


  }

}
