using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinarySearchGenerics
{
    class Program
    {
        // resenje problema koriscenjem Liste iz generic kolekcije
        static void Main(string[] args)
        {
            // pravimo listu i u nju cemo smestiti random brojeve
            var listaBrojeva = new List<int>();

            // za to nam treba instanca random klase
            var rand = new Random();

            // brojIzListe nam je potreban za poredjenje, da bi izbegli iste brojeve u listi
            int brojIzListe = 0;

            for (int i = 0; i < 10; i++)
            {
                brojIzListe = rand.Next(100);

                // ovaj nacin provere koriscenjem Contains() metode postaje sve sporiji kako lista raste po velicini
                // jer mora da proveri svaki clan liste
                if (!listaBrojeva.Contains(brojIzListe)) 
                {
                    listaBrojeva.Add(rand.Next(100));
                }
                
            }

            // sortiranje liste da bi bilo moguce uraditi binary search
            listaBrojeva.Sort();

            Console.WriteLine("Brojevi u listi su:");
            foreach (var item in listaBrojeva)
            {
                // ispis liste
                Console.WriteLine(item);
            }

            Console.WriteLine("Koji broj trazite:");

            // koverzija stringa u int jer readline prima string
            int trazeniBroj = Convert.ToInt32(Console.ReadLine());

            if (listaBrojeva.Contains(trazeniBroj))
            {
                //ispis broja i njegovog indeksa u slucaju da se nalazi u listi
                int index = listaBrojeva.BinarySearch(trazeniBroj);
                Console.WriteLine("Trazeni broj {0} je pronadjen na indeksu {1}!",trazeniBroj,index);
            }
            else
            {
                //ako se broj ne nalazi u listi
                Console.WriteLine("Trazeni broj nije pronadjen.");
            }
        }
    }
}
