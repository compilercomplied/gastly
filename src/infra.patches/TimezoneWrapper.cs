
using System;
using System.Runtime.InteropServices;

namespace infra.patches
{

  public static class TZWrapper
  {

    public static TimeZoneInfo GetLocalTZ() =>
      RuntimeInformation.IsOSPlatform(OSPlatform.Windows)
        ? TimeZoneInfo.FindSystemTimeZoneById("Central European Standard Time")
        : TimeZoneInfo.FindSystemTimeZoneById("CET");

  }

}
