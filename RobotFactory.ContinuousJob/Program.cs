using Microsoft.Azure.WebJobs;
using System;

namespace RobotFactory.ContinuousJob
{
    class Program
    {
        static void Main()
        {
            var config = new JobHostConfiguration();
            config.Queues.MaxPollingInterval = TimeSpan.FromSeconds(2);

            var host = new JobHost(config);
            host.RunAndBlock();
        }
    }
}
