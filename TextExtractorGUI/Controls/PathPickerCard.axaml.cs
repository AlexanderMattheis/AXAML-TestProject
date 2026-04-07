using System.Windows.Input;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Data;

namespace TextExtractorGUI.Controls;

/// <summary>
/// Wiederverwendbares Card-/Form-Control zur Pfadauswahl (Header + Textfeld + Button).
/// Die visuelle Struktur und das Layout stehen in <c>PathPickerCard.axaml</c>,
/// diese Datei ist der Code-Behind (StyledProperties + Initialisierung).
/// </summary>
public partial class PathPickerCard : UserControl
{
    /// <summary>
    /// Avalonia-<see cref="StyledProperty{TValue}"/> für die Überschrift der Card
    /// (bindbar/stylbar über XAML).
    /// </summary>
    public static readonly StyledProperty<string?> HeaderProperty =
        AvaloniaProperty.Register<PathPickerCard, string?>(nameof(Header));

    /// <summary>
    /// Avalonia-<see cref="StyledProperty{TValue}"/> für den Pfad-/Textfeld-Inhalt.
    /// Default-Binding: TwoWay, damit Änderungen aus UI und ViewModel synchron bleiben.
    /// </summary>
    public static readonly StyledProperty<string?> PathProperty =
        AvaloniaProperty.Register<PathPickerCard, string?>(nameof(Path), defaultBindingMode: BindingMode.TwoWay);

    /// <summary>
    /// Avalonia-<see cref="StyledProperty{TValue}"/> für den Watermark-/Placeholder-Text
    /// im Eingabefeld (Anzeige, wenn der Pfad leer ist).
    /// </summary>
    public static readonly StyledProperty<string?> WatermarkProperty =
        AvaloniaProperty.Register<PathPickerCard, string?>(nameof(Watermark));

    /// <summary>
    /// Avalonia-<see cref="StyledProperty{TValue}"/> für den Button-Text.
    /// </summary>
    public static readonly StyledProperty<string?> ButtonTextProperty =
        AvaloniaProperty.Register<PathPickerCard, string?>(nameof(ButtonText));

    /// <summary>
    /// Avalonia-<see cref="StyledProperty{TValue}"/> für das auszuführende Command,
    /// das i. d. R. an den Button gebunden wird.
    /// </summary>
    public static readonly StyledProperty<ICommand?> ButtonCommandProperty =
        AvaloniaProperty.Register<PathPickerCard, ICommand?>(nameof(ButtonCommand));

    /// <summary>
    /// Konstruktor: initialisiert das Control und lädt das zugehörige XAML
    /// (erstellt die visuellen Elemente und wendet Bindings/Styles an).
    /// </summary>
    public PathPickerCard()
    {
        InitializeComponent();
    }
    
    /// <summary>
    /// CLR-Wrapper um <see cref="HeaderProperty"/>:
    /// ermöglicht bequemes Setzen/Lesen in C# und Bindings in XAML über <c>Header</c>.
    /// </summary>
    public string? Header
    {
        get => GetValue(HeaderProperty);
        set => SetValue(HeaderProperty, value);
    }

    /// <summary>
    /// CLR-Wrapper um <see cref="PathProperty"/>:
    /// bindbarer Pfad-/Textfeldwert (standardmäßig TwoWay).
    /// </summary>
    public string? Path
    {
        get => GetValue(PathProperty);
        set => SetValue(PathProperty, value);
    }

    /// <summary>
    /// CLR-Wrapper um <see cref="WatermarkProperty"/>:
    /// Placeholder-Text für das Eingabefeld.
    /// </summary>
    public string? Watermark
    {
        get => GetValue(WatermarkProperty);
        set => SetValue(WatermarkProperty, value);
    }

    /// <summary>
    /// CLR-Wrapper um <see cref="ButtonTextProperty"/>:
    /// Text, der im Button angezeigt wird.
    /// </summary>
    public string? ButtonText
    {
        get => GetValue(ButtonTextProperty);
        set => SetValue(ButtonTextProperty, value);
    }

    /// <summary>
    /// CLR-Wrapper um <see cref="ButtonCommandProperty"/>:
    /// Command, das beim Klick (oder entsprechender Interaktion) ausgeführt werden soll.
    /// </summary>
    public ICommand? ButtonCommand
    {
        get => GetValue(ButtonCommandProperty);
        set => SetValue(ButtonCommandProperty, value);
    }
}