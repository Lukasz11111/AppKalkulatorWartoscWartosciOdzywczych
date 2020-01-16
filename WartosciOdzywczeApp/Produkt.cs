using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WartosciOdzywczeApp
{
    class Produkt
    {
        private string nazwa;
        private float weglowodany;
        private float bialka;
        private float tluszcze;
        private float blonik;
        private float kalorie;

        private float weglowodany_rzeczywista_ilosc;
        private float bialka_rzeczywista_ilosc;
        private float tluszcze_rzeczywista_ilosc;
        private float blonik_rzeczywista_ilosc;
        private float kalorie_rzeczywista_ilosc;

        public Produkt(string nazwa, float weglowodany, float bialka, float tluszcze, float blonik, float kalorie)
        {
            this.nazwa = nazwa;
            this.Weglowodany = weglowodany;
            this.Bialka = bialka;
            this.Tluszcze = tluszcze;
            this.Blonik = blonik;
            this.Kalorie = kalorie;

        }

        public string Nazwa { get => nazwa; set => nazwa = value; }
        public float Weglowodany { get => weglowodany; set => weglowodany = value; }
        public float Bialka { get => bialka; set => bialka = value; }
        public float Tluszcze { get => tluszcze; set => tluszcze = value; }
        public float Blonik { get => blonik; set => blonik = value; }
        public float Kalorie { get => kalorie; set => kalorie = value; }
        public float Kalorie_rzeczywista_ilosc { get => kalorie_rzeczywista_ilosc; set => kalorie_rzeczywista_ilosc = value; }
        public float Weglowodany_rzeczywista_ilosc { get => weglowodany_rzeczywista_ilosc; set => weglowodany_rzeczywista_ilosc = value; }
        public float Bialka_rzeczywista_ilosc { get => bialka_rzeczywista_ilosc; set => bialka_rzeczywista_ilosc = value; }
        public float Tluszcze_rzeczywista_ilosc { get => tluszcze_rzeczywista_ilosc; set => tluszcze_rzeczywista_ilosc = value; }
        public float Blonik_rzeczywista_ilosc { get => blonik_rzeczywista_ilosc; set => blonik_rzeczywista_ilosc = value; }
    }
}
