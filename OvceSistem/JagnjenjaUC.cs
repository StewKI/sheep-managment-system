using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.Drawing.Drawing2D;

namespace OvceSistem
{
    public partial class JagnjenjaUC : UserControl
    {
        Jagnjenje uj = new Jagnjenje();

        public JagnjenjaUC()
        {
            InitializeComponent();
        }

        void PostaviDataGridView(DataGridView dgv, int n, int m, int w, int h)
        {
            dgv.AllowUserToAddRows = false;
            dgv.AllowUserToDeleteRows = false;
            dgv.AllowUserToOrderColumns = false;
            dgv.AllowUserToResizeColumns = true;
            dgv.AllowUserToResizeRows = false;

            dgv.ColumnHeadersVisible = false;
            dgv.RowHeadersVisible = true;
            dgv.ScrollBars = ScrollBars.Both;

            dgv.RowCount = n;
            dgv.ColumnCount = m;

            for (int i = 0; i < n; i++)
                dgv.Rows[i].Height = h; //visina svakog reda

            for (int j = 0; j < m; j++)
                dgv.Columns[j].Width = w; //sirina svake kolone
            /*
            for(int i = 0; i<n; i++)
            {
                for(int j  = 0; j<m; j++)
                {
                    dgv[j, i].Style.BackColor = Color.LightYellow;
                    dgv[j, i].Style.Font = new Font("Arial", 12, FontStyle.Regular);
                }
            }*/

        }

        /*void Osvezi()
        {
            PostaviDataGridView(dgv, uj.jagnjici.Count * 2, 10, 100, 15);
            dgv.Columns[0].Width = 15;

            for (int i = 0; i < uj.jagnjici.Count * 2; i += 2)
            {
                int k = i / 2;
                dgv[0, i].Value = k + 1;
                
                if (k > 0 && uj.jagnjici[k-1].majka.idBroj != uj.jagnjici[k].majka.idBroj)
                {
                    dgv[1, i].Value = uj.jagnjici[k].majka.tetovirBroj;
                    dgv[1, i + 1].Value = uj.jagnjici[k].majka.idBroj;

                    dgv[2, i].Value = uj.jagnjici[k].datumJagnjenja.FStringDatum();

                    dgv[3, i].Value = uj.jagnjici[k].otac.tetovirBroj;
                    dgv[3, i + 1].Value = uj.jagnjici[k].otac.idBroj;
                }
                else if (k == 0)
                {
                    dgv[1, i].Value = uj.jagnjici[k].majka.tetovirBroj;
                    dgv[1, i + 1].Value = uj.jagnjici[k].majka.idBroj;

                    dgv[2, i].Value = uj.jagnjici[k].datumJagnjenja.FStringDatum();

                    dgv[3, i].Value = uj.jagnjici[k].otac.tetovirBroj;
                    dgv[3, i + 1].Value = uj.jagnjici[k].otac.idBroj;
                }

                dgv[4, i].Value = uj.jagnjici[k].pol == 1 ? "Žensko" : "Muško";

                dgv[5, i].Value = uj.jagnjici[k].kg1;
                dgv[6, i].Value = uj.jagnjici[k].kg30;
                dgv[7, i].Value = uj.jagnjici[k].kg90;

                dgv[8, i].Value = uj.jagnjici[k].idBroj;
                dgv[9, i].Value = uj.jagnjici[k].statusJagnjeta;
            }
        }*/

