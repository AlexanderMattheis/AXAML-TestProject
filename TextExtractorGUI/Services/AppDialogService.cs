using System.Threading.Tasks;
using Avalonia.Controls;
using TextExtractorGUI.Settings;
using TextExtractorGUI.ViewModels.Settings;
using TextExtractorGUI.Views;

namespace TextExtractorGUI.Services;

/// <summary>
/// Service zum Öffnen von Fenstern.
/// </summary>
public sealed class AppDialogService : IAppDialogService
{
    /// <summary>
    /// Service zum Verwalten von Fenstern.
    /// </summary>
    private readonly IWindowService windowService;
    
    /// <summary>
    /// Service zum Verwalten der Anwendungs-Einstellungen.
    /// </summary>
    private readonly IAppSettingsService einstellungenService;

    /// <summary>
    /// Initialisierungs-Konstruktor.
    /// </summary>
    /// <param name="windowService">Service zum Verwalten von Fenstern</param>
    /// <param name="einstellungenService">Service zum Verwalten von Einstellungen</param>
    public AppDialogService(IWindowService windowService, IAppSettingsService einstellungenService)
    {
        this.windowService = windowService;
        this.einstellungenService = einstellungenService;
    }

    /// <summary>
    /// Öffnet das Einstellungs-Fenster.
    /// </summary>
    public async Task OpenEinstellungenAsync()
    {
        // liefert das aktive Top-Level-Fenster
        TopLevel? fenster = windowService.TryGetTopLevel();

        // erstellt das Einstellungs-Fenster mit passenden ViewModel
        SettingsWindow einstellungenFenster = new()
        {
            DataContext = new SettingsViewModel(einstellungenService)
        };

        // wenn: Fenster vom Typ Avalonia-Window
        // dann: zentriere Einstellungs-Fenster am aktiven Top-Level-Fenster
        if (fenster is Window owner)
        {
            einstellungenFenster.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            await einstellungenFenster.ShowDialog(owner); // öffne modal
        }
        // sonst: zentriere Einstellungen-Fenster auf dem Bildschirm
        else
        {
            einstellungenFenster.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            einstellungenFenster.Show(); // nicht-modal
        }
    }
    
}