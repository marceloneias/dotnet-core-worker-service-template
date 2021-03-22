using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace MeuWorker
{
    public class WorkerService1 : BackgroundService
    {
        private readonly ILogger<WorkerService1> _logger;
        private readonly ServiceConfigurations _serviceConfigurations;

        public WorkerService1(ILogger<WorkerService1> logger, IConfiguration configuration)
        {
            _logger = logger;

            _serviceConfigurations = new ServiceConfigurations();
            new ConfigureFromConfigurationOptions<ServiceConfigurations>(
                configuration.GetSection("ServiceConfigurations"))
                .Configure(_serviceConfigurations);

            _logger.LogWarning($"Worker Service 1 Interval in Seconds: {_serviceConfigurations.WorkerService1_IntervalInSeconds}");
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                await Task.Delay(_serviceConfigurations.WorkerService1_IntervalInMilliseconds, stoppingToken);

                //Your worker service code should be write here.
                _logger.LogInformation("Worker Service 1 running at: {time}", DateTimeOffset.Now);
            }
        }

        public override async Task StartAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Worker Service 1 started at: {time}", DateTimeOffset.Now);
            await base.StartAsync(cancellationToken);
        }

        public override async Task StopAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Worker Service 1 stopped at: {time}", DateTimeOffset.Now);
            await base.StopAsync(cancellationToken);
        }
    }
}
