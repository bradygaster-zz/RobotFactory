using Microsoft.Azure.WebJobs;
using RobotFactory.Common;
using System;
using System.Collections.Generic;

namespace RobotFactory.Scheduled
{
    class Program
    {
        static void Main()
        {
            var config = new JobHostConfiguration();

            // start the job host
            JobHost host = new JobHost(config);

            host.Call(typeof(Functions).GetMethod("SetupRobot"),
                new
                {
                    robot = new Robot
                    {
                        Name = "HAL",
                        CostToWork = 10
                    }
                });

            host.Call(typeof(Functions).GetMethod("SetupRobot"),
                new
                {
                    robot = new Robot 
                    { 
                        Name = "RJD2",
                        CostToWork = 20
                    }
                });

            host.Call(typeof(Functions).GetMethod("SetupRobot"),
                new
                {
                    robot = new Robot
                    { 
                        Name = "R2D2",
                        CostToWork = 30
                    }
                });
        }
    }
}