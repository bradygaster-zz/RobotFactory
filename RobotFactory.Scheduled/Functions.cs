using Microsoft.Azure.WebJobs;
using RobotFactory.Common;
using System.Collections.Generic;
using System.IO;

namespace RobotFactory.Scheduled
{
    public class Functions
    {
        [NoAutomaticTrigger]
        public static void SetupRobot(TextWriter log, 
            Robot robot,
            [Queue(Strings.QueueNames.NeedsInitialization)] out Robot toBeInitialized)
        {
            log.WriteLine(Strings.RobotNeedsInitializationLog, robot.Name);

            toBeInitialized = robot;
        }
    }
}
