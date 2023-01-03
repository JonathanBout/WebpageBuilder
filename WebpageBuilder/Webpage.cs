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

		/// <summary>
		/// Saves the HTML and CSS files to <paramref name="directoryPath"/>.
		/// </summary>
		/// <param name="directoryPath">The path to save the file to</param>
		public void SaveToFile(string directoryPath)
		{
			var directory = new DirectoryInfo(directoryPath);
			if (!directory.Exists)
			{
				directory.Create();
			}
			var htmlFile = Path.Join(directoryPath, "index.html");
			var cssFile  = Path.Join(directoryPath, "styles.css");

			File.WriteAllText(htmlFile, PageHTML.ToString());
			File.WriteAllText(cssFile , PageCSS .ToString());
		}
	}
}