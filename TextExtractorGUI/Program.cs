using System;
using Avalonia;

namespace TextExtractorGUI;

/// <summary>
/// Represents the entry point of the application.
/// </summary>
/// <remarks>
/// This class initializes and starts the Avalonia application
/// with a classic desktop lifetime. It configures the application
/// environment and is critical for the overall execution flow.
/// </remarks>
static class Program
{
    // Initialization code. Don't use any Avalonia, third-party APIs or any
    // SynchronizationContext-reliant code before AppMain is called: things aren't initialized
    // yet and stuff might break.
    [STAThread]
    public static void Main(string[] args) => BuildAvaloniaApp()
        .StartWithClassicDesktopLifetime(args);

    // Avalonia configuration, don't remove; also used by visual designer.
    public static AppBuilder BuildAvaloniaApp()
        => AppBuilder.Configure<App>()
            .UsePlatformDetect()
            .WithInterFont()
            .LogToTrace();
}