namespace AppConvertitore
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        public MainPage()
        {
            //Inizializza i componenti grafici
            InitializeComponent();
        }

        private void btnConverti_Clicked(object sender, EventArgs e)
        {
            string valoreImporto = entConversione.Text;
            try
            {
                double franchi = Convert.ToDouble(valoreImporto);
                double euro = franchi * 1.07;
                lblRisultato.Text = "Euro: " + euro;
            }
            catch (ArgumentNullException aex)
            {
                lblRisultato.TextColor = Colors.Red;
                lblRisultato.Text = "Errore nesssun valore";
            }
            catch (FormatException fex)
            {
                lblRisultato.TextColor = Colors.Red;
                lblRisultato.Text = "Errore valore non valido";
            }
            catch(OverflowException oex)
            {
                lblRisultato.TextColor = Colors.Red;
                lblRisultato.Text = "Errore valore troppo alto";
            }

        }

        private void btnReset_Clicked(object sender, EventArgs e)
        {
            entConversione.Text = "";
            lblRisultato.Text = "Pronto per convertire";
            lblRisultato.TextColor = Colors.Black;
            entConversione.Focus();
        }
    }

}
