namespace GuessThePassword.ViewModel;

using GuessThePassword.Core;
using GuessThePassword.Model;

public class OptionsViewModel : ObservableObject
{
    public OptionsViewModel()
    {
        CurrentDifficulty = Data.CurrentDifficulty = Data.Difficulties[0];

        NextDiffCommand = new RelayCommand(o =>
        {
            Index++;
            CurrentDifficulty = Data.Difficulties[Index];
        });

        PrevDiffCommand = new RelayCommand(o =>
        {
            Index--;
            CurrentDifficulty = Data.Difficulties[Index];
        });

        SelectDiffCommand = new RelayCommand(o =>
        {
            System.Windows.MessageBox.Show("fsdfsd");
        });
    }
    private int _index;
    private Difficulty _currentDifficulty;

    public RelayCommand NextDiffCommand { get; set; }
    public RelayCommand PrevDiffCommand { get; set; }

    public RelayCommand SelectDiffCommand { get; set; }

    public int Index
    {
        get => _index;
        set
        {
            if (value > Data.Difficulties.Count - 1)
                _index = 0;

            else if (value < 0)
                _index = Data.Difficulties.Count - 1;

            else
                _index = value;
        }
    }
    
    public Difficulty CurrentDifficulty
    {
        get => _currentDifficulty;
        set
        {
            _currentDifficulty = value;
            OnPropertyChanged();
        }
    }
}