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
using System.Xml;

namespace SqlSorgu
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-K0C08G8;Initial Catalog=Rehber;Integrated Security=True");

        void calistir()
        {
            SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-K0C08G8;Initial Catalog="+ comboBox1.Text +";Integrated Security=True");
            string sorgu = richTextBox1.Text;

            try
            {
                SqlDataAdapter da = new SqlDataAdapter(sorgu, baglanti);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;
            }
            catch (Exception)
            {

                MessageBox.Show("Sorgunuzu Kontrol Edin !", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        void ekleSilGuncelle()
        {
            SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-K0C08G8;Initial Catalog=" + comboBox1.Text + ";Integrated Security=True");

            string sorgu = richTextBox1.Text;
            try
            {
                baglanti.Open();
                SqlCommand komut = new SqlCommand(sorgu, baglanti);
                komut.ExecuteNonQuery();
                baglanti.Close();
            }
            catch (Exception)
            {

                MessageBox.Show("Sorgunuzu Kontrol Edin !", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("Select * From sys.databases", baglanti);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                comboBox1.Items.Add(dr[0]);
            }
            baglanti.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            calistir();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ekleSilGuncelle();



        }

       
        private void linkLabel1_Click(object sender, EventArgs e)
        {
              System.Diagnostics.Process.Start("https://tr.wikipedia.org/wiki/SQL");
        }
    }
}
