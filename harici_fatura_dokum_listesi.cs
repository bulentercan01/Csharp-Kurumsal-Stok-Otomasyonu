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
    public partial class harici_fatura_dokum_listesi : Form
    {
        public harici_fatura_dokum_listesi()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source = CODERENG; Initial Catalog = YemekhaneApp; Integrated Security = True");
        SqlCommandBuilder scb;
        SqlDataAdapter sda;
        DataTable dt;
       
        
        private void harici_fatura_dokum_listesi_Load_1(object sender, EventArgs e)
        {
            if (label2.Text == "False")
            {
                button3.Enabled = false;
                button4.Enabled = false;
                button5.Enabled = false;
            }
            label2.Hide();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            Fatura_Dokum_Listesi FTRDL = new Fatura_Dokum_Listesi();
            FTRDL.label4.Text = label2.Text;
            FTRDL.Show();
            this.Close();

        }

        private void button6_Click_1(object sender, EventArgs e)
        {
            baglanti.Open();
            sda = new SqlDataAdapter("SELECT * FROM harici_fatura_dokum where tarih BETWEEN @tar1 AND @tar2 ", baglanti);
            dt = new DataTable();
            sda.SelectCommand.Parameters.AddWithValue("@tar1", dateTimePicker1.Value);
            sda.SelectCommand.Parameters.AddWithValue("@tar2", dateTimePicker2.Value);
            sda.Fill(dt);
            dataGridView1.DataSource = dt;

            double toplam = 0;
            for(int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                toplam += Convert.ToDouble(dataGridView1.Rows[i].Cells[7].Value);
                label4.Text = toplam.ToString();
            }
            baglanti.Close();
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            harici_fatura_ekle hrcftrekle = new harici_fatura_ekle();
            hrcftrekle.Show();
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            scb = new SqlCommandBuilder(sda);
            sda.Update(dt);
        }

        private void button3_Click(object sender, EventArgs e)
        {
                scb = new SqlCommandBuilder(sda);
                foreach(DataGridViewRow item in this.dataGridView1.SelectedRows)
                {
                    dataGridView1.Rows.RemoveAt(item.Index);
                }
                sda.Update(dt);
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            dahili_fatura_dokum_listesi dhlftrdl = new dahili_fatura_dokum_listesi();
            dhlftrdl.label2.Text = label2.Text;
            dhlftrdl.Show();
            this.Close();
        }
    }
}
