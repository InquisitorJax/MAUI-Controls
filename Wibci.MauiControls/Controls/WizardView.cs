namespace Wibci.MauiControls.Controls;

// doc: https://redth.codes/building-a-step-by-step-wizard-control-in-net-maui

public sealed class WizardView : Grid
{
    public event EventHandler<StepChangedEventArgs>? StepChanged;

    public static readonly BindableProperty IsLoopEnabledProperty = BindableProperty.Create(
        propertyName: nameof(IsLoopEnabled),
        returnType: typeof(bool),
        declaringType: typeof(WizardView),
        defaultValue: true,
        defaultBindingMode: BindingMode.OneWay,
        propertyChanged: OnIsLoopEnabledChanged);

    private static void OnIsLoopEnabledChanged(BindableObject bindable, object oldValue, object newValue)
    {
        if (bindable is WizardView view)
        {
            view.UpdatePositionProperties();
        }
    }

    private bool _isBusy;
    private const int AnimationTime = 250;

    public bool IsLoopEnabled
    {
        get { return (bool)GetValue(IsLoopEnabledProperty); }
        set { SetValue(IsLoopEnabledProperty, value); }
    }

    public bool CanMoveForward { get; set; } = true;
    public bool CanMoveBack { get; set; } = true;

    public int Position { get; set; }

    protected override void OnChildAdded(Element child)
    {
        if (child is VisualElement ve)
        {
            ve.IsVisible = false;

            if (GetCurrentIndex() < 0)
            {
                ve.IsVisible = true;
            }
        }

        var currentIndex = GetCurrentIndex();
        CanMoveBack = IsLoopEnabled || currentIndex > 0;
        CanMoveForward = IsLoopEnabled || currentIndex < Children.Count - 1;

        base.OnChildAdded(child);
    }

    public int GetCurrentIndex()
    {
        for (var i = 0; i < Children.Count; i++)
        {
            if (Children[i] is VisualElement ve && ve.IsVisible)
                return i;
        }

        return -1;
    }

    public async Task Forward()
    {
        if (_isBusy || !CanMoveForward)
            return;

        _isBusy = true;

        try
        {
            var c = GetCurrentIndex();

            var currentIndex = c;
            var nextIndex = c + 1;

            if (nextIndex >= Children.Count)
                    nextIndex = 0;

            if (currentIndex == nextIndex)
                return;

            var currentView = Children[currentIndex] as VisualElement;
            var nextView = Children[nextIndex] as VisualElement;

            if (nextView == null || currentView == null)
                return;

            // Prepare the 'next' view to show, moving it out of 
            // view, by setting its x translation to the right of
            // our container (container's width)
            nextView.TranslationX = this.Width;
            // Make the 'next' view visible so we see it sliding in
            // now that it's translated outside of the container view and not 'seen'
            nextView.IsVisible = true;

            // Animate the translation of both the 'next' and 'current'
            // views so that we get a slide effect
            // The 'next' view slides in from the right and the
            // current view slides out of view to the right
            await Task.WhenAll(
                nextView.TranslateTo(0, 0, AnimationTime, Easing.CubicInOut),
                currentView.TranslateTo(-1 * this.Width, 0, AnimationTime, Easing.CubicInOut));

            // Reset the visibility and translation of the
            // current (now previous) view now that the animation is complete
            currentView.IsVisible = false;
            currentView.TranslationX = 0;

            // Invoke an event to know the step changed
            StepChanged?.Invoke(this, new StepChangedEventArgs(currentIndex, nextIndex));
            UpdatePositionProperties();
        }
        finally
        {
            _isBusy = false;
        }
    }

    public async Task Back()
    {
        if (_isBusy || !CanMoveBack)
            return;

        _isBusy = true;


        try
        {
            var c = GetCurrentIndex();

            var currentIndex = c;
            var nextIndex = c - 1;

            if (nextIndex < 0)
                nextIndex = Children.Count - 1;
            if (currentIndex == nextIndex)
                return;

            var currentView = Children[currentIndex] as VisualElement;
            var nextView = Children[nextIndex] as VisualElement;

            if (nextView == null || currentView == null)
                return;

            // Prepare the 'next' view to show, moving it out of 
            // view, by setting its x translation to the right of
            // our container (container's width)
            nextView.TranslationX = -this.Width;
            // Make the 'next' view visible so we see it sliding in
            // now that it's translated outside of the container view and not 'seen'
            nextView.IsVisible = true;

            // Animate the translation of both the 'next' and 'current'
            // views so that we get a slide effect
            // The 'next' view slides in from the right and the
            // current view slides out of view to the right
            await Task.WhenAll(
                nextView.TranslateTo(0, 0, AnimationTime, Easing.CubicInOut),
                currentView.TranslateTo(Width, 0, AnimationTime, Easing.CubicInOut));

            // Reset the visibility and translation of the
            // current (now previous) view now that the animation is complete
            currentView.IsVisible = false;
            currentView.TranslationX = 0;

            // Invoke an event to know the step changed
            StepChanged?.Invoke(this, new StepChangedEventArgs(currentIndex, nextIndex));
            UpdatePositionProperties();
        }
        finally
        {
            _isBusy = false;
        }
    }

    private void UpdatePositionProperties()
    {
        var currentIndex = GetCurrentIndex();
        CanMoveBack = IsLoopEnabled || currentIndex > 0;
        OnPropertyChanged(nameof(CanMoveBack));
        CanMoveForward = IsLoopEnabled || currentIndex < Children.Count - 1;
        OnPropertyChanged(nameof(CanMoveForward));
        Position = currentIndex;
        OnPropertyChanged(nameof(Position));
    }
}

public class StepChangedEventArgs : EventArgs
{
    public StepChangedEventArgs(int previousStepIndex, int stepIndex)
        : base()
    {
        PreviousStepIndex = previousStepIndex;
        StepIndex = stepIndex;
    }

    public int PreviousStepIndex { get; }
    public int StepIndex { get; }
}

