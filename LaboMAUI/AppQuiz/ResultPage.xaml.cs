

namespace AppQuiz;

public partial class ResultPage : ContentPage
{
    private int _score;

    public ResultPage(int score)
    {
        _score = score;
        InitializeComponent();
        ShowGui();
    }

    private string _filePath = Path.Combine(
        FileSystem.AppDataDirectory, "bestscore.txt");

    private void SaveBestScore(string name, int score)
    {
        var best = LoadBestScore();

        if (score > best.score)
        {
            try
            {
                string today = DateTime.Now.ToString("yyyy-MM-dd");
                string line = $"{name};{score};{today}";

                File.WriteAllText(_filePath, line);

            }
            catch (Exception e)
            {
                DisplayAlert("Errore", "Impossibile salvare: " + e.Message, "OK");
            }
        }
    }

    private (string name, int score, string date) LoadBestScore()
    {
        if (!File.Exists(_filePath))
            return ("Nessuno", 0, "-");

        try
        {
            string content = File.ReadAllText(_filePath);
            string[] parts = content.Split(';');

            if (parts.Length == 3)
            {
                string name = parts[0];
                int score = int.Parse(parts[1]);
                string date = parts[2];

                return (name, score, date);
            }
        }
        catch
        {
            DisplayAlert("Errore", "Il file potrebbe essere corrotto, non esistente o con valori sbagliati", "OK");
        }

        return ("Errore", 0, "-");
    }

    private async void OnSave_Clicked(object sender, EventArgs e)
    {
        string name = NameEntry.Text;

        if (string.IsNullOrWhiteSpace(name))
        {
            await DisplayAlert("Errore", "Inserisci un nome valido", "OK");
            return;
        }

        SaveBestScore(name, _score);

        ShowGui();
    }

    private void ShowGui()
    {
        ScoreLabel.Text = "Hai fatto: " + _score.ToString();
        var best = LoadBestScore();
        LblBestScore.Text = $"{best.name} - {best.score} punti ({best.date})";    
    }

    private async void OnRestart_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new MainPage());
    }
}
