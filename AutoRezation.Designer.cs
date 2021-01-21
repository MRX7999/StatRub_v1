namespace StatRub_v1
{
    partial class AutoRezation
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AutoRezation));
            this.Button_Go_ON = new MetroFramework.Controls.MetroButton();
            this.Regestration_Button = new MetroFramework.Controls.MetroButton();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.waterMark2 = new StatRub_v1.WaterMark();
            this.waterMark1 = new StatRub_v1.WaterMark();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // Button_Go_ON
            // 
            this.Button_Go_ON.Location = new System.Drawing.Point(236, 307);
            this.Button_Go_ON.Name = "Button_Go_ON";
            this.Button_Go_ON.Size = new System.Drawing.Size(221, 59);
            this.Button_Go_ON.TabIndex = 0;
            this.Button_Go_ON.Text = "Вход";
            this.Button_Go_ON.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.Button_Go_ON.Click += new System.EventHandler(this.Button_Go_ON_Click);
            // 
            // Regestration_Button
            // 
            this.Regestration_Button.Location = new System.Drawing.Point(278, 372);
            this.Regestration_Button.Name = "Regestration_Button";
            this.Regestration_Button.Size = new System.Drawing.Size(128, 23);
            this.Regestration_Button.TabIndex = 1;
            this.Regestration_Button.Text = "Зарегистрироваться";
            this.Regestration_Button.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.Regestration_Button.Click += new System.EventHandler(this.Regestration_Button_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::StatRub_v1.Properties.Resources.giphy_downsized_large;
            this.pictureBox1.Location = new System.Drawing.Point(23, 52);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(663, 373);
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "notifyIcon1";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.StatRub_v1_Client_MouseDoubleClick);
            // 
            // waterMark2
            // 
            this.waterMark2.AccessibleName = "Enter Password";
            this.waterMark2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.waterMark2.Font = new System.Drawing.Font("Microsoft Sans Serif", 24.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.waterMark2.ForeColor = System.Drawing.SystemColors.Info;
            this.waterMark2.Location = new System.Drawing.Point(219, 149);
            this.waterMark2.Name = "waterMark2";
            this.waterMark2.PasswordChar = '*';
            this.waterMark2.Size = new System.Drawing.Size(252, 44);
            this.waterMark2.TabIndex = 5;
            this.waterMark2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.waterMark2.Watermark = "PASSWORD";
            this.waterMark2.TextChanged += new System.EventHandler(this.waterMark2_TextChanged);
            // 
            // waterMark1
            // 
            this.waterMark1.AccessibleName = "Enter Login";
            this.waterMark1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.waterMark1.Font = new System.Drawing.Font("Microsoft Sans Serif", 24.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.waterMark1.ForeColor = System.Drawing.SystemColors.Info;
            this.waterMark1.Location = new System.Drawing.Point(219, 79);
            this.waterMark1.Name = "waterMark1";
            this.waterMark1.Size = new System.Drawing.Size(252, 44);
            this.waterMark1.TabIndex = 4;
            this.waterMark1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.waterMark1.Watermark = "LOGIN";
            this.waterMark1.TextChanged += new System.EventHandler(this.waterMark1_TextChanged);
            // 
            // AutoRezation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(713, 448);
            this.Controls.Add(this.waterMark2);
            this.Controls.Add(this.waterMark1);
            this.Controls.Add(this.Regestration_Button);
            this.Controls.Add(this.Button_Go_ON);
            this.Controls.Add(this.pictureBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AutoRezation";
            this.Style = MetroFramework.MetroColorStyle.Silver;
            this.Text = "Авторизация";
            this.TextAlign = System.Windows.Forms.VisualStyles.HorizontalAlign.Center;
            this.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.Load += new System.EventHandler(this.AutoRezation_Load);
            this.Resize += new System.EventHandler(this.FormAutorezatian_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroButton Button_Go_ON;
        private MetroFramework.Controls.MetroButton Regestration_Button;
        private WaterMark waterMark1;
        private WaterMark waterMark2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
    }
}