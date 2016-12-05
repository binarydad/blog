using System.Collections.Generic;

namespace BinaryDad.Models
{
    public class Blog : TextContent
    {
        public Blog() : base(ContentType.Blog) { }

        public virtual ICollection<BlogEntry> Entries { get; set; }
    }
}
