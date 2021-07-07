using domain.mapping;
using Microsoft.Extensions.DependencyInjection;

namespace application.builder.Injection.Extensions
{

  public static class AppInjection
  {

    public static IServiceCollection BuildDependencyTree(this IServiceCollection services)
    {

      services.AddHttpClient();

      services.AddAutoMapper(typeof(MapperInitialization));


      services
        .AddDomainHttpClients()
        .AddDomainBroadcastClients()
        .AddDomainUsecases();


      return services;

    }

  }

}
