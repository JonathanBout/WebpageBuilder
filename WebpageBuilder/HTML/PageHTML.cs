namespace WebpageBuilder.HTML
{
    public class PageHTML
    {
        public HTMLElement Head { get; } = new()
        {
            ElementName = "head"
        };
        public HTMLElement Body { get; } = new()
        {
            ElementName = "body"
        };

        public override string ToString()
        {
            return Head.ToString() + Body.ToString();
        }
    }
}