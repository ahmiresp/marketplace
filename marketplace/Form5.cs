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
            pctbxsellitem.MouseEnter += pctbxsellitem_MouseEnter;
            pctbxsellitem.MouseLeave += pctbxsellitem_MouseLeave;
        }

        // Placeholder for richTextBox1
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
    }
}
