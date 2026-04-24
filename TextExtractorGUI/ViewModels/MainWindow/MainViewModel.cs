using TextExtractorGUI.Infrastructure
;
using TextExtractorGUI.Services;

namespace TextExtractorGUI.ViewModels.MainWindow;

/// <summary>
/// ViewModel für das Hauptfenster.
/// </summary>
/// <remarks>
/// Verantwortlich für das Bereitstellen von Commands
/// (z. B. Datei-Auswahl und Starten der Verarbeitung),
/// die anschließend von der View (MainWindow) gebunden und ausgelöst werden.
/// </remarks>
public sealed partial class MainViewModel : ObservableObject
{
    /// <summary>
    /// Initialisierungs-Konstruktor.
    /// </summary>
    /// <param name="dateiDialogService">Service zum Öffnen von Datei-Dialogen</param>
    /// <param name="appDialogService">Service zum Öffnen App-Dialogen</param>
    public MainViewModel(IFileDialogService dateiDialogService, IAppDialogService appDialogService)
    {
        // Command zum Auswählen einer index.html (oder vergleichbaren HTML-Eingabedatei).
        // Benötigt den Dialog-Service, um dem Benutzer einen Dateiauswahldialog anzuzeigen.
        BrowseIndexHtmlCommand = CreateBrowseIndexHtmlCommand(dateiDialogService);

        // Command zum Auswählen einer Markdown-Zieldatei/-quelle (je nach Anwendungslogik).
        // Benötigt den Dialog-Service, um dem Benutzer einen Dateiauswahldialog anzuzeigen.
        BrowseMarkdownCommand = CreateBrowseMarkdownCommand(dateiDialogService);

        // Command zum Starten der eigentlichen Berechnung/Verarbeitung.
        // Benötigt hier keinen Dialog-Service, da die Arbeit auf bereits ausgewählten Pfaden/Daten basiert.
        StartBerechnungCommand = CreateStartBerechnungCommand();
        
        OpenSettingsCommand = CreateOpenEinstellungenCommand(appDialogService);
    }
}