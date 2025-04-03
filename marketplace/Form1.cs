using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace marketplace
{
    public partial class Form1: Form
    {
        public Form1()
        {
            InitializeComponent();
            this.MinimumSize = new Size(503, 400); 
            this.MaximumSize = new Size(1200, 800); 
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void BTNSIGNLOG_Click(object sender, EventArgs e)
        {
            loginForm loginform = new loginForm();
            loginform.Show();
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
