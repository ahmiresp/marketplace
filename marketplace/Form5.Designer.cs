namespace marketplace
{
    partial class Sellit_form
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.BTNCHAT = new System.Windows.Forms.Button();
            this.btnAccount = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.btnsellit = new System.Windows.Forms.Button();
            this.btnbrowes = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(59)))), ((int)(((byte)(48)))));
            this.panel1.Controls.Add(this.BTNCHAT);
            this.panel1.Controls.Add(this.btnAccount);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.btnsellit);
            this.panel1.Controls.Add(this.btnbrowes);
            this.panel1.ForeColor = System.Drawing.Color.Snow;
            this.panel1.Location = new System.Drawing.Point(0, 1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(718, 31);
            this.panel1.TabIndex = 11;
            // 
            // BTNCHAT
            // 
            this.BTNCHAT.AutoSize = true;
            this.BTNCHAT.BackColor = System.Drawing.Color.Transparent;
            this.BTNCHAT.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.BTNCHAT.Location = new System.Drawing.Point(283, 0);
            this.BTNCHAT.Name = "BTNCHAT";
            this.BTNCHAT.Size = new System.Drawing.Size(76, 32);
            this.BTNCHAT.TabIndex = 4;
            this.BTNCHAT.Text = "CHAT";
            this.BTNCHAT.UseVisualStyleBackColor = false;
            // 
            // btnAccount
            // 
            this.btnAccount.AutoSize = true;
            this.btnAccount.BackColor = System.Drawing.Color.Transparent;
            this.btnAccount.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnAccount.Location = new System.Drawing.Point(598, 3);
            this.btnAccount.Name = "btnAccount";
            this.btnAccount.Size = new System.Drawing.Size(108, 32);
            this.btnAccount.TabIndex = 3;
            this.btnAccount.Text = "ACCOUNT";
            this.btnAccount.UseVisualStyleBackColor = false;
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
            // btnsellit
            // 
            this.btnsellit.AutoSize = true;
            this.btnsellit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(237)))), ((int)(((byte)(222)))));
            this.btnsellit.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnsellit.ForeColor = System.Drawing.Color.Black;
            this.btnsellit.Location = new System.Drawing.Point(109, 0);
            this.btnsellit.Name = "btnsellit";
            this.btnsellit.Size = new System.Drawing.Size(86, 31);
            this.btnsellit.TabIndex = 1;
            this.btnsellit.Text = "SELL IT";
            this.btnsellit.UseVisualStyleBackColor = false;
            this.btnsellit.Click += new System.EventHandler(this.btnsellit_Click);
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
            // panel2
            // 
            this.panel2.Controls.Add(this.label1);
            this.panel2.Location = new System.Drawing.Point(141, 52);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(437, 232);
            this.panel2.TabIndex = 12;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(102, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(105, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "SELL ITEM";
            // 
            // Sellit_form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(718, 540);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "Sellit_form";
            this.Text = "Form5";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button BTNCHAT;
        private System.Windows.Forms.Button btnAccount;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnsellit;
        private System.Windows.Forms.Button btnbrowes;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
    }
}