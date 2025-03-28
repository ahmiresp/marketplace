﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO; // Required for handling file paths
using System.Data.SqlClient;

namespace marketplace
{
    public partial class Sellit_form : Form
    {
        public Sellit_form()
        {
            InitializeComponent();
            SetPlaceholder(); // Set the initial placeholder text for richTextBox1
            SetItemNamePlaceholder(); // Set the initial placeholder text for txtItemName
            SetPricePlaceholder(); // Set the initial placeholder text for txtboxprice
            SetLocationPlaceholder(); // Set the initial placeholder text for txtboxlocation
                                      // Assign mouse events for cursor change
            FetchAccountDetails();
            pctbxsellitem.MouseEnter += pctbxsellitem_MouseEnter;
            pctbxsellitem.MouseLeave += pctbxsellitem_MouseLeave;
            pnlaccount.Visible = false;
            pnlhereclicked.Visible = false;
        }
        SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-V8S0DNV\SQLEXPRESS;Initial Catalog=marketplace;Integrated Security=True;");

        // Placeholder for richTextBox1

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


        private void SetPlaceholder()
        {
            if (string.IsNullOrWhiteSpace(richTextBox1.Text))
            {
                richTextBox1.Text = "Product Description...";
                richTextBox1.ForeColor = Color.Gray;
            }
        }

        private void richTextBox1_Enter(object sender, EventArgs e)
        {
            if (richTextBox1.Text == "Product Description...")
            {
                richTextBox1.Text = "";
                richTextBox1.ForeColor = Color.Black;
            }
        }

        private void richTextBox1_Leave(object sender, EventArgs e)
        {
            SetPlaceholder();
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            // Your existing event handler remains unchanged
        }

        // Placeholder for txtItemName
        private void SetItemNamePlaceholder()
        {
            if (string.IsNullOrWhiteSpace(txtItemName.Text))
            {
                txtItemName.Text = "Enter Item Name";
                txtItemName.ForeColor = Color.Gray;
            }
        }

        private void txtItemName_Enter(object sender, EventArgs e)
        {
            if (txtItemName.Text == "Enter Item Name")
            {
                txtItemName.Text = "";
                txtItemName.ForeColor = Color.Black;
            }
        }

        private void txtItemName_Leave(object sender, EventArgs e)
        {
            SetItemNamePlaceholder();
        }

        private void txtItemName_TextChanged(object sender, EventArgs e)
        {
            // Your existing event handler remains unchanged
        }

        // Placeholder for txtboxprice
        private void SetPricePlaceholder()
        {
            if (string.IsNullOrWhiteSpace(txtboxprice.Text))
            {
                txtboxprice.Text = "Enter Price";
                txtboxprice.ForeColor = Color.Gray;
            }
        }

        private void txtboxprice_Enter(object sender, EventArgs e)
        {
            if (txtboxprice.Text == "Enter Price")
            {
                txtboxprice.Text = "";
                txtboxprice.ForeColor = Color.Black;
            }
        }

        private void txtboxprice_Leave(object sender, EventArgs e)
        {
            SetPricePlaceholder();
        }

        private void txtboxprice_TextChanged(object sender, EventArgs e)
        {
            // Your existing event handler remains unchanged
        }

        // Placeholder for txtboxlocation
        private void SetLocationPlaceholder()
        {
            if (string.IsNullOrWhiteSpace(txtboxlocation.Text))
            {
                txtboxlocation.Text = "Enter Location";
                txtboxlocation.ForeColor = Color.Gray;
            }
        }

        private void txtboxlocation_Enter(object sender, EventArgs e)
        {
            if (txtboxlocation.Text == "Enter Location")
            {
                txtboxlocation.Text = "";
                txtboxlocation.ForeColor = Color.Black;
            }
        }

        private void txtboxlocation_Leave(object sender, EventArgs e)
        {
            SetLocationPlaceholder();
        }

        private void txtboxlocation_TextChanged(object sender, EventArgs e)
        {
            // Your existing event handler remains unchanged
        }

        private void Sellit_form_Load(object sender, EventArgs e)
        {
            SetPlaceholder();
            SetItemNamePlaceholder();
            SetPricePlaceholder();
            SetLocationPlaceholder();
        }
        private void pctbxsellitem_MouseEnter(object sender, EventArgs e)
        {
            pctbxsellitem.Cursor = Cursors.Hand; // Change cursor to hand when hovering

           
        }

        private void pctbxsellitem_MouseLeave(object sender, EventArgs e)
        {
            pctbxsellitem.Cursor = Cursors.Default; // Change back to default when leaving
        }
        // Click event for PictureBox to allow user to upload an image
        private void pctbxsellitem_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Title = "Select an Image";
                openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string selectedImagePath = openFileDialog.FileName;
                    pctbxsellitem.Image = Image.FromFile(selectedImagePath);
                    pctbxsellitem.SizeMode = PictureBoxSizeMode.StretchImage; // Adjust image to fit PictureBox
                }
            }
        }

        private void pnlaccount_Paint(object sender, PaintEventArgs e)
        {
           
        }

        private void btnAccount_Click(object sender, EventArgs e)
        {
            pnlaccount.Visible = true;
            pnlaccount.BringToFront();
            FetchAccountDetails(); // 🆕 Fetch details when button is clicked
        }

        private void linklabelverify_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            pnlhereclicked.Visible = true;
            pnlhereclicked.BringToFront();
        }

        private void btnsellit_Click(object sender, EventArgs e)
        {
            pnlsellitem.Visible = true;
            pnlsellitem.BringToFront();
            
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
        
        private void pnlsellitem_Paint(object sender, PaintEventArgs e)
        {

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

        private void txtboxprice_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void txtboxlocation_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void btnAdditem_Click(object sender, EventArgs e)
        {
            string connectionString = @"Data Source=DESKTOP-V8S0DNV\SQLEXPRESS;Initial Catalog=marketplace;Integrated Security=True;";

            // Get values from textboxes
            string itemName = txtItemName.Text;
            string price = txtboxprice.Text;
            string location = txtboxlocation.Text;
            string description = richTextBox1.Text;

            // Ensure all fields are filled
            if (string.IsNullOrWhiteSpace(itemName) || string.IsNullOrWhiteSpace(price) ||
                string.IsNullOrWhiteSpace(location) || string.IsNullOrWhiteSpace(description))
            {
                MessageBox.Show("Please fill in all fields before adding the item.", "Missing Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "INSERT INTO items (item_name, price, location, description) VALUES (@item_name, @price, @location, @description)";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@item_name", itemName);
                        cmd.Parameters.AddWithValue("@price", price);
                        cmd.Parameters.AddWithValue("@location", location);
                        cmd.Parameters.AddWithValue("@description", description);

                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Item added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Failed to add item.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AccountName_Click(object sender, EventArgs e)
        {

        }

        private void AccountContact_Click(object sender, EventArgs e)
        {

        }
    }
}
