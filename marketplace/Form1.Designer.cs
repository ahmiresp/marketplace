namespace marketplace
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnbrowes = new System.Windows.Forms.Button();
            this.btnsellit = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.BTNSIGNLOG = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pictureBox1.Image = global::marketplace.Properties.Resources.logomarketplace_removebg_preview;
            this.pictureBox1.InitialImage = null;
            this.pictureBox1.Location = new System.Drawing.Point(-2, 28);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(488, 273);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 8;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(59)))), ((int)(((byte)(48)))));
            this.panel1.Controls.Add(this.BTNSIGNLOG);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.btnsellit);
            this.panel1.Controls.Add(this.btnbrowes);
            this.panel1.ForeColor = System.Drawing.Color.Snow;
            this.panel1.Location = new System.Drawing.Point(-1, -1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(487, 32);
            this.panel1.TabIndex = 9;
            // 
            // btnbrowes
            // 
            this.btnbrowes.AutoSize = true;
            this.btnbrowes.BackColor = System.Drawing.Color.Transparent;
            this.btnbrowes.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnbrowes.Location = new System.Drawing.Point(13, 0);
            this.btnbrowes.Name = "btnbrowes";
            this.btnbrowes.Size = new System.Drawing.Size(90, 32);
            this.btnbrowes.TabIndex = 0;
            this.btnbrowes.Text = "BROWSE";
            this.btnbrowes.UseVisualStyleBackColor = false;
            // 
            // btnsellit
            // 
            this.btnsellit.AutoSize = true;
            this.btnsellit.BackColor = System.Drawing.Color.Transparent;
            this.btnsellit.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnsellit.Location = new System.Drawing.Point(109, 0);
            this.btnsellit.Name = "btnsellit";
            this.btnsellit.Size = new System.Drawing.Size(86, 32);
            this.btnsellit.TabIndex = 1;
            this.btnsellit.Text = "SELL IT";
            this.btnsellit.UseVisualStyleBackColor = false;
            // 
            // button1
            // 
            this.button1.AutoSize = true;
            this.button1.BackColor = System.Drawing.Color.Transparent;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button1.Location = new System.Drawing.Point(201, 0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(76, 32);
            this.button1.TabIndex = 2;
            this.button1.Text = "CATEGORY";
            this.button1.UseVisualStyleBackColor = false;
            // 
            // BTNSIGNLOG
            // 
            this.BTNSIGNLOG.AutoSize = true;
            this.BTNSIGNLOG.BackColor = System.Drawing.Color.Transparent;
            this.BTNSIGNLOG.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.BTNSIGNLOG.Location = new System.Drawing.Point(368, 0);
            this.BTNSIGNLOG.Name = "BTNSIGNLOG";
            this.BTNSIGNLOG.Size = new System.Drawing.Size(108, 32);
            this.BTNSIGNLOG.TabIndex = 3;
            this.BTNSIGNLOG.Text = "LOG IN / SIGN UP";
            this.BTNSIGNLOG.UseVisualStyleBackColor = false;
            this.BTNSIGNLOG.Click += new System.EventHandler(this.BTNSIGNLOG_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(316, 216);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Learn more about";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(352, 242);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "The MarketPlace";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(125, 327);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(232, 34);
            this.label3.TabIndex = 12;
            this.label3.Text = "LANDING PAGE";
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(47, 383);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(410, 132);
            this.label4.TabIndex = 13;
            this.label4.Text = resources.GetString("label4.Text");
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(177, 544);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(117, 24);
            this.label5.TabIndex = 14;
            this.label5.Text = "ABOUT US";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(487, 680);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnbrowes;
        private System.Windows.Forms.Button BTNSIGNLOG;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnsellit;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
    }
}

