using Avalonia.Controls;
using Avalonia.Platform.Storage;

namespace TextExtractorGUI.Services;

/// <summary>
/// Interface für Fenster-Zugriff-Services.
/// </summary>
public interface IWindowService
{
    /// <summary>
    /// Setzt das aktive Top-Level-Fenster.
    /// </summary>
    /// <param name="topLevel">Top-Level-Fenster</param>
    void SetAktivesFenster(TopLevel topLevel);

    /// <summary>
    /// Liefert das aktuell aktive TopLevel (oder <c>null</c>).
    /// </summary>
    TopLevel? TryGetTopLevel();

    /// <summary>
    /// Versucht den <see cref="IStorageProvider"/> für das
    /// aktive Top-Level-Fenster zu erhalten.
    /// </summary>
    /// <returns>Instanz eines <see cref="IStorageProvider"/>-Objekts</returns>
    IStorageProvider TryGetStorageProvider();
}
