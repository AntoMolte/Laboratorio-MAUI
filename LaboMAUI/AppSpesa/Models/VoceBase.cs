using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppSpesa.Models
{
    public abstract class VoceBase
    {
        private string _descrizione;

        public string Descrizione
        {
            get { return _descrizione; }
            set { _descrizione = value; }
        }

        public VoceBase()
        {
            
        }

        public abstract string ToRiga();
        public abstract List<VoceBase> FromRiga(string fileName);
    }
}
