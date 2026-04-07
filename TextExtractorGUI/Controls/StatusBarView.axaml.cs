using Avalonia;
using Avalonia.Controls;

namespace TextExtractorGUI.Controls;

/// <summary>
/// Wiederverwendbare Statusleiste (UserControl) zur Anzeige von Statustext.
/// Die UI (Border/ScrollViewer/TextBlock) ist in <c>StatusBarView.axaml</c> definiert,
/// diese Datei ist der Code-Behind (bindbare Properties + Initialisierung).
/// </summary>
public partial class StatusBarView : UserControl
{
    /// <summary>
    /// Avalonia-<see cref="StyledProperty{TValue}"/> für den Statustext.
    /// - Bindbar und stylbar über XAML.
    /// - <c>string?</c>, damit "kein Status" (null) ebenfalls möglich ist.
    /// </summary>
    public static readonly StyledProperty<string?> StatusTextProperty =
        AvaloniaProperty.Register<StatusBarView, string?>(nameof(StatusText));

    /// <summary>
    /// Konstruktor: initialisiert das Control und lädt das zugehörige XAML
    /// (erstellt die visuellen Elemente und wendet Bindings/Styles an).
    /// </summary>
    public StatusBarView()
    {
        InitializeComponent();
    }
    
    /// <summary>
    /// CLR-Wrapper um <see cref="StatusTextProperty"/>:
    /// ermöglicht bequemes Setzen/Lesen in C# und Bindings in XAML über den Namen <c>StatusText</c>.
    /// </summary>
    public string? StatusText
    {
        get => GetValue(StatusTextProperty);
        set => SetValue(StatusTextProperty, value);
    }
}