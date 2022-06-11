using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace OvceSistem
{
    public class Jagnjenje
    {
        public List<Jagnje> jagnjici = new List<Jagnje>();

        private string path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "/OvceSistem/";

        private string TrenutniFajl()
        {
            StreamReader sr = new StreamReader(path + "Podaci/OsnovniPodaci.txt");
            string[] a = sr.ReadLine().Split('~');
            sr.Close();
            return path + a[1];
        }

        private void PostaviFajl(string k)
        {
            StreamWriter sw = new StreamWriter("Podaci/OsnovniPodaci.txt");
            sw.WriteLine(k);
            sw.Close();
        }

        public void Ucitaj()
        {
            StreamReader sr = new StreamReader(TrenutniFajl());
            jagnjici.Clear();
            while (!sr.EndOfStream)
            {
                jagnjici.Add(new Jagnje(sr.ReadLine()));
            }
            sr.Close();
        }

        public void Sacuvaj()
        {
            StreamWriter sw = new StreamWriter(TrenutniFajl());
            for (int i = 0; i < jagnjici.Count; i++)
            {
                sw.WriteLine(jagnjici[i].StringJagnje());
            }
            sw.Close();
        }

        public static void Sortiraj(List<Jagnje> ovcas, bool opadajuce = true)
        {
            for (int i = 0; i < ovcas.Count - 1; i++)
            {
                for (int j = i + 1; j < ovcas.Count; j++)
                {
                    if (Datum.Uporedi(ovcas[i].datumJagnjenja, ovcas[j].datumJagnjenja) == 1)
                    {
                        Jagnje T = ovcas[i];
                        ovcas[i] = ovcas[j];
                        ovcas[j] = T;
                    }
                }
            }
        }

        public void Obrisi(int k)
        {
            jagnjici.RemoveAt(k);
        }
    }
}
