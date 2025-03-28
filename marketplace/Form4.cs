using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace marketplace
{
    public partial class BROWSE_FORM: Form
    {
        public BROWSE_FORM()
        {
            InitializeComponent();
        }

        private void BROWSE_FORM_Load(object sender, EventArgs e)
        {

        }

        private void btnsellit_Click(object sender, EventArgs e)
        {
            Sellit_form sellit = new Sellit_form();
            sellit.Show();
            this.Hide();
        }

        private void btnAccount_Click(object sender, EventArgs e)
        {

        }
    }
}
