namespace Wibci.MauiControls.Controls;

public class MarkdownTextView : Label
{
	public static BindableProperty MarkdownProperty = BindableProperty.Create(nameof(Markdown), typeof(string), typeof(MarkdownTextView));
	public string Markdown
	{
		get { return (string)GetValue(MarkdownProperty); }
		set { SetValue(MarkdownProperty, value); }
	}
}
