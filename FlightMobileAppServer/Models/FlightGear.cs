using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FlightMobileAppServer.Models
{
    public class FlightGear
    {
        Dictionary<string, string> valuesAndPlaces = new Dictionary<string, string>();

        public FlightGear()
        {
            valuesAndPlaces.Add("aileron", "/controls/flight/aileron");

        }

        public void setValues(Command command)
        {
            valuesAndPlaces.Add("aileron", setRequest("aileron", command.Aileron));
            valuesAndPlaces.Add("rudder", setRequest("rudder", command.Aileron));
            valuesAndPlaces.Add("elevator", setRequest("elevator", command.Aileron));
            valuesAndPlaces.Add("throttle", setRequest("throttle", command.Aileron));
            // Send the requests to the flightGear and update the values that we get.

        }

        public string setRequest(string variable, double val)
        {
            string str = "set /controls/flight/" + variable + "/"  + val;
            str += " \n";
            return str;
        }

        public bool checkSuccessInPost(Command command)
        {
            // Get from the FlightGear the 4 values. recieve.
            // Check that the values correct.
            // If not - return false.
            return true;
        }
    }
}