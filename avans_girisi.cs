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
    public partial class avans_girisi : Form
    {
        public avans_girisi()
        {
            InitializeComponent();
        }

        SqlConnection baglanti = new SqlConnection("Data Source = CODERENG; Initial Catalog = YemekhaneApp; Integrated Security = True");
        private void button1_Click(object sender, EventArgs e)
        {
            baglanti.Open();

            try
            {
            SqlCommand komut = new SqlCommand("INSERT INTO alinan_avans (tarih,avans_miktar) VALUES (@tarih, @mktr)",baglanti);
            komut.Parameters.AddWithValue("@tarih", dateTimePicker1.Value);
            komut.Parameters.AddWithValue("@mktr", textBox1.Text);
                if (baglanti.State == ConnectionState.Closed)
                {
                    baglanti.Open();
                }

                komut.ExecuteNonQuery();
                baglanti.Close();
                MessageBox.Show("Avans Girişi Başarılı...");
                textBox1.Clear();
                
            }
            catch (SqlException)
            {
                MessageBox.Show("Hata...");
            }
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            avans_goruntule avnsgrt = new avans_goruntule();
            avnsgrt.Show();
        }
    }
}
