
namespace ServerskiDeo
{
    partial class Form1
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
            this.btnStart = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.txtBroj1 = new System.Windows.Forms.TextBox();
            this.txtBroj2 = new System.Windows.Forms.TextBox();
            this.txtBroj3 = new System.Windows.Forms.TextBox();
            this.txtBroj4 = new System.Windows.Forms.TextBox();
            this.btnPokreniServer = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(104, 49);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(120, 63);
            this.btnStart.TabIndex = 0;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnStop
            // 
            this.btnStop.Location = new System.Drawing.Point(352, 49);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(120, 63);
            this.btnStop.TabIndex = 1;
            this.btnStop.Text = "Stop";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // txtBroj1
            // 
            this.txtBroj1.Location = new System.Drawing.Point(132, 190);
            this.txtBroj1.Name = "txtBroj1";
            this.txtBroj1.Size = new System.Drawing.Size(61, 20);
            this.txtBroj1.TabIndex = 2;
            this.txtBroj1.TextChanged += new System.EventHandler(this.txtBroj1_TextChanged);
            // 
            // txtBroj2
            // 
            this.txtBroj2.Location = new System.Drawing.Point(231, 190);
            this.txtBroj2.Name = "txtBroj2";
            this.txtBroj2.Size = new System.Drawing.Size(61, 20);
            this.txtBroj2.TabIndex = 3;
            this.txtBroj2.TextChanged += new System.EventHandler(this.txtBroj2_TextChanged);
            // 
            // txtBroj3
            // 
            this.txtBroj3.Location = new System.Drawing.Point(338, 190);
            this.txtBroj3.Name = "txtBroj3";
            this.txtBroj3.Size = new System.Drawing.Size(61, 20);
            this.txtBroj3.TabIndex = 4;
            this.txtBroj3.TextChanged += new System.EventHandler(this.txtBroj3_TextChanged);
            // 
            // txtBroj4
            // 
            this.txtBroj4.Location = new System.Drawing.Point(448, 190);
            this.txtBroj4.Name = "txtBroj4";
            this.txtBroj4.Size = new System.Drawing.Size(61, 20);
            this.txtBroj4.TabIndex = 5;
            this.txtBroj4.TextChanged += new System.EventHandler(this.txtBroj4_TextChanged);
            // 
            // btnPokreniServer
            // 
            this.btnPokreniServer.Location = new System.Drawing.Point(252, 264);
            this.btnPokreniServer.Name = "btnPokreniServer";
            this.btnPokreniServer.Size = new System.Drawing.Size(120, 63);
            this.btnPokreniServer.TabIndex = 6;
            this.btnPokreniServer.Text = "Pokreni Server";
            this.btnPokreniServer.UseVisualStyleBackColor = true;
            this.btnPokreniServer.Click += new System.EventHandler(this.btnPokreniServer_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnPokreniServer);
            this.Controls.Add(this.txtBroj4);
            this.Controls.Add(this.txtBroj3);
            this.Controls.Add(this.txtBroj2);
            this.Controls.Add(this.txtBroj1);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.btnStart);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.TextBox txtBroj1;
        private System.Windows.Forms.TextBox txtBroj2;
        private System.Windows.Forms.TextBox txtBroj3;
        private System.Windows.Forms.TextBox txtBroj4;
        private System.Windows.Forms.Button btnPokreniServer;
    }
}