        void Osvezi()
        {
            PostaviDataGridView(dgv, uj.jagnjici.Count * 2 + 2, 10, 100, 15);
            dgv.Columns[0].Width = 20;

            for(int i = 0; i<10; i++)
                for(int j = 0; j<2; j++)
                {
                    dgv[i, j].Style.BackColor = Color.LightGray;
                }

            dgv[0, 0].Value = ""; dgv[1, 0].Value = "Tetovir broj ovce"; dgv[2, 0].Value = "Datum Jagnjenja"; dgv[3, 0].Value = "Tetovir broj ovna"; dgv[4, 0].Value = "Pol"; dgv[5, 0].Value = "Težina pri rođenju"; dgv[6, 0].Value = "Težina sa 30 dana"; dgv[7, 0].Value = "Težina sa 90 dana"; dgv[8, 0].Value = "ID broj jagnjeta"; dgv[9, 0].Value = "Status jagnjeta";
            dgv[0, 1].Value = ""; dgv[1, 1].Value = "ID broj ovce";      dgv[2, 1].Value = "Datum Jagnjenja"; dgv[3, 1].Value = "ID broj ovna";      dgv[4, 1].Value = "Pol"; dgv[5, 1].Value = "Težina pri rođenju"; dgv[6, 1].Value = "Težina sa 30 dana"; dgv[7, 1].Value = "Težina sa 90 dana"; dgv[8, 1].Value = "ID broj jagnjeta"; dgv[9, 1].Value = "Status jagnjeta";

            for (int i = 2; i < uj.jagnjici.Count * 2+2; i += 2)
            {
                int k = (i - 2) / 2;
                dgv[0, i].Value = k + 1;
                dgv[0, i+1].Value = k + 1;

                if (k > 0 && uj.jagnjici[k - 1].majka.idBroj != uj.jagnjici[k].majka.idBroj)
                {
                    dgv[1, i].Value = uj.jagnjici[k].majka.tetovirBroj;
                    dgv[1, i + 1].Value = uj.jagnjici[k].majka.idBroj;

                    dgv[2, i].Value = uj.jagnjici[k].datumJagnjenja.FStringDatum();
                    dgv[2, i+1].Value = uj.jagnjici[k].datumJagnjenja.FStringDatum();

                    dgv[3, i].Value = uj.jagnjici[k].otac.tetovirBroj;
                    dgv[3, i + 1].Value = uj.jagnjici[k].otac.idBroj;
                }
                else if (k == 0)
                {
                    dgv[1, i].Value = uj.jagnjici[k].majka.tetovirBroj;
                    dgv[1, i + 1].Value = uj.jagnjici[k].majka.idBroj;

                    dgv[2, i].Value = uj.jagnjici[k].datumJagnjenja.FStringDatum();
                    dgv[2, i+1].Value = uj.jagnjici[k].datumJagnjenja.FStringDatum();

                    dgv[3, i].Value = uj.jagnjici[k].otac.tetovirBroj;
                    dgv[3, i + 1].Value = uj.jagnjici[k].otac.idBroj;
                }
                else
                {
                    dgv[1, i].Value = null;
                    dgv[1, i + 1].Value = null;
                    dgv[2, i].Value = "";
                    dgv[2, i + 1].Value = "";
                    dgv[3, i].Value = null;
                    dgv[3, i + 1].Value = null;
                }

                dgv[4, i].Value = uj.jagnjici[k].pol == 1 ? "Žensko" : "Muško";

                dgv[5, i].Value = uj.jagnjici[k].kg1;
                dgv[6, i].Value = uj.jagnjici[k].kg30;
                dgv[7, i].Value = uj.jagnjici[k].kg90;

                dgv[8, i].Value = uj.jagnjici[k].idBroj;
                dgv[9, i].Value = uj.jagnjici[k].statusJagnjeta;

                dgv[4, i+1].Value = uj.jagnjici[k].pol == 1 ? "Žensko" : "Muško";

                dgv[5, i+1].Value = uj.jagnjici[k].kg1;
                dgv[6, i+1].Value = uj.jagnjici[k].kg30;
                dgv[7, i+1].Value = uj.jagnjici[k].kg90;

                dgv[8, i+1].Value = uj.jagnjici[k].idBroj;
                dgv[9, i+1].Value = uj.jagnjici[k].statusJagnjeta;
            }
        }

        private void JagnjenjaUC_Load(object sender, EventArgs e)
        {
            uj.Ucitaj();
            Osvezi();
            dgv.AutoGenerateColumns = false;
            this.BackColor = Color.FromName("Control");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using(DodajJagnjenje dj = new DodajJagnjenje())
            {
                dj.DodajFormat();
                if(dj.ShowDialog() == DialogResult.OK)
                {
                    for (int i = 0; i < dj.jagnjici.Count; i++)
                        uj.jagnjici.Add(dj.jagnjici[i]);

                    Jagnjenje.Sortiraj(uj.jagnjici);
                    uj.Sacuvaj();
                    Osvezi();
                }
            }
        }

