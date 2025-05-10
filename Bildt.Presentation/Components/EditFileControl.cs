using Bildt.Application.Services;
using Bildt.Core.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

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
            _image = ImageService.GetImage(filePath);
            if (_image != null)
            {
                textBox1.Text = _image.Description;
                pictureBox1.ImageLocation = filePath;
            }
            UpdatePreview();
            this.ResumeLayout();
        }

        private void UpdatePreview()
        {
            if (pictureBox1.Image is null || _image is null)
            {
                pictureBox2.Image = null;
                return;
            };

            var image = pictureBox1.Image;

            var newImage = new Bitmap(image.Width + borderSize*2, image.Height + borderSize + borderBottom);
            using var g = Graphics.FromImage(newImage);
            g.FillRectangle(Brushes.White, 0, 0, newImage.Width, newImage.Height);
            g.DrawImage(image, borderSize, borderSize);
            g.DrawString(_image.Description, new System.Drawing.Font("Arial", 12), Brushes.Black, new PointF(10, newImage.Height - borderBottom));
            g.Flush();

            pictureBox2.Image = newImage;
        }
    }
}
