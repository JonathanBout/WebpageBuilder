namespace WebpageBuilder.HTML
{
	public class HTMLFile
	{
		readonly HTMLElement _head = new()
		{
			Name = "head"
		};

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

		public override string ToString()
		{
			return Head.ToString() + Body.ToString();
		}
	}
}