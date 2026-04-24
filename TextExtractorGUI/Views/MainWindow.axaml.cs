using Avalonia.Controls;

namespace TextExtractorGUI.Views;

/// <summary>
/// Code-Behind der Hauptansicht (MainWindow).
/// </summary>
public partial class MainWindow : Window
{
    /// <summary>
    /// Verknüpft das Fenster mit dem zugehörigen ViewModel.
    /// </summary>
    public MainWindow()
    {
        // lädt und initialisiert alle in MainWindow.axaml definierten Controls
        InitializeComponent();

        // DataContext wird zentral in App.axaml.cs gesetzt (Composition Root).
    }       
}