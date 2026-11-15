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
    public partial class kullanici_islemleri_2 : Form
    {
        public kullanici_islemleri_2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            kisi_ekle kekle = new kisi_ekle();
            kekle.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
            kisi_guncelle kguncelle = new kisi_guncelle();
            kguncelle.Show();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            kisi_sil ksil = new kisi_sil();
            ksil.Show();
        }
    }
}
