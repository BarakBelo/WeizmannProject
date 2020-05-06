using System;
using System.Text;
using System.Net.Sockets;

namespace Server
{
    class Client
    {
        public Socket ClientConnetion;
        public Client (Socket sock)
        {
            this.ClientConnetion=sock;
        }
        public Socket GetSock ()
        {
            return this.ClientConnetion;
        }
        public void SetSock (Socket sock)
        {
            this.ClientConnetion=sock;
        }
        public void sendData(string msg)
        {
            ClientConnetion.Send(ASCIIEncoding.ASCII.GetBytes(msg));
        }
        public String GetData ()
        {
            String msg;
            byte [] buffer= new byte [1024];
            int MsgLength=ClientConnetion.Receive(buffer);
            msg=Encoding.ASCII.GetString(buffer, 0, MsgLength);
            return msg;
        }
        public void GetPic(string location, string data)
        {


            try
            {
                Download d = new Download();
                d.StartDownload(location, data, ClientConnetion);
            }
            catch
            {
                GetPic(location, data);
            }
        }
        public void Close()
        {
            ClientConnetion.Close();
            ClientConnetion = null;
        }

    }
}
