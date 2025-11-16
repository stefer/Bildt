using System.Drawing;
using Bildt.Application.Models;

namespace Bildt.Application.Services;

public static class ImageService
{
    public static void SetDescription(ImageModel image)
    {
        SetImageDescription(image.FilePath, image.Description);
    }

    public static ImageModel GetImage(string filePath)
    {
        using var image = Image.FromFile(filePath);
        return new ImageModel
        {
            FilePath = filePath,
            Description = GetImageDescription(image) ?? "",
            RotationFlip = GetExifOrientation(image)
        };
    }

    private const int PropertyTagImageTitle = 270;
    private const int PropertyTagOrientation = 274;

    private static string? GetImageDescription(Image image)
    {
        var imageDescriptionItem = image.PropertyItems.Where(x => x.Id == PropertyTagImageTitle).FirstOrDefault();
        if (imageDescriptionItem is {Type: 2, Value: { }})
        {
            return System.Text.Encoding.UTF8.GetString(imageDescriptionItem.Value).Trim('\0');
        }
        return null;
    }

    public static RotateFlipType GetExifOrientation(Image image)
    {
        var prop = image.PropertyItems.FirstOrDefault(p => p.Id == PropertyTagOrientation);
        if (prop == null || prop.Value == null || prop.Value.Length == 0) return RotateFlipType.RotateNoneFlipNone;

        // Orientation value is typically a short (2 bytes); but some images present a single byte.
        int orientation = prop.Value.Length >= 2 ? BitConverter.ToUInt16(prop.Value, 0) : prop.Value[0];
        return RotateFlipTypeFromExifOrientation(orientation);
    }

    public static RotateFlipType RotateFlipTypeFromExifOrientation(int exifOrientation)
    {
        return exifOrientation switch
        {
            2 => RotateFlipType.RotateNoneFlipX,
            3 => RotateFlipType.Rotate180FlipNone,
            4 => RotateFlipType.Rotate180FlipX,
            5 => RotateFlipType.Rotate90FlipX,
            6 => RotateFlipType.Rotate90FlipNone,
            7 => RotateFlipType.Rotate270FlipX,
            8 => RotateFlipType.Rotate270FlipNone,
            _ => RotateFlipType.RotateNoneFlipNone,
        };
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