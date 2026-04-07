using Avalonia.Controls;
using TextExtractorGUI.Services;
using TextExtractorGUI.ViewModels;
using MainWindowViewModel = TextExtractorGUI.ViewModels.MainWindow.MainWindowViewModel;

namespace TextExtractorGUI;

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

        // setzt den DataContext für MVVM-Datenbindungen in der View (Bindings in XAML)
        DataContext = new MainWindowViewModel(new DateiDialogService(StorageProvider));
    }
}