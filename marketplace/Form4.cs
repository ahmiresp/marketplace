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
            FetchAccountDetails();
            pnlaccount.Visible = false;
            pnlhereclicked.Visible = false;
            catpopup.Visible = false;

        }
        SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-V8S0DNV\SQLEXPRESS;Initial Catalog=marketplace;Integrated Security=True;");
        private void BROWSE_FORM_Load(object sender, EventArgs e)
        {

        }
        private void FetchAccountDetails()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-V8S0DNV\SQLEXPRESS;Initial Catalog=marketplace;Integrated Security=True;"))
                {
                    conn.Open();
                    string query = "SELECT username, contact FROM signup_form WHERE username = @username";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        // 🆕 Use the stored username from loginForm
                        cmd.Parameters.AddWithValue("@username", loginForm.LoggedInUser);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read()) // If user exists, update labels
                            {
                                AccountName.Text = reader["username"].ToString();
                                AccountContact.Text = reader["contact"].ToString();
                            }
                            else
                            {
                                MessageBox.Show("User not found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void btnsellit_Click(object sender, EventArgs e)
        {
            Sellit_form sellit = new Sellit_form();
            sellit.Show();
            this.Hide();
        }

        private void btnAccount_Click(object sender, EventArgs e)
        {
            pnlaccount.Visible = true;
            pnlaccount.BringToFront();
            FetchAccountDetails(); // 🆕 Fetch details when button is clicked
        }

        private void btnlogout_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to logout?", "Logout Confirmation",
                                           MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                Form1 form1 = new Form1();
                form1.Show();
                this.Hide();
            }
        }

        private void linklabelverify_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            pnlhereclicked.Visible = true;
            pnlhereclicked.BringToFront();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Title = "Select an Image";
                openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string selectedImagePath = openFileDialog.FileName;
                    pictureBox6.Image = Image.FromFile(selectedImagePath);
                    pictureBox6.SizeMode = PictureBoxSizeMode.StretchImage; // Adjust image to fit PictureBox
                }
            }
        }

        private Image originalImage6;
        private Image originalImage7;

        private void pictureBox6_MouseEnter(object sender, EventArgs e)
        {
            pictureBox6.Cursor = Cursors.Hand; // Change to "Grab" cursor
            if (originalImage6 == null)
                originalImage6 = pictureBox6.Image; // Store original image

            pictureBox6.Image = ApplyColorOverlay(originalImage6, Color.Blue, 100);
        }

        private void pictureBox6_MouseLeave(object sender, EventArgs e)
        {
            pictureBox6.Cursor = Cursors.Default; // Restore default cursor
            pictureBox6.Image = originalImage6; // Restore original image
        }

        private void pictureBox7_MouseEnter(object sender, EventArgs e)
        {
            pictureBox7.Cursor = Cursors.Hand;
            if (originalImage7 == null)
                originalImage7 = pictureBox7.Image;

            pictureBox7.Image = ApplyColorOverlay(originalImage7, Color.Blue, 100);
        }

        private void pictureBox7_MouseLeave(object sender, EventArgs e)
        {
            pictureBox7.Cursor = Cursors.Default;
            pictureBox7.Image = originalImage7;
        }
        private Image ApplyColorOverlay(Image image, Color color, int alpha)
        {
            Bitmap bmp = new Bitmap(image);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                using (SolidBrush brush = new SolidBrush(Color.FromArgb(alpha, color)))
                {
                    g.FillRectangle(brush, new Rectangle(0, 0, bmp.Width, bmp.Height));
                }
            }
            return bmp;
        }



        private void pictureBox7_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Title = "Select an Image";
                openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string selectedImagePath = openFileDialog.FileName;
                    pictureBox7.Image = Image.FromFile(selectedImagePath);
                    pictureBox7.SizeMode = PictureBoxSizeMode.StretchImage; // Adjust image to fit PictureBox
                }
            }
        }

        private void catpopup_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btncategory_Click(object sender, EventArgs e)
        {
            catpopup.Visible = true;
        }

        private void btncatelectronics_Click(object sender, EventArgs e)
        {
            this.btncatelectronics.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btncatelectronics.FlatAppearance.BorderSize = 0;
        }
    }
}
