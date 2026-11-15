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
    public partial class login : Form
    {
        public login()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=CODERENG;Initial Catalog=YemekhaneApp;Integrated Security=True");
        private void button1_Click(object sender, EventArgs e)
        {
            
            baglanti.Open();
            string komut = "select * from kullanici where kadi='" + textBox1.Text + "' and sifre='" + textBox2.Text + "'";
            DataTable dt = new DataTable();
            SqlDataAdapter adp = new SqlDataAdapter(komut, baglanti);
            adp.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                if (dt.Rows[0]["yetki"].ToString() == "True")
                {

                    this.Hide();
                    first_page frstpg = new first_page();
                    frstpg.Show();
                    frstpg.label1.Text = "True";
                }

                else if (dt.Rows[0]["yetki"].ToString() == "False")
                {

                    this.Hide();
                    first_page frstpg = new first_page();
                    frstpg.Show();
                    frstpg.button4.Enabled = false;//kullanıcı islemleri butonu kapalı
                    frstpg.label1.Text = "False";
                    frstpg.button5.Enabled = false;

                }
            }
            baglanti.Close();

        }
    }
}
