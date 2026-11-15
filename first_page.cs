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
    public partial class first_page : Form
    {
        public first_page()
        {
            InitializeComponent();
        }

       

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            yemek_listesi ymklist = new yemek_listesi();
            ymklist.label4.Text = label1.Text;
            ymklist.Show();
        }

       
        private void first_page_Load(object sender, EventArgs e)
        {
            

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Fatura_Dokum_Listesi ftrdkm = new Fatura_Dokum_Listesi();
            ftrdkm.label4.Text = label1.Text;
            ftrdkm.Show();
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            yemekhane_stok_hareketi ymksh = new yemekhane_stok_hareketi();
            ymksh.label7.Text = label1.Text;
            ymksh.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            kullanici_islemleri_2 islemkullanici = new kullanici_islemleri_2();
            islemkullanici.Show();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            special_data_setting sysset = new special_data_setting();
            sysset.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Close();            
            Application.Exit();
        }

        private void toolTip1_Popup(object sender, PopupEventArgs e)
        {
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Close();
            login lgn = new login();
            lgn.Show();
        }
    }
}
