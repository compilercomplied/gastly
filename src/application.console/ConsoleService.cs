using Microsoft.Extensions.Hosting;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace application.console
{

  public class ConsoleService : IHostedService
  {

    readonly IRunner _runner;

    public ConsoleService(IRunner runner)
    {
      _runner = runner;
    }

    public Task StartAsync(CancellationToken cancellationToken)
    {

      _runner.Run();
      return Task.CompletedTask;

    }

    public Task StopAsync(CancellationToken cancellationToken)
    {

      Console.WriteLine("Goodbye world!");
      return Task.CompletedTask;

    }

  }

}
