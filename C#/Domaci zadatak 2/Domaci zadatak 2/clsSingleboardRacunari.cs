using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domaci_zadatak_2
{
    class clsSingleboardRacunari:clsBazna,iSingleboardRacunari
    {
        private string _dijagonala;
        private string _cpu;
        private string _ram;

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

        public string ram
        {
            get { return _ram; }
            set { _ram = value; }
        }

        public void Isplati()
        {
            Console.WriteLine("clsSingleboardRacunari:Isplati");
        }

        public void CitajKarticu()
        {
            Console.WriteLine("clsSingleboardRacunari:CitajKarticu");
        }

        public override void UnosTeksta()
        {
            Console.WriteLine("clsSingleboardRacunari:UnosTeksta");
        }
    }
}
