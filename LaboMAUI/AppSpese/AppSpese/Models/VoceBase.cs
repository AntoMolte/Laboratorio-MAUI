using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppSpese.Models
{
    public abstract class VoceBase
    {
        private string _descrizione = string.Empty;

        public string Descrizione
        {
            get { return _descrizione; }
            set {_descrizione = value;}
        }

        public abstract string ToRiga(); 
    }
}
