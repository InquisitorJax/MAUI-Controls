using Wibci.MauiControls.Controls;

namespace Wibci.MauiControls.Pages;

public partial class EntryPage : ContentPage
{
	public EntryPage()
	{
		EntryExHandler.HandlerCount = 0;

		InitializeComponent();

        Unloaded += EntryPage_Unloaded;
	}

    private void EntryPage_Unloaded(object? sender, EventArgs e)
    {
        Unloaded -= EntryPage_Unloaded;
        DisconnectHandlers();
    }

    private void EntryEx_KeyPressed(object sender, KeyPressEventArgs e)
    {
		_keyPressLabel.Text = e.Key.ToString();
    }

    private void DisconnectHandlers()
    {
        // TODO: Find a way to call DisconnectHandler for views handlers: see - https://github.com/AdamEssenmacher/MemoryToolkit.Maui
        foreach (var element in this.GetVisualTreeDescendants().OfType<IElement>()) element.Handler?.DisconnectHandler();
        // Doesn't work?!? ===> SET BACKGROUND still being called exponentially when entry page opens again :(
    }

}