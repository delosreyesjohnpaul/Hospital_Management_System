namespace PatientsManagementSystem
{
    partial class Login
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login));
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pmsLABEl = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.bunifuElipse1 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.RoleCB = new System.Windows.Forms.ComboBox();
            this.UserName = new System.Windows.Forms.TextBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            this.Password = new System.Windows.Forms.TextBox();
            this.LoginBTN = new Bunifu.Framework.UI.BunifuThinButton2();
            this.ResetLB = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.panel1.Controls.Add(this.pictureBox3);
            this.panel1.Controls.Add(this.pmsLABEl);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(657, 112);
            this.panel1.TabIndex = 0;
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.pictureBox3.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox3.Image")));
            this.pictureBox3.Location = new System.Drawing.Point(623, 3);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(31, 32);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 10;
            this.pictureBox3.TabStop = false;
            this.pictureBox3.Click += new System.EventHandler(this.pictureBox3_Click_1);
            // 
            // pmsLABEl
            // 
            this.pmsLABEl.AutoSize = true;
            this.pmsLABEl.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pmsLABEl.Font = new System.Drawing.Font("Rockwell Condensed", 16.27826F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pmsLABEl.ForeColor = System.Drawing.SystemColors.ControlText;
            this.pmsLABEl.Location = new System.Drawing.Point(180, 42);
            this.pmsLABEl.Name = "pmsLABEl";
            this.pmsLABEl.Size = new System.Drawing.Size(369, 30);
            this.pmsLABEl.TabIndex = 1;
            this.pmsLABEl.Text = "PATIENTS MANAGEMENT SYSTEM";
            this.pmsLABEl.Click += new System.EventHandler(this.pmsLABEl_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(3, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(651, 146);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // bunifuElipse1
            // 
            this.bunifuElipse1.ElipseRadius = 10;
            this.bunifuElipse1.TargetControl = this;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Rockwell", 18.15652F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label1.Location = new System.Drawing.Point(153, 428);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(176, 32);
            this.label1.TabIndex = 2;
            this.label1.Text = "USER NAME";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Rockwell", 18.15652F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label2.Location = new System.Drawing.Point(153, 528);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(172, 32);
            this.label2.TabIndex = 3;
            this.label2.Text = "PASSWORD";
            // 
            // RoleCB
            // 
            this.RoleCB.Font = new System.Drawing.Font("Cambria", 13.77391F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RoleCB.FormattingEnabled = true;
            this.RoleCB.Items.AddRange(new object[] {
            "ADMIN",
            "DOCTOR",
            "RECEPTIONIST"});
            this.RoleCB.Location = new System.Drawing.Point(159, 369);
            this.RoleCB.Name = "RoleCB";
            this.RoleCB.Size = new System.Drawing.Size(343, 34);
            this.RoleCB.TabIndex = 4;
            // 
            // UserName
            // 
            this.UserName.Font = new System.Drawing.Font("Cambria", 13.77391F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UserName.Location = new System.Drawing.Point(159, 465);
            this.UserName.Name = "UserName";
            this.UserName.Size = new System.Drawing.Size(343, 33);
            this.UserName.TabIndex = 5;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(249, 136);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(170, 126);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 6;
            this.pictureBox2.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.WhiteSmoke;
            this.label3.Font = new System.Drawing.Font("Rockwell", 13.77391F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label3.Location = new System.Drawing.Point(244, 265);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(187, 25);
            this.label3.TabIndex = 2;
            this.label3.Text = "HOSPITAL NAME";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // Password
            // 
            this.Password.Font = new System.Drawing.Font("Cambria", 13.77391F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Password.Location = new System.Drawing.Point(159, 565);
            this.Password.Name = "Password";
            this.Password.Size = new System.Drawing.Size(343, 33);
            this.Password.TabIndex = 7;
            this.Password.UseSystemPasswordChar = true;
            // 
            // LoginBTN
            // 
            this.LoginBTN.ActiveBorderThickness = 1;
            this.LoginBTN.ActiveCornerRadius = 20;
            this.LoginBTN.ActiveFillColor = System.Drawing.Color.Lime;
            this.LoginBTN.ActiveForecolor = System.Drawing.Color.White;
            this.LoginBTN.ActiveLineColor = System.Drawing.Color.Lime;
            this.LoginBTN.BackColor = System.Drawing.SystemColors.Control;
            this.LoginBTN.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("LoginBTN.BackgroundImage")));
            this.LoginBTN.ButtonText = "Login";
            this.LoginBTN.Cursor = System.Windows.Forms.Cursors.Hand;
            this.LoginBTN.Font = new System.Drawing.Font("Gadugi", 13.77391F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LoginBTN.ForeColor = System.Drawing.Color.Black;
            this.LoginBTN.IdleBorderThickness = 1;
            this.LoginBTN.IdleCornerRadius = 20;
            this.LoginBTN.IdleFillColor = System.Drawing.SystemColors.InactiveBorder;
            this.LoginBTN.IdleForecolor = System.Drawing.SystemColors.Highlight;
            this.LoginBTN.IdleLineColor = System.Drawing.SystemColors.HotTrack;
            this.LoginBTN.Location = new System.Drawing.Point(230, 608);
            this.LoginBTN.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.LoginBTN.Name = "LoginBTN";
            this.LoginBTN.Size = new System.Drawing.Size(189, 62);
            this.LoginBTN.TabIndex = 8;
            this.LoginBTN.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.LoginBTN.Click += new System.EventHandler(this.LoginBTN_Click);
            // 
            // ResetLB
            // 
            this.ResetLB.AutoSize = true;
            this.ResetLB.Font = new System.Drawing.Font("Gadugi", 13.77391F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ResetLB.ForeColor = System.Drawing.SystemColors.Desktop;
            this.ResetLB.Location = new System.Drawing.Point(291, 676);
            this.ResetLB.Name = "ResetLB";
            this.ResetLB.Size = new System.Drawing.Size(69, 26);
            this.ResetLB.TabIndex = 9;
            this.ResetLB.Text = "Reset";
            this.ResetLB.Click += new System.EventHandler(this.ResetLB_Click);
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(657, 751);
            this.Controls.Add(this.ResetLB);
            this.Controls.Add(this.LoginBTN);
            this.Controls.Add(this.Password);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.UserName);
            this.Controls.Add(this.RoleCB);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Bodoni MT", 8.139131F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private Bunifu.Framework.UI.BunifuElipse bunifuElipse1;
        private System.Windows.Forms.Label pmsLABEl;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox UserName;
        private System.Windows.Forms.ComboBox RoleCB;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox Password;
        private Bunifu.Framework.UI.BunifuThinButton2 LoginBTN;
        private System.Windows.Forms.Label ResetLB;
        private System.Windows.Forms.PictureBox pictureBox3;
    }
}

