using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domaci_zadatak_2
{
    public class clsBazna : iBazna
    {
        private string _imeProizvoda;
        private string _proizvodjac;
        private float _cena;
        private int _garancija;

        public string imeProizvoda
        {
            get { return _imeProizvoda; }
            set
            {
                if (value.Length > 30)
                {
                    throw new Exception("Ime proizvoda je predugacko");
                }
                else if (value.Trim() == "")
                {
                    throw new Exception("Unesi ime proizvoda!");
                }
                else
                {
                    _imeProizvoda = value;
                }
            }
        }

        public string proizvodjac
        {
            get { return _proizvodjac; }
            set
            {
                if (value.Length > 20)
                {
                    throw new Exception("Ime proizvodjaca je predugacko");
                }
                else if (value.Trim() == "")
                {
                    throw new Exception("Unesi ime proizvodjaca!");
                }
                else
                {
                    _proizvodjac = value;
                }
            }
        }

        public float cena
        {
            get { return _cena; }
            set
            {
                if (!(value is float))
                {
                    throw new Exception("Pogresan tip podatka je unet");
                }
                else
                {
                    _cena = value;
                }
            }
        }

        public int garancija
        {
            get { return _garancija; }
            set
            {
                if(value < 1 || value > 5 )
                {
                    throw new Exception("Garancija moze biti od 1 do 5 godina");
                }
                else
                {
                    _garancija = value;
                }
            }
        }

        public void Prodaj()
        {
            Console.WriteLine("clsBazna:Prodaj");
        }

        public void Dostavi()
        {
            Console.WriteLine("clsBazna:Dostavi");
        }

        public void Promovisi()
        {
            Console.WriteLine("clsBazna:Promovisi");
        }

        public virtual void UnosTeksta() // metoda za override
        {
            Console.WriteLine("clsBazna:UnosTeksta"); 
        }
    }
}
