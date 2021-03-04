using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Logging;
using Quartz;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using System.Threading;


namespace QuartzWorkerService.Controller
{
    [DisallowConcurrentExecution]
    public class Quartzz: BackgroundService,IJob
    {
        private readonly ILogger<Quartzz> _logger;
        public Quartzz(ILogger<Quartzz> logger)
        {
            _logger = logger;
        }

        public Task Execute(IJobExecutionContext context)
        {
            _logger.LogInformation("Can you see me");
            return Task.CompletedTask;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {

            while (!stoppingToken.IsCancellationRequested)
            {
                _logger.LogInformation("Background services running at: {time}", DateTimeOffset.Now);
                await Task.Delay(30000, stoppingToken);
            }
            // throw new NotImplementedException();
        }
    }
}
