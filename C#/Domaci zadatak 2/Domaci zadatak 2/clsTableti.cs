using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domaci_zadatak_2
{
    class clsTableti : clsBazna, iTableti
    {
        private string _dijagonala;
        private string _rezolucija;
        private string _cpu;

        public string dijagonala
        {
            get { return _dijagonala; }
            set { _dijagonala = value; }
        }

        public string rezolucija
        {
            get { return _rezolucija; }
            set { _rezolucija = value; }
        }

        public string cpu
        {
            get { return _cpu; }
            set { _cpu = value; }
        }

        public void PokreniProgram()
        {
            Console.WriteLine("clsTableti:PokreniProgram");
        }

        public void IgrajIgricu()
        {
            Console.WriteLine("clsTableti:IgrajIgricu");
        }

        public void SlusajMuziku()
        {
            Console.WriteLine("clsTableti:SlusajMuziku");
        }

        public void Surfuj()
        {
            Console.WriteLine("clsTableti:Surfuj");
        }

        public override void UnosTeksta()
        {
            Console.WriteLine("clsTableti:UnosTeksta");
        }
    }
}
