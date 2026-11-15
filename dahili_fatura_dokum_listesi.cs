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
    public partial class dahili_fatura_dokum_listesi : Form
    {
        public dahili_fatura_dokum_listesi()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source = CODERENG; Initial Catalog = YemekhaneApp; Integrated Security = True");
        SqlCommandBuilder scb;
        SqlDataAdapter sda;
        DataTable dt;
        private void button1_Click(object sender, EventArgs e)
        {            
            harici_fatura_dokum_listesi hftrdl = new harici_fatura_dokum_listesi();
            hftrdl.label2.Text = label2.Text;
            hftrdl.Show();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            Fatura_Dokum_Listesi ftrdl = new Fatura_Dokum_Listesi();
            ftrdl.label4.Text = label2.Text;
            ftrdl.Show();
            this.Close();
        }
        
        private void button7_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            sda = new SqlDataAdapter("SELECT * FROM dahili_fatura_dokum WHERE tarih BETWEEN @tar1 AND @tar2 ", baglanti);
            dt = new DataTable();
            sda.SelectCommand.Parameters.AddWithValue("@tar1", dateTimePicker1.Value);
            sda.SelectCommand.Parameters.AddWithValue("@tar2", dateTimePicker2.Value);

            sda.Fill(dt);
            dataGridView1.DataSource = dt;
            
            double toplam = 0;
            for(int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                toplam += Convert.ToDouble(dataGridView1.Rows[i].Cells[7].Value);
                label3.Text = toplam.ToString();
            }
            baglanti.Close();

        }

        private void button5_Click(object sender, EventArgs e)
        {
            scb = new SqlCommandBuilder(sda);
            sda.Update(dt);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            scb = new SqlCommandBuilder(sda);
            foreach (DataGridViewRow item in this.dataGridView1.SelectedRows)
            {
                dataGridView1.Rows.RemoveAt(item.Index);
            }
            sda.Update(dt);
        }

        private void button6_Click(object sender, EventArgs e)
        {            
            dahili_fatura_ekle dhftrekle = new dahili_fatura_ekle();
            dhftrekle.Show();
        }

        private void dahili_fatura_dokum_listesi_Load(object sender, EventArgs e)
        {
            
            if (label2.Text == "False")
            {
                button4.Enabled = false;
                button5.Enabled = false;
                button6.Enabled = false;
            }
            label2.Hide();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
    }

