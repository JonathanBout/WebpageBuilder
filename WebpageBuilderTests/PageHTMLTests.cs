namespace WebpageBuilderTests
{
	public class HTMLFileTests
	{
		[Test]
		public void DivAddedHTML()
		{
			var html = new HTMLFile();
			html.Body.AddElement(new HTMLElement());
			var expected = "<head></head><body><div></div></body>";
			Assert.That(html.ToString(), Is.EqualTo(expected));
		}

		[Test]
		public void DivWithMultipleModifiersHTML()
		{
			var html = new HTMLFile();
			html.Body.AddElement(new HTMLElement());
			html.Body.First().Atributes.Add("class", "classname");
			html.Body.First().Atributes.Add("id", "idname");
			var expected = "<head></head><body><div class='classname' id='idname'></div></body>";
			Assert.That(html.ToString(), Is.EqualTo(expected));
		}

		[Test]
		public void DivWithTextHTML()
		{
			var html = new HTMLFile();
			html.Body.AddElement(new HTMLElement("div", "Hello, World!"));
			var expected = "<head></head><body><div>Hello, World!</div></body>";
			Assert.That(html.ToString(), Is.EqualTo(expected));
		}

		[Test]
		public void DivWithContentHTML()
		{
			var html = new HTMLFile()
			{
				Body = new HTMLElement()
				{
					Name = "content",
					Elements =
					{
						new HTMLElement()
						{
							Name = "div",
							Elements =
							{
								new HTMLElement("p", "Hello, World!")
							}
						}
					}
				}
			};
			var expected = "<head></head><body><div><p>Hello, World!</p></div></body>";
			Assert.That(html.ToString(), Is.EqualTo(expected));
		}


		[Test]
		public void DivWithClassHTML()
		{
			var html = new HTMLFile();
			html.Body.AddElement(new HTMLElement());
			html.Body.First().Atributes.Add("class", "classname");
			var expected = "<head></head><body><div class='classname'></div></body>";
			Assert.That(html.ToString(), Is.EqualTo(expected));
		}

		[Test]
		public void ComplexHTML()
		{
			var head = new HTMLElement
			{
				Name = "head",
				Elements =
				{
					new("title", "Index Page"),
					new("link", "")
					{
						Atributes =
						{
							{"href", "styles.css" },
							{"rel",  "stylesheet" }
						}
					}
				}
			};
			var body = new HTMLElement
			{
				Name = "body",
				Elements =
				{
					new("h1", "Hello, World!"),
					new()
					{
						Name = "p",
						Elements =
						{
							new("", "Lorem ipsum dolor"),
							new("a", "sit")
							{
								Atributes =
								{
									{"href", "https://example.com/" }
								}
							},
							new("", "amet")
						}
					}
				}
			};
			var html = new HTMLFile
			{
				Head = head,
				Body = body,
			};
			var expected = "<head><title>Index Page</title><link href='styles.css' rel='stylesheet'></link></head><body><h1>Hello, World!</h1><p>Lorem ipsum dolor<a href='https://example.com/'>sit</a>amet</p></body>";
			Assert.That(html.ToString(), Is.EqualTo(expected));
		}
	}
}