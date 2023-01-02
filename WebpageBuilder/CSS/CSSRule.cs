namespace WebpageBuilder.CSS
{
    public class CSSRule
    {
        public string Selector { get; set; } = "*";
        public Dictionary<string, string> Properties { get; } = new();

        public override string ToString()
        {
            string ret = Selector + "{";
            foreach (var prop in Properties)
            {
                ret += $"{prop.Key}:{prop.Value};";
            }
            return ret + "}";
        }
    }
}