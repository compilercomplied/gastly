using System;
using System.Collections.Generic;
using System.Text;

namespace domain.configuration
{
  public static class EnvHelper
  {
    public static string UnwrapEnvVar(string name) =>
      Environment.GetEnvironmentVariable(name) 
      ?? throw new Exception($"Unknown env var '{name}'");
  }
}
