using Bildt.Application.Services;

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
                Filter = "Bildfiler|*.jpg;*.jpeg;*.png;*.bmp",
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

                    var imageModel = ImageService.GetImage(filePath);

                    // Add the image to the ListView with the thumbnail
                    var listViewItem = new ListViewItem
                    {
                        Tag = filePath,
                        Checked = File.Exists(imageModel.TitledImagePath),
                        Text = Path.GetFileName(filePath),
                        ImageKey = filePath // Use the file path as the key for the thumbnail,
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

        private void editFileControl1_Load(object sender, EventArgs e)
        {

        }
    }
}
