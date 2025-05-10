using Bildt.Application.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bildt.Presentation
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void laddaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using var openFileDialog = new OpenFileDialog()
            {
                Title = "Välj bilder",
                Multiselect = true,
                Filter = "Bildfiler|*.jpg;*.jpeg;*.png;*.bmp"
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                foreach (var filePath in openFileDialog.FileNames)
                {
                    // Generate a thumbnail for the image
                    using var image = Image.FromFile(filePath);
                    var thumbnail = image.GetThumbnailImage(64, 64, () => false, IntPtr.Zero);

                    // Add the thumbnail to the ImageList
                    imageList1.Images.Add(filePath, thumbnail);

                    // Add the image to the ListView with the thumbnail
                    var listViewItem = new ListViewItem
                    {
                        Tag = filePath,
                        Text = Path.GetFileName(filePath),
                        ImageKey = filePath // Use the file path as the key for the thumbnail
                    };
                    listView1.Items.Add(listViewItem);
                }
            }
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0 && listView1.SelectedItems[0] is ListViewItem selectedItem && selectedItem.Tag is not null)
            {
                string filePath = selectedItem.Tag.ToString() ?? string.Empty;
                editFileControl1.SetImage(filePath);
            }
        }
    }
}
