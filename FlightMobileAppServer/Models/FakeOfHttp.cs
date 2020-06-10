using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace FlightMobileAppServer.Models
{
    public class FakeOfHttp
    {
       
        private FlightGear flightGear = new FlightGear();
        private static Command commandManager = new Command();
        public FakeOfHttp()
        {
            Command value = new Command()
            {
                Aileron = 1,
                Elevator = 0.98,
                Throttle = 0.32,
                Rudder = -0.93
            };
            commandManager.SetValuesFromPost(value);
            // Call the methood that will update the values and update the flightGear.
            flightGear.setValues(value);
            if (!flightGear.checkSuccessInPost(value))
            {
                //return "Dont success".
            }

            flightGear.UpdateTcpSetValues(value);
            }
    }
}