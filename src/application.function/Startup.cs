using application.builder.Injection.Extensions;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using System;

[assembly: FunctionsStartup(typeof(application.function.Startup))]
namespace application.function
{

  public class Startup : FunctionsStartup
  {

    public override void Configure(IFunctionsHostBuilder builder)
    {
      builder.Services.BuildDependencyTree();
    }

  }

}
