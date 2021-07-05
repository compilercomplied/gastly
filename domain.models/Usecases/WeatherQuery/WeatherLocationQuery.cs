
namespace domain.models.Usecases.WeatherQuery
{

  public class WeatherLocationQueryReq
  {

    public string LocationID { get; set; }
    public bool Broadcast { get; set; } = true;

  }

  public class WeatherLocationQueryRes
  {

    public WLQTemperature Temperature { get; set; }
    public WLQHumidity Humidity { get; set; }
    public WLQDay Morning { get; set; }
    public WLQDay Afternoon { get; set; }
    public WLQDay Evening { get; set; }


  }

  public class WLQDay
  { 

    public WeatherStatus Weather { get; set; }
    public decimal RainfallProbability { get; set; }
    public WLQWind Wind { get; set; }
    public decimal? ExpectedTemperature { get; set; }
    public int Humidity { get; set; }

  }

  public class WLQHumidity
  { 

    public decimal Min { get; set; }
    public decimal Max { get; set; }

  }

  public class WLQTemperature
  { 

    public decimal Min { get; set; }
    public decimal Max { get; set; }

  }

  public class WLQWind
  { 

    public string Direction { get; set; }
    public int Speed { get; set; }

  }

}
