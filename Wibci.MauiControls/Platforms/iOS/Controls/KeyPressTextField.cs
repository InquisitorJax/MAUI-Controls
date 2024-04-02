using CoreGraphics;
using Foundation;
using Microsoft.Maui.Platform;
using UIKit;
using Wibci.MauiControls.Controls;

namespace Wibci.MauiControls.Platforms.iOS.Controls;

public class KeyPressTextField : MauiTextField
{
    // doc: https://www.hackingwithswift.com/example-code/uikit/how-to-detect-keyboard-input-using-pressesbegan-and-pressesended

    public event EventHandler<KeyPressEventArgs>? KeyPressed;

    public KeyPressTextField()
    {
    }

    public KeyPressTextField(CGRect frame) : base(frame)
    {
    }


    public override void PressesBegan(NSSet<UIPress> presses, UIPressesEvent evt)
    {
        base.PressesBegan(presses, evt);
        var pressesList = presses.ToArray().ToList();
        var firstPress = pressesList.FirstOrDefault(k => k.Key != null);

        if (firstPress?.Key != null)
        {
            var keyCode = KeyCode.Unknown;

            switch (firstPress.Key.KeyCode)
            {
                case UIKeyboardHidUsage.KeyboardUpArrow:
                    keyCode = KeyCode.UpArrow;
                    break;
                case UIKeyboardHidUsage.KeyboardDownArrow:
                    keyCode = KeyCode.DownArrow;
                    break;
            }

            if (keyCode != KeyCode.Unknown)
            {
                KeyPressed?.Invoke(this, new KeyPressEventArgs(keyCode, firstPress.Key.Characters));
            }
        }
    }
}