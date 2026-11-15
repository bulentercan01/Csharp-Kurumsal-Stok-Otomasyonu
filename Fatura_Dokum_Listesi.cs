using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace YemekhaneApp2
{
    public partial class Fatura_Dokum_Listesi : Form
    {
        public Fatura_Dokum_Listesi()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            dahili_fatura_dokum_listesi dftrdl = new dahili_fatura_dokum_listesi();
            dftrdl.label2.Text = label4.Text;
            dftrdl.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            harici_fatura_dokum_listesi hftrdl = new harici_fatura_dokum_listesi();
            hftrdl.label2.Text = label4.Text;
            hftrdl.Show();
        }

        private void Fatura_Dokum_Listesi_Load(object sender, EventArgs e)
        {
            label4.Hide();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {           
            first_page frstpg = new first_page();
            frstpg.label1.Text = label4.Text;
            frstpg.Show();
            this.Close();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            fatura_dokum_gelir_gider ftrgg = new fatura_dokum_gelir_gider();
            ftrgg.Show();
        }
    }
}
