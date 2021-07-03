using domain.models.Usecases.WeatherQuery;
using domain.models.Usecases.WeatherQuery.Aemet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace domain.mapping.Profiles
{

  public partial class WeatherProfile
  {

    void AemetMaps()
    {

      CreateMap<Dia, WeatherLocationQueryRes>()
        .ForMember(src => src.Morning, opts => opts.MapFrom(src =>
          new WLQDay
          { 
            RainfallProbability = src.ProbPrecipitacion.FirstOrDefault(p => p.Periodo == "06-12") != null
              ? src.ProbPrecipitacion.FirstOrDefault(p => p.Periodo == "06-12").Value : 0,
            Wind = src.Viento.FirstOrDefault(p => p.Periodo == "06-12") != null
              ? new WLQWind 
              {
                Direction = src.Viento.FirstOrDefault(p => p.Periodo == "06-12").Direccion,
                Speed = src.Viento.FirstOrDefault(p => p.Periodo == "06-12").Velocidad,
              } : null
          }))
        .ForMember(src => src.Afternoon, opts => opts.MapFrom(src =>
          new WLQDay
          { 
            RainfallProbability = src.ProbPrecipitacion.FirstOrDefault(p => p.Periodo == "12-18") != null
              ? src.ProbPrecipitacion.FirstOrDefault(p => p.Periodo == "12-18").Value : 0,
            Wind = src.Viento.FirstOrDefault(p => p.Periodo == "12-18") != null
              ? new WLQWind 
              {
                Direction = src.Viento.FirstOrDefault(p => p.Periodo == "12-18").Direccion,
                Speed = src.Viento.FirstOrDefault(p => p.Periodo == "12-18").Velocidad,
              } : null
          }))
        .ForMember(src => src.Evening, opts => opts.MapFrom(src =>
          new WLQDay
          { 
            RainfallProbability = src.ProbPrecipitacion.FirstOrDefault(p => p.Periodo == "18-24") != null
              ? src.ProbPrecipitacion.FirstOrDefault(p => p.Periodo == "18-24").Value : 0,
            Wind = src.Viento.FirstOrDefault(p => p.Periodo == "18-24") != null
              ? new WLQWind 
              {
                Direction = src.Viento.FirstOrDefault(p => p.Periodo == "18-24").Direccion,
                Speed = src.Viento.FirstOrDefault(p => p.Periodo == "18-24").Velocidad,
              } : null
          }))

        .ForMember(src => src.Temperature, opts => opts.MapFrom(src =>
          new WLQTemperature
          {
            Max = src.Temperatura.Maxima,
            Min = src.Temperatura.Minima,
          })
        )
        .ForMember(src => src.Humidity, opts => opts.MapFrom(src =>
          new WLQHumidity
          {
            Max = src.HumedadRelativa.Maxima,
            Min = src.HumedadRelativa.Minima,
          })
        );

    }

  }

}
