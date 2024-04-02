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

    protected override void ConnectHandler(MauiTextField platformView)
    {
        base.ConnectHandler(platformView);

        if (VirtualView is EntryEx entry)
        {
            if (entry.HasBorder)
            {
                platformView.Layer.BorderWidth = new nfloat(0.8);
                platformView.Layer.BorderColor = UIColor.LightGray.CGColor;
                platformView.BorderStyle = UITextBorderStyle.RoundedRect;
            }
            else
            {
                platformView.Layer.BorderWidth = 0;
                platformView.BorderStyle = UITextBorderStyle.None;
            }
            platformView.Layer.CornerRadius = 4;
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
            entryHandler.PlatformView.Layer.BorderColor = isValid ? UIColor.LightGray.CGColor : validationColor.ToCGColor();
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
