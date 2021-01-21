namespace StatRub_v1
{
    partial class RegestrationFrom
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RegestrationFrom));
            this.waterMark1 = new StatRub_v1.WaterMark();
            this.waterMark2 = new StatRub_v1.WaterMark();
            this.waterMark3 = new StatRub_v1.WaterMark();
            this.waterMark4 = new StatRub_v1.WaterMark();
            this.metroButton1 = new MetroFramework.Controls.MetroButton();
            this.SuspendLayout();
            // 
            // waterMark1
            // 
            this.waterMark1.AccessibleName = "Enter Email";
            this.waterMark1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.waterMark1.Font = new System.Drawing.Font("Microsoft Sans Serif", 24.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.waterMark1.ForeColor = System.Drawing.SystemColors.Info;
            this.waterMark1.Location = new System.Drawing.Point(159, 78);
            this.waterMark1.Name = "waterMark1";
            this.waterMark1.Size = new System.Drawing.Size(252, 44);
            this.waterMark1.TabIndex = 5;
            this.waterMark1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.waterMark1.Watermark = "EMAIL";
            this.waterMark1.TextChanged += new System.EventHandler(this.waterMark1_TextChanged);
            // 
            // waterMark2
            // 
            this.waterMark2.AccessibleName = "Enter Login";
            this.waterMark2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.waterMark2.Font = new System.Drawing.Font("Microsoft Sans Serif", 24.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.waterMark2.ForeColor = System.Drawing.SystemColors.Info;
            this.waterMark2.Location = new System.Drawing.Point(159, 144);
            this.waterMark2.Name = "waterMark2";
            this.waterMark2.Size = new System.Drawing.Size(252, 44);
            this.waterMark2.TabIndex = 6;
            this.waterMark2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.waterMark2.Watermark = "USER LOGIN";
            this.waterMark2.TextChanged += new System.EventHandler(this.waterMark2_TextChanged);
            // 
            // waterMark3
            // 
            this.waterMark3.AccessibleName = "Enter Login";
            this.waterMark3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.waterMark3.Font = new System.Drawing.Font("Microsoft Sans Serif", 24.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.waterMark3.ForeColor = System.Drawing.SystemColors.Info;
            this.waterMark3.Location = new System.Drawing.Point(159, 212);
            this.waterMark3.Name = "waterMark3";
            this.waterMark3.Size = new System.Drawing.Size(252, 44);
            this.waterMark3.TabIndex = 7;
            this.waterMark3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.waterMark3.Watermark = "USER PASS";
            this.waterMark3.TextChanged += new System.EventHandler(this.waterMark3_TextChanged);
            // 
            // waterMark4
            // 
            this.waterMark4.AccessibleName = "Enter Login";
            this.waterMark4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.waterMark4.Font = new System.Drawing.Font("Microsoft Sans Serif", 24.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.waterMark4.ForeColor = System.Drawing.SystemColors.Info;
            this.waterMark4.Location = new System.Drawing.Point(159, 278);
            this.waterMark4.Name = "waterMark4";
            this.waterMark4.Size = new System.Drawing.Size(252, 44);
            this.waterMark4.TabIndex = 8;
            this.waterMark4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.waterMark4.Watermark = "CONFIRM PASS";
            this.waterMark4.TextChanged += new System.EventHandler(this.waterMark4_TextChanged);
            // 
            // metroButton1
            // 
            this.metroButton1.Location = new System.Drawing.Point(208, 340);
            this.metroButton1.Name = "metroButton1";
            this.metroButton1.Size = new System.Drawing.Size(146, 59);
            this.metroButton1.TabIndex = 9;
            this.metroButton1.Text = "Enter Form";
            this.metroButton1.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroButton1.Click += new System.EventHandler(this.metroButton1_Click);
            // 
            // RegestrationFrom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(548, 435);
            this.Controls.Add(this.metroButton1);
            this.Controls.Add(this.waterMark4);
            this.Controls.Add(this.waterMark3);
            this.Controls.Add(this.waterMark2);
            this.Controls.Add(this.waterMark1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "RegestrationFrom";
            this.Style = MetroFramework.MetroColorStyle.White;
            this.Text = "RegestrationFrom";
            this.TextAlign = System.Windows.Forms.VisualStyles.HorizontalAlign.Center;
            this.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.Load += new System.EventHandler(this.RegestrationFrom_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private WaterMark waterMark1;
        private WaterMark waterMark2;
        private WaterMark waterMark3;
        private WaterMark waterMark4;
        private MetroFramework.Controls.MetroButton metroButton1;
    }
}