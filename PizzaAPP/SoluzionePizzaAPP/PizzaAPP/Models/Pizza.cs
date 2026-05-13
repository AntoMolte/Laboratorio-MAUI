using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaAPP.Models
{
    public class Pizza
    {
        public string Nome { get; set; } = string.Empty;
        public decimal Prezzo { get; set; }
        public string Ingredienti { get; set; } = string.Empty;
        public string PrezzoFormattato => $"Fr {Prezzo:F2}";
    }
}
