namespace GuessThePassword.ViewModel;

using GuessThePassword.Core;
using GuessThePassword.View;
using System.Windows;

public class MainViewModel : ObservableObject
{
    public MainViewModel()
    {
        OptionsView = new OptionsView();
        GameView = new GameView();

        CurrentView = GameView;

        ExitCommand = new RelayCommand(o => 
            Application.Current.Shutdown());

        MinimizeCommand = new RelayCommand(o =>
            Application.Current.MainWindow.WindowState = WindowState.Minimized);

        ChangeViewCommand = new RelayCommand(o => 
            CurrentView = CurrentView == GameView ? OptionsView : GameView);
    }
    private object? _currentView;

    public static OptionsView? OptionsView { get; set; }
    public static GameView? GameView { get; set; }

    public RelayCommand ExitCommand { get; set; }
    public RelayCommand MinimizeCommand { get; set; }

    public RelayCommand ChangeViewCommand { get; set; }

    public object CurrentView
    {
        get => _currentView; 
        set 
        { 
            _currentView = value;
            OnPropertyChanged();
        }
    }
}