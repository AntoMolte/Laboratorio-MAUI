namespace AppQuiz;

public partial class ResultPage : ContentPage
{
    private int _score;

    public ResultPage(int currentScore)
    {
        InitializeComponent();
        _score = currentScore;

        ScoreLabel.Text = $"Punteggio: {_score}";
    }

    private async void OnRestartClicked(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }
}
