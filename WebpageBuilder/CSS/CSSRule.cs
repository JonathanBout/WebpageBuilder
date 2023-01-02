namespace WebpageBuilder.CSS
{
    /// <summary>
    /// The CSS Rule class.
    /// </summary>
    public class CSSRule
    {
        /// <summary>
        /// Gets or sets the selector for this rule.
        /// </summary>
        public string Selector { get; set; } = "*";
        /// <summary>
        /// Gets the Properties for this rule.
        /// </summary>
        public Dictionary<string, string> Properties { get; } = new();

        /// <summary>
        /// Converts this <see cref="CSSRule"/> to its <see cref="string"/> representation.
        /// </summary>
        /// <returns>This rule as a string.</returns>
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