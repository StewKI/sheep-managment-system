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
    public partial class Unesi_ovcu : Form
    {
        public Ovca o;

        string upit = "Dodati unetu ovcu?";

        public Unesi_ovcu()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            /*if (Datum.MogucDatum(new Datum((int)numericUpDown1.Value, domainUpDown1.SelectedIndex + 1, (int)numericUpDown2.Value)))
            {
                u.Dodaj(new Ovca(textBox2.Text, textBox3.Text, textBox1.Text.ToUpper(), radioButton1.Checked ? 1 : 0, new Datum((int)numericUpDown1.Value, domainUpDown1.SelectedIndex + 1, (int)numericUpDown2.Value)));
                u.Sacuvaj();
                MessageBox.Show("Ovca je uspešno dodata!", "Obaveštenje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                numericUpDown1.Value = 1;
                numericUpDown2.Value = DateTime.Today.Year;
                domainUpDown1.SelectedIndex = 0;
            }
            else
                MessageBox.Show("Neispravan datum!", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);*/

            if(!Datum.MogucDatum(new Datum((int)numericUpDown1.Value, domainUpDown1.SelectedIndex + 1, (int)numericUpDown2.Value)))
            {
                MessageBox.Show("Neispravan datum!", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if(MessageBox.Show(upit, "Potvrda", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                o = new Ovca(textBox2.Text, textBox3.Text, textBox1.Text.ToUpper(), radioButton1.Checked ? 1 : 0, new Datum((int)numericUpDown1.Value, domainUpDown1.SelectedIndex + 1, (int)numericUpDown2.Value));
                DialogResult = DialogResult.OK;
                Close();
            }
        }

        private void Unesi_ovcu_Load(object sender, EventArgs e)
        {
            numericUpDown2.Maximum = DateTime.Today.Year;
            numericUpDown2.Minimum = 1950;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void DodajFormat()
        {
            domainUpDown1.SelectedIndex = 0;
            radioButton1.Checked = true;
            numericUpDown2.Value = DateTime.Today.Year;
        }

        public void IzmeniFormat(Ovca ovca)
        {
            Text = "Izmeni ovcu";
            button1.Text = "Izmeni";
            upit = "Izmeniti ovcu?";
            textBox1.Text = ovca.ime;
            textBox2.Text = ovca.idBroj;
            textBox3.Text = ovca.tetovirBroj;
            if (ovca.pol == 0) radioButton2.Checked = true;
            else radioButton1.Checked = true;
            numericUpDown1.Value = ovca.datumRodjenja.dan;
            domainUpDown1.SelectedIndex = ovca.datumRodjenja.mesec-1;
            numericUpDown2.Value = ovca.datumRodjenja.godina;
        }
    }
}
