using System.Drawing;

namespace Bildt.Infrastructure.Services
{
    public class ImageExporter
    {
        public void ExportWithFrame(string inputPath, string outputPath, string description)
        {
            using (var image = Image.FromFile(inputPath))
            {
                int frameHeight = 50;
                var newImage = new Bitmap(image.Width, image.Height + frameHeight);
                using (var g = Graphics.FromImage(newImage))
                {
                    g.FillRectangle(Brushes.White, 0, 0, newImage.Width, newImage.Height);
                    g.DrawImage(image, 0, 0);
                    g.DrawString(description, new Font("Arial", 12), Brushes.Black, new PointF(10, image.Height + 10));
                }
                newImage.Save(outputPath);
            }
        }
    }
}
