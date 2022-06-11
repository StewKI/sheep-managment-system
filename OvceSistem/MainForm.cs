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
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            ovce2.BringToFront();
        }

        private void zatvoriToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ovce2.BringToFront();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            jagnjenjaUC1.BringToFront();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            podesavanja1.BringToFront();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Da li ste sigurni da želite da zatvorite program?", "Potvrda", MessageBoxButtons.YesNo, MessageBoxIcon.Question)== DialogResult.No)
            {
                e.Cancel = true;
            }
        }
    }
}
