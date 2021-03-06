﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Web;
using System.IO;
using System.Web.Services.Description;

namespace FlightMobileAppServer.Models
{
    public class Server
    {
        FlightGear flightGear;

        // Connection to simulator for screenshot.
        // Connection to application.
        public Server()
        {
            flightGear = new FlightGear();
         
        
            //string result = SocketSendReceive(hostTcp, portTcp);

            
        }
        
        public void Start()
        {
            flightGear.Start();
            
        }
        /* IPEndPoint localEndPoint = new IPEndPoint(IPAddress.Any, 8000);
         Socket newsock = new Socket(AddressFamily.InterNetwork,
                            SocketType.Stream, ProtocolType.Tcp);
         newsock.Bind(localEndPoint);
         newsock.Listen(10);
         Socket client = newsock.Accept();*/
        public static Socket ConnectSocket(string server, int port)
        {
            Socket s = null;
            IPHostEntry hostEntry = null;

            // Get host related information.
            hostEntry = Dns.GetHostEntry(server);

            // Loop through the AddressList to obtain the supported AddressFamily. This is to avoid
            // an exception that occurs when the host IP Address is not compatible with the address family
            // (typical in the IPv6 case).
            foreach (IPAddress address in hostEntry.AddressList)
            {
                IPEndPoint ipe = new IPEndPoint(address, port);
                Socket tempSocket =
                    new Socket(ipe.AddressFamily, SocketType.Stream, ProtocolType.Tcp);

                tempSocket.Connect(ipe);

                if (tempSocket.Connected)
                {
                    s = tempSocket;
                    break;
                }
                else
                {
                    continue;
                }
            }
            return s;
        }
        public static string SocketSendReceive(string server, int port)
        {
            string request = "GET / HTTP/1.1\r\nHost: " + server +
                "\r\nConnection: Close\r\n\r\n";
            Byte[] bytesSent = Encoding.ASCII.GetBytes(request);
            Byte[] bytesReceived = new Byte[256];
            string page = "";

            // Create a socket connection with the specified server and port.
            using (Socket s = ConnectSocket(server, port))
            {

                if (s == null)
                    return ("Connection failed");

                // Send request to the server.
                s.Send(bytesSent, bytesSent.Length, 0);

                // Receive the server home page content.
                int bytes = 0;
                page = "Default HTML page on " + server + ":\r\n";

                // The following will block until the page is transmitted.
                do
                {
                    bytes = s.Receive(bytesReceived, bytesReceived.Length, 0);
                    page = page + Encoding.ASCII.GetString(bytesReceived, 0, bytes);
                }
                while (bytes > 0);
            }

            return page;
        }

       /* public static void Main(string[] args)
        {
            string host;
            int port = 80;

            if (args.Length == 0)
                // If no server name is passed as argument to this program,
                // use the current host name as the default.
                host = Dns.GetHostName();
            else
                host = args[0];

            host = "www.google.com";
            string result = SocketSendReceive(host, port);
            Console.WriteLine(result);
        }*/
    }
}