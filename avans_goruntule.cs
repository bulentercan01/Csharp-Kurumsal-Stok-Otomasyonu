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
    public partial class avans_goruntule : Form
    {
        public avans_goruntule()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source = CODERENG; Initial Catalog = YemekhaneApp; Integrated Security = True");
        SqlCommandBuilder scb;
        SqlDataAdapter sda;
        DataTable dt;

        private void button3_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            sda = new SqlDataAdapter("SELECT *FROM alinan_avans ",baglanti);
            dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
            baglanti.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            scb = new SqlCommandBuilder(sda);
            sda.Update(dt);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            scb = new SqlCommandBuilder(sda);
            foreach (DataGridViewRow item in this.dataGridView1.SelectedRows)
            {
                dataGridView1.Rows.RemoveAt(item.Index);
            }
            sda.Update(dt);
        }
    }
}
