using domain.configuration.Constants.Environment;
using System;

namespace domain.configuration.HttpClients
{

  public class AemetConfiguration
  {

    public AemetConfiguration() 
    {

      BaseUrl = EnvHelper.UnwrapEnvVar(Aemet.URL);
      Token = EnvHelper.UnwrapEnvVar(Aemet.TOKEN);

    }

    public string BaseUrl { get; set; }
    public string Token { get; set; }

  }

}
