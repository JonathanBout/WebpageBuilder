namespace WebpageBuilderTests
{
	public class WebpageTests
	{
		[Test]
		public void EmptyWebpageHTML()
		{
			var webpage = new Webpage();
			string expected = "<head></head><body></body>";
			Assert.That(webpage.PageHTML.ToString(), Is.EqualTo(expected));
		}

		[Test]
		public void EmptyWebpageCSS()
		{
			var webpage = new Webpage();
			string expected = string.Empty;
			Assert.That(webpage.PageCSS.ToString(), Is.EqualTo(expected));
		}

		[Test]
		public void SaveToFileTestHTMLCSS()
		{
			var webpage = new Webpage();
			webpage.PageCSS.Rules.Add(new CSSRule()
			{
				Selector = CSSSelector.Element("main").AnyChild(CSSSelector.Link)
				.Visited(),
				Properties =
				{
					{"text-decoration", "underline solid 1px" }
				}
			});
			webpage.PageHTML.Body.AddElement(new HTMLElement()
			{
				Name = "h1",
				Atributes =
				{
					{"id", "title" }
				},
				Elements =
				{
					new HTMLElement("", "the Index.html file")
				}
			});
			webpage.PageHTML.Body.AddElement(new HTMLElement
			{
				Name = "p",
				Elements =
				{
					new HTMLElement("", "This is the main file of this page."),
					new HTMLElement("a", "go to another site")
					{
						Atributes =
						{
							{"href", "https://example.com" }
						}
					}
				}
			});
			string fileLocation = Path.Combine(Path.GetTempPath(), "testfiles");
			webpage.SaveToFile(fileLocation);
			var htmlInfo = new FileInfo(Path.Combine(fileLocation, "index.html"));
			var cssInfo  = new FileInfo(Path.Combine(fileLocation, "styles.css"));
			string expectedHTML = "<head></head><body><h1 id='title'>the Index.html file</h1><p>This is the main file of this page.<a href='https://example.com'>go to another site</a></p></body>";
			string expectedCSS  = "main a:visited{text-decoration:underline solid 1px;}";
			Assert.Multiple(() =>
			{
				Assert.That(htmlInfo.Exists);
				Assert.That(cssInfo.Exists);
			});
			using var htmlReader = htmlInfo.OpenText();
			using var cssReader = cssInfo.OpenText();
			Assert.Multiple(() =>
			{
				Assert.That(htmlReader.ReadToEnd(), Is.EqualTo(expectedHTML));
				Assert.That(cssReader .ReadToEnd(), Is.EqualTo(expectedCSS ));
			});
		}
	}
}