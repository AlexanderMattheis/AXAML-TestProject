using Avalonia.Controls;
using Avalonia.Platform.Storage;

namespace TextExtractorGUI.Services;

/// <summary>
/// Zugriff auf Fenster.
/// </summary>
public sealed class WindowService : IWindowService
{
    /// <summary>
    /// Top-Level Fenster der Anwendung.
    /// </summary>
    private TopLevel aktivesFenster = null!;
    
    /// <inheritdoc cref="IWindowService.SetAktivesFenster" />
    public void SetAktivesFenster(TopLevel topLevel)
    { 
        aktivesFenster = topLevel;
    }

    /// <inheritdoc cref="IWindowService.TryGetTopLevel" />
    public TopLevel TryGetTopLevel() => aktivesFenster;

    /// <inheritdoc cref="IWindowService.TryGetStorageProvider" />
    public IStorageProvider TryGetStorageProvider() => aktivesFenster.StorageProvider;
}