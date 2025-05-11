using System.Drawing;
using Bildt.Core.Models;

namespace Bildt.Application.Services
{
    public static class ImageService
    {
        public static void SetDescription(ImageModel image)
        {
            SetImageDescription(image.FilePath, image.Description);
        }

        public static ImageModel GetImage(string filePath)
        {
            return new ImageModel
            {
                FilePath = filePath,
                Description = GetImageDescription(filePath) ?? ""
            };
        }

        private const int PropertyTagImageTitle = 270;

        private static string? GetImageDescription(string filePath)
        {
            using var image = Image.FromFile(filePath);
            var imageDescriptionItem = image.PropertyItems.Where(x => x.Id == PropertyTagImageTitle).FirstOrDefault();
            if (imageDescriptionItem is {Type: 2, Value: { }})
            {
                return System.Text.Encoding.UTF8.GetString(imageDescriptionItem.Value).Trim('\0');
            }
            return null;
        }

        private static void SetImageDescription(string filePath, string description)
        {
            string tempFilePath = filePath + ".tmp";
            using (var image = Image.FromFile(filePath))
            {
                // Create a new PropertyItem
                var propertyItem = image.PropertyItems[0]; // Use an existing PropertyItem as a template
                propertyItem.Id = PropertyTagImageTitle;
                propertyItem.Type = 2; // ASCII
                propertyItem.Value = System.Text.Encoding.UTF8.GetBytes(description + '\0'); // Add null terminator
                propertyItem.Len = propertyItem.Value.Length;

                // Set the PropertyItem
                image.SetPropertyItem(propertyItem);

                // Save the image back to the file
                image.Save(tempFilePath, image.RawFormat);
            }

            // Replace the original file with the updated one
            File.Delete(filePath);
            File.Move(tempFilePath, filePath);
        }
    }
}