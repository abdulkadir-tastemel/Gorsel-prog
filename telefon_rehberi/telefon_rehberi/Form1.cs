using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace telefon_rehberi
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Application.Exit();

        }

        OleDbConnection con=new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=db.mdb");
        OleDbCommand cmd;
        OleDbDataAdapter da, dal;
        DataSet ds, dls;
        public static string yol;




        int secilisatir;

        private void dta_grid_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            secilisatir = e.RowIndex;
            lbl_id.Text = dls.Tables["kisi"].Rows[secilisatir]["id_kisi"].ToString();
            lbl_name.Text= dls.Tables["kisi"].Rows[secilisatir]["ad_soyad"].ToString();
            lbl_bol.Text = dls.Tables["kisi"].Rows[secilisatir]["bolum_id"].ToString();
            lbl_tel.Text = dls.Tables["kisi"].Rows[secilisatir]["telefon"].ToString();
            lbl_email.Text= dls.Tables["kisi"].Rows[secilisatir]["email"].ToString();

        }

        private void doldur()
        {
            string txtkişi = "select * from kisi";
            dal = new OleDbDataAdapter(txtkişi, con);
            dls = new DataSet();
            con.Open();
            dal.Fill(dls, "kisi");
            con.Close();

            dta_grid.DataSource = dls.Tables["kisi"];

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string arama = "select * From kisi where ad_soyad like '" + textBox1.Text + "%'";
            baglantı(arama);
        }

        int grupid;
            
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {


            try
            {
                grupid = Convert.ToInt32(comboBox1.SelectedValue.ToString());
                string group = "select * From kisi where bolum_id=" + grupid;
                baglantı(group);
            }
            catch
            {

             
            }

            
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dbDataSet.bolum' table. You can move, or remove it, as needed.
            this.bolumTableAdapter.Fill(this.dbDataSet.bolum);

            doldur();


        }

        private void baglantı( string txt)
        {
            
            dal = new OleDbDataAdapter(txt, con);
            dls = new DataSet();
            con.Open();
            dal.Fill(dls, "kisi");
            con.Close();

            dta_grid.DataSource = dls.Tables["kisi"];

        }
    }
}
