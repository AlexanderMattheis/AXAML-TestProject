using System.Threading.Tasks;

namespace TextExtractorGUI.Settings;

/// <summary>
/// Laden und Speichern von Einstellungen.
/// </summary>
public interface ISettingsStore
{
    /// <summary>
    /// Lädt die Einstellungen asynchron.
    /// </summary>
    AppSettings Load();
    
    /// <summary>
    /// Speichert die Einstellungen asynchron.
    /// </summary>
    /// <param name="einstellungen">zu speichernde Einstellungen</param>
    void Save(AppSettings einstellungen);
}