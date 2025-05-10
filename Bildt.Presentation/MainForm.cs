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
            InitializeCustomComponents();
        }

        private void InitializeComponent()
        {
            SuspendLayout();
            // 
            // MainForm
            // 
            ClientSize = new Size(800, 450);
            Name = "Bildt";
            ResumeLayout(false);
        }

        private void InitializeCustomComponents()
        {
            loadImagesButton = new Button
            {
                Text = "Ladda",
                Location = new Point(10, 10),
                Size = new Size(100, 30)
            };
            loadImagesButton.Click += LoadImagesButton_Click;

            exportButton = new Button
            {
                Text = "Exportera",
                Location = new Point(120, 10),
                Size = new Size(100, 30)
            };
            exportButton.Click += ExportButton_Click;

            Controls.Add(loadImagesButton);
            Controls.Add(exportButton);

            imageThumbnails = new ImageList
            {
                ImageSize = new Size(64, 64), // Thumbnail size
                ColorDepth = ColorDepth.Depth32Bit
            };

            imageList = new ListView
            {
                Location = new Point(420, 50),
                Size = new Size(200, 300),
                View = View.LargeIcon,
                LargeImageList = imageThumbnails,
                MultiSelect = false,
                FullRowSelect = true,
            };
            imageList.SelectedIndexChanged += ImageList_SelectedIndexChanged;
            Controls.Add(imageList);
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