using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Quartz;
using QuartzWorkerService.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuartzWorkerService
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
                    // Add the required Quartz.NET services
                    services.AddQuartz(q =>
                    {
                        // Use a Scoped container to create jobs. I'll touch on this later
                        q.UseMicrosoftDependencyInjectionScopedJobFactory();
                        // Create a "key" for the job
                        //  var jobKey = new JobKey("This is the Job Key");

                        // Register the job with the DI container
                        // q.AddJob<Quartzz>(opts => opts.WithIdentity(jobKey));
                        // Create a trigger for the job
                        //q.AddTrigger(opts => opts
                        //    .ForJob(jobKey) // link to the HelloWorldJob
                        //    .WithIdentity("My Job Trigger-trigger") // give the trigger a unique name
                        //    .WithCronSchedule("5 * * * * ?")); // run every 5 seconds
                        // Register the job, loading the schedule from configuration
                    q.AddJobAndTrigger<Quartzz>(hostContext.Configuration);

                    });

                    // Add the Quartz.NET hosted service

                    services.AddQuartzHostedService(
                        q => q.WaitForJobsToComplete = true);
                  //  services.AddHostedService<Quartzz>();
                });
    }
}