using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FlightMobileAppServer.Models
{
    public class Command
    {
        public double Aileron { get; set; }
        public double Rudder { get; set; }
        public double Elevator { get; set; }
        public double Throttle { get; set; }

        // Set the values from post command.
        public void SetValuesFromPost(Command command)
        {
            Aileron = command.Aileron;
            Rudder = command.Rudder;
            Elevator = command.Elevator;
            Throttle = command.Throttle;
        }
    }
}