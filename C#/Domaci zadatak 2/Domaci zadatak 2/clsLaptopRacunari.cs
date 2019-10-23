using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domaci_zadatak_2
{
    class clsLaptopRacunari:clsBazna,iLaptopRacunari
    {
        private string _dijagonala;
        private string _cpu;
        private string _gpu;

        public string dijagonala
        {
            get { return _dijagonala; }
            set { _dijagonala = value; }
        }

        public string cpu
        {
            get { return _cpu; }
            set { _cpu = value; }
        }

        public string gpu
        {
            get { return _gpu; }
            set { _gpu = value; }
        }

        public void PokreniProgram()
        {
            Console.WriteLine("clsLaptopRacunari:PokreniProgram");
        }

        public void IgrajIgricu()
        {
            Console.WriteLine("clsLaptopRacunari:IgrajIgricu");
        }

        public void SlusajMuziku()
        {
            Console.WriteLine("clsLaptopRacunari:SlusajMuziku");
        }

        public void Surfuj()
        {
            Console.WriteLine("clsLaptopRacunari:Surfuj");
        }

        public override void UnosTeksta()
        {
            Console.WriteLine("clsLaptopRacunari:UnosTeksta");
        }
    }
}
