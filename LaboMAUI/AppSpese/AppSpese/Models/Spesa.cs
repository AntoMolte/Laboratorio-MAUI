using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppSpese.Models
{
    public class Spesa : VoceBase
    {
        private double _importo = 0;
        private int _quantita = 0;

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
        public static List<Spesa> FromRiga(string fileName)
        {
            List<Spesa> voces = new List<Spesa>();

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
            return $"{Descrizione};{Importo.ToString("0.##")};{Quantita}";
        }

        public override string ToString()
        {
            return $"Descrizione: {Descrizione}\n" +
                $"Quantità: {Quantita}\n" +
                $"Importo per unità: {Importo}\n" +
                $"Importo Totale: {Importo * Quantita}\n" +
                $"-------------------------------------\n";
        }
    }
}
