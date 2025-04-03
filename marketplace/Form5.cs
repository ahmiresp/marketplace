using System;
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

        class ItemDetails
        {
            public int Id { get; set; }  // ✅ Add Id to track items
            public string ItemName { get; set; }
            public string Price { get; set; }
            public string Location { get; set; }
            public string Description { get; set; }
            public byte[] ItemImage { get; set; }
            public string Category { get; set; }  // ✅ New field for Category
        }


        public Sellit_form()
        {
            InitializeComponent();
            SetPlaceholder(); // Set the initial placeholder text for richTextBox1
            SetItemNamePlaceholder(); // Set the initial placeholder text for txtItemName
            SetPricePlaceholder(); // Set the initial placeholder text for txtboxprice
            SetLocationPlaceholder(); // Set the initial placeholder text for txtboxlocation
                                      // Assign mouse events for cursor change
            FetchAccountDetails();
            this.Load += Dashboard_Load;
            pctbxsellitem.MouseEnter += pctbxsellitem_MouseEnter;
            pctbxsellitem.MouseLeave += pctbxsellitem_MouseLeave;
            pnlaccount.Visible = false;
            pnlhereclicked.Visible = false;

            this.MinimumSize = new Size(1085, 675);
            this.MaximumSize = new Size(1200, 800);
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
            PopulateCategoryDropdowns();
            txtItemNameDesc.Enabled = false;
            txtPriceDesc.Enabled = false;
            txtLocationDesc.Enabled = false;
            richTextBox2.Enabled = false;
            cmbCategoryDesc.Enabled = false;
            pctbxitemclk.Enabled = false;
            pctbxitemclk.Enabled = false;

            // 🔹 Disable "Save Changes" button initially
            btnSaveChanges.Enabled = false;
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

            string itemName = txtItemName.Text;
            string price = txtboxprice.Text;
            string location = txtboxlocation.Text;
            string description = richTextBox1.Text;
            string category = cmbCategory.SelectedItem?.ToString(); // Get category from combobox
            string loggedInUser = loginForm.LoggedInUser;

            if (string.IsNullOrWhiteSpace(itemName) || string.IsNullOrWhiteSpace(price) ||
                string.IsNullOrWhiteSpace(location) || string.IsNullOrWhiteSpace(description) ||
                string.IsNullOrWhiteSpace(category) || pctbxsellitem.Image == null)
            {
                MessageBox.Show("Please fill in all fields and select an image before adding the item.", "Missing Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            byte[] imageBytes;
            using (MemoryStream ms = new MemoryStream())
            {
                pctbxsellitem.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                imageBytes = ms.ToArray();
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "INSERT INTO items (item_name, price, location, description, username, item_image, category) " +
                                   "VALUES (@item_name, @price, @location, @description, @username, @item_image, @category)";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@item_name", itemName);
                        cmd.Parameters.AddWithValue("@price", price);
                        cmd.Parameters.AddWithValue("@location", location);
                        cmd.Parameters.AddWithValue("@description", description);
                        cmd.Parameters.AddWithValue("@username", loggedInUser);
                        cmd.Parameters.AddWithValue("@item_image", imageBytes);
                        cmd.Parameters.AddWithValue("@category", category);

                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Item added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadUserItems();

                            txtItemName.Text = "";
                            txtboxprice.Text = "";
                            txtboxlocation.Text = "";
                            richTextBox1.Text = "";
                            cmbCategory.SelectedIndex = -1; // Reset combobox
                            pctbxsellitem.Image = Properties.Resources.Screenshot_2025_03_26_185333;
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



        private void Dashboard_Load(object sender, EventArgs e)
        {
            LoadUserItems(); // Call LoadUserItems when form loads
            pnlitemsalesdescription.Visible = false;
        }








        private void LoadUserItems()
        {
            string connectionString = @"Data Source=DESKTOP-V8S0DNV\SQLEXPRESS;Initial Catalog=marketplace;Integrated Security=True;";
            string loggedInUser = loginForm.LoggedInUser;

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT id, item_name, price, location, description, item_image, category FROM items WHERE username = @username";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@username", loggedInUser);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            flpItemsContainer.Controls.Clear();

                            while (reader.Read())
                            {
                                int itemId = Convert.ToInt32(reader["id"]);
                                string itemName = reader["item_name"].ToString();
                                string price = reader["price"].ToString();
                                string location = reader["location"].ToString();
                                string description = reader["description"].ToString();
                                string category = reader["category"].ToString();
                                byte[] imageBytes = reader["item_image"] as byte[];

                                // ✅ Print fetched data in console (for debugging)
                                Console.WriteLine($"Item Loaded - ID: {itemId}, Name: {itemName}, Price: {price}, Location: {location}, Category: {category}");

                                // Create a new panel for each item
                                Panel itemPanel = new Panel
                                {
                                    Size = pnlitems1.Size,
                                    BorderStyle = pnlitems1.BorderStyle,
                                    BackColor = pnlitems1.BackColor,
                                    Cursor = Cursors.Hand
                                };

                                PictureBox pbItem = new PictureBox
                                {
                                    Size = new Size(140, 70),
                                    Location = new Point(10, 10),
                                    SizeMode = PictureBoxSizeMode.StretchImage
                                };

                                if (imageBytes != null && imageBytes.Length > 0)
                                {
                                    using (MemoryStream ms = new MemoryStream(imageBytes))
                                    {
                                        pbItem.Image = Image.FromStream(ms);
                                    }
                                }
                                else
                                {
                                    pbItem.Image = Properties.Resources.Screenshot_2025_03_26_185333;
                                }

                                Label lblItemName = new Label { Text = "Item: " + itemName, AutoSize = true, Location = new Point(10, 90) };
                                Label lblPrice = new Label { Text = "Price: " + price, AutoSize = true, Location = new Point(10, 110) };
                                Label lblLocation = new Label { Text = "Location: " + location, AutoSize = true, Location = new Point(10, 130) };
                                Label lblCategory = new Label { Text = "Category: " + category, AutoSize = true, Location = new Point(10, 150) };

                                // ✅ Store item details inside the Panel's Tag property
                                itemPanel.Tag = new ItemDetails
                                {
                                    Id = itemId,
                                    ItemName = itemName,
                                    Price = price,
                                    Location = location,
                                    Description = description,
                                    Category = category,
                                    ItemImage = imageBytes
                                };

                                // ✅ Add click event to the panel
                                itemPanel.Click += ItemPanel_Click;

                                itemPanel.Controls.Add(pbItem);
                                itemPanel.Controls.Add(lblItemName);
                                itemPanel.Controls.Add(lblPrice);
                                itemPanel.Controls.Add(lblLocation);
                                itemPanel.Controls.Add(lblCategory);

                                flpItemsContainer.Controls.Add(itemPanel);
                            }

                            if (flpItemsContainer.Controls.Count == 0)
                            {
                                MessageBox.Show("No items found for this account.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
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











        private int selectedItemID = -1; // Store the selected item's ID

        private void ItemPanel_Click(object sender, EventArgs e)
        {
            Panel clickedPanel = sender as Panel;

            if (clickedPanel != null && clickedPanel.Tag is ItemDetails item)
            {
                // ✅ Debugging to confirm event is triggered
                Console.WriteLine($"Clicked Item - ID: {item.Id}, Name: {item.ItemName}, Category: {item.Category}");

                // ✅ Bring pnlitemsalesdescription to the front
                pnlitemsalesdescription.Visible = true;
                pnlitemsalesdescription.BringToFront();
                pnlitemsalesdescription.Refresh(); // Force UI update

                // ✅ Send other panels behind
                pnlsellitem.SendToBack();
                pnlaccount.SendToBack();

                // ✅ Fill in item details
                selectedItemID = item.Id;
                txtItemNameDesc.Text = item.ItemName;
                txtPriceDesc.Text = item.Price;
                txtLocationDesc.Text = item.Location;
                richTextBox2.Text = item.Description;

                // ✅ Set category in cmbCategoryDesc
                if (cmbCategoryDesc.Items.Contains(item.Category))
                {
                    cmbCategoryDesc.SelectedItem = item.Category;
                }
                else
                {
                    cmbCategoryDesc.SelectedIndex = -1; // If category is not in the list, clear selection
                }

                // ✅ Display image
                if (item.ItemImage != null && item.ItemImage.Length > 0)
                {
                    using (MemoryStream ms = new MemoryStream(item.ItemImage))
                    {
                        pctbxitemclk.Image = Image.FromStream(ms);
                    }
                }
                else
                {
                    pctbxitemclk.Image = Properties.Resources.Screenshot_2025_03_26_185333;
                }
            }
            else
            {
                MessageBox.Show("Error: No item details found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void PopulateCategoryDropdowns()
        {
            string[] categories = { "ELECTRONICS", "APPLIANCES", "CLOTHES", "SHOES", "BAGS", "FURNITURES" };

            // ✅ Populate both ComboBoxes
            cmbCategory.Items.AddRange(categories);
            cmbCategoryDesc.Items.AddRange(categories);
        }












        private void AccountName_Click(object sender, EventArgs e)
        {

        }

        private void AccountContact_Click(object sender, EventArgs e)
        {

        }

        private void pnlitems1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pnlhereclicked_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnitemdelete_Click(object sender, EventArgs e)
        {
            if (selectedItemID == -1)
            {
                MessageBox.Show("Please select an item to delete.", "No Item Selected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult confirmDelete = MessageBox.Show("Are you sure you want to delete this item?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirmDelete == DialogResult.Yes)
            {
                string connectionString = @"Data Source=DESKTOP-V8S0DNV\SQLEXPRESS;Initial Catalog=marketplace;Integrated Security=True;";

                try
                {
                    using (SqlConnection conn = new SqlConnection(connectionString))
                    {
                        conn.Open();
                        string query = "DELETE FROM items WHERE id = @id"; // Use 'id' instead of 'item_id'

                        using (SqlCommand cmd = new SqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@id", selectedItemID);

                            int rowsAffected = cmd.ExecuteNonQuery();

                            if (rowsAffected > 0)
                            {
                                MessageBox.Show("Item deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                // ✅ Refresh the item list
                                LoadUserItems();

                                // ✅ Hide details panel again
                                pnlitemsalesdescription.Visible = false;
                                selectedItemID = -1; // Reset the selection
                            }
                            else
                            {
                                MessageBox.Show("Failed to delete item.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnedititem_Click(object sender, EventArgs e)
        {
            // ✅ Enable editing for input fields
            txtItemNameDesc.Enabled = true;
            txtPriceDesc.Enabled = true;
            txtLocationDesc.Enabled = true;
            richTextBox2.Enabled = true;

            // ✅ Enable category selection and image update
            cmbCategoryDesc.Enabled = true;
            pctbxitemclk.Enabled = true;

            // ✅ Enable "Save Changes" button
            btnSaveChanges.Enabled = true;
        }
       
        private void UpdateItemDetails()
        {
            if (selectedItemID == -1)
            {
                MessageBox.Show("No item selected!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string updatedItemName = txtItemNameDesc.Text;
            string updatedPrice = txtPriceDesc.Text;
            string updatedLocation = txtLocationDesc.Text;
            string updatedDescription = richTextBox2.Text;
            string updatedCategory = cmbCategoryDesc.SelectedItem?.ToString();

            // ✅ Convert image to byte array
            byte[] updatedImageBytes;
            using (MemoryStream ms = new MemoryStream())
            {
                pctbxitemclk.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                updatedImageBytes = ms.ToArray();
            }

            string connectionString = @"Data Source=DESKTOP-V8S0DNV\SQLEXPRESS;Initial Catalog=marketplace;Integrated Security=True;";

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = @"UPDATE items 
                             SET item_name = @item_name, 
                                 price = @price, 
                                 location = @location, 
                                 description = @description, 
                                 category = @category, 
                                 item_image = @item_image 
                             WHERE id = @id";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", selectedItemID);
                        cmd.Parameters.AddWithValue("@item_name", updatedItemName);
                        cmd.Parameters.AddWithValue("@price", updatedPrice);
                        cmd.Parameters.AddWithValue("@location", updatedLocation);
                        cmd.Parameters.AddWithValue("@description", updatedDescription);
                        cmd.Parameters.AddWithValue("@category", updatedCategory);
                        cmd.Parameters.AddWithValue("@item_image", updatedImageBytes);

                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Item updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadUserItems(); // ✅ Refresh item list
                        }
                        else
                        {
                            MessageBox.Show("Failed to update item.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSaveChanges_Click(object sender, EventArgs e)
        {
            UpdateItemDetails();

            // 🔹 Disable editing after saving
            txtItemNameDesc.Enabled = false;
            txtPriceDesc.Enabled = false;
            txtLocationDesc.Enabled = false;
            richTextBox2.Enabled = false;

            // 🔹 Disable category selection and image update
            cmbCategoryDesc.Enabled = false;
            pctbxitemclk.Enabled = false;

            // ✅ Disable "Save Changes" button after saving
            btnSaveChanges.Enabled = false;
        }

        private void pctbxitemclk_Click(object sender, EventArgs e)
        {
            if (pctbxitemclk.Enabled) // Allow only when enabled (edit mode)
            {
                using (OpenFileDialog openFileDialog = new OpenFileDialog())
                {
                    openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif";
                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        pctbxitemclk.Image = Image.FromFile(openFileDialog.FileName);
                    }
                }
            }
        }

        private void btnbrowes_Click(object sender, EventArgs e)
        {
            BROWSE_FORM browse = new BROWSE_FORM();
            browse.Show();
            this.Hide();
        }
    }
}
