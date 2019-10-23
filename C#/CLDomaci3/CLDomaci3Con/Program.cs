using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLDomaci3Con
{
    class Program
    {
        static void Main(string[] args)
        {
            CLDomaci3.Class1 x = new CLDomaci3.Class1();

            Console.WriteLine("Uneti putanju fajla za citanje: ");
            x.putanja = Console.ReadLine();
            Console.WriteLine(x.Read(x.putanja));

            Console.WriteLine("Izmeni sadrzaj: ");
            x.sadrzaj = Console.ReadLine();

            Console.WriteLine("Uneti putanju fajla za snimanje: ");
            x.putanja = Console.ReadLine();
            x.Save(x.sadrzaj, x.putanja);

            if (x.Save(x.sadrzaj,x.putanja))
            {
                Console.WriteLine("Fajl je snimljen!");
            }
            else
            {
                Console.WriteLine("Doslo je do greske!");
            }

            Console.ReadKey();
        }
    }
}
