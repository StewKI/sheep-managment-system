using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace OvceSistem
{
    public class Upravljanje
    {
        public List<Ovca> ovce = new List<Ovca>();

        private string path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "/OvceSistem/";

        private string TrenutniFajl()
        {
            StreamReader sr = new StreamReader(path + "Podaci/OsnovniPodaci.txt");
            string[] a = sr.ReadLine().Split('~');
            sr.Close();
            return path + a[0];
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
            ovce.Clear();
            while (!sr.EndOfStream)
            {
                ovce.Add(new Ovca(sr.ReadLine()));
            }
            sr.Close();
        }

        public void Sacuvaj()
        {
            StreamWriter sw = new StreamWriter(TrenutniFajl());
            for(int i = 0; i<ovce.Count; i++)
            {
                sw.WriteLine(ovce[i].StringOvca());
            }
            sw.Close();
        }

        public static void Sortiraj(List<Ovca> ovcas, bool opadajuce = true)
        {
            for (int i = 0; i < ovcas.Count - 1; i++)
            {
                for (int j = i + 1; j < ovcas.Count; j++)
                {
                    if (Datum.Uporedi(ovcas[i].datumRodjenja, ovcas[j].datumRodjenja) == 1)
                    {
                        Ovca T = ovcas[i];
                        ovcas[i] = ovcas[j];
                        ovcas[j] = T;
                    }
                }
            }
        }

        public void Dodaj(Ovca ovca)
        {
            ovce.Add(ovca);

            Sortiraj(ovce);
        }

        public void Izbaci(int k)
        {
            ovce.RemoveAt(k);
        }
    }
}
