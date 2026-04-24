using Avalonia.Controls;
using TextExtractorGUI.Services;

namespace TextExtractorGUI.Extensions;

/// <summary>
/// Extension für <see cref="Window"/>.
/// </summary>
public static class WindowExtensions
{
    /// <summary>
    /// Aktiviert das Tracking für das angegebene Fenster.
    /// </summary>
    /// <param name="window">Fenster dessen Aktivität getrackt werden soll</param>
    /// <param name="windowService">Service zum Verwalten des aktiven Fensters</param>
    public static void ActivateTracking(this Window window, IWindowService windowService)
    {
        window.Opened += (_, _) => windowService.SetAktivesFenster(window);
        window.Activated += (_, _) => windowService.SetAktivesFenster(window);
    }
    
}