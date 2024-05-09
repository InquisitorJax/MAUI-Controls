using Wibci.MauiControls.Pages;

namespace Wibci.MauiControls;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();

		Routing.RegisterRoute(nameof(MarkdownPage), typeof(MarkdownPage));
        Routing.RegisterRoute(nameof(EntryPage), typeof(EntryPage));
        Routing.RegisterRoute(nameof(WizardViewPage), typeof(WizardViewPage));
    }
}
