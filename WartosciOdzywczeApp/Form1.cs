using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace WartosciOdzywczeApp
{
	public partial class Form1 : Form
	{
        Teksty statyczneTeksty = new Teksty();
        
        public Form1()
		{
			InitializeComponent();
            label1.Text = statyczneTeksty.label_o_programie();
            



        }
        

        private void test()
        {
            DB_con conection = new DB_con();
            SQLiteCommand sql_cmd2 =  conection.Polacz();
            string nazwa = null;
            sql_cmd2.CommandText= "SELECT nazwa FROM Produkty WHERE id=1;";
            SQLiteDataReader kursor1 = sql_cmd2.ExecuteReader();
            while (kursor1.Read())
            {
                nazwa = kursor1.GetString(0);
            }
            MessageBox.Show(nazwa);
            conection.Rozlacz();
        }


		private void Form1_Load(object sender, EventArgs e)
		{

		}

        private void wprowadzProduktToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StronaDruga stronaDruga = new StronaDruga();
            stronaDruga.Location = this.Location;
            stronaDruga.StartPosition = FormStartPosition.Manual;
            stronaDruga.FormClosing += delegate { this.Show(); }; 
            stronaDruga.Show();
            this.Hide();
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void przeliczToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Przelicz przelicz = new Przelicz();
            przelicz.Location = this.Location;
            przelicz.StartPosition = FormStartPosition.Manual;
            przelicz.FormClosing += delegate { this.Show(); };
            przelicz.Show();
            this.Hide();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
