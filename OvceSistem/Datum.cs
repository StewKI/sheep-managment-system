using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OvceSistem
{
    public class Datum
    {
        public int dan, mesec, godina;

        

        public Datum(string S)
        {
            string[] s = S.Split('-');
            dan = int.Parse(s[0]);
            mesec = int.Parse(s[1]);
            godina = int.Parse(s[2]);
        }
        public Datum(int d, int m, int g)
        {
            dan = d;
            mesec = m;
            godina = g;
        }

        public string StringDatum() { return dan + "-" + mesec + "-" + godina; }

        public string FStringDatum()
        {
            string s = "";
            if (dan < 10) s += "0" + dan + ".";
            else s += dan + ".";
            if (mesec < 10) s += "0" + mesec + ".";
            else s += mesec + ".";
            s += godina + ".";
            return s;
        }

        public static int Uporedi(Datum a, Datum b)
        {
            if (a.godina > b.godina) return 1;
            else if (a.godina < b.godina) return -1;
            else if (a.mesec > b.mesec) return 1;
            else if (a.mesec < b.mesec) return -1;
            else if (a.dan > b.dan) return 1;
            else if (a.dan < b.dan) return -1;
            else return 0;
        }

        public static bool MogucDatum(Datum d)
        {
            if(d.godina > 1950 && d.godina <= DateTime.Today.Year)
            {
                if(d.mesec > 0 && d.mesec <= 12)
                {
                    if (d.dan > 0 && d.dan <= DateTime.DaysInMonth(d.godina, d.mesec))
                        return true;
                }
            }
            return false;
        }
    }
}
