using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domaci_zadatak_2
{
    class Program
    {
        static void Main(string[] args)
        {
            // instanciranje bazna klasa
            clsBazna b = new clsBazna();
                       
            // bazne metode
            b.Dostavi();
            b.Prodaj();
            b.Promovisi();

            //instanciranje izvedene klase
            clsGamingKonzole gk = new clsGamingKonzole();

            //bazna svojstva 
            gk.imeProizvoda = "xbox";
            gk.proizvodjac = "Microsoft";
            gk.cena = 50000f;
            gk.garancija = 2;

            //svojstva izvedene klase
            gk.hardDisc = "1TB";
            gk.procesor = "3.2GHZ";
            gk.ram = "8GB";

            //metode izvedene klase
            gk.IgrajIgricu();
            gk.GledajFilm();
            gk.SlusajMuziku();

            // override metoda izvedene klase
            gk.UnosTeksta();

        }
    }
}
