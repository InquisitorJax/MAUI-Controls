using Wibci.MauiControls.ViewModel;

namespace Wibci.MauiControls.Pages;

public partial class WizardViewPage : ContentPage
{
	public WizardViewPage()
	{
		InitializeComponent();
		BindingContext = new WizardViewModel();
	}
}