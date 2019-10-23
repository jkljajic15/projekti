using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domaci_zadatak_2
{
    class clsEbookCitaci:clsBazna,iEbookCitaci
    {
        private string _dijagonala;
        private string _memorija;
        private string _tezina;

        public string dijagonala
        {
            get { return _dijagonala; }
            set { _dijagonala = value; }
        }

        public string memorija
        {
            get { return _memorija; }
            set { _memorija = value; }
        }

        public string tezina
        {
            get { return _tezina; }
            set { _tezina = value; }
        }

        public void Citaj()
        {
            Console.WriteLine("clsEbookCitaci:Citaj");
        }

        public void Surfuj()
        {
            Console.WriteLine("clsEbookCitaci:Surfuj");
        }

        public override void UnosTeksta()
        {
            Console.WriteLine("clsEbookCitaci:UnosTeksta");
        }
    }
}
