using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppQuiz.Models
{
    public abstract class QuestionBase
    {
        public string Text { get; set; }
        public int Points { get; set; }

        public QuestionBase(string text, int points)
        {
            Text = text;
            Points = points;
        }

        public abstract bool CheckAnswer(object answer);
        public abstract string ToRiga();

        public static QuestionBase? DaRiga(string riga)
        {
            var parts = riga.Split(';');
            if (parts.Length < 4) return null;

            string type = parts[0];
            string text = parts[1];
            if (!int.TryParse(parts[2], out int points)) return null;
            string answer = parts[3];

            if (type == "TF" && bool.TryParse(answer, out bool correct))
                return new TrueFalseQuestion(text, points, correct);

            if (type == "OPEN")
                return new OpenQuestion(text, points, answer);

            return null;
        }
    }
}
