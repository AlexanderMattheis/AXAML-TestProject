using System.Threading.Tasks;

namespace TextExtractorGUI.Services;

/// <summary>
/// Service für das Öffnen von Dialogen.
/// </summary>
public interface IAppDialogService
{
    /// <summary>
    /// Öffnet das Einstellungs-Fenster.
    /// </summary>
    Task OpenEinstellungenAsync();
}