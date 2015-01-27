
namespace RobotFactory.Common
{
    public class Robot
    {
        public string Name { get; set; }

        public int BatteryMeter { get; set; }

        public int CostToWork { get; set; }

        public Robot()
        {
            this.BatteryMeter = 0;
            this.CostToWork = 10;
        }

        public void DoWork()
        {
            this.BatteryMeter -= this.CostToWork;
        }
    }
}
