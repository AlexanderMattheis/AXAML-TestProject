namespace TextExtractorGUI.Settings;

/// <summary>
/// Einstellungen der Anwendung mit Default-Werten.
/// </summary>
public sealed class AppSettings
{
    /// <summary>
    /// Sprache der Anwendung.
    /// </summary>
    public string KulturName { get; set; }
    
    /// <summary>
    /// Thema der Anwendung.
    /// </summary>
    public Thema Thema { get; set; }

    /// <summary>
    /// Default-Konstruktor.
    /// </summary>
    public AppSettings()
    {
        KulturName = "de";
        Thema = Thema.Dark;
    }

    /// <summary>
    /// Initialisierungs-Konstruktor.
    /// </summary>
    /// <param name="kulturName">Name der Kultur</param>
    /// <param name="thema">Thema der Anwendung</param>
    public AppSettings(string kulturName, Thema thema)
    {
        KulturName = kulturName;
        Thema = thema;
    }
}