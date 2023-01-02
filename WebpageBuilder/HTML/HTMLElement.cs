using System.Collections;

namespace WebpageBuilder.HTML
{
    public class HTMLElement : IEnumerable<HTMLElement>
    {
        public string ElementName { get; init; } = "div";
        public Dictionary<string, string> Modifiers { get; init; } = new();
        List<HTMLElement> ChildElements { get; init; } = new();
        string Text { get; set; } = "";

        public bool HasElements => ChildElements.Any();
        public bool HasText => !string.IsNullOrEmpty(Text);

        public HTMLElement() { }
        public HTMLElement(string text)
        {
            Text = text;
        }

        public HTMLElement(IEnumerable<HTMLElement> elements)
        {
            ChildElements = elements.ToList();
        }

        public HTMLElement[] GetContent()
        {
            return ChildElements.ToArray();
        }

        public string GetText()
        {
            if (string.IsNullOrEmpty(Text))
            {
                return string.Join("", ChildElements);
            }
            return Text;
        }

        public void SetText(string text)
        {
            ChildElements.Clear();
            Text = text;
        }

        public void AddElement(HTMLElement element)
        {
            if (string.IsNullOrEmpty(Text))
            {
                ChildElements.Add(element);
            }
            else
            {
                ChildElements.Add(new HTMLElement()
                {
                    Text = Text
                });
                ChildElements.Add(element);
                Text = "";
            }
        }

        public void RemoveElement(int index)
        {
            ChildElements.RemoveAt(index);
        }

        public override string ToString()
        {
            string modifiers = "";
            if (Modifiers.Any())
            {
                foreach (var modifier in Modifiers)
                {
                    modifiers += string.Format(" {0}='{1}'", modifier.Key, modifier.Value);
                }
            }
            return string.Format("<{0}{1}>{2}</{0}>", ElementName, modifiers, GetText());
        }

        public IEnumerator<HTMLElement> GetEnumerator() => ChildElements.GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}