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
    public partial class urun_ekle_cikar : Form
    {
        public urun_ekle_cikar()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source = CODERENG; Initial Catalog = YemekhaneApp; Integrated Security = True");

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            button1.Show();
            textBox1.Show();
            button2.Hide();
            comboBox1.Hide();
        }

        private void urun_ekle_cikar_Load(object sender, EventArgs e)
        {
            button2.Hide();
            comboBox1.Hide();
            SqlCommand komut = new SqlCommand("SELECT * FROM urun_listesi", baglanti);
            SqlDataReader dr;
            baglanti.Open();
            dr = komut.ExecuteReader();

            while (dr.Read())
            {
                comboBox1.Items.Add(dr["urun_adi"]);
            }
           
            baglanti.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            try
            {
                SqlCommand komut = new SqlCommand("DELETE FROM urun_listesi WHERE urun_adi=@urun_adi", baglanti);
                komut.Parameters.AddWithValue("@urun_adi", comboBox1.Text);
                if (baglanti.State == ConnectionState.Closed)
                {
                    baglanti.Open();
                }
                komut.ExecuteNonQuery();
                
                MessageBox.Show("Silme İşlemi Başarılı");

                //silme işleminden sonra comboxtaki verileri yeniler
                SqlCommand komut1 = new SqlCommand("SELECT * FROM urun_listesi", baglanti);
                SqlDataReader dr;
                
                dr = komut1.ExecuteReader();

                while (dr.Read())
                {
                    comboBox1.Items.Add(dr["urun_adi"]);
                }
                baglanti.Close();
                
            }
            catch (SqlException)
            {
                MessageBox.Show("Hata Oluştu...");
            }
            
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            button1.Hide();
            textBox1.Hide();
            button2.Show();
            comboBox1.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            try
            {
                SqlCommand komut = new SqlCommand("INSERT INTO urun_listesi (urun_adi) VALUES (@urun_adi)",baglanti);
                komut.Parameters.AddWithValue("@urun_adi", textBox1.Text);

                if (baglanti.State == ConnectionState.Closed)
                {
                    baglanti.Open();
                }

                komut.ExecuteNonQuery();
                

                MessageBox.Show("Ürün Eklendi");

                //ekleme işleminden sonra comboxtaki verileri yeniler
                SqlCommand komut1 = new SqlCommand("SELECT * FROM urun_listesi", baglanti);
                SqlDataReader dr;

                dr = komut1.ExecuteReader();

                while (dr.Read())
                {
                    comboBox1.Items.Add(dr["urun_adi"]);
                }
                baglanti.Close();
                textBox1.Clear();

            }
            catch(SqlException)
            {
                MessageBox.Show("Hata Oluştu");
            }
            

        }
    }
}
