using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightMobileAppServer.Models
{
    interface ITCPClient
    {
        void Connect(string ip, int port);
        void Write(string command);
        string Read(); // blocking call
        void Disconnect();
    }
}
