namespace AppQuiz.Models
{
    public class TrueFalseQuestion : QuestionBase
    {
        public bool CorrectAnswer { get; set; }

        public TrueFalseQuestion(string text, int points, bool correctAnswer)
            : base(text, points)
        {
            CorrectAnswer = correctAnswer;
        }

        public override bool CheckAnswer(object answer)
        {
            if (answer is bool b) return b == CorrectAnswer;
            return false;
        }

        public override string ToRiga()
            => $"TF;{Text};{Points};{CorrectAnswer}";
    }
}