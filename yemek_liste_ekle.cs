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
    public partial class yemek_liste_ekle : Form
    {
        public yemek_liste_ekle()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=CODERENG;Initial Catalog=YemekhaneApp;Integrated Security=True"); 
        SqlDataAdapter sda;
        DataTable dt;

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            sda = new SqlDataAdapter("SELECT * FROM yemek_listesi", baglanti);
            dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommand komut = new SqlCommand("INSERT INTO yemek_listesi (Tarih, yemek_1, yemek_2, yemek_3,yemek_4) VALUES (@tarih,@y1,@y2,@y3,@y4)", baglanti);

                komut.Parameters.AddWithValue("@tarih", dateTimePicker1.Value);
                komut.Parameters.AddWithValue("@y1", textBox1.Text);
                komut.Parameters.AddWithValue("@y2", textBox2.Text);
                komut.Parameters.AddWithValue("@y3", textBox3.Text);
                komut.Parameters.AddWithValue("@y4", textBox4.Text);
                

                if (baglanti.State == ConnectionState.Closed)
                {
                    baglanti.Open();
                }

                komut.ExecuteNonQuery();
                baglanti.Close();

                MessageBox.Show("Yemek Eklendi..");
                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
                textBox4.Clear();
            }
            catch (SqlException)
            {
                MessageBox.Show("Hata Oluştu... ");
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            
            yemek_listesi ymklst = new yemek_listesi();
            ymklst.label4.Text = label7.Text;
            ymklst.Show();
            this.Close();
        }

        private void yemek_liste_ekle_Load(object sender, EventArgs e)
        {
            label7.Hide();
        }
    }
}
