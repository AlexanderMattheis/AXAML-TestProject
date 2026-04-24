using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Avalonia.Platform.Storage;
using TextExtractorGUI.Infrastructure.Constants;
using TextExtractorGUI.Ressources;

namespace TextExtractorGUI.Services;

/// <summary>
/// Klasse mit Operationen zum Arbeiten mit Dialogen.
/// </summary>
/// <param name="storageProvider">Plattform übergreifende Abstraktion für Datei- und Ordnerzugriff</param>
public sealed class FileDialogService : IFileDialogService
{
    /// <summary>
    /// Zugriff auf das aktive Top-Level-Fenster.
    /// </summary>
    private readonly IWindowService windowService;

    /// <summary>
    /// Initialisierungs-Konstruktor.
    /// </summary>
    /// <param name="windowService">Zugriff auf aktives Top-Level-Fenster</param>
    /// <exception cref="ArgumentNullException">
    /// Ausnahme sofern Argument <see cref="null"/> war
    /// </exception>
    public FileDialogService(IWindowService windowService)
    {
        this.windowService = windowService;
    }

    /// <summary>
    /// Provider zum Öffnen und Speichern von Dialogen.
    /// </summary>
    /// <exception cref="InvalidOperationException">
    /// Ausnahme sofern kein aktives Top-Level-Fenster vorhanden ist
    /// </exception>
    private IStorageProvider StorageProvider => windowService.TryGetStorageProvider() ;

    /// <inheritdoc cref="IFileDialogService.PickIndexHtmlAsync"/>
    public async Task<string?> PickIndexHtmlAsync()
    {
        // warte bis Dateiauswahl abgeschlossen ist
        IReadOnlyList<IStorageFile> dateien 
            = await StorageProvider
                .OpenFilePickerAsync(new FilePickerOpenOptions
        {
            Title = Strings.Select_IndexHtml,   // Dialog-Titel
            AllowMultiple = false,              // nur eine Datei selektieren
            FileTypeFilter =                    // Filter für Dateitypen
            [
                new FilePickerFileType(FileFormats.HTML)
                {
                    Patterns = [FileEndings.HTML]   // Filter HTML-Dateien
                },   
                FilePickerFileTypes.All             // Filter alle Dateitypen
            ]
        });

        // gibt ersten Pfad als String zurück
        return dateien.FirstOrDefault()?.Path.LocalPath;
    }

    /// <inheritdoc cref="IFileDialogService.PickOutputMarkdownAsync"/>
    public async Task<string?> PickOutputMarkdownAsync(string? dateiname = null)
    {
        // warte bis Dateiauswahl abgeschlossen ist
        IStorageFile? datei = await StorageProvider
            .SaveFilePickerAsync(new FilePickerSaveOptions
        {
            Title = Strings.Select_MarkdownOutputPath,  // Dialog-Titel
            SuggestedFileName = dateiname,              // Dateiname
            FileTypeChoices =
            [
                new FilePickerFileType(FileFormats.MARKDOWN)
                {
                    Patterns = [FileEndings.MARKDOWN]   // Filter Markdown-Dateien
                }  
            ]
        });
        
        // gibt Pfad als String zurück
        return datei?.Path.LocalPath;
    }
    
}