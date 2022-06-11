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
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Unesi_ovcu unesi_Ovcu = new Unesi_ovcu();
            unesi_Ovcu.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            PrikaziOvce prikaziOvce = new PrikaziOvce();
            prikaziOvce.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Jagnjenja j = new Jagnjenja();
            j.Show();
        }
    }

    
}
