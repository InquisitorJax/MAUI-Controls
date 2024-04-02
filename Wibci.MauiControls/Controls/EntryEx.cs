#nullable enable
namespace Wibci.MauiControls.Controls;

public sealed class EntryEx : Entry
{
    public event EventHandler<KeyPressEventArgs>? KeyPressed;

    public static readonly BindableProperty IsValidProperty = BindableProperty.Create(
        propertyName: nameof(IsValid),
        returnType: typeof(bool),
        declaringType: typeof(EntryEx),
        defaultValue: true,
        defaultBindingMode: BindingMode.OneWay);

    public static readonly BindableProperty ValidationColorProperty = BindableProperty.Create(
        propertyName: nameof(ValidationColor),
        returnType: typeof(Color),
        declaringType: typeof(EntryEx),
        defaultValue: Colors.Red,
        defaultBindingMode: BindingMode.OneWay);

    public static readonly BindableProperty HasBorderProperty = BindableProperty.Create(
        propertyName: nameof(HasBorder),
        returnType: typeof(bool),
        declaringType: typeof(EntryEx),
        defaultValue: true,
        defaultBindingMode: BindingMode.OneWay);


    public bool IsValid
    {
        get { return (bool)GetValue(IsValidProperty); }
        set { SetValue(IsValidProperty, value); }
    }

    public Color ValidationColor
    {
        get { return (Color)GetValue(ValidationColorProperty); }
        set { SetValue(ValidationColorProperty, value); }
    }
    public bool HasBorder
    {
        get { return (bool)GetValue(HasBorderProperty); }
        set { SetValue(HasBorderProperty, value); }
    }

    public void OnKeyPressed(KeyCode keyCode, string key)
    {
        KeyPressed?.Invoke(this, new KeyPressEventArgs(keyCode, key));
    }
}

public class KeyPressEventArgs : EventArgs
{
    public KeyPressEventArgs(KeyCode code, string key)
    {
        KeyCode = code;
        Key = key;
    }

    public KeyCode KeyCode { get; }
    public string Key { get; }
}

public enum KeyCode
{
    Unknown,
    UpArrow,
    DownArrow
}
