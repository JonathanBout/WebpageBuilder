using System.Collections;

namespace WebpageBuilder.HTML
{
	/// <summary>
	/// The HTML Element class.
	/// </summary>
	public class HTMLElement : IEnumerable<HTMLElement>
	{
		/// <summary>
		/// Gets or initializes the elements name.
		/// </summary>
		public string Name { get; init; } = "div";
		/// <summary>
		/// Gets or initializes the elements attributes, e.g. href='http://example.com'.
		/// </summary>
		public Dictionary<string, string> Atributes { get; init; } = new();
		/// <summary>
		/// Gets or initializes the elements child elements. If this list is empty, the <see cref="Text"/> property is used.
		/// </summary>
		public List<HTMLElement> Elements { get; init; } = new();
		/// <summary>
		/// The elements text contents.
		/// </summary>
		string Text { get; set; } = "";

		/// <summary>
		/// Gets if this element has any child elements.
		/// </summary>
		public bool HasElements => Elements.Any();

		/// <summary>
		/// The default constructor.
		/// </summary>
		public HTMLElement() { }

		/// <summary>
		/// Creates an element with <paramref name="name"/> and <paramref name="text"/> content.
		/// </summary>
		/// <param name="name">The name of the element</param>
		/// <param name="text">The plaintext content of the element</param>
		public HTMLElement(string name, string text)
		{
			Name = name;
			Text = text;
		}

		/// <summary>
		/// Gets the <see cref="Text"/> if it has a value. Otherwise, returns the child elements tree.
		/// </summary>
		/// <returns>The content as a <see cref="string"/></returns>
		public string GetText()
		{
			if (string.IsNullOrEmpty(Text))
			{
				return string.Join("", Elements);
			}
			return Text;
		}

		/// <summary>
		/// Sets the plaintext content of the element and clears the child elements list.
		/// </summary>
		/// <param name="text">The content as a <see cref="string"/></param>
		public void SetText(string text)
		{
			Elements.Clear();
			Text = text;
		}

		/// <summary>
		/// Adds the <paramref name="element"/> to the elements list. If <see cref="Text"/> is specified,
		/// prepends it to the list of elements.
		/// </summary>
		/// <param name="element">The <see cref="HTMLElement"/> to add.</param>
		public void AddElement(HTMLElement element)
		{
			if (string.IsNullOrEmpty(Text))
			{
				Elements.Add(element);
			}
			else
			{
				Elements.Insert(0, new HTMLElement()
				{
					Name = "",
					Text = Text
				});
				Elements.Add(element);
				Text = "";
			}
		}

		/// <summary>
		/// Converts the HTMLElement to its <see cref="string"/> representation.
		/// </summary>
		/// <returns>The full element with all attributes and child elements.</returns>
		public override string ToString()
		{
			if (string.IsNullOrWhiteSpace(Name))
			{
				return Text;
			}
			string modifiers = "";
			if (Atributes.Any())
			{
				foreach (var modifier in Atributes)
				{
					modifiers += string.Format(" {0}='{1}'", modifier.Key, modifier.Value);
				}
			}
			return string.Format("<{0}{1}>{2}</{0}>", Name, modifiers, GetText());
		}

		public IEnumerator<HTMLElement> GetEnumerator() => Elements.GetEnumerator();
		IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
	}
}