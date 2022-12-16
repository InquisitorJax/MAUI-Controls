namespace Wibci.MauiControls.Pages;

public partial class MarkdownPage : ContentPage
{
	public MarkdownPage()
	{
		InitializeComponent();
	}

	public const string MarkdownSampleText = @"This is *italic* and __underline__ and **bold** and __*underline italic*__ and __**underline bold**__ and ***bold italic*** and __***underline bold italic***__.
This is ~~strike through~~.
This is ~sub~script and this is ^super^script.
This is <span style=""color:blue"">blue text</span> and <span style=""background:yellow"">highlighted text</span>

This is a list:
* line 1
* line 2";

	protected override void OnAppearing()
	{
		base.OnAppearing();
		_lblRaw.Text = MarkdownSampleText;
		_lblMarkdown.Markdown = MarkdownSampleText;
	}
}