namespace TextExtractorGUI.Settings;

/// <summary>
/// Service für Anwendungs-Einstellungen.
/// </summary>
public interface IAppSettingsService
{
    /// <summary>
    /// Zugriff auf die aktuellen Einstellungen.
    /// </summary>
    AppSettings Current { get; }
    
    /// <summary>
    /// Initialisiert mit der jeweiligen Konfiguration.
    /// </summary>
    void Init();

    /// <summary>
    /// Setzt die Kultur der Anwendung basierend auf dem angegebenen Kultur-Namen.
    /// </summary>
    /// <param name="kulturName">Name der zu setzenden Kultur</param>
    void SetKultur(string kulturName);

    /// <summary>
    /// Setzt das Thema der Anwendung.
    /// </summary>
    /// <param name="thema">zu setzendes Thema</param>
    void SetThema(Thema thema);
}