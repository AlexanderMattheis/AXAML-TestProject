using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Avalonia.Platform.Storage;

namespace TextExtractorGUI.Services;

/// <summary>
/// Klasse mit Operationen zum Arbeiten mit Dialogen.
/// </summary>
/// <param name="storageProvider">Plattform übergreifende Abstraktion für Datei- und Ordnerzugriff</param>
public sealed class DateiDialogService(IStorageProvider storageProvider)
{
    /// <summary>
    /// Erlaubt die Selektion der index.html-Datei.
    /// </summary>
    /// <returns>Task mit Pfad zur index.html-Datei</returns>
    public async Task<string?> PickIndexHtmlAsync()
    {
        // warte bis Dateiauswahl abgeschlossen ist
        IReadOnlyList<IStorageFile> dateien 
            = await storageProvider.OpenFilePickerAsync(new FilePickerOpenOptions
        {
            Title = "index.html auswählen", // Dialog-Titel
            AllowMultiple = false,          // nur eine Datei selektieren
            FileTypeFilter =                // Filter für Dateitypen
            [
                new FilePickerFileType("HTML") { Patterns = ["*.html"] },   // Filter HTML-Dateien
                FilePickerFileTypes.All                                     // Filter alle Dateitypen
            ]
        });

        // gibt ersten Pfad als String zurück
        return dateien.FirstOrDefault()?.Path.LocalPath;
    }

    /// <summary>
    /// Erlaubt die Selektion des Ausgabepfades für die Markdown-Datei.
    /// </summary>
    /// <param name="dateiname"></param>
    /// <returns>Task mit Pfad zur Ausgabe-Datei</returns>
    public async Task<string?> PickOutputMarkdownAsync(string? dateiname = null)
    {
        // warte bis Dateiauswahl abgeschlossen ist
        IStorageFile? datei = await storageProvider.SaveFilePickerAsync(new FilePickerSaveOptions
        {
            Title = "Markdown-Datei speichern", // Dialog-Titel
            SuggestedFileName = dateiname,      // Dateiname
            FileTypeChoices =
            [
                new FilePickerFileType("Markdown") { Patterns = ["*.md"] }  // Filter HTML-Dateien
            ]
        });
        
        // gibt Pfad als String zurück
        return datei?.Path.LocalPath;
    }
    
}