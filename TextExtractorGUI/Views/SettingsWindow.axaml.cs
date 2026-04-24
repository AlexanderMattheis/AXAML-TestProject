using Avalonia.Controls;
using Avalonia.Interactivity;

namespace TextExtractorGUI.Views;

/// <summary>
/// Code-Behind der Hauptansicht (MainWindow).
/// </summary>
public partial class SettingsWindow : Window
{
    /// <summary>
    /// Verknüpft das Fenster mit dem zugehörigen ViewModel.
    /// </summary>
    public SettingsWindow()
    {
        // lädt und initialisiert alle in MainWindow.axaml definierten Controls
        InitializeComponent();

        // DataContext wird zentral in App.axaml.cs gesetzt (Composition Root).
    }      
    
    private void Close_OnClick(object? sender, RoutedEventArgs e)
    {
        Close();
    }

}