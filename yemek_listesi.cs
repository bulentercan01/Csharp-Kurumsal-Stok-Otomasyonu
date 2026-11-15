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
    public partial class yemek_listesi : Form
    {
        public yemek_listesi()
        {
            InitializeComponent();
        }
        SqlDataAdapter sda;
        SqlCommandBuilder scb;
        DataTable dt;

        private void button1_Click(object sender, EventArgs e)
        {            
            first_page stpg = new first_page();
            stpg.label1.Text = label4.Text;
            stpg.Show();
            this.Close();
        }

       

        private void button3_Click_1(object sender, EventArgs e)
        {            
            SqlConnection baglanti = new SqlConnection("Data Source = CODERENG; Initial Catalog = YemekhaneApp; Integrated Security = True");

            sda = new SqlDataAdapter("SELECT * FROM yemek_listesi WHERE Tarih BETWEEN  @tar1 and @tar2", baglanti);

            dt = new DataTable();
            sda.SelectCommand.Parameters.AddWithValue("@tar1", dateTimePicker1.Value);
            sda.SelectCommand.Parameters.AddWithValue("@tar2", dateTimePicker2.Value);
            sda.Fill(dt);
            dataGridView1.DataSource = dt;

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            yemek_liste_ekle ymklst = new yemek_liste_ekle();
            ymklst.label7.Text = label4.Text;
            ymklst.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            scb = new SqlCommandBuilder(sda);
            sda.Update(dt);
        }

        private void yemek_listesi_Load(object sender, EventArgs e)
        {
            label4.Hide();
            if (label4.Text == "False")//YETKİ FALSE İSE EKLE VE GUNCELLE BUTONLARINI GİZLE
            {
                button4.Enabled = false;
                button5.Enabled = false;
            }
            
        }

        private void button6_Click(object sender, EventArgs e)
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
