using System.Diagnostics;
using WebpageBuilder.CSS;
using WebpageBuilder.HTML;

namespace WebpageBuilder
{
    public class Webpage
	{
		public PageHTML PageHTML { get; } = new();
		public PageCSS PageCSS { get; } = new();
	}
}