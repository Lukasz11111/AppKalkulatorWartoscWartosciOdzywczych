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
		public Form1()
		{
			InitializeComponent();
            test();


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
	}
}
