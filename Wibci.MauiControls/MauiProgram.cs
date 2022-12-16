using Microsoft.Extensions.Logging;
using Microsoft.Maui.Controls.Compatibility.Hosting;
using Wibci.MauiControls.Controls;

namespace Wibci.MauiControls;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.UseMauiCompatibility() // to be able to use Renderers
			.ConfigureMauiHandlers(handlers =>
			{
				//handlers.AddHandler(typeof(MarkdownTextView), typeof(MarkdownTextViewHandler));
#if ANDROID
				handlers.AddCompatibilityRenderer(typeof(MarkdownTextView), typeof(MarkdownTextViewRenderer));
#endif
			})
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});

#if DEBUG
		builder.Logging.AddDebug();
#endif

		return builder.Build();
	}
}
