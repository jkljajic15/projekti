using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domaci_zadatak_2
{
    class clsGamingKonzole : clsBazna, iGamingKonzole
    {
        private string _hardDisc;
        private string _procesor;
        private string _ram;

        public string hardDisc
        {
            get { return _hardDisc; }
            set { _hardDisc = value; }
        }

        public string procesor
        {
            get { return _procesor; }
            set { _procesor = value; }
        }

        public string ram
        {
            get { return _ram; }
            set { _ram = value; }
        }

        public void IgrajIgricu()
        {
            Console.WriteLine("clsGamingKonzole:IgrajIgicu");
        }

        public void SlusajMuziku()
        {
            Console.WriteLine("clsGamingKonzole:SlusajMuziku");
        }

        public void GledajFilm()
        {
            Console.WriteLine("clsGamingKonzole:GledajFilm");
        }

        public override void UnosTeksta()
        {
            Console.WriteLine("clsGamingKonzole:UnosTeksta");
        }
    }
}
