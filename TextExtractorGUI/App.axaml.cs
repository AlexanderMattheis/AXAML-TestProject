using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using TextExtractorGUI.Extensions;
using TextExtractorGUI.Services;
using TextExtractorGUI.Settings;
using TextExtractorGUI.ViewModels.MainWindow;
using TextExtractorGUI.Views;

namespace TextExtractorGUI;

/// <summary>
/// Einstiegspunkt der Anwendung.
/// </summary>
/// <remarks>
/// Diese Klasse verbindet die XAML-Definition (App.axaml) mit dem Laufzeitverhalten.
/// </remarks>
public class App : Application
{
    /// <summary>
    /// Name der Anwendung.
    /// </summary>
    private const string ANWENDUNG_NAME = "TextExtractorGUI";

    /// <summary>
    /// Zugriff auf Fenster.
    /// </summary>
    private readonly IWindowService windowService = new WindowService();

    /// <summary>
    /// Methode aufgerufen zur Initialisierung der Anwendung.
    /// </summary>
    /// <remarks>
    /// Lädt das zugehörige XAML (App.axaml) und wendet definierte Ressourcen/Styles an.
    /// </remarks>
    public override void Initialize()
    {
        // lädt das XAML für diese Application-Instanz (Ressourcen, Styles, ggf. Theme-Definitionen).
        AvaloniaXamlLoader.Load(this);
    }

    /// <summary>
    /// Methode aufgerufen nach der Initialisierung der Anwendung.
    /// </summary>
    /// <remarks>
    /// Hier wird typischerweise das ApplicationLifetime-spezifische Verhalten gesetzt,
    /// z.B. das Hauptfenster bei klassischen Desktop-Apps.
    /// </remarks>
    public override void OnFrameworkInitializationCompleted()
    {
        // wenn: keine Desktop-Applikation
        // dann: breche ab
        if (ApplicationLifetime is not IClassicDesktopStyleApplicationLifetime desktop)
        {
            base.OnFrameworkInitializationCompleted();
            return;
        }
        // sonst: Desktop-Applikation initialisieren
        MainWindow window = CreateMainWindow(InitializeEinstellungen());
        
        window.ActivateTracking(windowService);
        desktop.MainWindow = window;
        base.OnFrameworkInitializationCompleted();
    }

    /// <summary>
    /// Initialisiert die Anwendungseinstellungen.
    /// </summary>
    /// <returns>
    /// Einstellungen-Service
    /// </returns>
    private IAppSettingsService InitializeEinstellungen()
    {
        ISettingsStore einstellungenSpeicher = new JsonSettingsStore(ANWENDUNG_NAME);
        IAppSettingsService einstellungen = new AppSettingsService(einstellungenSpeicher);
        einstellungen.Init();
        return einstellungen;
    }

    /// <summary>
    /// Erstellt das Hauptfenster mit allen erforderlichen Services.
    /// </summary>
    /// <param name="einstellungenService">Service zum Setzen Einstellungen</param>
    /// <returns>
    /// konfiguriertes <see cref="MainWindow"/>
    /// </returns>
    private MainWindow CreateMainWindow(IAppSettingsService einstellungenService)
    {
        IFileDialogService dateiDialogService = new FileDialogService(windowService);
        IAppDialogService appDialogService = new AppDialogService(windowService, einstellungenService);

        // setzt das beim Start aufzurufende Hauptfenster der Anwendung
        return new MainWindow
        {
            DataContext = new MainViewModel(dateiDialogService, appDialogService)
        };
    }
}