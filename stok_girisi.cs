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
    public partial class stok_girisi : Form
    {
        public stok_girisi()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source = CODERENG; Initial Catalog = YemekhaneApp; Integrated Security = True");
        SqlDataAdapter sda;        
        DataTable dt;
       
       

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            yemekhane_stok_hareketi stkhrkt = new yemekhane_stok_hareketi();
            stkhrkt.label7.Text = label8.Text;
            stkhrkt.Show();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {            
                SqlCommand komut = new SqlCommand("INSERT INTO stok_girisi (urun_adı, giris_tarihi, giris_miktar,kdvli_birim_fiyati,iskonto,kdv_orani)VALUES(@uad,@gtar,@gmik,@kdvbrm,@isk,@kdvorn)", baglanti);

                komut.Parameters.AddWithValue("@uad", comboBox1.Text);
                komut.Parameters.AddWithValue("@gtar", dateTimePicker1.Value);
                komut.Parameters.AddWithValue("@gmik", textBox1.Text);
                komut.Parameters.AddWithValue("@kdvbrm", textBox2.Text);
                komut.Parameters.AddWithValue("@isk", textBox3.Text);
                komut.Parameters.AddWithValue("@kdvorn", textBox4.Text);

                if (baglanti.State == ConnectionState.Closed)
                {
                    baglanti.Open();
                }

                komut.ExecuteNonQuery();
                baglanti.Close();
                MessageBox.Show("Kayıt Başarılı...");
            }
            catch(SqlException)
            {
                MessageBox.Show("Hata...");
            }
            
        }

        private void stok_girisi_Load(object sender, EventArgs e)
        {
            if (label8.Text == "False")
            {
                button2.Enabled = false;
            }
            SqlCommand komut = new SqlCommand("SELECT * FROM urun_listesi",baglanti);
            SqlDataReader dr;
            baglanti.Open();
            dr = komut.ExecuteReader();

            while (dr.Read())
            {
                comboBox1.Items.Add(dr["urun_adi"]);
            }
            baglanti.Close();


        }                

        private void button3_Click(object sender, EventArgs e)
        {
            
            sda = new SqlDataAdapter("SELECT * FROM stok_girisi", baglanti);
            dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
