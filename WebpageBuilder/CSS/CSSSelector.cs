namespace WebpageBuilder.CSS
{
	/// <summary>
	/// A Helper Class for CSS Selectors
	/// </summary>
	public static class CSSSelector
	{
		/// <summary>
		/// The <c>html</c> selector
		/// </summary>
		public static readonly CSSSelectorStruct HTML = "html";
		/// <summary>
		/// The <c>body</c> selector
		/// </summary>
		public static readonly CSSSelectorStruct Body = "body";
		/// <summary>
		/// The <c>h1</c> selector
		/// </summary>
		public static readonly CSSSelectorStruct H1 = "h1";
		/// <summary>
		/// The <c>h2</c> selector
		/// </summary>
		public static readonly CSSSelectorStruct H2 = "h2";
		/// <summary>
		/// The <c>h3</c> selector
		/// </summary>
		public static readonly CSSSelectorStruct H3 = "h3";
		/// <summary>
		/// The <c>a</c> selector
		/// </summary>
		public static readonly CSSSelectorStruct Link = "a";
		/// <summary>
		/// The <c>img</c> selector
		/// </summary>
		public static readonly CSSSelectorStruct Img = "img";
		/// <summary>
		/// The <c>* (star)</c> selector
		/// </summary>
		public static readonly CSSSelectorStruct All = "*";
		/// <summary>
		/// The <c>ol</c> selector
		/// </summary>
		public static readonly CSSSelectorStruct OrderedList = "ol";
		/// <summary>
		/// The <c>ul</c> selector
		/// </summary>
		public static readonly CSSSelectorStruct UnorderedList = "ul";
		/// <summary>
		/// The <c>li</c> selector
		/// </summary>
		public static readonly CSSSelectorStruct ListItem = "li";

		/// <summary>
		/// The <c>:first-child</c> selector
		/// </summary>
		public static CSSSelectorStruct FirstChild()
			=> ":first-child";
		/// <summary>
		/// The <c>:nth-child(<paramref name="n"/>)</c> selector
		/// </summary>
		public static CSSSelectorStruct NthChild(int n)
			=> $":nth-child({n})";
		/// <summary>
		/// The <c>:nth-last-child(<paramref name="n"/>)</c> selector
		/// </summary>
		public static CSSSelectorStruct NthLastChild(int n)
			=> $":nth-last-child({n})";
		/// <summary>
		/// The <c>:last-child</c> selector
		/// </summary>
		public static CSSSelectorStruct LastChild()
			=> ":last-child";
		/// <summary>
		/// The <c>:visited</c> selector
		/// </summary>
		public static CSSSelectorStruct Visited()
			=> ":visited";
		/// <summary>
		/// The <c>:hover</c> selector
		/// </summary>
		public static CSSSelectorStruct Hover()
			=> ":hover";
		/// <summary>
		/// The <c>:after</c> selector
		/// </summary>
		public static CSSSelectorStruct After()
			=> ":after";

		/// <summary>
		/// The <c>:first-child</c> selector
		/// </summary>
		/// <param name="parentSelector">the parent selector</param>
		/// <returns>the parent selector with the <c>:first-child</c> selector appended to it</returns>
		public static CSSSelectorStruct FirstChild(this CSSSelectorStruct parentSelector)
			=> parentSelector + FirstChild();
		/// <summary>
		/// The <c>:nth-last-child(<paramref name="n"/>)</c> selector
		/// </summary>
		/// <param name="parentSelector">the parent selector</param>
		/// <returns>the parent selector with the <c>:nth-last-child(<paramref name="n"/>)</c> selector appended to it</returns>
		public static CSSSelectorStruct NthLastDirectChild(this CSSSelectorStruct parentSelector, int n)
			=> parentSelector + NthLastChild(n);
		/// <summary>
		/// The <c>:nth-child(<paramref name="n"/>)</c> selector
		/// </summary>
		/// <param name="parentSelector">the parent selector</param>
		/// <returns>the parent selector with the <c>:nth-child(<paramref name="n"/>)</c> selector appended to it</returns>
		public static CSSSelectorStruct NthDirectChild(this CSSSelectorStruct parentSelector, int n)
			=> parentSelector + NthChild(n);
		/// <summary>
		/// The <c>:last-child</c> selector
		/// </summary>
		/// <param name="parentSelector">the parent selector</param>
		/// <returns>the parent selector with the <c>:last-child</c> selector appended to it</returns>
		public static CSSSelectorStruct LastDirectChild(this CSSSelectorStruct parentSelector)
			=> parentSelector + LastChild();
		/// <summary>
		/// The <c>></c> selector
		/// </summary>
		/// <param name="parentSelector">the parent selector</param>
		/// <returns>the parent selector with the <c>></c> selector appended to it</returns>
		public static CSSSelectorStruct DirectChild(this CSSSelectorStruct parentSelector, string contentSelector = "*")
			=> parentSelector + " > " + contentSelector;
		/// <summary>
		/// The <c>  (space)</c> selector.
		/// </summary>
		/// <param name="parentSelector">the parent selector</param>
		/// <returns>the parent selector with the <c>  (space)</c> selector appended to it</returns>
		public static CSSSelectorStruct AnyChild(this CSSSelectorStruct parentSelector, string contentSelector = "*")
			=> parentSelector + " " + contentSelector;

		/// <summary>
		/// The <c>:visited</c> selector
		/// </summary>
		/// <param name="selector">the parent selector</param>
		/// <returns>the parent selector with the <c>:visited</c> selector appended to it</returns>
		public static CSSSelectorStruct Visited(this CSSSelectorStruct selector)
			=> selector + Visited();
		/// <summary>
		/// The <c>:hover</c> selector
		/// </summary>
		/// <param name="selector">the parent selector</param>
		/// <returns>the parent selector with the <c>:hover</c> selector appended to it</returns>
		public static CSSSelectorStruct Hover(this CSSSelectorStruct selector)
			=> selector + Hover();

		/// <summary>
		/// Builds a element selector named <paramref name="name"/>.
		/// </summary>
		/// <param name="name">The name of the element</param>
		/// <returns>The element selector</returns>
		public static CSSSelectorStruct Element(string name)
		{
			return new CSSSelectorStruct(name);
		}

		/// <summary>
		/// Creates a <see cref="CSSRule"/> from a CSS Selector.
		/// </summary>
		/// <param name="selector">The selector to create the rule with</param>
		/// <returns>The <see cref="CSSRule"/> created.</returns>
		public static CSSRule ToRule(this CSSSelectorStruct selector)
		{
			return new CSSRule()
			{
				Selector = selector,
			};
		}
	}

	/// <summary>
	/// A helper struct.
	/// </summary>
	public readonly struct CSSSelectorStruct
	{
		/// <summary>
		/// Gets the content of the struct. Initialized to <c>"*"</c> by default.
		/// </summary>
		string Content { get; }

		/// <summary>
		/// The constructor.
		/// </summary>
		/// <param name="content">The content of the <see cref="CSSSelectorStruct"/></param>
		public CSSSelectorStruct(string content)
		{
			Content = content.ToLower();
		}

		/// <summary>
		/// The default constructor.
		/// </summary>
		public CSSSelectorStruct() : this("*") { }

		public static implicit operator string(CSSSelectorStruct value)
		{
			return value.Content;
		}

		public static implicit operator CSSSelectorStruct(string value)
		{
			return new CSSSelectorStruct(value);
		}
	}
}