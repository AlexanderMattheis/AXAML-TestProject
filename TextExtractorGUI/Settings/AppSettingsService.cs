using System;
using Avalonia;
using Avalonia.Styling;
using Avalonia.Threading;
using TextExtractorGUI.Infrastructure;

namespace TextExtractorGUI.Settings;

/// <summary>
/// Service für Anwendungs-Einstellungen.
/// </summary>
public sealed class AppSettingsService : IAppSettingsService
{
    /// <summary>
    /// Store für Einstellungen.
    /// </summary>
    private readonly ISettingsStore store;

    /// <summary>
    /// Speicherung der aktuellen Einstellungen des Programms.
    /// </summary>
    public AppSettings Current { get; private set; } = new();

    /// <summary>
    /// Initialisierungs-Konstruktor.
    /// </summary>
    /// <param name="store">Store für Einstellungen</param>
    public AppSettingsService(ISettingsStore store)
    { 
        this.store = store;
    }

    /// <summary>
    /// Initialisiert mit der jeweiligen Konfiguration.
    /// </summary>
    public void Init()
    {
        Current = store.Load();
        ApplyEinstellungen();
    }
    
    /// <summary>
    /// Wende alle Einstellungen an.
    /// </summary>
    private void ApplyEinstellungen()
    {
        Localization.Instanz.SetKultur(Current.KulturName);
        ApplyThema(Current.Thema);
    }

    /// <summary>
    /// Setzt die Kultur der Anwendung basierend auf dem angegebenen Kultur-Namen.
    /// </summary>
    /// <param name="kulturName">Name der Kultur</param>
    public void SetKultur(string kulturName)
    {
        // wenn: Kultur nicht angegeben ist
        // dann: breche ab
        if (string.IsNullOrWhiteSpace(kulturName))
            return;

        // wenn: Kultur bereits gesetzt ist
        // dann: breche ab
        if (string.Equals(Current.KulturName, kulturName, StringComparison.OrdinalIgnoreCase))
            return;

        // sonst: setze Kultur
        Current.KulturName = kulturName;
        Localization.Instanz.SetKultur(kulturName);

        // speichere in Datei ab
        store.Save(Current);
    }

    /// <summary>
    /// Setzt das Thema der Anwendung.
    /// </summary>
    /// <param name="thema">Thema der Anwendung</param>
    public void SetThema(Thema thema)
    {
        // wenn: Thema bereits gesetzt ist
        // dann: breche ab
        if (Current.Thema == thema)
        {
            return;
        }

        // sonst: setze Thema
        Current.Thema = thema;
        ApplyThema(thema);
        
        // speichere in Datei ab
        store.Save(Current);
    }

    /// <summary>
    /// Wendet das angegebene Thema an.
    /// </summary>
    /// <param name="thema">zu setzendes Thema</param>
    private static void ApplyThema(Thema thema)
    {
        Application? app = Application.Current;
        if (app is null) return;

        // wenn: UI-Thread
        // dann: setze das Thema direkt
        if (Dispatcher.UIThread.CheckAccess())
        {       
            SetThema(app, thema);
        }
        // sonst: setze das Thema im UI-Thread
        else
        {
            Dispatcher.UIThread.Post(() => SetThema(app, thema));
        }
    }

    /// <summary>
    /// Setzt das Thema.
    /// </summary>
    /// <param name="app">Instanz der Anwendung</param>
    /// <param name="thema">zu setzendes Thema</param>
    private static void SetThema(Application app, Thema thema)
    {
        app.RequestedThemeVariant = thema switch
        {
            Thema.Light => ThemeVariant.Light,
            Thema.Dark => ThemeVariant.Dark,
            _ => ThemeVariant.Default
        };
    }
    
}
