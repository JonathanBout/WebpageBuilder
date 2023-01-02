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
	}
}