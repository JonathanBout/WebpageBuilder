using System.Diagnostics;
using WebpageBuilder.CSS;
using WebpageBuilder.HTML;

namespace WebpageBuilder
{
	/// <summary>
	/// The Webpage class
	/// </summary>
    public class Webpage
	{
		/// <summary>
		/// Gets this <see cref="Webpage"/>s HTML.
		/// </summary>
		public HTMLFile PageHTML { get; } = new();

		/// <summary>
		/// Gets this <see cref="Webpage"/>s CSS.
		/// </summary>
		public CSSFile PageCSS { get; } = new();
	}
}