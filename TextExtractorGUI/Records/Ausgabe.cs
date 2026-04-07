namespace TextExtractorGUI.Records;

/// <summary>
/// Ausgabe einer Programm-Ausführung.
/// </summary>
/// <param name="rueckgabeWert">Rückgabewert der Programm-Main</param>
/// <param name="text">Text auf der Ausgabe-Konsole</param>
/// <param name="fehler">Text auf der Fehler-Konsole</param>
public record Ausgabe(int rueckgabeWert, string text, string fehler);