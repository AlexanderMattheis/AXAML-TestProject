using Avalonia;
using Avalonia.Controls;

namespace TextExtractorGUI.Controls;

/// <summary>
/// Wiederverwendbares Header-Control (UserControl) für Titel + Untertitel.
/// Die eigentliche UI-Struktur steht in der zugehörigen <c>HeaderView.axaml</c>,
/// diese Datei ist der Code-Behind (Properties + Initialisierung).
/// </summary>
public partial class HeaderView : UserControl
{
    /// <summary>
    /// Avalonia-<see cref="StyledProperty{TValue}"/> für den Titel (bindbar/stylbar über XAML).
    /// Default: <c>"TextExtractor"</c>.
    /// </summary>
    public static readonly StyledProperty<string?> TitleProperty =
        AvaloniaProperty.Register<HeaderView, string?>(nameof(Title), defaultValue: null);

    /// <summary>
    /// Avalonia-<see cref="StyledProperty{TValue}"/> für den Untertitel (bindbar/stylbar über XAML).
    /// Default: kurzer Hinweistext für den Benutzer.
    /// </summary>
    public static readonly StyledProperty<string?> SubtitleProperty =
        AvaloniaProperty.Register<HeaderView, string?>(nameof(Subtitle), defaultValue: null);
    
    /// <summary>
    /// Konstruktor: initialisiert das Control und lädt das zugehörige XAML
    /// (erstellt die visuellen Elemente und wendet Bindings/Styles an).
    /// </summary>
    public HeaderView()
    {
        InitializeComponent();
    }

    /// <summary>
    /// CLR-Wrapper um <see cref="TitleProperty"/>:
    /// ermöglicht bequemes Setzen/Lesen in C# und Bindings in XAML über den Namen <c>Title</c>.
    /// </summary>
    public string? Title
    {
        get => GetValue(TitleProperty);
        set => SetValue(TitleProperty, value);
    }

    /// <summary>
    /// CLR-Wrapper um <see cref="SubtitleProperty"/>:
    /// ermöglicht bequemes Setzen/Lesen in C# und Bindings in XAML über den Namen <c>Subtitle</c>.
    /// </summary>
    public string? Subtitle
    {
        get => GetValue(SubtitleProperty);
        set => SetValue(SubtitleProperty, value);
    }
    
}