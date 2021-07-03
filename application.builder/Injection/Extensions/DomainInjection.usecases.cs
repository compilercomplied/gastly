using domain.usecases.Usecases;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace application.builder.Injection.Extensions
{

  public static partial class DomainInjection
  {

    public static IServiceCollection AddDomainUsecases(this IServiceCollection services)
    {

      services.AddScoped<WeatherQueryUC>();

      return services;

    }

  }

}
