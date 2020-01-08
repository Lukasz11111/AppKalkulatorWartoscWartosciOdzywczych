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
    public partial class Przelicz : Form
    {
        List<Produkt> produkty;
        List<FlowLayoutPanel> panele_produktow;
        public Przelicz()
        {
            InitializeComponent();
            flowLayoutPanel2.Controls.Add(button_add());
            produkty =  lista_produktow();
            panele_produktow = new List<FlowLayoutPanel>();
        }

      private  Button button_add()
        {
            Button dodaj= new Button();
            dodaj.Size = new Size(40, 20);
            dodaj.Text = "ADD";
            dodaj.Click += new EventHandler(button_Click);
            return dodaj;
        }
        protected void button_Click(object sender, EventArgs e)
        {
            Button button = sender as Button;
            flowLayoutPanel2.Controls.Add(panel_produktow());
            flowLayoutPanel2.Controls.Add(button_add());
           button.Hide();
        }
     private   FlowLayoutPanel panel_produktow()
        {
            FlowLayoutPanel panel = new FlowLayoutPanel();
            panel.Size = new Size(280, 30);
            panel.Controls.Add(combo_produkty());
            panel.Controls.Add(box_gramatura());
            panel.Controls.Add(label_produktu());
            panele_produktow.Add(panel);
            return panel;

        }

        private TextBox box_gramatura()
        {
            TextBox box = new TextBox();
            box.Size = new Size(28, 80);
            return box;

        }

        private Label label_produktu()
        {
            Label label = new Label();
            label.Text = " gram produktu";
            label.Margin = new Padding(0, 5, 0, 0);
            return label;

        }
        private  ComboBox combo_produkty()
        {
            List<Produkt> produkty_ = new List<Produkt>();

            foreach(Produkt produkt in produkty)
            {
                produkty_.Add(produkt);
            }
            ComboBox combo = new ComboBox();
            combo.Text = "Wybierz Produkt";
            combo.DataSource = produkty_;
            combo.DisplayMember = "nazwa";
            combo.DropDownStyle = ComboBoxStyle.DropDownList;
            return combo;
        }

        private List<Produkt> lista_produktow()
        {
            List<Produkt> produkts = new List<Produkt>();
               DB_con conection = new DB_con();
            SQLiteCommand sql_cmd2 = conection.Polacz();
            string nazwa = null;
            sql_cmd2.CommandText = "SELECT * FROM Produkty;";
            SQLiteDataReader kursor1 = sql_cmd2.ExecuteReader();
            while (kursor1.Read())
            {
                Produkt produkt = new Produkt(kursor1.GetString(1),kursor1.GetFloat(2), kursor1.GetFloat(3), kursor1.GetFloat(4), kursor1.GetFloat(5));
                produkts.Add(produkt);


            }
            //MessageBox.Show(produkts[1].Nazwa);
            conection.Rozlacz();
            return produkts;
        }




        private void wprowadzProduktToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<Produkt> produkty_lista = new List<Produkt>();
            float weglo = 0, bialka = 0, tluszcze = 0, blonik = 0, gramatura = 0;

            foreach (FlowLayoutPanel panel in panele_produktow)
            {
                float gramatura_produktu = 0, mnoznik_produktu = 0;
                float.TryParse((panel.Controls[1] as TextBox).Text, out gramatura_produktu);
                gramatura += gramatura_produktu;
                mnoznik_produktu = gramatura_produktu / 100;

                Produkt produkt = (panel.Controls[0] as ComboBox).SelectedItem as Produkt;

                produkt.Weglowodany_rzeczywista_ilosc= produkt.Weglowodany * mnoznik_produktu;
                produkt.Bialka_rzeczywista_ilosc = produkt.Bialka * mnoznik_produktu;
                produkt.Tluszcze_rzeczywista_ilosc = produkt.Tluszcze * mnoznik_produktu;
                produkt.Blonik_rzeczywista_ilosc = produkt.Blonik * mnoznik_produktu;

                weglo += produkt.Weglowodany * mnoznik_produktu;
                bialka += produkt.Bialka * mnoznik_produktu;
                tluszcze += produkt.Tluszcze * mnoznik_produktu;
                blonik += produkt.Blonik * mnoznik_produktu;
                produkty_lista.Add(produkt);
            }
            string podsumowanie = "Węglowodany: " + weglo.ToString() + " \n"
                + "Białka: " + bialka.ToString() + " \n"
                + "Tłuszcze: " + tluszcze.ToString() + " \n"
                + "Blonnik: " + blonik.ToString() + " \n" +
                "Chcesz zobaczyć szczegóły?";
            const string caption = "Przelicznik";
            var result = MessageBox.Show(podsumowanie, caption,
                                MessageBoxButtons.OKCancel,
                                MessageBoxIcon.Information);

            if (result == DialogResult.OK)
            {
                string message = "";
                foreach(Produkt produkt in produkty_lista)
                {
                    message += $" {produkt.Nazwa}\n" +
                        $"Weglowodany: {produkt.Weglowodany_rzeczywista_ilosc} g " +
                        $"Białka: {produkt.Bialka_rzeczywista_ilosc} g " +
                        $"Tłuszecze: {produkt.Tluszcze_rzeczywista_ilosc} g " +
                        $"Błoniki: {produkt.Blonik_rzeczywista_ilosc} g\n\n";
                }
                MessageBox.Show(message, "Szczegół",
                               MessageBoxButtons.OK,
                               MessageBoxIcon.None);

            }

        }

        private void flowLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
