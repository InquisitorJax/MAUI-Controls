using Android.Graphics.Drawables;
using Android.Runtime;
using Android.Views;
using AndroidX.AppCompat.Widget;
using Microsoft.Maui.Controls.Compatibility.Platform.Android;
using Microsoft.Maui.Handlers;
using Microsoft.Maui.Controls.Platform;
using static Android.Views.View;

namespace Wibci.MauiControls.Controls;

public partial class EntryExHandler
{

    private void MapIsValid(IEntryHandler entryHandler, IEntry entry)
    {
        Console.WriteLine("=====> Map IsValid!");

        if (entry is EntryEx entryEx)
        {
            SetBackgroundAttributes(entryHandler.PlatformView, entryEx);
        }
    }

    protected override void ConnectHandler(AppCompatEditText platformView)
    {
        base.ConnectHandler(platformView);
        if (VirtualView is EntryEx entry)
        {
            SetBackgroundAttributes(platformView, entry);
            SetupKeyListener(platformView, entry);
        }
    }

    protected override void DisconnectHandler(AppCompatEditText platformView)
    {
        platformView.SetOnKeyListener(null);
        platformView.Dispose();
        base.DisconnectHandler(platformView);
    }

    private static void SetBackgroundAttributes(AppCompatEditText platformView, EntryEx entry)
    {
        GradientDrawable shape = new();
        shape.SetShape(ShapeType.Rectangle);
        shape.SetCornerRadius(20);

        if (entry.BackgroundColor != null)
        {
            shape.SetColor(entry.BackgroundColor.ToAndroid());
        }

        if (!entry.IsValid)
        {
            shape.SetStroke(3, entry.ValidationColor.ToAndroid());
        }
        else if (entry.HasBorder)
        {
            var borderColor = Colors.Gray;
            shape.SetStroke(3, borderColor.ToAndroid());
        }

        if (entry.HasBorder)
        {
            platformView.SetBackground(shape);
        }
        else
        {
            platformView.Background = null;
        }
    }

    private static void SetupKeyListener(AppCompatEditText platformView, EntryEx entry)
    {
        platformView.SetOnKeyListener(new OnKeyListener(entry));
    }
}

public class OnKeyListener : Java.Lang.Object, IOnKeyListener
{
    private readonly WeakReference<EntryEx> _entry;

    public OnKeyListener(EntryEx entry)
    {
        _entry = new WeakReference<EntryEx>(entry);
    }

    public bool OnKey(Android.Views.View? v, [GeneratedEnum] Keycode keyCode, KeyEvent? e)
    {
        // event fires for both up and down
        if (e?.Action == KeyEventActions.Down)
        {
            var entryKeyCode = KeyCode.Unknown;

            switch (e.KeyCode)
            {
                case Keycode.DpadUp:
                    entryKeyCode = KeyCode.UpArrow;
                    break;
                case Keycode.DpadDown:
                    entryKeyCode = KeyCode.DownArrow;
                    break;
            }

            if (entryKeyCode != KeyCode.Unknown)
            {
                if (_entry.TryGetTarget(out var entry))
                {
                    entry.OnKeyPressed(entryKeyCode, e.KeyCode.ToString());
                }
                return true; // stay on the entry when up or down key pressed
            }
        }

        return false;
    }
}
