using CommunityToolkit.Mvvm.ComponentModel;

namespace Wibci.MauiControls.ViewModel
{
    internal partial class WizardViewModel : ObservableObject
    {

        [ObservableProperty]
        private int _selectedPage;

        private void GoNext()
        {
            SelectedPage++;
        }

        private void GoPrevious()
        {
            SelectedPage--;
        }
    }
}
