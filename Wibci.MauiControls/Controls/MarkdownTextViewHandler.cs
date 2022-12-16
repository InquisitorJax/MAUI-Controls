using Microsoft.Maui.Handlers;

namespace Wibci.MauiControls.Controls;

public partial class MarkdownTextViewHandler : LabelHandler
{
	// doc: https://alexdunn.org/2017/02/28/xamarin-controls-markdowntextview/

	static IPropertyMapper<MarkdownTextView, MarkdownTextViewHandler> PropertyMapper = new PropertyMapper<MarkdownTextView, MarkdownTextViewHandler>(Mapper)
	{
		[nameof(MarkdownTextView.Markdown)] = (handler, textView) => MapMarkdownProperty(handler, textView)
	};

	static partial void MapMarkdownProperty(MarkdownTextViewHandler handler, MarkdownTextView textView);

	public MarkdownTextViewHandler() : base(PropertyMapper)
	{
	}
}
