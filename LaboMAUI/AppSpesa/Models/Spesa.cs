using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppSpesa.Models
{
    public class Spesa : VoceBase
    {
        private double _importo;
        private int _quantita;

        public double Importo
        {
            get { return _importo; }
            set { _importo = value; }
        }
        public int Quantita
        {             
            get { return _quantita; }
            set { _quantita = value; }
        }
        public override List<VoceBase> FromRiga(string fileName)
        {
            List<VoceBase> voces = new List<VoceBase>();
            try
            {
                string filePath = Path.Combine(FileSystem.AppDataDirectory, fileName);
                if (File.Exists(filePath))
                {
                    string[] lines = File.ReadAllLines(filePath);
                    
                    foreach (string l in lines)
                    {
                        voces.Add(new Spesa
                        {
                            Descrizione = l.Split(';')[0],
                            Importo = double.Parse(l.Split(';')[1]),
                            Quantita = int.Parse(l.Split(';')[2])
                        });
                    }
                    return voces;
                }
            }
            catch (Exception)
            {
                throw;
            }
            return voces;
        }

        public override string ToRiga()
        {
            return $"{Descrizione};{Importo};{Quantita}";
        }
    }
}
