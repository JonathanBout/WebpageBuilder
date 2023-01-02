namespace WebpageBuilder.CSS
{
    public class PageCSS
    {
        public List<CSSRule> Rules { get; init; } = new();
        public override string ToString()
        {
            return string.Join("\n", Rules.Select(x => x.ToString()));
        }
    }
}