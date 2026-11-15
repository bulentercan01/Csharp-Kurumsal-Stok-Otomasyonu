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
    public partial class kisi_sil : Form
    {
        public kisi_sil()
        {
            InitializeComponent();
        }

        SqlDataAdapter sda;
        SqlCommandBuilder scb;
        DataTable dt;

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection baglanti = new SqlConnection("Data Source = CODERENG; Initial Catalog = YemekhaneApp; Integrated Security = True");
            sda = new SqlDataAdapter("SELECT id, kadi, adi, soyadi from kullanici",baglanti);
            dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            scb = new SqlCommandBuilder(sda);
          foreach (DataGridViewRow item in this.dataGridView1.SelectedRows)
                {
                    dataGridView1.Rows.RemoveAt(item.Index);
                }
            sda.Update(dt);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
            kullanici_islemleri_2 klncislem = new kullanici_islemleri_2();
            klncislem.Show();
        }
    }
}
