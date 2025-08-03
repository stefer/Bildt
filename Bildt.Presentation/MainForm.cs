using Bildt.Application.Services;

namespace Bildt.Presentation
{
    public partial class MainForm : Form
    {
        private string _selectedFolder = string.Empty;

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
                _selectedFolder = folderDialog.SelectedPath;
                Text = $"Bilder från: {_selectedFolder}";

                LoadFilesFromFolder(_selectedFolder);
            }
        }

        private void LoadFilesFromFolder(string folder)
        {
            // Filändelser vi är intresserade av
            string[] extensions = { ".jpg", ".jpeg", ".png", ".bmp" };

            // Hämta alla bildfiler i mappen
            var imageFiles = Directory.GetFiles(folder)
                                      .Where(file => extensions.Contains(Path.GetExtension(file).ToLower()))
                                      .Where(file => !file.Contains(".gen", StringComparison.CurrentCultureIgnoreCase)) // Exkludera .gen-filer
                                      .ToList();

            //  Rensa gamla bilder och objekt
            imageList1.Images.Clear();
            listView1.Items.Clear();

            foreach (var filePath in imageFiles)
            {
                // Generera en thumbnail
                using var image = Image.FromFile(filePath);
                var thumbnail = image.GetThumbnailImage(64, 64, () => false, IntPtr.Zero);

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

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0 && listView1.SelectedItems[0] is ListViewItem selectedItem && selectedItem.Tag is not null)
            {
                string filePath = selectedItem.Tag.ToString() ?? string.Empty;
                editFileControl1.SetImage(filePath);
            }
        }

        private void editFileControl1_SaveClicked(object sender, EventArgs e)
        {
            LoadFilesFromFolder(_selectedFolder);
        }
    }
}
