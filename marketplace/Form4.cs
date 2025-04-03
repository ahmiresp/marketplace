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
using System.IO;

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
            LoadAutoCompleteData();
            btncatelectronics.Click += btncatelectronics_Click;
            btncatappliances.Click += btncatappliances_Click;
            btncatclothes.Click += btncatclothes_Click;
            btncatshoes.Click += btncatshoes_Click;
            btncatbags.Click += btncatbags_Click;
            btncatfurnitures.Click += btncatfurnitures_Click;
            this.MinimumSize = new Size(1085, 675);
            this.MaximumSize = new Size(1200, 800);

        }
        SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-V8S0DNV\SQLEXPRESS;Initial Catalog=marketplace;Integrated Security=True;");
        private void BROWSE_FORM_Load(object sender, EventArgs e)
        {
            LoadAllItems();
        }


        private void LoadAllItems(string searchTerm = "", string categoryFilter = "")
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-V8S0DNV\SQLEXPRESS;Initial Catalog=marketplace;Integrated Security=True;"))
                {
                    conn.Open();

                    // Modify the query to include category filtering
                    string query = "SELECT i.id, i.item_name, i.price, i.location, i.description, i.item_image, i.category, s.username " +
                                   "FROM dbo.items i " +
                                   "JOIN signup_form s ON i.username = s.username " +
                                   "WHERE (i.item_name LIKE @SearchTerm OR i.location LIKE @SearchTerm OR s.username LIKE @SearchTerm)";

                    // Apply category filter if provided
                    if (!string.IsNullOrEmpty(categoryFilter))
                    {
                        query += " AND i.category = @CategoryFilter";
                    }

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@SearchTerm", "%" + searchTerm + "%");

                        if (!string.IsNullOrEmpty(categoryFilter))
                        {
                            cmd.Parameters.AddWithValue("@CategoryFilter", categoryFilter);
                        }

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            flpAllItemsContainer.Controls.Clear(); // Clear previous controls

                            bool itemsFound = false;

                            while (reader.Read())
                            {
                                itemsFound = true;

                                int itemId = Convert.ToInt32(reader["id"]);
                                string itemName = reader["item_name"].ToString();
                                string price = reader["price"].ToString();
                                string location = reader["location"].ToString();
                                string description = reader["description"].ToString();
                                string category = reader["category"].ToString();
                                string username = reader["username"].ToString();
                                byte[] imageBytes = reader["item_image"] as byte[];

                                // Create item panel
                                Panel itemPanel = new Panel
                                {
                                    Size = new Size((flpAllItemsContainer.Width / 4) - 10, 250),
                                    BorderStyle = BorderStyle.FixedSingle,
                                    BackColor = ColorTranslator.FromHtml("#5c80bc"),
                                    Cursor = Cursors.Hand
                                };

                                PictureBox pbItem = new PictureBox
                                {
                                    Size = new Size(itemPanel.Width - 20, 100),
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
                                    pbItem.Image = Properties.Resources.Screenshot_2025_03_26_185333; // Default image
                                }

                                // Create labels
                                Label lblItemName = new Label { Text = "Item: " + itemName, AutoSize = true, Location = new Point(10, 120) };
                                Label lblPrice = new Label { Text = "Price: " + price, AutoSize = true, Location = new Point(10, 140) };
                                Label lblLocation = new Label { Text = "Location: " + location, AutoSize = true, Location = new Point(10, 160) };
                                Label lblCategory = new Label { Text = "Category: " + category, AutoSize = true, Location = new Point(10, 180) };
                                Label lblUsername = new Label { Text = "Posted by: " + username, AutoSize = true, Location = new Point(10, 200) };

                                // Store item details inside the Panel's Tag property
                                itemPanel.Tag = new ItemDetails
                                {
                                    Id = itemId,
                                    ItemName = itemName,
                                    Price = price,
                                    Location = location,
                                    Description = description,
                                    Category = category,
                                    ItemImage = imageBytes,
                                    Username = username
                                };

                                // Add click event
                                itemPanel.Click += ItemPanel_Click;

                                // Add controls to panel
                                itemPanel.Controls.Add(pbItem);
                                itemPanel.Controls.Add(lblItemName);
                                itemPanel.Controls.Add(lblPrice);
                                itemPanel.Controls.Add(lblLocation);
                                itemPanel.Controls.Add(lblCategory);
                                itemPanel.Controls.Add(lblUsername);

                                // Add panel to FlowLayoutPanel
                                flpAllItemsContainer.Controls.Add(itemPanel);
                            }

                            if (!itemsFound)
                            {
                                Label lblNoItems = new Label
                                {
                                    Text = "No items found",
                                    AutoSize = true,
                                    ForeColor = Color.Red,
                                    Location = new Point(flpAllItemsContainer.Width / 2 - 50, flpAllItemsContainer.Height / 2)
                                };
                                flpAllItemsContainer.Controls.Add(lblNoItems);
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




        public class ItemDetails
        {
            public int Id { get; set; }
            public string ItemName { get; set; }
            public string Price { get; set; }
            public string Location { get; set; }
            public string Description { get; set; }
            public string Category { get; set; }
            public byte[] ItemImage { get; set; }
            public string Username { get; set; }  // Add Username property
        }


        private void ItemPanel_Click(object sender, EventArgs e)
        {
            Panel clickedPanel = (Panel)sender;
            ItemDetails itemDetails = (ItemDetails)clickedPanel.Tag;

            // Example: Display item details including the username
            MessageBox.Show($"Item: {itemDetails.ItemName}\nPrice: {itemDetails.Price}\nLocation: {itemDetails.Location}\n" +
                            $"Category: {itemDetails.Category}\nPosted by: {itemDetails.Username}\nDescription: {itemDetails.Description}");
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
        private void LoadAutoCompleteData()
        {
            AutoCompleteStringCollection itemNameData = new AutoCompleteStringCollection();
            AutoCompleteStringCollection locationData = new AutoCompleteStringCollection();
            AutoCompleteStringCollection usernameData = new AutoCompleteStringCollection();

            using (SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-V8S0DNV\SQLEXPRESS;Initial Catalog=marketplace;Integrated Security=True;"))
            {
                try
                {
                    conn.Open();
                    // SQL query to fetch item_name, location, and username
                    string query = "SELECT item_name, location, username FROM dbo.items";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    SqlDataReader reader = cmd.ExecuteReader();

                    // Add item_name, location, and username to their respective collections
                    while (reader.Read())
                    {
                        string itemName = reader["item_name"].ToString();
                        string location = reader["location"].ToString();
                        string username = reader["username"].ToString();

                        // Add to respective AutoComplete collections
                        itemNameData.Add(itemName);
                        locationData.Add(location);
                        usernameData.Add(username);
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            // Set up AutoComplete for txtSearch: Suggest items from any of the three collections
            txtSearch.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            txtSearch.AutoCompleteSource = AutoCompleteSource.CustomSource;

            // Combine all three collections into one by adding them one by one
            AutoCompleteStringCollection combinedData = new AutoCompleteStringCollection();
            combinedData.AddRange(itemNameData.Cast<string>().ToArray());
            combinedData.AddRange(locationData.Cast<string>().ToArray());
            combinedData.AddRange(usernameData.Cast<string>().ToArray());

            // Assign the combined data to AutoCompleteCustomSource
            txtSearch.AutoCompleteCustomSource = combinedData;
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
            LoadAllItems("", "Electronics");
        }

        private void flpAllItemsContainer_Paint(object sender, PaintEventArgs e)
        {
            int panelWidth = (flpAllItemsContainer.Width / 4) - 10; // 10px padding between items
            int panelHeight = 250;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string searchTerm = txtSearch.Text.Trim();
            LoadAllItems(searchTerm);
        }

        private void btncatappliances_Click(object sender, EventArgs e)
        {
            LoadAllItems("", "Appliances");
        }

        private void btncatclothes_Click(object sender, EventArgs e)
        {
            LoadAllItems("", "Clothes");
        }

        private void btncatshoes_Click(object sender, EventArgs e)
        {
            LoadAllItems("", "Shoes");
        }

        private void btncatbags_Click(object sender, EventArgs e)
        {
            LoadAllItems("", "Bags");
        }

        private void btncatfurnitures_Click(object sender, EventArgs e)
        {
            LoadAllItems("", "Furnitures");
        }
    }
}
