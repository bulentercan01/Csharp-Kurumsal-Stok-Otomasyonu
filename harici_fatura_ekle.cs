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
    public partial class harici_fatura_ekle : Form
    {
        public harici_fatura_ekle()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=CODERENG;Initial Catalog=YemekhaneApp;Integrated Security=True");
        SqlDataAdapter sda;
        DataTable dt;
        private void button1_Click(object sender, EventArgs e)
        {
            sda = new SqlDataAdapter("SELECT * FROM harici_fatura_dokum", baglanti);
            dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            try
            {
                SqlCommand komut = new SqlCommand("INSERT INTO harici_fatura_dokum (firma_adi, tarih, fatura_no, nevi, kdvsiz_tutar, kdv_tutar, toplam_tutar) values (@fadi,@trh,@fno,@nevi,@kdvsz_ttr,@kdv_ttr,@top_ttr)", baglanti);

                komut.Parameters.AddWithValue("@fadi", textBox1.Text);
                komut.Parameters.AddWithValue("@trh", dateTimePicker1.Value);
                komut.Parameters.AddWithValue("@fno", textBox2.Text);
                komut.Parameters.AddWithValue("@nevi", textBox3.Text);
                komut.Parameters.AddWithValue("@kdvsz_ttr", textBox4.Text);
                komut.Parameters.AddWithValue("@kdv_ttr", textBox5.Text);
                komut.Parameters.AddWithValue("top_ttr", textBox6.Text);
                if (baglanti.State == ConnectionState.Closed)
                {
                    baglanti.Open();
                }
                komut.ExecuteNonQuery();
                baglanti.Close();
                MessageBox.Show("Fatura Eklendi...");
            }
            catch (SqlException)
            {
                MessageBox.Show("Bağlantı Hatası");
            }
        }
    }
}
