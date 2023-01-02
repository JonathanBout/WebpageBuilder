namespace WebpageBuilder.CSS
{
	public static class CSSSelector
	{
		public static readonly CSSSelectorStruct HTML = "html";
		public static readonly CSSSelectorStruct Body = "body";
		public static readonly CSSSelectorStruct H1 = "h1";
		public static readonly CSSSelectorStruct H2 = "h2";
		public static readonly CSSSelectorStruct H3 = "h3";
		public static readonly CSSSelectorStruct Link = "a";
		public static readonly CSSSelectorStruct Img = "img";
		public static readonly CSSSelectorStruct All = "*";
		public static readonly CSSSelectorStruct OrderedList = "ol";
		public static readonly CSSSelectorStruct UnorderedList = "ul";
		public static readonly CSSSelectorStruct ListItem = "li";

		public static CSSSelectorStruct FirstChild()
			=> ":first-child";
		public static CSSSelectorStruct NthChild(int n)
			=> $":nth-child({n})";
		public static CSSSelectorStruct NthLastChild(int n)
			=> $":nth-last-child({n})";
		public static CSSSelectorStruct LastChild()
			=> ":last-child";
		public static CSSSelectorStruct Visited()
			=> ":visited";
		public static CSSSelectorStruct Hover()
			=> ":hover";

		public static CSSSelectorStruct FirstChild(this CSSSelectorStruct parentSelector)
			=> parentSelector + FirstChild();
		public static CSSSelectorStruct NthLastDirectChild(this CSSSelectorStruct parentSelector, int n)
			=> parentSelector + NthLastChild(n);
		public static CSSSelectorStruct NthDirectChild(this CSSSelectorStruct parentSelector, int n)
	=> parentSelector + NthChild(n);
		public static CSSSelectorStruct LastDirectChild(this CSSSelectorStruct parentSelector)
			=> parentSelector + LastChild();

		public static CSSSelectorStruct DirectChild(this CSSSelectorStruct parentSelector, string contentSelector = "*")
			=> parentSelector + " > " + contentSelector;
		public static CSSSelectorStruct AnyChild(this CSSSelectorStruct parentSelector, string contentSelector = "*")
			=> parentSelector + " " + contentSelector;

		public static CSSSelectorStruct Visited(this CSSSelectorStruct selector)
			=> selector + Visited();
		public static CSSSelectorStruct Hover(this CSSSelectorStruct selector)
			=> selector + Hover();

		public static CSSSelectorStruct Element(string name)
		{
			return new CSSSelectorStruct(name);
		}

		public static CSSRule ToRule(this CSSSelectorStruct selector)
		{
			return new CSSRule()
			{
				Selector = selector,
			};
		}
	}

	public readonly struct CSSSelectorStruct
	{
		string Content { get; }
		public CSSSelectorStruct(string content)
		{
			Content = content.ToLower();
		}

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