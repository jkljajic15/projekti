using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domaci_zadatak_2
{
    interface iBazna
    {
        string imeProizvoda { get; set; }
        string proizvodjac { get; set; }
        float cena { get; set; }
        int garancija { get; set; }

        void Prodaj();
        void Dostavi();
        void Promovisi();
        void UnosTeksta();

    }

    interface iGamingKonzole
    {
        string hardDisc { get; set; }
        string procesor { get; set; }
        string ram { get; set; }

        void IgrajIgricu();
        void SlusajMuziku();
        void GledajFilm();
    }

    interface iDesktopRacunari
    {
        string hdd { get; set; }
        string cpu { get; set; }
        string gpu { get; set; }
        string ram { get; set; }

        void PokreniProgram();
        void IgrajIgricu();
        void Surfuj();
        void SlusajMuziku();
        
    }

    interface iLaptopRacunari
    {
        string dijagonala { get; set; }
        string cpu { get; set; }
        string gpu { get; set; }

        void PokreniProgram();
        void IgrajIgricu();
        void SlusajMuziku();
        void Surfuj();
        
    }

    interface iEbookCitaci
    {
        string dijagonala { get; set; }
        string memorija { get; set; }
        string tezina { get; set; }

        void Citaj();
        void Surfuj();
        
    }

    interface iTableti
    {
        string dijagonala { get; set; }
        string rezolucija { get; set; }
        string cpu { get; set; }

        void PokreniProgram();
        void IgrajIgricu();
        void SlusajMuziku();
        void Surfuj();
        
    }

    interface iSingleboardRacunari
    {
        string dijagonala { get; set; }
        string cpu { get; set; }
        string ram { get; set; }

        //primer metoda za bankomat
        void Isplati();
        void CitajKarticu();
    }

    interface iMobilniTelefoni
    {
        string kamera { get; set; }
        string memorija { get; set; }
        string dijagonala { get; set; }

        void Pozovi();
        void Slikaj();
        void SlusajMuziku();
    }
}
