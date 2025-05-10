using Bildt.Core.Models;

namespace Bildt.Application.Services
{
    public class ImageService
    {
        public void SetDescription(Image image, string description)
        {
            image.Description = description;
            // Logic to save description as Exif metadata
        }
    }
}