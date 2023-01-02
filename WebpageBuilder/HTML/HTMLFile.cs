namespace WebpageBuilder.HTML
{
	/// <summary>
	/// The HTML File class
	/// </summary>
	public class HTMLFile
	{
		readonly HTMLElement _head = new()
		{
			Name = "head"
		};

		/// <summary>
		/// The <c>Head</c> element.
		/// </summary>
		public HTMLElement Head
		{
			get => _head; 
			init
			{
				if (value.Name != "head")
				{
					if (value.HasElements)
					{
						_head = new HTMLElement
						{
							Name = "head",
							Elements = value.Elements
						};
					}else
					{
						_head = new HTMLElement("head", value.GetText());
					}
				}else
				{
					_head = value;
				}
			}
		}

		readonly HTMLElement _body = new()
		{
			Name = "body"
		};

		/// <summary>
		/// The <c>Body</c> element
		/// </summary>
		public HTMLElement Body
		{
			get => _body;
			init
			{
				if (value.Name != "body")
				{
					if (value.HasElements)
					{
						_body = new HTMLElement
						{
							Name = "body",
							Elements = value.Elements
						};
					}
					else
					{
						_body = new HTMLElement("body", value.GetText());
					}
				}
				else
				{
					_body = value;
				}
			}
		}

		/// <summary>
		/// Converts this <see cref="HTMLFile"/> to its <see cref="string"/> representation.
		/// </summary>
		/// <returns>This HTML File as a string</returns>
		public override string ToString()
		{
			return Head.ToString() + Body.ToString();
		}
	}
}