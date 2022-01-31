namespace GuessThePassword.ViewModel;

using GuessThePassword.Core;
using GuessThePassword.Model;

using System;
using System.Text.RegularExpressions;

public class GameViewModel : ObservableObject
{
    public GameViewModel()
    {
        _password = _random.Next(PassLenght / 10, PassLenght);

        GuessCommand = new RelayCommand(o =>
        {
            if (_passRegex.IsMatch(MainViewModel.GameView.TBoxPassword.Text))
            {
                if (Attempts >= CurrentDifficulty.Attempts)
                {
                    MainViewModel.GameView.LabelAttempts.Content = "Попытки потрачены";
                    Attempts = 0;
                    _password = _random.Next(PassLenght / 10, PassLenght);
                }

                var userPass = Convert.ToInt32(MainViewModel.GameView.TBoxPassword.Text);
                Attempts++;

                if (userPass < _password)
                    MainViewModel.GameView.LabelRes.Content = "Пароль больше";
                else if (userPass > _password)
                    MainViewModel.GameView.LabelRes.Content = "Пароль меньше";

                else if (userPass == _password)
                {
                    MainViewModel.GameView.LabelRes.Content = "Вы угадали!";
                    _password = _random.Next(PassLenght / 10, PassLenght);
                    Attempts = 0;
                }

                MainViewModel.GameView.TBoxPassword.Text = "";
            }
        });
    }
    private Regex _passRegex  = new Regex("^[0-9]{3,4}$");
    private Random _random  = new Random();

    private int _attempts;
    private int _password;

    private int PassLenght
    {
        get => (int)Math.Pow(10, CurrentDifficulty.PassLenght);
    }

    public int Attempts
    {
        get => _attempts;
        set
        {
            _attempts = value;
            OnPropertyChanged();
        }
    }

    public Difficulty CurrentDifficulty
    {
        get => Data.CurrentDifficulty;
    }

    public RelayCommand GuessCommand { get; set; }
}