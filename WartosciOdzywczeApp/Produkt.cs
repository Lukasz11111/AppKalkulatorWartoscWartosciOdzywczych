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

        public Produkt(string nazwa, float weglowodany, float bialka, float tluszcze, float blonik)
        {
            this.nazwa = nazwa;
            this.Weglowodany = weglowodany;
            this.Bialka = bialka;
            this.Tluszcze = tluszcze;
            this.Blonik = blonik;
        }

        public string Nazwa { get => nazwa; set => nazwa = value; }
        public float Weglowodany { get => weglowodany; set => weglowodany = value; }
        public float Bialka { get => bialka; set => bialka = value; }
        public float Tluszcze { get => tluszcze; set => tluszcze = value; }
        public float Blonik { get => blonik; set => blonik = value; }
    }
}
