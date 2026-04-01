using AppSpesa.Models; // Aggiungere questa direttiva using per il namespace corretto

namespace AppSpesa
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        public MainPage()
        {
            InitializeComponent();
        }

        private void OnSalvaClicked(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(EntNomeLista.Text) || string.IsNullOrEmpty(EntDescrizione.Text) || string.IsNullOrEmpty(EntImporto.Text) || string.IsNullOrEmpty(EntQuantita.Text))
            {
                DisplayAlert("Attenzione", "Compilare tutti i campi", "OK");
                return; // Interrompe l'esecuzione se i campi non sono compilati
            }
            try
            {
                Spesa spesa = new Spesa
                {
                    Descrizione = EntDescrizione.Text,
                    Importo = double.Parse(EntImporto.Text),
                    Quantita = int.Parse(EntQuantita.Text)
                };
                string filePath = Path.Combine(FileSystem.AppDataDirectory, $"{EntNomeLista.Text}.txt");
                File.AppendAllText(filePath, spesa.ToRiga() + Environment.NewLine);
            }
            catch (Exception ex)
            {
                DisplayAlert("Errore", $"Si è verificato un errore: {ex.Message}", "OK");
            }
        }

        private async Task onVediClicked(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(EntNomeLista.Text))
            {
                await DisplayAlert("Attenzione", "Inserire il nome della lista da visualizzare", "OK");
                return; // Interrompe l'esecuzione se il campo del nome della lista non è compilato
            }
            try
            {
                Spesa spesa = new Spesa();
                List<VoceBase> voci = spesa.FromRiga($"{EntNomeLista.Text}.txt");
                string messaggio = string.Join(Environment.NewLine, voci.Select(v => v.ToRiga()));
                await DisplayAlert("Contenuto della lista", messaggio, "OK");
            }
            catch (Exception ex)
            {
                await DisplayAlert("Errore", $"Si è verificato un errore: {ex.Message}", "OK");
            }
        }
    }
}
