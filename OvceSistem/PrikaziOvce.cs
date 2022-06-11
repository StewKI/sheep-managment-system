using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace OvceSistem
{
    public partial class PrikaziOvce : Form
    {
        Upravljanje u = new Upravljanje();

        List<Ovca> prikaz = new List<Ovca>();

        public PrikaziOvce()
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
            prikaz = Ovca.Pretraga(u.ovce, textBox1.Text);
            PostaviDataGridView(dataGridView1, prikaz.Count, 6, 120, 20);
            dataGridView1.Columns[0].Width = 25;

            for (int i = 0; i < prikaz.Count; i++)
            {
                dataGridView1[0, i].Value = (i + 1).ToString() + ".";
                dataGridView1[1, i].Value = prikaz[i].ime;
                dataGridView1[2, i].Value = prikaz[i].idBroj;
                dataGridView1[3, i].Value = prikaz[i].tetovirBroj;
                dataGridView1[4, i].Value = prikaz[i].pol == 1 ? "ženski" : "muški";
                dataGridView1[5, i].Value = prikaz[i].datumRodjenja.FStringDatum();
            }
        }

        private void PrikaziOvce_Load(object sender, EventArgs e)
        {
            u.Ucitaj();

            prikaz = u.ovce;
            Osvezi();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Osvezi();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Da li ste sigurni da zelite da obrišete tu ovcu?", "Da li ste sigurni", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                u.Izbaci(dataGridView1.CurrentCell.RowIndex);
                //u.Sacuvaj();
                prikaz = u.ovce;
                Osvezi();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            
            Osvezi();
        }
    }
}
