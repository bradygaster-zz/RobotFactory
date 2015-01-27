using Microsoft.AspNet.SignalR;
using RobotFactory.Web.Hubs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace RobotFactory.Web.Controllers
{
    public class RobotController : ApiController
    {
        [HttpGet]
        [Route("robot/charge/{robotName}/{value}")]
        public async Task<HttpResponseMessage> SetRobotCharge(string robotName, int value)
        {
            GlobalHost.ConnectionManager.GetHubContext<RobotStatusHub>()
                .Clients.All.receivedRobotChargeUpdate(robotName, value);

            return new HttpResponseMessage(HttpStatusCode.OK);
        }

        [HttpGet]
        [Route("robot/recharge/{robotName}")]
        public async Task<HttpResponseMessage> Recharge(string robotName)
        {
            GlobalHost.ConnectionManager.GetHubContext<RobotStatusHub>()
                .Clients.All.rechargerRobotMovedToRobot(robotName);

            return new HttpResponseMessage(HttpStatusCode.OK);
        }
    }
}
