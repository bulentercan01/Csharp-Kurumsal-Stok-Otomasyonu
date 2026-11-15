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
    public partial class fatura_dokum_gelir_gider : Form
    {
        public fatura_dokum_gelir_gider()
        {
            InitializeComponent();
        }

        SqlConnection baglanti = new SqlConnection("Data Source = CODERENG; Initial Catalog = YemekhaneApp; Integrated Security = True");
        SqlCommandBuilder scb;
        SqlDataAdapter sda;
        DataTable dt;

        private void button1_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            //databaseden alınan toplam avansları cekip label a atadık
            SqlCommand komut_avans = new SqlCommand("select sum(avans_miktar) from alinan_avans where  tarih between @tar1 and @tar2 ", baglanti);
            komut_avans.Parameters.AddWithValue("@tar1", dateTimePicker1.Value);
            komut_avans.Parameters.AddWithValue("@tar2", dateTimePicker2.Value);
            label7.Text = Convert.ToString(komut_avans.ExecuteScalar().ToString());
            double avans = Convert.ToDouble(label7.Text);

            //double avans = Convert.ToDouble(avans_str);           

            //databaseden cekilen toplam dahili harcamaları labela atadık
            SqlCommand komut_dahili_toplam = new SqlCommand("select sum(toplam_tutar) from dahili_fatura_dokum where tarih between @tar1 and @tar2 ", baglanti);
            komut_dahili_toplam.Parameters.AddWithValue("@tar1", dateTimePicker1.Value);
            komut_dahili_toplam.Parameters.AddWithValue("@tar2", dateTimePicker2.Value);
            string dahili_tutar_str;            
            dahili_tutar_str = komut_dahili_toplam.ExecuteScalar().ToString();            
            label8.Text = dahili_tutar_str;

            double dahili_tutar = Convert.ToDouble(dahili_tutar_str);

            ////databaseden cekilen toplam harici harcamaları labela atadık
            SqlCommand komut_harici_toplam = new SqlCommand("select sum(toplam_tutar) from harici_fatura_dokum where tarih between @tar1 and @tar2 ", baglanti);
            komut_harici_toplam.Parameters.AddWithValue("@tar1", dateTimePicker1.Value);
            komut_harici_toplam.Parameters.AddWithValue("@tar2", dateTimePicker2.Value);
            string harici_tutar_str;
            harici_tutar_str = komut_harici_toplam.ExecuteScalar().ToString();
            label9.Text = harici_tutar_str.ToString();

            double harici_tutar = Convert.ToDouble(harici_tutar_str);

            double avans_ustu = avans - (dahili_tutar + harici_tutar);

            string avans_ustu_str = avans_ustu.ToString();
            label10.Text = avans_ustu_str;

            baglanti.Close();
        }
    }
}
