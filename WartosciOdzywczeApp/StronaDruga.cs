using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;

namespace WartosciOdzywczeApp
{
    public partial class StronaDruga : Form
    {
        public StronaDruga()
        {
            InitializeComponent();
        }

        public void wprowadzProduktToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void StronaDruga_Load(object sender, EventArgs e)
        {

        }

        private void StronaDruga_FormClosed(object sender, FormClosedEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(textBoxNazwa.Text))
                try
                {
                    float weglo, bialka, tluszcze, blonik, kalorie;

                    float.TryParse(textBoxWeglo.Text.Replace(',', '.'), out weglo);
                    float.TryParse(textBoxBialka.Text.Replace(',', '.'), out bialka);
                    float.TryParse(textBoxTluszcze.Text.Replace(',', '.'), out tluszcze);
                    float.TryParse(textBoxBlonik.Text.Replace(',', '.'), out blonik);
                    float.TryParse(textBoxKalorie.Text.Replace(',', '.'), out kalorie);
                    Produkt produkt = new Produkt(textBoxNazwa.Text, weglo, bialka, tluszcze, blonik, kalorie);
                    zapisz_produkt(produkt.Nazwa, produkt.Weglowodany, produkt.Bialka, produkt.Tluszcze, produkt.Blonik);
                    label7.Text = "Udało się dodać produkt";

                }
                catch
                {
                    MessageBox.Show("Nie udało się dodać produktu!");
                }
            else
                MessageBox.Show("Nie udało się dodać produktu!\n Nazwa nie może być pusta!");
        }

        private void zapisz_produkt(string nazwa, float weglo, float bialka, float tluszcze, float blonik)
        {
            DB_con conection = new DB_con();
            SQLiteCommand sql_cmd2 = conection.Polacz();
            sql_cmd2.CommandText = $"INSERT INTO Produkty (nazwa, weglowdany, bialka, tluszcze, blonnik) VALUES ('{nazwa}', {weglo}, {bialka}, {tluszcze}, {blonik});";
            SQLiteDataReader kursor1 = sql_cmd2.ExecuteReader();
            conection.Rozlacz();
        }

        private void textBoxNazwa_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
