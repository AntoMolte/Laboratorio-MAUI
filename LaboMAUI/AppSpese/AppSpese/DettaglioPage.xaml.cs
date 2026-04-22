using AppSpese.Models;

namespace AppSpese;

public partial class DettaglioPage : ContentPage
{
    private string nameList = string.Empty;
    public DettaglioPage(string listaName)
    {
        nameList = listaName;
        InitializeComponent();
        ReadLista();
    }

    private async void OnBackClicked(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }

    private void ReadLista()
    {
        List<Spesa> spesaList = Spesa.FromRiga($"{nameList}.txt");
        spesaList.ForEach(item => EdiListaSpesa.Text += item.ToString());
        /*
        foreach (Spesa spesa in spesaList)
        {
            EdiListaSpesa.Text += spesa.ToString();
        }
        */

        EdiListaSpesa.Text += $"Totale Spesa:{spesaList.Sum(item => item.Quantita * item.Importo)}";
        /*
        double totaleSpesa = 0;
        foreach(Spesa spesa in spesaList)
        {
            totaleSpesa += spesa.Quantita * spesa.Importo;
        }
        EdiListaSpesa.Text += $"Totale Spesa:{totaleSpesa};
        */
    }
}