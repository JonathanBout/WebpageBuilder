using System.Collections;

namespace WebpageBuilder.HTML
{
	public class HTMLElement : IEnumerable<HTMLElement>
	{
		public string Name { get; init; } = "div";
		public Dictionary<string, string> Atributes { get; init; } = new();
		public List<HTMLElement> Elements { get; init; } = new();
		string Text { get; set; } = "";

		public bool HasElements => Elements.Any();
		public bool HasText => !string.IsNullOrEmpty(Text);

		public HTMLElement() { }

		public HTMLElement(string name, string text)
		{
			Name = name;
			Text = text;
		}

		public HTMLElement[] GetContent()
		{
			return Elements.ToArray();
		}

		public string GetText()
		{
			if (string.IsNullOrEmpty(Text))
			{
				return string.Join("", Elements);
			}
			return Text;
		}

		public void SetText(string text)
		{
			Elements.Clear();
			Text = text;
		}

		public void AddElement(HTMLElement element)
		{
			if (string.IsNullOrEmpty(Text))
			{
				Elements.Add(element);
			}
			else
			{
				Elements.Add(new HTMLElement()
				{
					Text = Text
				});
				Elements.Add(element);
				Text = "";
			}
		}

		public void RemoveElement(int index)
		{
			Elements.RemoveAt(index);
		}

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