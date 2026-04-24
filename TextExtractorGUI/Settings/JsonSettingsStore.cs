using System;
using System.IO;
using System.Text.Json;

namespace TextExtractorGUI.Settings;

/// <summary>
/// Verwaltet das Laden und Speichern von Einstellungen im JSON-Format.
/// </summary>
public sealed class JsonSettingsStore : ISettingsStore
{
    /// <summary>
    /// Name der Einstellungs-Datei.
    /// </summary>
    private const string EINSTELLUNGEN_DATEI = "settings.json";
    
    /// <summary>
    /// Pfad zur Einstellungsdatei.
    /// </summary>
    private readonly string dateipfad;

    /// <summary>
    /// Initialisierungs-Konstruktor.
    /// </summary>
    /// <param name="appName">Name der App</param>
    public JsonSettingsStore(string appName)
    {
        // speichert unter Roaming unter Windows bzw. in Linux unter ~/.config
        string wurzel = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
        string ordner = Path.Combine(wurzel, appName); // bildet Pfad mit App-Namen
        Directory.CreateDirectory(ordner); // erstellt Ordner mit App-Namen

        dateipfad = Path.Combine(ordner, EINSTELLUNGEN_DATEI);
    }

    /// <summary>
    /// Lädt die Einstellungen aus der Datei.
    /// </summary>
    /// <returns>
    /// Einstellungen der Anwendung
    /// </returns>
    public AppSettings Load()
    {
        // wenn: Dateipfad nicht vorhanden
        // dann: gebe Default-Einstellungen zurück
        if (!File.Exists(dateipfad)) return new AppSettings();

        try
        {
            // liest und deserialisiert JSON-Text
            string jsonText = File.ReadAllText(dateipfad);
            return JsonSerializer.Deserialize<AppSettings>(jsonText) ?? new AppSettings();
        }
        catch // im Fehlerfall immer Default ausgeben
        {
            return new AppSettings();
        }
    }

    /// <summary>
    /// Speichert die Einstellungen in der Datei.
    /// </summary>
    /// <param name="einstellungen">Einstellungen, welche serialisiert und gespeichert werden sollen</param>
    public void Save(AppSettings einstellungen)
    {
        // serialisiere und schreibe JSON-Text
        JsonSerializerOptions options = new()
        {
            WriteIndented = true
        };
        
        // serialisert den JSON-Text und speichert ihn in einer Datei
        string jsonText = JsonSerializer.Serialize(einstellungen, options);
        File.WriteAllText(dateipfad, jsonText);
    }
    
}