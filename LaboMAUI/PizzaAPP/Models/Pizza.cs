using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaAPP.Models
{
    internal class Pizza
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

        private string Ingredienti 
        { 
            get { return _ingredienti; }
            set { _ingredienti = value; }
        }
    }
        
}
