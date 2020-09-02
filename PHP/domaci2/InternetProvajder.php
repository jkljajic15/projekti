<?php
require_once 'Korisnik.php';
require_once 'PrepaidKorisnik.php';
require_once 'PostpaidKorisnik.php';
require_once 'ListingUnos.php';

class InternetProvajder
{
    private $ime;
    private $listaKorisnika = [];

    public function __construct(string $ime)
    {
        $this->ime = $ime;
    }

    public function generisiRacune()
    {
        foreach($this->listaKorisnika as $korisnik){
            if ($korisnik instanceof PostpaidKorisnik){
                $korisnik->generisiRacun();
            }
        }
    }

    public function zabeleziSaobracaj(Korisnik $korisnik, string $url, int $mb)
    {
        $brUgovora = $korisnik->getBrUgovora();
        echo "Br. ugovora: $brUgovora, poseceni url: $url, potroseno megabajta: $mb <br> ";
    }

    public function prikazPrepaidKorisnika()
    {
        foreach ($this->listaKorisnika as $prepaidKorisnik) {

            if ($prepaidKorisnik instanceof PrepaidKorisnik) {
                $brUgovora = $prepaidKorisnik->getBrUgovora();
                $ime = $prepaidKorisnik->getIme();
                $prezime = $prepaidKorisnik->getPrezime();
                $stanjeKredita = $prepaidKorisnik->getKredit();
                $tarifniDodaci = implode(", ", $prepaidKorisnik->getTarifniDodaci());

                echo "Br ugovora: $brUgovora , Ime: $ime , Prezime: $prezime, Stanje kredita: $stanjeKredita, Tarifni dodaci: $tarifniDodaci<BR>";
            }
        }
    }

    public function prikazPostpaidKorisnika()
    {
        foreach ($this->listaKorisnika as $postpaidKorisnik) {

            if ($postpaidKorisnik instanceof PostpaidKorisnik) {
                $brUgovora = $postpaidKorisnik->getBrUgovora();
                $ime = $postpaidKorisnik->getIme();
                $prezime = $postpaidKorisnik->getPrezime();
                $tarfniPaket = $postpaidKorisnik->getTarifniPaketIme();
                echo "Br ugovora: $brUgovora , Ime: $ime , Prezime: $prezime, Tarifni paket: $tarfniPaket Tarifni dodaci: { ";

                foreach ($postpaidKorisnik->getTarifniDodaci() as $dodatak){
                    echo " :{$dodatak->getTipDodatka()}: ";
                }

                echo " }<br>";
            }
        }
    }

    public function dodajKorisnika(Korisnik $korisnik)
    {
        array_push($this->listaKorisnika, $korisnik);
    }

}