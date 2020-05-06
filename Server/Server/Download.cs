using System;
using System.Text;
using System.IO;
using System.Net.Sockets;


namespace Server
{
    class Download
    {
        public void StartDownload(string location, string data, Socket ClientSocket)
        {
            long size = long.Parse(data);
            FileStream fout = new FileStream(location, FileMode.Create, FileAccess.Write);
            NetworkStream nfs = new NetworkStream(ClientSocket);
            long rby = 0;
            while (rby < size)
            {
                byte[] buffer = new byte[2048];
                int length = nfs.Read(buffer, 0, buffer.Length);
                fout.Write(buffer, 0, length);
                rby = rby + length;
            }
            fout.Dispose();
            nfs.Dispose();
        }
    }
}

