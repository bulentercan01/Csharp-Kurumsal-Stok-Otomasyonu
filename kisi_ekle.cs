using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace YemekhaneApp2
{
    public partial class kisi_ekle : Form
    {
        public kisi_ekle()
        {
            InitializeComponent();
        }
          SqlConnection baglanti = new SqlConnection("Data Source=CODERENG;Initial Catalog=YemekhaneApp;Integrated Security=True");
          
        private void button2_Click(object sender, EventArgs e)
        {
            bool yetki = false;

            if (radioButton1.Checked)
            {
                yetki = false;
            }
            else if(radioButton2.Checked)
            {
                yetki = true;
            }
            else
            {
                MessageBox.Show("Yetkilendirme Hatasi");
            }

            
            string sifre;
            if (textBox2.Text == textBox5.Text)
            {
                sifre = textBox5.Text;
            

            try
            {
            SqlCommand komut = new SqlCommand("INSERT INTO kullanici (kadi,sifre,adi,soyadi,yetki) VALUES (@kad,@sifre,@ad,@soyad,@yetki)",baglanti);

                komut.Parameters.AddWithValue("@kad",textBox1.Text);
                komut.Parameters.AddWithValue("@sifre", textBox5.Text);
                komut.Parameters.AddWithValue("@ad", textBox3.Text);
                komut.Parameters.AddWithValue("@soyad", textBox4.Text);
                komut.Parameters.AddWithValue("@yetki", yetki);

                if (baglanti.State == ConnectionState.Closed)
                {
                    baglanti.Open();
                }

                komut.ExecuteNonQuery();
                baglanti.Close();
                    
                MessageBox.Show("Kişi Eklendi..");
            }
            catch(SqlException)
            {
                MessageBox.Show("Hata Oluştu... ");
            }        
            } else
            {
                MessageBox.Show("Şifreler Uyuşmuyor...");
            }

        }
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            kullanici_islemleri_2 klis = new kullanici_islemleri_2();
            klis.Show();
        }

        
        private void kisi_ekle_Load(object sender, EventArgs e)
        {

        }
    }
}
