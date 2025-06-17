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
            using var folderDialog = new FolderBrowserDialog
            {
                Description = "Välj en mapp med bilder"
            };

            if (folderDialog.ShowDialog() == DialogResult.OK)
            {
                string selectedFolder = folderDialog.SelectedPath;
                this.Text = $"Bilder från: {selectedFolder}";

                // Filändelser vi är intresserade av
                string[] extensions = { ".jpg", ".jpeg", ".png", ".bmp" };

                // Hämta alla bildfiler i mappen
                var imageFiles = Directory.GetFiles(selectedFolder)
                                          .Where(file => extensions.Contains(Path.GetExtension(file).ToLower()))
                                          .ToList();

                //  Rensa gamla bilder och objekt
                imageList1.Images.Clear();
                listView1.Items.Clear();

                foreach (var filePath in imageFiles)
                {
                    // Generera en thumbnail
                    using var image = Image.FromFile(filePath);
                    var thumbnail = image.GetThumbnailImage(64, 64, () => false, IntPtr.Zero);

                    // Skippa .gen -filer (om de finns i mappen)
                    if (filePath.ToLower().Contains(".gen"))
                        continue;

                    // Lägg till thumbnailen i ImageList
                    imageList1.Images.Add(filePath, thumbnail);
                    var imageModel = ImageService.GetImage(filePath);

                    // Lägg till i ListView
                    var listViewItem = new ListViewItem
                    {
                        Tag = filePath,
                        Checked = File.Exists(imageModel.TitledImagePath),
                        Text = Path.GetFileName(filePath),
                        ImageKey = filePath,
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

        private void filToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
