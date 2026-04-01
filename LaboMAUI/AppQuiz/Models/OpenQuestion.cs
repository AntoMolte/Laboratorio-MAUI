namespace AppQuiz.Models
{
    public class OpenQuestion : QuestionBase
    {
        public string CorrectAnswer { get; set; }

        public OpenQuestion(string text, int points, string correctAnswer)
            : base(text, points)
        {
            CorrectAnswer = correctAnswer;
        }

        public override bool CheckAnswer(object answer)
        {
            if (answer is string s)
                return s.Trim().Equals(CorrectAnswer.Trim(), StringComparison.OrdinalIgnoreCase);
            return false;
        }

        public override string ToRiga()
            => $"OPEN;{Text};{Points};{CorrectAnswer}";
    }
}