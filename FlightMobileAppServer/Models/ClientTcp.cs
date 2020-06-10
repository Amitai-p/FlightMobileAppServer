using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Web;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace FlightMobileAppServer.Models
{
    public class ClientTcp : ITCPClient
    {
        TcpClient tcpclnt;
        NetworkStream stm;

        public ClientTcp()
        {
            this.tcpclnt = new TcpClient();
        }

        public void Connect(string ip, int port)
        {
            try
            {
                tcpclnt.Connect(ip, port);
                this.stm = this.tcpclnt.GetStream();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw new Exception("There is aproblem with connecting to the server");
            }
        }
        public void Disconnect()
        {
            tcpclnt.GetStream().Close();
            tcpclnt.Close();
            tcpclnt = null;
        }

        public string Read()
        {
            if (tcpclnt != null)
            {
                try
                {
                    if (tcpclnt.ReceiveBufferSize > 0)
                    {
                        byte[] bb = new byte[tcpclnt.ReceiveBufferSize];
                        int k = this.stm.Read(bb, 0, 100);
                        string massage = "";
                        for (int i = 0; i < k; i++)
                            massage += (Convert.ToChar(bb[i]));
                        return massage;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    //Thread.Sleep(2000);
                }
            }
            return "ERR";
        }
        public void Write(string command)
        {
            try
            {
                this.stm = this.tcpclnt.GetStream();
                ASCIIEncoding asen = new ASCIIEncoding();
                byte[] ba = asen.GetBytes(command);

                stm.Write(ba, 0, ba.Length);
            }
            catch (Exception e)
            {
                Console.WriteLine("The sever is stoped");
                Thread.Sleep(2000);
            }
        }
    }
}
