namespace Server
{
    partial class FullWatch
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
            this.FW = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.FW)).BeginInit();
            this.SuspendLayout();
            // 
            // FW
            // 
            this.FW.Location = new System.Drawing.Point(0, 0);
            this.FW.Name = "FW";
            this.FW.Size = new System.Drawing.Size(501, 362);
            this.FW.TabIndex = 0;
            this.FW.TabStop = false;
            this.FW.MouseClick += new System.Windows.Forms.MouseEventHandler(this.FW_MouseClick);
            this.FW.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.FW_MouseDoubleClick);
         /*   this.FW.MouseMove += new System.Windows.Forms.MouseEventHandler(this.FW_MouseMove);*/
            // 
            // FullWatch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(500, 362);
            this.Controls.Add(this.FW);
            this.Name = "FullWatch";
            this.Text = "Full Watch";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FullWatch_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.FW)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox FW;
    }
}