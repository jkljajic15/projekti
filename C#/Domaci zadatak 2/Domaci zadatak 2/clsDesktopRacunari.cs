using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domaci_zadatak_2
{
    class clsDesktopRacunari : clsBazna, iDesktopRacunari
    {
        private string _hdd;
        private string _cpu;
        private string _gpu;
        private string _ram;

        public string hdd
        {
            get { return _hdd; }
            set { _hdd = value; }
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

        public string ram
        {
            get { return _ram; }
            set { _ram = value; }
        }

        public void PokreniProgram()
        {
            Console.WriteLine("clsDesktopRacunari:PokreniProgram");
        }

        public void IgrajIgricu()
        {
            Console.WriteLine("clsDesktopRacunari:IgrajIgricu");
        }

        public void SlusajMuziku()
        {
            Console.WriteLine("clsDesktopRacunari:SlusajMuziku");
        }

        public void Surfuj()
        {
            Console.WriteLine("clsDesktopRacunari:Surfuj");
        }

        public override void UnosTeksta()
        {
            Console.WriteLine("clsDesktopRacunari:UnosTeksta");
        }
    }
}
