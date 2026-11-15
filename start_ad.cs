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
    public partial class start_ad : Form
    {
        public start_ad()
        {
            InitializeComponent();
            this.TransparencyKey = Color.Turquoise;
            this.BackColor = Color.Turquoise;
        }
        int sayi = 5;

        private void start_ad_Load(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            timer1.Interval = 1000;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label1.Hide();
            sayi--;
            label1.Text = sayi.ToString();
            if (sayi == 0)
            {
                //timer1.Enabled = false;
                login frm = new login();
                frm.Show();
                this.Hide();
            }
        }
    }
}

