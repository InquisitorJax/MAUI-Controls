using Microsoft.Maui.Handlers;
using Microsoft.Maui.Platform;
using System.Drawing;
using UIKit;
using Wibci.MauiControls.Platforms.iOS.Controls;

namespace Wibci.MauiControls.Controls;
public partial class EntryExHandler
{
    private KeyPressTextField? _textField;

    protected override MauiTextField CreatePlatformView()
    {
        // https://github.com/xamarin/Xamarin.Forms/blob/master/Xamarin.Forms.Platform.iOS/Renderers/EntryRenderer.cs
        _textField = new KeyPressTextField(RectangleF.Empty)
        {
            BorderStyle = UITextBorderStyle.RoundedRect,
            ClipsToBounds = true
        };
        _textField.KeyPressed += TextField_KeyPressed;
        return _textField;
    }

    protected override void DisconnectHandler(MauiTextField platformView)
    {
        if (_textField != null)
        {
            _textField.KeyPressed -= TextField_KeyPressed;
            _textField = null;
        }
        base.DisconnectHandler(platformView);
    }


    private void MapEntryEx(IEntryHandler entryHandler, IEntry entry)
    {
        Console.WriteLine($"====== Handler Fire! {++HandlerCount}");
        Console.WriteLine("=====> Initial Mapping");

        if (entry is EntryEx entryEx)
        {
            if (entryEx.HasBorder)
            {
                PlatformView.Layer.BorderWidth = new nfloat(0.8);
                PlatformView.Layer.BorderColor = UIColor.LightGray.CGColor;
                PlatformView.BorderStyle = UITextBorderStyle.RoundedRect;
            }
            else
            {
                PlatformView.Layer.BorderWidth = 0;
                PlatformView.BorderStyle = UITextBorderStyle.None;
            }
            PlatformView.Layer.CornerRadius = 5;
        }
    }

    private void MapIsValid(IEntryHandler entryHandler, IEntry entry)
    {
        Console.WriteLine("=====> Map IsValid!");

        if (entry is EntryEx entryEx)
        {
            //TODO: ValidationColor property with default of red
            var isValid = entryEx.IsValid;
            var validationColor = entryEx.ValidationColor;
            PlatformView.Layer.BorderColor = isValid ? UIColor.LightGray.CGColor : validationColor.ToCGColor();
        }
    }

    private void TextField_KeyPressed(object? sender, KeyPressEventArgs e)
    {
        if (VirtualView is EntryEx entry)
        {
            entry.OnKeyPressed(e.KeyCode, e.Key);
        }
    }
}
