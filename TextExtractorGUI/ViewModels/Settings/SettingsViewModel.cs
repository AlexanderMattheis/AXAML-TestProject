using System.Linq;
using TextExtractorGUI.Infrastructure;
using TextExtractorGUI.Models;
using TextExtractorGUI.Settings;

namespace TextExtractorGUI.ViewModels.Settings;

/// <summary>
/// ViewModel für das Hauptfenster.
/// </summary>
public sealed class SettingsViewModel : ObservableObject
{
    #region Felder
    /// <summary>
    /// Service zum Setzen der Einstellungen.
    /// </summary>
    private readonly IAppSettingsService einstellungenService;

    /// <summary>
    /// Backing-Feld für <see cref="SelektierteSprache"/>.
    /// </summary>
    private Language selektierteSprache;
    
    /// <summary>
    /// Backing-Feld für <see cref="SelektiertesThema"/>.
    /// </summary>
    private Thema selektiertesThema;
    #endregion

    #region Properties
    /// <summary>
    /// Liste der verfügbaren Sprachen.
    /// </summary>
    public Language[] VerfuegbareSprachen { get; }
    
    /// <summary>
    /// Liste der Themen.
    /// </summary>
    public Thema[] VerfuegbareThemes { get; }
    
    /// <summary>
    /// Selektierte Sprache.
    /// </summary>
    public Language SelektierteSprache
    {
        get => selektierteSprache;
        set
        {
            selektierteSprache = value;
            OnPropertyChanged();
            einstellungenService.SetKultur(selektierteSprache.KulturName);
        }
    }
    
    /// <summary>
    /// Selektiertes Thema.
    /// </summary>
    public Thema SelektiertesThema
    {
        get => selektiertesThema;
        set
        {
            selektiertesThema = value;
            OnPropertyChanged();
            einstellungenService.SetThema(selektiertesThema);
        }
    }
    #endregion
    
    /// <summary>
    /// Erstellt eine neue Instanz des <see cref="MainViewModel"/> und initialisiert die Commands.
    /// </summary>
    /// <param name="einstellungenService">Service für Einstellungen</param>
    public SettingsViewModel(IAppSettingsService einstellungenService)
    {
        this.einstellungenService = einstellungenService;

        VerfuegbareSprachen =
        [
            new Language("English", "en"),
            new Language("Deutsch", "de")
        ];

        VerfuegbareThemes = [Thema.System, Thema.Light, Thema.Dark];

        selektierteSprache =
            VerfuegbareSprachen.FirstOrDefault(x => x.KulturName == einstellungenService.Current.KulturName)
            ?? VerfuegbareSprachen.First();

        selektiertesThema = einstellungenService.Current.Thema;
    }
    
}