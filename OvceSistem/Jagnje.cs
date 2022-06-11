using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OvceSistem
{
    public class Jagnje
    {
        public Ovca majka, otac;
        public Datum datumJagnjenja;
        public decimal kg1, kg30, kg90;
        public int pol;
        public StatusJagnjeta statusJagnjeta;
        public string idBroj;

        public Jagnje(Ovca m, Ovca t, Datum d, int p, decimal k1, decimal k30, decimal k90, StatusJagnjeta status, string id)
        {
            majka = m;
            otac = t;
            datumJagnjenja = d;
            pol = p;
            kg1 = k1;
            kg30 = k30;
            kg90 = k90;
            statusJagnjeta = status;
            idBroj = id;
        }

        public Jagnje(string S)
        {
            string[] s = S.Split('~');
            Upravljanje u = new Upravljanje();
            u.Ucitaj();

            if (Ovca.Pretraga(u.ovce, s[0]).Count == 0) majka = new Ovca(s[0], "", "", 1, new Datum(1, 1, 2020));
            else majka = Ovca.Pretraga(u.ovce, s[0])[0];
            
            if (Ovca.Pretraga(u.ovce, s[1]).Count == 0) otac = new Ovca(s[1], "", "", 0, new Datum(1, 1, 2020));
            else otac = Ovca.Pretraga(u.ovce, s[1])[0];

            datumJagnjenja = new Datum(s[2]);
            kg1 = decimal.Parse(s[3]);
            kg30 = decimal.Parse(s[4]);
            kg90 = decimal.Parse(s[5]);
            pol = int.Parse(s[6]);
            statusJagnjeta = (StatusJagnjeta)int.Parse(s[7]);
            idBroj = s[8];
        }
        public string StringJagnje()
        {
            return majka.idBroj + "~" + otac.idBroj + "~" + datumJagnjenja.StringDatum() + "~" + kg1 + "~" + kg30 + "~" + kg90 + "~" + pol + "~" + (int)statusJagnjeta + "~" + idBroj;
        }

        public enum StatusJagnjeta
        {
            Na_Stanju,
            Prodato,
            Uginulo,
            Zaklano,
            Umatičeno
        }
    }
}
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                          