using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Logging;
using Quartz;
using System.Threading.Tasks;
namespace QuartzWorkerService.Controller
{
    [DisallowConcurrentExecution]
    public class Quartzz:IJob
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
    }
}
