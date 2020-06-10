using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FlightMobileAppServer.Models
{
    public class FlightGear
    {
        Dictionary<string, string> valuesAndPlaces = new Dictionary<string, string>();
        Queue<string> setReqeusts;
        ClientTcp tcp;
        string ipTcp;
        int portTcp;

        public FlightGear()
        {
            tcp = new ClientTcp();
            portTcp = 5402;
            //hostTcp = "http://localhost:8080/screenshot?window=WindowA&stream=y";
            ipTcp = "127.0.0.1";
            setReqeusts = new Queue<string>();
            valuesAndPlaces.Add("aileron", "/controls/flight/aileron");
            //new thread of Update etc.
        }

        public void Start()
        {
            try
            {
                tcp.Connect(ipTcp, portTcp);
            }
            catch (Exception)
            {
                Console.WriteLine("Problem in connect to tcp");
            }
        }

        public void setValues(Command command)
        {
            setReqeusts.Enqueue(setRequest("aileron", command.Aileron));
            setReqeusts.Enqueue(setRequest("rudder", command.Aileron));
            setReqeusts.Enqueue(setRequest("elevator", command.Aileron));
            setReqeusts.Enqueue(setRequest("throttle", command.Aileron));

         /*   valuesAndPlaces.Add("aileron", setRequest("aileron", command.Aileron));
            valuesAndPlaces.Add("rudder", setRequest("rudder", command.Aileron));
            valuesAndPlaces.Add("elevator", setRequest("elevator", command.Aileron));
            valuesAndPlaces.Add("throttle", setRequest("throttle", command.Aileron));*/
            // Send the requests to the flightGear and update the values that we get.

        }

        public void UpdateTcpSetValues(Command command)
        {
            string temp;
            while (setReqeusts.Count > 0)
            {
                temp = setReqeusts.Dequeue();
                tcp.Write(temp);
               // string s = tcp.Read();
            }
            //while there is no values in queue then send set request to flightGear
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