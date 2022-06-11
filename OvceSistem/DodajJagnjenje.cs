using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OvceSistem
{
    public partial class DodajJagnjenje : Form
    {
        Upravljanje u = new Upravljanje();

        List<Ovca> majka = new List<Ovca>();
        List<Ovca> otac = new List<Ovca>();
        
        public List<Jagnje> jagnjici = new List<Jagnje>();

        private string upit = "Da li ste sigurni da želite da unesete ovo jagnjenje?";

        private class jagnje
        {
            public int pol;
            public decimal kg;

            public jagnje(int Pol, decimal Kg)
            {
                pol = Pol;
                kg = Kg;
            }
        }

        List<jagnje> jagnjes = new List<jagnje>();

        public DodajJagnjenje()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Count() > 0)
            {
                majka = Ovca.Pretraga(u.ovce, textBox1.Text, 1);
                bool k = false;
                if (majka.Count == 0)
                {
                    MessageBox.Show("Ovca nije pronađena!", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    majka.Add(new Ovca(textBox1.Text, "", "", 1, new Datum("1-1-2020")));
                    k = true;
                }
                dgv1[0, 0].Value = majka[0].ime;
                if(!k) dgv1[0, 1].Value = majka[0].datumRodjenja.FStringDatum();
                else dgv1[0, 1].Value = "";
                dgv1[1, 1].Value = majka[0].tetovirBroj;
                dgv1[1, 0].Value = majka[0].idBroj;

                button2.Enabled = true;
                button2.Text = "Izaberi";
            }
        }

        private void DodajJagnjenje_Load(object sender, EventArgs e)
        {
            u.Ucitaj();
            PostaviDataGridView(dgv1, 2, 2, 137, 23);
            PostaviDataGridView(dgv2, 2, 2, 137, 23);

            numericUpDown2.Maximum = DateTime.Today.Year;
            numericUpDown2.Minimum = 1950;
            


            numericUpDown3.Increment = 0.1m;
            numericUpDown3.Value = 3.5m;
        }

        void PostaviDataGridView(DataGridView dgv, int n, int m, int w, int h)
        {
            dgv.AllowUserToAddRows = false;
            dgv.AllowUserToDeleteRows = false;
            dgv.AllowUserToOrderColumns = false;
            dgv.AllowUserToResizeColumns = false;
            dgv.AllowUserToResizeRows = false;

            dgv.ColumnHeadersVisible = false;
            dgv.RowHeadersVisible = false;
            dgv.ScrollBars = ScrollBars.None;

            dgv.RowCount = n;
            dgv.ColumnCount = m;

            for (int i = 0; i < n; i++)
                dgv.Rows[i].Height = h; //visina svakog reda

            for (int j = 0; j < m; j++)
                dgv.Columns[j].Width = w; //sirina svake kolone

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dgv1[1, 0].Value != null && dgv1[1, 0].Value.ToString().Count() > 0)
            {
                button2.Enabled = false;
                button2.Text = "Izabrano";
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (textBox2.Text.Count() > 0)
            {
                otac = Ovca.Pretraga(u.ovce, textBox2.Text, 0);
                bool k = false;
                if (otac.Count == 0)
                {
                    MessageBox.Show("Ovan nije pronađen!", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    otac.Add(new Ovca(textBox2.Text, "", "", 0, new Datum("1-1-2020")));
                    k = true;
                }
                dgv2[0, 0].Value = otac[0].ime;
                if (!k) dgv2[0, 1].Value = otac[0].datumRodjenja.FStringDatum();
                else dgv2[0, 1].Value = "";
                dgv2[1, 1].Value = otac[0].tetovirBroj;
                dgv2[1, 0].Value = otac[0].idBroj;

                button3.Enabled = true;
                button3.Text = "Izaberi";
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (dgv2[1, 0].Value != null && dgv2[1, 0].Value.ToString().Count() > 0)
            {
                button3.Enabled = false;
                button3.Text = "Izabrano";
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            numericUpDown1.Value = DateTime.Today.Day;
            domainUpDown1.SelectedIndex = DateTime.Today.Month - 1;
            numericUpDown2.Value = DateTime.Today.Year;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            jagnjes.Add(new jagnje(comboBox1.SelectedIndex, numericUpDown3.Value));
            PostaviDataGridView(dgv3, jagnjes.Count, 2, 137, 23);
            dgv3.ScrollBars = ScrollBars.Vertical;
            for (int i = 0; i < jagnjes.Count; i++)
            {
                dgv3[0, i].Value = jagnjes[i].pol == 1 ? "Žensko" : "Muško";
                dgv3[1, i].Value = jagnjes[i].kg.ToString();
            }
            button9.Visible = true;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Da li ste sigurni da želite da odustanete?", "Potvrda", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                Close();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (button2.Enabled)
                MessageBox.Show("Nije izabrana ovca!", "Greška!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if(button3.Enabled)
                MessageBox.Show("Nije izabran ovan!", "Greška!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if(!Datum.MogucDatum(new Datum((int)numericUpDown1.Value, domainUpDown1.SelectedIndex+1, (int)numericUpDown2.Value)))
                MessageBox.Show("Neispravan datum jagnjenja!", "Greška!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if(jagnjes.Count == 0)
                MessageBox.Show("Nije uneto nijedno jagnje!", "Greška!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if(MessageBox.Show(upit, "Potvrda", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                jagnjici.Clear();
                //MessageBox.Show(jagnjes.Count.ToString());
                for(int i = 0; i<jagnjes.Count; i++)
                {
                    jagnjici.Add(new Jagnje(majka[0], otac[0], new Datum((int)numericUpDown1.Value, domainUpDown1.SelectedIndex + 1, (int)numericUpDown2.Value), jagnjes[i].pol, jagnjes[i].kg, 0m, 0m, Jagnje.StatusJagnjeta.Na_Stanju, ""));
                }
                
                DialogResult = DialogResult.OK;
                this.Close();
            }
        }
        

        private void button9_Click(object sender, EventArgs e)
        {
            jagnjes.Clear();
            PostaviDataGridView(dgv3, jagnjes.Count, 2, 137, 23);
            dgv3.ScrollBars = ScrollBars.Vertical;
            for (int i = 0; i < jagnjes.Count; i++)
            {
                dgv3[0, i].Value = jagnjes[i].pol == 1 ? "Žensko" : "Muško";
                dgv3[1, i].Value = jagnjes[i].kg.ToString();
            }
            button9.Visible = false;
        }

        public void DodajFormat()
        {
            numericUpDown1.Value = DateTime.Today.Day;
            domainUpDown1.SelectedIndex = DateTime.Today.Month - 1;
            numericUpDown2.Value = DateTime.Today.Year;
            button9.Visible = false;
        }

        public void IzmeniFormat(List<Jagnje> lj)
        {
            Text = "Izmeni jagnjenje";
            upit = "Da li ste sigurni da želite da izmenite ovo jagnjenje?";
            button7.Text = "Izmeni";
            PostaviDataGridView(dgv1, 2, 2, 137, 23);
            PostaviDataGridView(dgv2, 2, 2, 137, 23);

            majka.Add(lj[0].majka);
            dgv1[0, 0].Value = majka[0].ime;
            dgv1[0, 1].Value = majka[0].datumRodjenja.FStringDatum();
            dgv1[1, 1].Value = majka[0].tetovirBroj;
            dgv1[1, 0].Value = majka[0].idBroj;
            button2.Enabled = false;

            otac.Add(lj[0].otac);
            dgv2[0, 0].Value = otac[0].ime;
            dgv2[0, 1].Value = otac[0].datumRodjenja.FStringDatum();
            dgv2[1, 1].Value = otac[0].tetovirBroj;
            dgv2[1, 0].Value = otac[0].idBroj;
            button3.Enabled = false;

            numericUpDown1.Value = lj[0].datumJagnjenja.dan;
            domainUpDown1.SelectedIndex = lj[0].datumJagnjenja.mesec - 1;
            numericUpDown2.Value = lj[0].datumJagnjenja.godina;

            for(int i = 0; i<lj.Count; i++)
                jagnjes.Add(new jagnje(lj[i].pol, lj[i].kg1));
            PostaviDataGridView(dgv3, jagnjes.Count, 2, 137, 23);
            dgv3.ScrollBars = ScrollBars.Vertical;
            for (int i = 0; i < jagnjes.Count; i++)
            {
                dgv3[0, i].Value = jagnjes[i].pol == 1 ? "Žensko" : "Muško";
                dgv3[1, i].Value = jagnjes[i].kg.ToString();
            }
            button9.Visible = true;
        }
    }
}
