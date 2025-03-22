namespace marketplace
{
    partial class BROWSE_FORM
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
            this.btnAccount = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.btnsellit = new System.Windows.Forms.Button();
            this.btnbrowes = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(59)))), ((int)(((byte)(48)))));
            this.panel1.Controls.Add(this.btnAccount);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.btnsellit);
            this.panel1.Controls.Add(this.btnbrowes);
            this.panel1.ForeColor = System.Drawing.Color.Snow;
            this.panel1.Location = new System.Drawing.Point(0, -2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(629, 31);
            this.panel1.TabIndex = 10;
            // 
            // btnAccount
            // 
            this.btnAccount.AutoSize = true;
            this.btnAccount.BackColor = System.Drawing.Color.Transparent;
            this.btnAccount.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnAccount.Location = new System.Drawing.Point(521, 3);
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
            this.btnsellit.BackColor = System.Drawing.Color.Transparent;
            this.btnsellit.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnsellit.Location = new System.Drawing.Point(109, 0);
            this.btnsellit.Name = "btnsellit";
            this.btnsellit.Size = new System.Drawing.Size(86, 32);
            this.btnsellit.TabIndex = 1;
            this.btnsellit.Text = "SELL IT";
            this.btnsellit.UseVisualStyleBackColor = false;
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
            // BROWSE_FORM
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(629, 450);
            this.Controls.Add(this.panel1);
            this.Name = "BROWSE_FORM";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form4";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnAccount;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnsellit;
        private System.Windows.Forms.Button btnbrowes;
    }
}