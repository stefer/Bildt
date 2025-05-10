using System.Windows.Forms;

namespace Bildt.Presentation
{
    public partial class MainForm : Form
    {
        private Button? loadImagesButton;
        private Button? exportButton;

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
            Name = "MainForm";
            ResumeLayout(false);
        }

        private void InitializeCustomComponents()
        {
            loadImagesButton = new Button
            {
                Text = "Load Images",
                Location = new Point(10, 10),
                Size = new Size(100, 30)
            };
            loadImagesButton.Click += LoadImagesButton_Click;

            exportButton = new Button
            {
                Text = "Export",
                Location = new Point(120, 10),
                Size = new Size(100, 30)
            };
            exportButton.Click += ExportButton_Click;

            Controls.Add(loadImagesButton);
            Controls.Add(exportButton);
        }

        private void LoadImagesButton_Click(object? sender, EventArgs e)
        {
            // Logic to load images
        }

        private void ExportButton_Click(object? sender, EventArgs e)
        {
            // Logic to export images with frame and description
        }
    }
}