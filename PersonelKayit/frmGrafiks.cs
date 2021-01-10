using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PersonelKayit
{
    public partial class frmGrafiks : Form
    {
        public frmGrafiks()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=FERLATILTAS;Initial Catalog=PersonelVeriTabani;Integrated Security=True");

        private void frmGrafiks_Load(object sender, EventArgs e)
        {
            // Grafik 1 için
            baglanti.Open();
            SqlCommand komutg1 = new SqlCommand("select persehir,count(*) from tbl_personel group by persehir",baglanti);
            SqlDataReader dr1 = komutg1.ExecuteReader();
            while (dr1.Read())
            {
                chart1.Series["Sehirler"].Points.AddXY(dr1[0], dr1[1]);
            }
            baglanti.Close();


            // Grafik 2 için
            baglanti.Open();
            SqlCommand komutg2 = new SqlCommand("select permeslek,Avg(permaas) from tbl_personel group by permeslek", baglanti);
            SqlDataReader dr2 = komutg2.ExecuteReader();
            while (dr2.Read())
            {
                chart2.Series["Meslek-Maas"].Points.AddXY(dr2[0], dr2[1]);
            }
            baglanti.Close();



        }

        private void chart2_Click(object sender, EventArgs e)
        {

        }
    }
}
