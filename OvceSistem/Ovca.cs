using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OvceSistem
{
    public class Ovca
    {
        public string ime, idBroj, tetovirBroj;
        public int pol;
        public Datum datumRodjenja;
        
        public Ovca(string S)
        {
            string[] s = S.Split('~');
            idBroj = s[0];
            tetovirBroj = s[1];
            ime = s[2].ToUpper();
            pol = int.Parse(s[3]);
            datumRodjenja = new Datum(s[4]);
        }
        public Ovca(string id, string tetovir, string Ime, int Pol, Datum datum)
        {
            idBroj = id;
            tetovirBroj = tetovir;
            ime = Ime;
            pol = Pol;
            datumRodjenja = datum;
        }

        public string StringOvca() { return idBroj + "~" + tetovirBroj + "~" + ime + "~" + pol + "~" + datumRodjenja.StringDatum(); }

        public static List<Ovca> Pretraga(List<Ovca> ovcas, string kljuc)
        {
            List<Ovca> ovcas1 = new List<Ovca>();

            for(int i = 0; i<ovcas.Count; i++)
            {
                if (ovcas[i].idBroj.Contains(kljuc) || ovcas[i].tetovirBroj.Contains(kljuc) || ovcas[i].ime.Contains(kljuc))
                    ovcas1.Add(ovcas[i]);
            }

            return ovcas1;
        }

        public static List<Ovca> Pretraga(List<Ovca> ovcas, string kljuc, int pol)
        {
            List<Ovca> ovcas1 = new List<Ovca>();

            for (int i = 0; i < ovcas.Count; i++)
            {
                if(ovcas[i].pol == pol)
                    if (ovcas[i].idBroj.Contains(kljuc) || ovcas[i].tetovirBroj.Contains(kljuc) || ovcas[i].ime.Contains(kljuc))
                        ovcas1.Add(ovcas[i]);
            }

            return ovcas1;
        }

    }
}
