using TextExtractorGUI.Infrastructure;

namespace TextExtractorGUI.ViewModels.MainWindow;

/// <summary>
/// Properties definiert im ViewModel.
/// </summary>
/// <remarks>
/// Verantwortlich für:
/// - Auswahl der Eingabe-Datei (index.html)
/// - Auswahl des Ausgabe-Pfads (*.md)
/// - Starten der Extraktion und Anzeigen von Status/Fehlern
/// </remarks>
public sealed partial class MainViewModel
{
    /// <summary>
    /// Backing-Feld für <see cref="IndexHtmlPfad"/>.
    /// </summary>
    private string? indexHtmlPfad;

    /// <summary>
    /// Pfad zur ausgewählten index.html (Input).
    /// </summary>
    public string? IndexHtmlPfad
    {
        get => indexHtmlPfad;
        set
        {
            indexHtmlPfad = value;
            OnPropertyChanged();
        }
    }

    /// <summary>
    /// Backing-Feld für <see cref="MarkdownPfad"/>.
    /// </summary>
    private string? markdownPfad;

    /// <summary>
    /// Pfad zur Markdown-Ausgabedatei (Output).
    /// </summary>
    public string? MarkdownPfad
    {
        get => markdownPfad;
        set
        {
            markdownPfad = value;
            OnPropertyChanged();
        }
    }

    /// <summary>
    /// Backing-Feld für <see cref="Status"/>.
    /// </summary>
    private string status = Localization.Instanz["Status_Ready"];

    /// <summary>
    /// Statusmeldung für die UI.
    /// </summary>
    public string Status
    {
        get => status;
        private set
        {
            status = value;
            OnPropertyChanged();
        }
    }

    /// <summary>
    /// Backing-Feld für <see cref="IsBeschaeftigt"/>.
    /// </summary>
    private bool isBeschaeftigt;

    /// <summary>
    /// Beschreibt, ob das Programm gerade eine Extraktion durchführt.
    /// </summary>
    private bool IsBeschaeftigt
    {
        get => isBeschaeftigt;
        set
        {
            isBeschaeftigt = value;
            OnPropertyChanged();

            // Commands informieren, dass sich die CanExecute-Bedingung geändert hat.
            (BrowseIndexHtmlCommand as AsyncCommand)?.RaiseCanExecuteChanged();
            (BrowseMarkdownCommand as AsyncCommand)?.RaiseCanExecuteChanged();
            (StartBerechnungCommand as AsyncCommand)?.RaiseCanExecuteChanged();
            (OpenSettingsCommand as AsyncCommand)?.RaiseCanExecuteChanged();
        }
    }
}