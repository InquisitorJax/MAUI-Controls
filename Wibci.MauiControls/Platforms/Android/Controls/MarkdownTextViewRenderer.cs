using Android.Content;
using Microsoft.Maui.Controls.Compatibility.Platform.Android.FastRenderers;
using System.ComponentModel;
using Wibci.MauiControls.Extensions;
using Wibci.MauiControls.Platforms.Android.Utils;

namespace Wibci.MauiControls.Controls;

internal class MarkdownTextViewRenderer : LabelRenderer
{
	public MarkdownTextViewRenderer(Context context) : base(context)
	{
	}

	private MarkdownTextView MarkdownTextView => (MarkdownTextView)Element;

	protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
	{
		Console.WriteLine($"================================> {e.PropertyName}");
		base.OnElementPropertyChanged(sender, e);
		if (Control == null)
			return;

		//Control.TextFormatted = TextUtil.GetFormattedHtml(Wibci.MauiControls.Pages.MarkdownPage.MarkdownSampleText.GetHtmlFromMarkdown(true));
		// property change for markdow doesn't fire! :(
		if (e.PropertyName== nameof(MarkdownTextView.Markdown))
		{
			if (string.IsNullOrEmpty(MarkdownTextView.Markdown))
			{
				Control.Text = string.Empty;
			}
			else
			{
				Control.TextFormatted = TextUtil.GetFormattedHtml(MarkdownTextView.Markdown.GetHtmlFromMarkdown(true));
			}
		}
	}
}
