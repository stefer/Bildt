using Bildt.Application.Services;
using Bildt.Core.Models;
using static System.Net.Mime.MediaTypeNames;

namespace Bildt.Presentation.Components
{
    public partial class EditFileControl : UserControl
    {
        private const int borderSize = 20;
        private const int borderBottom = 40;

        private ImageModel? _image;

        public EditFileControl()
        {
            InitializeComponent();
        }

        public void SetImage(string filePath)
        {
            this.SuspendLayout();
            ClearPreview();
            _image = ImageService.GetImage(filePath);
            if (_image != null)
            {
                descriptionTextBox.Text = _image.Description;
                System.Drawing.Image image;
                using (var tmpImage = System.Drawing.Image.FromFile(filePath))
                {
                    image = new Bitmap(tmpImage);
                }
                origPictureBox.Image = image;
                UpdatePreview(image);
            }
            this.ResumeLayout();
        }

        private void ClearPreview()
        {
            editedPictureBox.Image = null;
        }

        private void UpdatePreview(System.Drawing.Image image)
        {
            var newImage = new Bitmap(image.Width + borderSize * 2, image.Height + borderSize + borderBottom);
            using (var g = Graphics.FromImage(newImage))
            {
                g.FillRectangle(Brushes.White, 0, 0, newImage.Width, newImage.Height);
                g.DrawImage(image, borderSize, borderSize, image.Width, image.Height);
                if (_image?.Description != null)
                {
                    g.DrawString(_image.Description, new System.Drawing.Font("Arial", 24), Brushes.Black, new PointF(borderSize + 10, newImage.Height - borderBottom));
                }
                g.Flush();
            }

            editedPictureBox.Image = newImage;
        }

        private void UpdateDescription(object sender, EventArgs e)
        {
            if (_image != null && _image.Description != descriptionTextBox.Text)
            {
                _image.Description = descriptionTextBox.Text;
                ImageService.SetDescription(_image);
                SetImage(_image.FilePath);
            }
        }

        private void Save(object sender, EventArgs e)
        {
            if (_image?.TitledImagePath != null)
            {
                editedPictureBox.Image?.Save(_image.TitledImagePath, System.Drawing.Imaging.ImageFormat.Jpeg);
            }
        }
    }
}
