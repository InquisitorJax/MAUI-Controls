﻿using Foundation;

namespace Wibci.MauiControls.Platforms.iOS.Util;


public static class TextUtil
{
	public static NSAttributedString GetAttributedStringFromHtml(string html)
	{
		var error = new NSError();
		try
		{
			var htmlData = NSData.FromString(html);
			if (htmlData != null && htmlData.Length > 0)
			{
				NSAttributedString attributedString = null;

				attributedString = new NSAttributedString(htmlData, new NSAttributedStringDocumentAttributes { DocumentType = NSDocumentType.HTML, StringEncoding = NSStringEncoding.UTF8 }, ref error);
				return attributedString;
			}
			return null;
		}
		catch (Exception ex)
		{
			Console.WriteLine(ex);
			return null;
		}

	}
}
