using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domaci_zadatak_2
{
    class clsMobilniTelefoni:clsBazna,iMobilniTelefoni
    {
        private string _kamera;
        private string _memorija;
        private string _dijagonala;

        public string kamera
        {
            get { return _kamera; }
            set { _kamera = value; }
        }

        public string memorija
        {
            get { return _memorija; }
            set { _memorija = value; }
        }

        public string dijagonala
        {
            get { return _dijagonala; }
            set { _dijagonala = value; }
        }

        public void Pozovi()
        {
            Console.WriteLine("clsMobilniTelefoni:Pozovi");
        }

        public void Slikaj()
        {
            Console.WriteLine("clsMobilniTelefoni:Slikaj");
        }

        public void SlusajMuziku()
        {
            Console.WriteLine("clsMobilniTelefoni:SlusajMuziku");
        }

        public override void UnosTeksta()
        {
            Console.WriteLine("clsMobilniTelefoni:UnosTeksta");
        }
    }
}