        #region mergeing
        bool IsTheSameCellValue(int column, int row)
        {
            DataGridViewCell cell1 = dgv[column, row];
            DataGridViewCell cell2 = dgv[column, row - 1];
            if (cell1.Value == null || cell2.Value == null || row%2 == 0)
            {
                return false;
            }
            return cell1.Value.ToString() == cell2.Value.ToString();
        }

        private void dgv_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            e.AdvancedBorderStyle.Bottom = DataGridViewAdvancedCellBorderStyle.None;
            if (e.RowIndex < 1 || e.ColumnIndex < 0)
                return;
            if (IsTheSameCellValue(e.ColumnIndex, e.RowIndex))
            {
                e.AdvancedBorderStyle.Top = DataGridViewAdvancedCellBorderStyle.None;
            }
            else
            {
                e.AdvancedBorderStyle.Top = dgv.AdvancedCellBorderStyle.Top;
            }
        }

        private void dgv_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex == 0)
                return;
            if (IsTheSameCellValue(e.ColumnIndex, e.RowIndex))
            {
                e.Value = "";
                e.FormattingApplied = true;
            }
        }
        #endregion

        private void button2_Click(object sender, EventArgs e)
        {
            if (dgv.CurrentCell.RowIndex >= 2)
            {
                if (MessageBox.Show("Da li ste sigurni da želite da obrišete izabrano jagnje?", "Potvrda", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    int k = (dgv.CurrentCell.RowIndex - 2) / 2;
                    uj.Obrisi(k);
                    //uj.Sacuvaj();
                    Osvezi();
                }
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (dgv.CurrentCell.RowIndex >= 2)
            {
                using (DodajJagnjenje dj = new DodajJagnjenje())
                {
                    int k = (dgv.CurrentCell.RowIndex - 2) / 2;
                    int[] r = CeloJagnjenjeInt(uj.jagnjici, k);
                    //MessageBox.Show(uj.jagnjici[r[0]].StringJagnje() + "   :   " + uj.jagnjici[r[1]].StringJagnje());
                    
                    dj.IzmeniFormat(CeloJagnjenje(uj.jagnjici, k));

                    if (dj.ShowDialog() == DialogResult.OK)
                    {
                        //MessageBox.Show(uj.jagnjici.Count.ToString());
                        for(int i = r[0]; i<=r[1]; i++)
                            uj.Obrisi(r[0]);
                        //MessageBox.Show(uj.jagnjici.Count.ToString());
                        
                        for (int i = 0; i < dj.jagnjici.Count; i++)
                            uj.jagnjici.Add(dj.jagnjici[i]);

                        Jagnjenje.Sortiraj(uj.jagnjici);
                        uj.Sacuvaj();
                        Osvezi();
                    }
                }
            }
        }

        private List<Jagnje> CeloJagnjenje(List<Jagnje> j, int k)
        {
            List<Jagnje> r = new List<Jagnje>();
            Jagnje jagnje = j[k];
            r.Add(jagnje);

            int i = k+1;
            while(i < j.Count && j[i].majka.idBroj == jagnje.majka.idBroj)
            {
                r.Add(j[i]);
                i++;
            }

            i = k - 1;
            while (i >= 0 && j[i].majka.idBroj == jagnje.majka.idBroj)
            {
                r.Add(j[i]);
                i--;
            }

            return r;
        }

        private int[] CeloJagnjenjeInt(List<Jagnje> j, int k)
        {
            int[] r = new int[2];
            Jagnje jagnje = j[k];

            int i = k + 1;
            while (i<j.Count && j[i].majka.idBroj == jagnje.majka.idBroj)
                i++;
            r[1] = i - 1;

            i = k - 1;
            while (i>=0 && j[i].majka.idBroj == jagnje.majka.idBroj)
                i--;
            r[0] = i + 1;

            return r;
        }
    }
}
