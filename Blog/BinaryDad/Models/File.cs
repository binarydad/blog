using System;
using System.Linq;

namespace BinaryDad.Models
{
    public class File : Content
    {
        static string[] imageTypes = new[] { "jpg", "jpeg", "png", "gif" };

        public File() : base(ContentType.File) { }

        public string MimeType { get; set; }
        public byte[] Data { get; set; }
        public bool IsImage
        {
            get { return imageTypes.Any(i => MimeType.IndexOf(i, StringComparison.OrdinalIgnoreCase) >= 0); }
        }
    }
}
