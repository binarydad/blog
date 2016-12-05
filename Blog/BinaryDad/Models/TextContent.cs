namespace BinaryDad.Models
{
    public class TextContent : Content
    {
        public TextContent() : this(ContentType.Text) { }

        public TextContent(TextContent content) : base(content)
        {
            Body = content.Body;
        }

        public TextContent(ContentType type) : base(type) { }

        public string Body { get; set; }
    }
}
