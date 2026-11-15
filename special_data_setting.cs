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
    public partial class special_data_setting : Form
    {
        public special_data_setting()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            avans_girisi avans_gr = new avans_girisi();
            avans_gr.Show();
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            urun_ekle_cikar uek = new urun_ekle_cikar();
            uek.Show();
        }
    }
}
