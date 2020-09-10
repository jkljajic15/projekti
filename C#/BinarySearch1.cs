using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinarySearch
{
    class Program
    {

         // prvi nacin binary search-a metodom divide and conqer
        static void Main(string[] args)
        {
            // inicjalizujemo niz, unosimo vrednosti
            int[] niz = { 1, 2, 4, 8, 26, 32 };

            // deklarisemo varijable koje su nam potrebne za resenje problema
            int min = 0;
            int max = niz.Length;
            int mid;

            Console.WriteLine("Unesite broj koji trazite u nizu: ");
            int vrednost = int.Parse(Console.ReadLine());

            while (min <= max)
            {
                try
                {
                    // sredinu niza smestamo u mid i sa njom poredimo
                    mid = (min + max) / 2;
                    //Console.WriteLine(mid);
                    if (niz[mid] == vrednost)
                    {
                        // vrednost pronadjena ako se nalazi u sredini niza, na indeksu 3
                        Console.WriteLine("Trazena vrednost broj {0} je na indeksu {1}.", vrednost, mid); 
                        break;
                    }
                    else if (niz[mid] > vrednost)
                    {
                        // ako je vrednost manja od sredine max pomeramo za jedan index u levo od sredine
                        max = mid - 1;
                    }
                    else if(niz[mid] < vrednost) // ako ovde stavimo else prijavljuje gresku, nisam siguran zasto.. iz tog razloga stoji else if
                    {
                        // ako nam je vrednost veca od sredine min pomeramo za jedno mesto u desno od sredine
                        min = mid + 1;
                    }
                }
                catch
                {
                    // ovde hvatamo exeption ako se broj ne nalazi u nizu, nije najbolje resenje ali moze da soluzi za ovaj primer
                    Console.WriteLine("Vrednost nije pronadjena.");
                    break;
                }   
            }
            Console.ReadKey();
        }
    }
}