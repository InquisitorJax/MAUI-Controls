using Microsoft.Maui.Platform;
using Wibci.MauiControls.Extensions;
using Wibci.MauiControls.Platforms.iOS.Util;

namespace Wibci.MauiControls.Controls;

public partial class MarkdownTextViewHandler
{
	static partial void MapMarkdownProperty(MarkdownTextViewHandler handler, MarkdownTextView textView)
	{
		handler.SetMarkdownAttributes(handler.PlatformView, textView.Markdown);
	}

	protected override MauiLabel CreatePlatformView()
	{
		var platformView = base.CreatePlatformView();

		SetMarkdownAttributes(platformView, string.Empty);

		return platformView;
	}

	private void SetMarkdownAttributes(MauiLabel platformView, string markdown)
	{
		if (platformView == null)
			return;

		if (string.IsNullOrEmpty(markdown))
		{
			platformView.Text = string.Empty;
		}
		else
		{
			platformView.AttributedText = TextUtil.GetAttributedStringFromHtml(markdown.GetHtmlFromMarkdown(true));
		}
	}
}
