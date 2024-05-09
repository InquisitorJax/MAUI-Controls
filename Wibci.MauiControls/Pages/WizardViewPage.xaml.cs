namespace Wibci.MauiControls.Pages;

public partial class WizardViewPage : ContentPage
{
	public WizardViewPage()
	{
		InitializeComponent();
	}

    private void Button_Next(object sender, EventArgs e)
    {
        _wizard.Forward();
    }

    private void Button_Prev(object sender, EventArgs e)
    {
        _wizard.Back();
    }
}