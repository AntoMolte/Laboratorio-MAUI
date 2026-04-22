using AppSpese.Models;
using System.Threading.Tasks;
using Microsoft.Maui.Controls;
using AppSpese.Models;
using System.Threading.Tasks;

namespace AppSpese
{
    public partial class MainPage : ContentPage
    {

        public MainPage()
        {
            InitializeComponent();
            RefreshListe();
        }

        private async void OnSalvaClicked(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(EntNomeLista.Text) ||
                string.IsNullOrEmpty(EntDescrizione.Text) ||
                string.IsNullOrEmpty(EntImporto.Text) ||
                string.IsNullOrEmpty(EntQuantita.Text))
            {
                await DisplayAlert("Errore", "Compilari tutti i campi", "Ok");
            }

            try
            {
                Spesa spesa = new Spesa
                {
                    Descrizione = EntDescrizione.Text,
                    Importo = double.Parse(EntImporto.Text),
                    Quantita = int.Parse(EntQuantita.Text),
                };
                string filePath = $"{Path.Combine(FileSystem.AppDataDirectory, EntNomeLista.Text)}.txt";

                File.AppendAllText(filePath, $"{spesa.ToRiga()}{Environment.NewLine}");
            }
            catch (Exception)
            {
               await DisplayAlert("Errore", "Compilari i campi con i valori corretti", "Ok");
            }

            RefreshListe();
            ClearFields();
            await DisplayAlert("Fatto", "Spesa salvata correttamente", "Ok");
        }

        private async void OnVediClicked(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(EntNomeLista.Text))
            {
                await DisplayAlert("Errore", "inserire nome lista", "Ok");
                return;
            }
             await Navigation.PushAsync(new DettaglioPage(EntNomeLista.Text));
        }      

        private void RefreshListe()
        {
            string[] filePaths = Directory.GetFiles(FileSystem.AppDataDirectory);
            List<string> fileNames = new List<string>();

            foreach (string filePath in filePaths)
            {
                fileNames.Add(Path.GetFileName(filePath));
            }

            EdiListe.Text = string.Join(Environment.NewLine, fileNames);
        }

        private void ClearFields()
        {
            EntDescrizione.Text = string.Empty;
            EntImporto.Text = string.Empty;
            EntQuantita.Text = string.Empty;
        }
    }
}
