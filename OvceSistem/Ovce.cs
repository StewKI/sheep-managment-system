using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OvceSistem
{
    public partial class Ovce : UserControl
    {
        Upravljanje u = new Upravljanje();

        List<Ovca> prikaz = new List<Ovca>();
        Dictionary<String, int> brojke = new Dictionary<String, int>();

        public Ovce()
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

            dgv.ColumnHeadersVisible = true;
            dgv.RowHeadersVisible = true;
            dgv.ScrollBars = ScrollBars.Both;
            dgv.RowCount = n;

            dgv.ColumnCount = m;


            for (int i = 0; i < n; i++)
            {
                //visina svakog reda
                dgv.Rows[i].Height = h;
            }

            for (int j = 0; j < m; j++)
            {
                //sirina svake kolone
                dgv.Columns[j].Width = w;
            }

        }

        private void Osvezi()
        {
            u.Ucitaj();

            brojke.Clear();
            for (int i = 0; i < u.ovce.Count; i++)
                brojke.Add(u.ovce[i].idBroj, i);
            
            prikaz = Ovca.Pretraga(u.ovce, textBox1.Text);
            //MessageBox.Show(prikaz.Count.ToString());
            PostaviDataGridView(dataGridView1, prikaz.Count, 6, 120, 20);
            dataGridView1.Columns[0].Width = 25;

            for (int i = 0; i < prikaz.Count; i++)
            {
                dataGridView1[0, i].Value = (i + 1).ToString() + ".";
                dataGridView1[1, i].Value = prikaz[i].ime;
                dataGridView1[2, i].Value = prikaz[i].idBroj;
                dataGridView1[3, i].Value = prikaz[i].tetovirBroj;
                dataGridView1[4, i].Value = prikaz[i].pol == 1 ? "Ženski" : "Muški";
                dataGridView1[5, i].Value = prikaz[i].datumRodjenja.FStringDatum();
            }
        }

        private void Ovce_Load(object sender, EventArgs e)
        {
            Osvezi();
            button4.Visible = false;

            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Da li ste sigurni da želite da obrišete tu ovcu?", "Potvrda", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                u.Izbaci(brojke[prikaz[dataGridView1.CurrentCell.RowIndex].idBroj]);
                u.Sacuvaj();
                prikaz = u.ovce;
                Osvezi();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            button4.Visible = false;
            Osvezi();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Osvezi();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using(Unesi_ovcu uo = new Unesi_ovcu())
            {
                uo.DodajFormat();
                if(uo.ShowDialog() == DialogResult.OK)
                {
                    u.Dodaj(uo.o);
                    u.Sacuvaj();
                    Osvezi();
                }
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            button4.Visible = true;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            int k = brojke[prikaz[dataGridView1.CurrentCell.RowIndex].idBroj];
            using (Unesi_ovcu uo = new Unesi_ovcu())
            {
                uo.IzmeniFormat(u.ovce[k]);
                if (uo.ShowDialog() == DialogResult.OK)
                {
                    u.Izbaci(k);
                    u.Dodaj(uo.o);
                    u.Sacuvaj();
                    Osvezi();
                }
            }
        }
    }
}
