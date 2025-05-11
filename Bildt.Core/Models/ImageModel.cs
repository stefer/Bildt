namespace Bildt.Core.Models
{
    public class ImageModel
    {
        public required string FilePath { get; set; }
        public required string Description { get; set; }

        public static readonly string TitledSuffix = ".gen";

        public string TitledImagePath => $"{Path.GetDirectoryName(FilePath)}{Path.DirectorySeparatorChar}{Path.GetFileNameWithoutExtension(FilePath)}{TitledSuffix}.jpg";
    }
}