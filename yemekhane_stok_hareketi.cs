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
    public partial class yemekhane_stok_hareketi : Form
    {
        public yemekhane_stok_hareketi()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            stok_girisi stkgrs = new stok_girisi();
            stkgrs.label8.Text = label7.Text;
            stkgrs.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
            first_page frstpg = new first_page();
            frstpg.Show();
        }

        private void yemekhane_stok_hareketi_Load(object sender, EventArgs e)
        {
            if (label7.Text == "False")
            {
                button1.Enabled = false;
                button2.Enabled = false;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            urun_listesi urnlst = new urun_listesi();
            urnlst.Show();
        }
    }
}
