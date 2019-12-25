using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Windows.Forms;

namespace WartosciOdzywczeApp
{
	class DB_con
    {
        public static SQLiteConnection sql_con;
        private SQLiteCommand sql_cmd;
        public static string BazaDabychPlik = "baza.db";
        public static string BazaDanychOn = "Data Source=" + BazaDabychPlik + ";Version=3;New=False;Compress=True;";
        public SQLiteCommand Polacz()
        {
            try
            {
                sql_con = new SQLiteConnection(BazaDanychOn);
                sql_con.Open();
                sql_cmd = sql_con.CreateCommand();
            }
            catch
            {
                MessageBox.Show("Błąd otwarcia");
            }
            return sql_cmd;
        }
        public void Rozlacz()
        {
            try
            {
                sql_con.Close();
            }
            catch
            {
                MessageBox.Show("Błąd zamkniecia");
            }
        }

    }
}
