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
using System.Security.Cryptography;

namespace marketplace
{
    public partial class signupForm : Form
    {
        public signupForm()
        {
            InitializeComponent();
        }
        SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-V8S0DNV\SQLEXPRESS;Initial Catalog=marketplace;Integrated Security=True;");

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void txtsignupbxusername_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtsignupbxgmail_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtsignupbxpassword_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtsignupbxcontact_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            string username = txtsignupbxusername.Text.Trim();
            string gmail = txtsignupbxgmail.Text.Trim();
            string password = txtsignupbxpassword.Text.Trim();
            string contact = txtsignupbxcontact.Text.Trim();

            //  Validation for empty fields
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(gmail) ||
                string.IsNullOrWhiteSpace(password) || string.IsNullOrWhiteSpace(contact))
            {
                MessageBox.Show("Please fill in all fields.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            //  Validation for Gmail format
            if (!gmail.Contains("@") || !gmail.Contains("."))
            {
                MessageBox.Show("Invalid Gmail format!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Password length validation (8-15 characters)
            if (password.Length < 8 || password.Length > 15)
            {
                MessageBox.Show("Password must be between 8 and 15 characters.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Contact number validation (must be exactly 11 digits)
            if (contact.Length != 11 || !IsAllDigits(contact))
            {
                MessageBox.Show("Contact number must be exactly 11 digits.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Hash the password
            string hashedPassword = HashPassword(password);

            try
            {
                conn.Open();

                // Check if Username already exists
                string checkUsernameQuery = "SELECT COUNT(*) FROM signup_form WHERE username = @username";
                using (SqlCommand checkUsernameCmd = new SqlCommand(checkUsernameQuery, conn))
                {
                    checkUsernameCmd.Parameters.AddWithValue("@username", username);
                    int usernameCount = (int)checkUsernameCmd.ExecuteScalar();
                    if (usernameCount > 0)
                    {
                        MessageBox.Show("Username is already taken! Please choose another one.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }

                // Check if Gmail already exists
                string checkGmailQuery = "SELECT COUNT(*) FROM signup_form WHERE gmail = @gmail";
                using (SqlCommand checkGmailCmd = new SqlCommand(checkGmailQuery, conn))
                {
                    checkGmailCmd.Parameters.AddWithValue("@gmail", gmail);
                    int gmailCount = (int)checkGmailCmd.ExecuteScalar();
                    if (gmailCount > 0)
                    {
                        MessageBox.Show("Gmail already exists! Try another one.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }

                // ✅ Insert new user
                string query = "INSERT INTO signup_form (username, gmail, password, contact) VALUES (@username, @gmail, @password, @contact)";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@username", username);
                    cmd.Parameters.AddWithValue("@gmail", gmail);
                    cmd.Parameters.AddWithValue("@password", hashedPassword);  // Store hashed password
                    cmd.Parameters.AddWithValue("@contact", contact);

                    int result = cmd.ExecuteNonQuery();

                    if (result > 0)
                    {
                        MessageBox.Show("Signup successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        loginForm loginform = new loginForm();
                        loginform.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Signup failed. Try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private bool IsAllDigits(string str)
        {
            foreach (char c in str)
            {
                if (!char.IsDigit(c))
                {
                    return false;
                }
            }
            return true;
        }

        private string HashPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                StringBuilder builder = new StringBuilder();
                foreach (byte b in bytes)
                {
                    builder.Append(b.ToString("x2")); // Convert byte to hex string
                }
                return builder.ToString();
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
