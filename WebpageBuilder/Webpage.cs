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

		public (FileInfo htmlFile, FileInfo cssFile) SaveToFile(string directoryPath)
		{
			var directory = new DirectoryInfo(directoryPath);
			if (!directory.Exists)
			{
				directory.Create();
			}
			var htmlFile = new FileInfo(Path.Join(directoryPath, "index.html"));
			var cssFile  = new FileInfo(Path.Join(directoryPath, "styles.css"));
			if (!htmlFile.Exists)
			{
				htmlFile.Create();
			}
			if (!cssFile.Exists)
			{
				cssFile.Create();
			}

			File.WriteAllText(htmlFile.FullName, PageHTML.ToString());
			File.WriteAllText(cssFile .FullName, PageCSS .ToString());
			return (htmlFile, cssFile);
		}
	}
}