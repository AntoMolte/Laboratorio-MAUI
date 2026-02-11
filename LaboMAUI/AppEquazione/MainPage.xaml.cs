namespace AppEquazione
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void btnCalcoloRadici_Clicked(object sender, EventArgs e)
        {
            try
            {
                double a = Convert.ToDouble(EntA.Text);
                double b = Convert.ToDouble(EntB.Text);
                double c = Convert.ToDouble(EntC.Text);
                if (a == 0)
                {
                    DisplayAlert("Attenzione", "Il coefficiente a deve essere diverso da zero.", "OK");
                    return;
                }
                double delta = Math.Pow(b, 2) - 4 * a * c;
                if (delta > 0)
                {
                    double x1 = (-b + Math.Sqrt(delta)) / (2 * a);
                    double x2 = (-b - Math.Sqrt(delta)) / (2 * a);
                    LblRisultato.TextColor = Colors.Green;
                    LblRisultato.Text = "x1 = " + x1 + " e x2 = " + x2;
                }
                else if (delta == 0)
                {
                    double x1 = -b / (2 * a);
                    LblRisultato.TextColor = Colors.Blue;
                    LblRisultato.Text = "x1 = x2 = " + x1;
                }
                else if (delta < 0)
                {
                    LblRisultato.TextColor = Colors.Red;
                    LblRisultato.Text = "Nessuna soluzione reale";
                }
            }
            catch (FormatException fex)
            {
                LblRisultato.TextColor = Colors.Red;
                LblRisultato.Text = "Errore: inserire valori numerici validi.";
            }
        }

    }
}
