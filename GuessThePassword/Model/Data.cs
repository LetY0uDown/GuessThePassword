namespace GuessThePassword.Model;

using System.Collections.ObjectModel;

public class Data
{
    public static ObservableCollection<Difficulty> Difficulties { get; set; } = new ObservableCollection<Difficulty>
    {
        new Difficulty { Title = "Easiest", Attempts = 15, PassLenght = 3 },
        new Difficulty { Title = "Easy", Attempts = 20, PassLenght = 4 },
        new Difficulty { Title = "Medium", Attempts = 15, PassLenght = 4 },
        new Difficulty { Title = "Hard", Attempts = 10, PassLenght = 4 },
        new Difficulty { Title = "Extreme 1", Attempts = 1, PassLenght = 3 },
        new Difficulty { Title = "Extreme", Attempts = 1, PassLenght = 4 }
    };

    public static Difficulty CurrentDifficulty { get; set; }
}