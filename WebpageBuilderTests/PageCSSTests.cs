namespace WebpageBuilderTests
{
	public class PageCSSTests
	{
		[Test]
		public void ComplexSelectorCSS()
		{
			var css = new PageCSS();
			css.Rules.Add(new CSSRule()
			{
				Selector = CSSSelector.Element("html").DirectChild(".classname").FirstChild()
				.AnyChild("#idname").LastDirectChild().Hover().DirectChild("*").NthDirectChild(3)
				.DirectChild(CSSSelector.Link).NthLastDirectChild(100).Visited(),
				Properties =
				{
					{"color", "red" },
					{"display", "block" }
				}
			}) ;
			var expected = "html > .classname:first-child #idname:last-child:hover > *:nth-child(3) > a:nth-last-child(100):visited{color:red;display:block;}";
			Assert.That(css.ToString(), Is.EqualTo(expected));
		}

		[Test]
		public void SingleSelectorCSS()
		{
			var css = new PageCSS();
			css.Rules.Add(new CSSRule()
			{
				Selector = CSSSelector.HTML,
			});
			var expected = "html{}";
			Assert.That(css.ToString(), Is.EqualTo(expected));
		}

		[Test]
		public void RuleWithSinglePropertyCSS()
		{
			var css = new CSSRule();
			css.Properties.Add("color", "#FFF");
			Assert.That(css.ToString(), Is.EqualTo("*{color:#FFF;}"));
		}

		[Test]
		public void RuleWithMultiplePropertiesCSS()
		{
			var css = new CSSRule();
			css.Properties.Add("color", "#FFF");
			css.Properties.Add("background-color", "#000");
			Assert.That(css.ToString(), Is.EqualTo("*{color:#FFF;background-color:#000;}"));
		}

		[Test]
		public void EmptyRuleCSS()
		{
			var css = new CSSRule();
			Assert.That(css.ToString(), Is.EqualTo("*{}"));
		}
	}
}