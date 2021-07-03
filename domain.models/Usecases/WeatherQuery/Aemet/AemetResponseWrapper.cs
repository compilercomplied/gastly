using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace domain.models.Usecases.WeatherQuery.Aemet
{

  public class AemetResponseWrapper
  {

    [JsonPropertyName("datos")]
    public string Data { get; set; }

    [JsonPropertyName("estado")]
    public int Status { get; set; }

  }

}
