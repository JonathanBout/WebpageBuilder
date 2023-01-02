namespace WebpageBuilder.CSS
{
    /// <summary>
    /// The CSS File class
    /// </summary>
    public class CSSFile
    {
        /// <summary>
        /// All <see cref="CSSRule"/>s for this <see cref="CSSFile"/>.
        /// </summary>
        public List<CSSRule> Rules { get; init; } = new();

        /// <summary>
        /// Converts this <see cref="CSSFile"/> to its string representation.
        /// </summary>
        /// <returns>This CSS File as a string.</returns>
        public override string ToString()
        {
            return string.Join("\n", Rules.Select(x => x.ToString()));
        }
    }
}