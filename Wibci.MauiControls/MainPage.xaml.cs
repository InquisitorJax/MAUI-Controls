using Wibci.MauiControls.Pages;

namespace Wibci.MauiControls;

public partial class MainPage : ContentPage
{

	public MainPage()
	{
		InitializeComponent();
	}

	private void OnMarkdownClicked(object sender, EventArgs e)
	{
		Shell.Current.GoToAsync(nameof(MarkdownPage), true);
	}
}

