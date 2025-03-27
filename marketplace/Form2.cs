using System;
using System.Data;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace marketplace
{
    public partial class loginForm : Form
    {
        public loginForm()
        {
            InitializeComponent();
        }

        SqlConnection conn = new SqlConnection(@"Data Source = DESKTOP - V8S0DNV\SQLEXPRESS; Initial Catalog = marketplace; Integrated Security = True; ");

        private void label3_Click(object sender, EventArgs e)
        {
           
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            signupForm signupform = new signupForm();
            signupform.Show();
            this.Hide();
        }

        private void btnlogin_Click(object sender, EventArgs e)
        {
            errorProvider1.Clear();
            errorProvider2.Clear();

            string username = txtloginbxusername.Text.Trim();
            string user_password = txtloginbxpassword.Text.Trim();
            bool isValid = true;

            if (string.IsNullOrWhiteSpace(username))
            {
                errorProvider1.SetError(txtloginbxusername, "Username cannot be empty.");
                isValid = false;
            }

            // ✅ Password Validation
            if (string.IsNullOrWhiteSpace(user_password))
            {
                errorProvider2.SetError(txtloginbxpassword, "Password cannot be empty.");
                isValid = false;
            }
            if (!isValid) 
                return;
            // 🚨 If any validation fails, stop execution
            try
            {
                conn.Open();

                // Check if username exists
                string query = "SELECT password FROM signup_form WHERE username = @username";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@username", username);
                    object result = cmd.ExecuteScalar();

                    if (result == null)
                    {
                        // 🚨 Username does not exist
                        errorProvider1.SetError(txtloginbxusername, "Username not found.");
                    }
                    else
                    {
                        string storedHashedPassword = result.ToString(); // Get hashed password from DB
                        string hashedInputPassword = HashPassword(user_password); // Hash entered password

                        if (storedHashedPassword == hashedInputPassword)
                        {
                            // ✅ Login Successful
                            MessageBox.Show("Login successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            BROWSE_FORM browse_form = new BROWSE_FORM();
                            browse_form.Show();
                            this.Hide();
                        }
                        else
                        {
                            // 🚨 Incorrect password
                            MessageBox.Show("Invalid credentials. Please try again.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conn.Close();
            }
        }
    

        // Hash the password using SHA-256
        private string HashPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }

        private void buttonTestConnection_Click(object sender, EventArgs e)
        {
            string connString = @"Data Source = DESKTOP - V8S0DNV\SQLEXPRESS; Initial Catalog = marketplace; Integrated Security = True;";

            using (SqlConnection conn = new SqlConnection(connString))
            {
                try
                {
                    conn.Open();
                    MessageBox.Show("Database Connection Successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Database Connection Failed!\nError: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                finally
                {
                    conn.Close();
                }
            }
        }

        private void txtloginbxusername_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void loginForm_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void showButton_Click(object sender, EventArgs e)
        {

        }

        private void hideButton_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
