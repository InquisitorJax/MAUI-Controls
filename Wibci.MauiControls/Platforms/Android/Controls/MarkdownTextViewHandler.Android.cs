using AndroidX.AppCompat.Widget;
using Wibci.MauiControls.Extensions;
using Wibci.MauiControls.Platforms.Android.Utils;

namespace Wibci.MauiControls.Controls;

public partial class MarkdownTextViewHandler
{
	static partial void MapMarkdownProperty(MarkdownTextViewHandler handler, MarkdownTextView textView)
	{
		handler.SetMarkdownAttributes(handler.PlatformView, textView.Markdown);
	}

	private void SetMarkdownAttributes(AppCompatTextView platformView, string markdown)
	{
		if (platformView == null)
			return;

		if (string.IsNullOrEmpty(markdown))
		{
			platformView.Text = string.Empty;
		}
		else
		{
			platformView.TextFormatted = TextUtil.GetFormattedHtml(markdown.GetHtmlFromMarkdown(true));
		}
	}


}
