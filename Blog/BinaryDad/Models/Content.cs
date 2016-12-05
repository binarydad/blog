using System;

namespace BinaryDad.Models
{
    public abstract class Content
    {
        protected Content(ContentType type)
        {
            Type = type;
        }

        protected Content(Content content)
        {
            ID = content.ID;
            Title = content.Title;
            Path = content.Path;
            Published = content.Published;
            LastModified = content.LastModified;
            Revision = content.Revision;
            Type = content.Type;
        }

        public Guid ID { get; set; }

        public string Title { get; set; }
        public string Path { get; set; }
        
        public DateTime? Published { get; set; }
        public DateTime? LastModified { get; set; }

        public int Revision { get; set; }

        public ContentType Type { get; private set; }
    }
}
