using PizzaAPP.Models;

namespace PizzaAPP
{
    public partial class MainPage : ContentPage
    {
        List<Pizza> pizze = new List<Pizza>();

        public MainPage()
        {
            InitializeComponent();
            pizze.Add(new Pizza("Margherita", 5.99f, "margherita.png", "Pomodoro, mozzarella, basilico"));
            pizze.Add(new Pizza("Pepperoni", 7.99f, "pepperoni.png", "Pomodoro, mozzarella, pepperoni"));
            pizze.Add(new Pizza("Vegetariana", 6.99f, "vegetariana.jpg", "Pomodoro, mozzarella, verdure grigliate"));
            pizze.Add(new Pizza("Hawaiian", 7.49f, "hawaiian.jpg", "Pomodoro, mozzarella, prosciutto cotto, ananas"));
            pickPizza.ItemsSource = pizze;
        }  
        private void OnSelectedIndexChanged(object sender, EventArgs e)
        {
            Pizza selectedPizza = (Pizza)pickPizza.SelectedItem;
        }
    }
}
