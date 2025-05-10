using Bildt.Core.Models;
using Bildt.Application.Services;

namespace Bildt.Presentation
{
    public partial class MainForm : Form
    {
        private Button? loadImagesButton;
        private Button? exportButton;
        private ListView? imageList;
        private ImageList? imageThumbnails;

        public MainForm()
        {
            InitializeComponent();
            loadImagesButton = new Button();
            exportButton = new Button();
        }

        private void ImageList_SelectedIndexChanged(object? sender, EventArgs e)
        {
            ArgumentNullException.ThrowIfNull(imageList);
            ArgumentNullException.ThrowIfNull(sender);

            // Get file path of the selected image
            if (imageList.SelectedItems.Count > 0 && imageList.SelectedItems[0] is ListViewItem selectedItem && selectedItem.Tag is not null)
            {
                string filePath = selectedItem.Tag.ToString() ?? string.Empty;
                var imageModel = ImageService.GetImage(filePath);
                // DisplayImage(imageModel);
            }
        }

        private void LoadImagesButton_Click(object? sender, EventArgs e)
        {
            ArgumentNullException.ThrowIfNull(imageList);
            ArgumentNullException.ThrowIfNull(imageThumbnails);
            ArgumentNullException.ThrowIfNull(sender);

            // Logic to load images
            using var openFileDialog = new OpenFileDialog() {
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
                    imageThumbnails.Images.Add(filePath, thumbnail);

                    // Add the image to the ListView with the thumbnail
                    var listViewItem = new ListViewItem
                    {
                        Tag = filePath,
                        Text = Path.GetFileName(filePath),
                        ImageKey = filePath // Use the file path as the key for the thumbnail
                    };
                    imageList.Items.Add(listViewItem);                
                }
            }
        }

        private void ExportButton_Click(object? sender, EventArgs e)
        {
            // Logic to export images with frame and description
        }
    }
}