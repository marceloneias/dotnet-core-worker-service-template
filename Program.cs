using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;

namespace MeuWorker
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureServices((hostContext, services) =>
                {
                    IConfiguration configuration = hostContext.Configuration;

                    services.AddHostedService<WorkerService1>()
                        .AddHostedService<WorkerService2>();

                    services.Configure<HostOptions>(options =>
                    {
                        var ShutdownTimeoutInSeconds = configuration.GetSection("ServiceConfigurations").GetValue<double>("ShutdownTimeoutInSeconds");
                        options.ShutdownTimeout = TimeSpan.FromSeconds(ShutdownTimeoutInSeconds);
                    });
                });
    }
}
