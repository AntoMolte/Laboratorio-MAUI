using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppQuiz.Models
{
    internal class OpenQuestion : QuestionBase
    {
        private string _correctAnswer;
        public string CorrectAnswer
        {
            get { return _correctAnswer; }
            set { _correctAnswer = value; }
        }
        public OpenQuestion(string text, int points, string correctAnswer) : base(text, points)
        {
            CorrectAnswer = correctAnswer;
        }
        public override bool CheckAnswer(bool userAnswer)
        {
            throw new NotImplementedException("OpenQuestion does not support boolean answers.");
        }
        public bool CheckAnswer(string userAnswer)
        {
            return string.Equals(userAnswer.Trim(), CorrectAnswer.Trim(), StringComparison.OrdinalIgnoreCase);
        }

    }
}
