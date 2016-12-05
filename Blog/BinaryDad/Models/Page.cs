namespace BinaryDad.Models
{
    public class Page : TextContent
    {
        public Page() : base(ContentType.Page) { }

        public Page(TextContent content) : base(content) { }

        public virtual Page Parent { get; set; }
    }
}
