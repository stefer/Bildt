namespace Bildt.Presentation
{
    partial class MainForm
    {
        private void InitializeComponent()
        {
            SuspendLayout();
            // 
            // MainForm
            // 
            ClientSize = new Size(800, 450);
            Name = "Bildt";

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

            ResumeLayout(false);
        }
    }
}