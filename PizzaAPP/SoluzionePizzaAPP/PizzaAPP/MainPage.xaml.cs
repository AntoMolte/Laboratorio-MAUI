using PizzaAPP.Models;

namespace PizzaAPP
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            await CaricaPizze();     // delega la logica di lettura a un metodo separato
        }
        private async Task CaricaPizze()
        {
            var pizze = new List<Pizza>();
            using var stream = await FileSystem.OpenAppPackageFileAsync("pizze.txt");
            using var reader = new StreamReader(stream);
            while (!reader.EndOfStream)
            {
                var riga = await reader.ReadLineAsync();
                if (string.IsNullOrWhiteSpace(riga)) continue;

                var parti = riga.Split('|');
                if (parti.Length < 3) continue;

                pizze.Add(new Pizza
                {
                    Nome = parti[0].Trim(),
                    Prezzo = decimal.Parse(parti[1].Trim(),
                                  System.Globalization.CultureInfo.InvariantCulture),
                    Ingredienti = parti[2].Trim()
                });
            }
            PizzeList.ItemsSource = pizze;
        }


    }
}
