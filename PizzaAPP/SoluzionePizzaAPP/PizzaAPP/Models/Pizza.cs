using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaAPP.Models
{
    public class Pizza
    {
        private string _nome;
        private float _prezzo;
        private string _image;
        private string _ingredienti;
        public string Nome
        {
            get { return _nome; }
            set { _nome = value; }
        }

        public float Prezzo
        {
            get { return _prezzo; }
            set { _prezzo = value; }
        }

        public string Image
        {
            get { return _image; }
            set { _image = value; }
        }

        public string Ingredienti
        {
            get { return _ingredienti; }
            set { _ingredienti = value; }
        }

        public Pizza(string nome, float prezzo, string image, string ingredienti)
        {
            _nome = nome;
            _prezzo = prezzo;
            _image = image;
            _ingredienti = ingredienti;
        }
    }
}
