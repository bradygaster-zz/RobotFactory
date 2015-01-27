
namespace RobotFactory.Common
{
    public class Strings
    {
        public static string InitializeRobotLog = "Robot {0} has been initialized";
        public static string ChargeRobotLog = "Robot {0} has been charged";
        public static string NullRobotChargeLog = "Null robot needs no charge"; // i love this for some reason
        public static string NullRobotWorkLog = "Null robot needs no work";
        public static string RobotNeedsInitializationLog = "Robot {0} needs initialization.";
        public static string RobotIsWorkingLog = "Robot {0} is working";

        public class QueueNames
        {
            public const string NeedsInitialization = "needsinitialization";
            public const string NeedsRecharging = "needsrecharging";
            public const string Working = "working";
        }
    }
}
