using AppQuiz.Models;
using System.Runtime.CompilerServices;

namespace AppQuiz
{
    public partial class MainPage : ContentPage
    {
        private List<QuestionBase> _questions = new List<QuestionBase>();
        private int _currentIndex = 0;
        private int _score = 0;

        public MainPage()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            if (_questions.Count == 0)
            {
                await LoadQuestions();
                ShowQuestion();
            }
        }

        private async Task LoadQuestions()
        {
            using var stream = await FileSystem.OpenAppPackageFileAsync("domande.txt");
            using var reader = new StreamReader(stream);

            while (!reader.EndOfStream)
            {
                string line = await reader.ReadLineAsync();

                if (string.IsNullOrWhiteSpace(line))
                    continue;

                string[] parts = line.Split(';');

                string type = parts[0];
                string text = parts[1];
                int points = int.Parse(parts[2]);
                string answer = parts[3];

                if (type == "TF")
                {
                    bool correct = bool.Parse(answer);

                    _questions.Add(
                        new TrueFalseQuestion(text, points, correct)
                    );
                }
                else if (type == "OPEN")
                {
                    _questions.Add(
                        new OpenQuestion(text, points, answer)
                    );
                }
            }
        }

        private void ShowQuestion()
        {
            if (_currentIndex < _questions.Count)
            {
                QuestionBase current = _questions[_currentIndex];

                if (current.GetType() == typeof(OpenQuestion))
                {
                    TrueButton.IsVisible = false;
                    FalseButton.IsVisible = false;
                    OpenAnswerEntry.IsVisible = true;
                    SubmitOpenAnswerButton.IsVisible = true;
                }
                else
                {
                    TrueButton.IsVisible = true;
                    FalseButton.IsVisible = true;
                    OpenAnswerEntry.IsVisible = false;
                    SubmitOpenAnswerButton.IsVisible = false;
                }

                QuestionTextLabel.Text = current.Text;
                ScoreLabel.Text = $"Punteggio: {_score}";
            }
            else
            {
                OnQuizFinished();
                QuestionTextLabel.Text = $"Quiz completato! Punteggio finale: {_score}";
                TrueButton.IsVisible = false;
                FalseButton.IsVisible = false;
                OpenAnswerEntry.IsVisible = false;
                SubmitOpenAnswerButton.IsVisible = false;
            }
        }

        private async void OnOpenAnswerClicked(object sender, EventArgs e)
        {
            string userAnswer = OpenAnswerEntry.Text;
            if (string.IsNullOrEmpty(userAnswer))
            {
                await DisplayAlert("Errore", "Per favore inserisci una risposta.", "OK");
                OpenAnswerEntry.Text = string.Empty;
                return;
            }
            else if (_questions[_currentIndex].GetType() == typeof(OpenQuestion) && (_questions[_currentIndex] as OpenQuestion).CheckAnswer(userAnswer))
            {
                _score += _questions[_currentIndex].Points;
                await DisplayAlert("Corretto!", "Hai indovinato.", "OK");
                OpenAnswerEntry.Text = string.Empty;
            }
            else
            {
                await DisplayAlert("Sbagliato!", "La risposta corretta era: " + (_questions[_currentIndex] as OpenQuestion).CorrectAnswer, "OK");
                OpenAnswerEntry.Text = string.Empty;
            }
            _currentIndex++;
            ShowQuestion();
        }
        private async void OnAnswerClicked(object sender, EventArgs e)
        {
            var btn = (Button)sender;
            bool userAnswer = bool.Parse(btn.CommandParameter.ToString());
            if (_questions[_currentIndex].CheckAnswer(userAnswer))
            {
                _score += _questions[_currentIndex].Points;
                await DisplayAlert("Corretto!", "Hai indovinato.", "OK");
            }
            else
            {
                await DisplayAlert("Sbagliato!", "La risposta corretta era: " + (_questions[_currentIndex] as TrueFalseQuestion).CorrectAnswer, "OK");
            }
            _currentIndex++;
            ShowQuestion();
        }

        private void btnResult_Clicked(object sender, EventArgs e)
        {
            OnQuizFinished();
        }
        private async void OnQuizFinished()
        {
            await Navigation.PushAsync(new ResultPage(_score));
        }

        private void btnScore_Clicked(object sender, EventArgs e)
        {
            OnQuizFinished();
        }

    }
}

