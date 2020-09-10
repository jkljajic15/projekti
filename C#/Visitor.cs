using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Visitor
{
    // visitor primer sa dve klase MlecniProizvodi i Cigare na kojima cemo pomucu visitora izracunati cenu sa pdv-om 

    // interface ivisitor koji u sebi ima dve metode koje "posecuju" klase
    interface IVisitor
    {
        double Visit(MlecniProizvodi mp);
        double Visit(Cigare c);
    }

    // ivisitable sa metodom Accept koja "prihvata" "posetu" od Visit metode iz klase Porez
    interface IVisitable
    {
        double Accept(IVisitor visitor);
    }

    class MlecniProizvodi : IVisitable
    {
         public double cena;

        // metoda da bi videli cenu bez pdv
        public double dajMiCenu()
        {
            return this.cena;
        }

        public double Accept(IVisitor visitor)
        {
            // vracamo cenu sa pdv-om
            return visitor.Visit(this);
        }
    }

    class Cigare : IVisitable
    {
        public double cena;

        public double dajMiCenu()
        {
            return this.cena;
        }

        public double Accept(IVisitor visitor)
        {
            return visitor.Visit(this);
        }
    }

    class Porez : IVisitor
    {
        // racunanje cene sa pdv-om u metodi Visit
        public double Visit(MlecniProizvodi mlecniProizvodi)
        {
            Console.WriteLine("Cena mlecnog proizvoda sa pdv-om:");

            return mlecniProizvodi.dajMiCenu() * 0.1 + mlecniProizvodi.dajMiCenu();
        }

        public double Visit(Cigare cigare)
        {
            Console.WriteLine("Cena cigara sa pdv-om:");

            return cigare.dajMiCenu() * 0.2 + cigare.dajMiCenu();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // instanciranje i dodeljivanje vrednosti svojstvu cena
            var mleko = new MlecniProizvodi();
            mleko.cena = 89;
            var winston = new Cigare();
            winston.cena = 150;

            // ispis cena pre pdv-a
            Console.WriteLine("Cena mlecnog proizvoda bez pdv-a: \n{0}",mleko.dajMiCenu());
            Console.WriteLine("Cena cigara bez pdv-a: \n{0}", winston.dajMiCenu());

            // instanca klase porez
            var pdv = new Porez();

            // ispis i pozivanje visitora
            Console.WriteLine(pdv.Visit(mleko));
            Console.WriteLine(pdv.Visit(winston));


            Console.ReadKey();

        }
    }
}
