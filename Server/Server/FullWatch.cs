using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace Server
{
    public partial class FullWatch : Form
    {
        public FullWatch()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
            this.FormBorderStyle = FormBorderStyle.None;

            FW.SetBounds(0, 0, SystemInformation.PrimaryMonitorSize.Width, SystemInformation.PrimaryMonitorSize.Height);
            Thread Show = new Thread(new ThreadStart(ShowS));
            Show.Start(); 
        }
        private void ShowS()
        {
            Thread.Sleep(1000);
            while (Ruler.big == true)
            {

                FW.ImageLocation = @"C:\temp\tempscreen0.jpeg";

            }
        }

        private void FW_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                Ruler.Sclick(Cursor.Position.X, Cursor.Position.Y, 1);
            else
               Ruler.Sclick(Cursor.Position.X, Cursor.Position.Y, 2);

        }

        private void FullWatch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 27) //Esc
            {
                Ruler.big = false;
                this.Close();
            }
            else
                Ruler.Skey(e.KeyData.ToString());
        }

        private void FW_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Ruler.Sclick(Cursor.Position.X, Cursor.Position.Y, 3);
        }
    }
}
