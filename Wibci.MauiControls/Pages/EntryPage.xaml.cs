using Wibci.MauiControls.Controls;

namespace Wibci.MauiControls.Pages;

public partial class EntryPage : ContentPage
{
	public EntryPage()
	{
		EntryExHandler.HandlerCount = 0;

		InitializeComponent();
	}

    private void EntryEx_KeyPressed(object sender, KeyPressEventArgs e)
    {
		_keyPressLabel.Text = e.Key.ToString();
    }
}