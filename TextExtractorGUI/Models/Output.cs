namespace TextExtractorGUI.Models;

/// <summary>
/// Ausgabe einer Programm-Ausführung.
/// </summary>
/// <param name="RueckgabeWert">Rückgabewert der Programm-Main</param>
/// <param name="Text">Text auf der Ausgabe-Konsole</param>
/// <param name="Fehler">Text auf der Fehler-Konsole</param>
public record Output(int RueckgabeWert, string Text, string Fehler);