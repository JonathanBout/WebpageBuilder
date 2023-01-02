using System.Diagnostics;
using WebpageBuilder.CSS;
using WebpageBuilder.HTML;

namespace WebpageBuilder
{
    public class Webpage
	{
		public HTMLFile PageHTML { get; } = new();
		public CSSFile PageCSS { get; } = new();
	}
}