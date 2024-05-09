using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace Wibci.MauiControls.ViewModel
{
    internal partial class WizardViewModel : ObservableObject
    {

        public WizardViewModel()
        {
            IsLoopEnabled = true;
            CheckCanMoveProperties();
        }

        [ObservableProperty]
        private int _pagePosition;

        [ObservableProperty]
        private string _page2Validation = string.Empty;

        [ObservableProperty]
        private bool _canMoveForward;

        [ObservableProperty]
        private bool _canMoveBack;

        [ObservableProperty]
        private bool _isLoopEnabled;

        [RelayCommand]
        private void GoForward()
        {
            if (CanMoveForward)
                PagePosition++;
        }

        [RelayCommand]
        private void GoBack()
        {
            if (CanMoveBack)
                PagePosition--;            
        }

        partial void OnPagePositionChanged(int oldValue, int newValue)
        {
            CheckCanMoveProperties();
        }

        partial void OnIsLoopEnabledChanged(bool oldValue, bool newValue)
        {
            CheckCanMoveProperties();
        }

        private void CheckCanMoveProperties()
        {
            CanMoveBack = PagePosition > 0 || IsLoopEnabled;
            CanMoveForward = PagePosition < 2 || IsLoopEnabled;
        }
    }

}
