namespace BinaryDad.Models
{
    public class BlogEntry : TextContent
    {
        public BlogEntry() : base(ContentType.BlogEntry) { }

        public BlogEntry(TextContent content) : base(content) { }

        public string Summary { get; set; }
        public virtual Blog Blog { get; set; }
    }
}
