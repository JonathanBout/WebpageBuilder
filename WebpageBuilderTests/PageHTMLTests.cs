namespace WebpageBuilderTests
{
	public class PageHTMLTests
	{
		[Test]
		public void DivAddedHTML()
		{
			var html = new PageHTML();
			html.Body.AddElement(new HTMLElement());
			var expected = "<head></head><body><div></div></body>";
			Assert.That(html.ToString(), Is.EqualTo(expected));
		}

		[Test]
		public void DivWithMultipleModifiersHTML()
		{
			var html = new PageHTML();
			html.Body.AddElement(new HTMLElement());
			html.Body.First().Modifiers.Add("class", "classname");
			html.Body.First().Modifiers.Add("id", "idname");
			var expected = "<head></head><body><div class='classname' id='idname'></div></body>";
			Assert.That(html.ToString(), Is.EqualTo(expected));
		}

		[Test]
		public void DivWithTextHTML()
		{
			var html = new PageHTML();
			html.Body.AddElement(new HTMLElement("Hello, World!"));
			var expected = "<head></head><body><div>Hello, World!</div></body>";
			Assert.That(html.ToString(), Is.EqualTo(expected));
		}

		[Test]
		public void DivWithContentHTML()
		{
			var html = new PageHTML();
			html.Body.AddElement(new HTMLElement(new HTMLElement[]
			{
				new HTMLElement("Hello, World!")
				{
					ElementName = "p"
				}
			}));
			var expected = "<head></head><body><div><p>Hello, World!</p></div></body>";
			Assert.That(html.ToString(), Is.EqualTo(expected));
		}


		[Test]
		public void DivWithClassHTML()
		{
			var html = new PageHTML();
			html.Body.AddElement(new HTMLElement());
			html.Body.First().Modifiers.Add("class", "classname");
			var expected = "<head></head><body><div class='classname'></div></body>";
			Assert.That(html.ToString(), Is.EqualTo(expected));
		}
	}
}