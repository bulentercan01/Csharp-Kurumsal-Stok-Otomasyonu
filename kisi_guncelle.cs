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
    public partial class kisi_guncelle : Form
    {
        public kisi_guncelle()
        {
            InitializeComponent();
        }

        SqlDataAdapter sda;
        SqlCommandBuilder scb;
        DataTable dt;

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection baglanti = new SqlConnection("Data Source = CODERENG; Initial Catalog = YemekhaneApp; Integrated Security = True");
            sda = new SqlDataAdapter("SELECT * FROM kullanici",baglanti);
            dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
            kullanici_islemleri_2 kllncislem = new kullanici_islemleri_2();
            kllncislem.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            scb = new SqlCommandBuilder(sda);
            sda.Update(dt);
        }
    }
}
