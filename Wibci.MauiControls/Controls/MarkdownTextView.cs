namespace Wibci.MauiControls.Controls;

public class MarkdownTextView : Label
{

	public static readonly BindableProperty MarkdownProperty = BindableProperty.Create(
			propertyName: nameof(Markdown),
			returnType: typeof(string),
			declaringType: typeof(MarkdownTextView),
			defaultValue: string.Empty,
			defaultBindingMode: BindingMode.OneWay);

	public string Markdown
	{
		get { return (string)GetValue(MarkdownProperty); }
		set { SetValue(MarkdownProperty, value); }
	}
}
