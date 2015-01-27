using Microsoft.Azure.WebJobs;
using RobotFactory.Common;
using System.IO;

namespace RobotFactory.ContinuousJob
{
    public class Functions
    {
        public static void InitializeRobot(
            [QueueTrigger(Strings.QueueNames.NeedsInitialization)] Robot robot,
            [Queue(Strings.QueueNames.NeedsRecharging)] out Robot toBeCharged,
            TextWriter writer)
        {
            writer.WriteLine(Strings.InitializeRobotLog, robot.Name);
            toBeCharged = robot;
        }

        public static void WorkRobot(
            [QueueTrigger(Strings.QueueNames.Working)] Robot robot,
            [Queue(Strings.QueueNames.NeedsRecharging)] ICollector<Robot> toBeCharged,
            [Queue(Strings.QueueNames.Working)] ICollector<Robot> toBeWorked,
            TextWriter writer)
        {
            writer.WriteLine(Strings.RobotIsWorkingLog, robot.Name);

            robot.DoWork();

            WebApiClient.UpdateRobotStatus(robot.Name, 
                robot.BatteryMeter);

            if (robot.BatteryMeter <= 20)
                toBeCharged.Add(robot);
            else
                toBeWorked.Add(robot);
        }

        public static void ChargeRobot(
            [QueueTrigger(Strings.QueueNames.NeedsRecharging)] Robot robot,
            [Queue(Strings.QueueNames.Working)] ICollector<Robot> toBeWorked,
            TextWriter writer)
        {
            robot.BatteryMeter = 100;
            writer.WriteLine(Strings.ChargeRobotLog, robot.Name);

            WebApiClient.RechargeRobot(robot.Name);

            toBeWorked.Add(robot);
        }
    }
}