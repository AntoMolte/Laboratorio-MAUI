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
            _questions.Add(new TrueFalseQuestion("Il C# è un linguaggio a oggetti.", 10, true));
            _questions.Add(new TrueFalseQuestion("Python è un linguaggio compilato?", 10, false));
            _questions.Add(new OpenQuestion("Qual è la capitale d'Italia?", 10, "Roma"));
            ShowQuestion();
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
                return;
            }
            else if (_questions[_currentIndex].GetType() == typeof(OpenQuestion) && (_questions[_currentIndex] as OpenQuestion).CheckAnswer(userAnswer))
            {
                _score += _questions[_currentIndex].Points;
                await DisplayAlert("Corretto!", "Hai indovinato.", "OK");
            }
            else
            {
                await DisplayAlert("Sbagliato!", "La risposta corretta era: " + (_questions[_currentIndex] as OpenQuestion).CorrectAnswer, "OK");
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
