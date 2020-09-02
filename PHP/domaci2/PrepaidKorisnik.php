<?php

require_once 'Korisnik.php';
require_once 'InternetProvajder.php';
require_once 'TarifniPaket.php';
require_once 'TarifniDodatak.php';

class PrepaidKorisnik extends Korisnik
{
    private $kredit;

    private $niz = ['Facebook', 'Instagram', 'Twitter', 'Viber'];

    public function __construct(InternetProvajder $internetProvajder, $ime, $prezime, $adresa, $brUgovora, TarifniPaket $tarifniPaket, $kredit)
    {
        parent::__construct($internetProvajder, $ime, $prezime, $adresa, $brUgovora, $tarifniPaket);
        $this->kredit = $kredit;
    }

    public function dopuniKredit(float $kredit)
    {
        $this->kredit += $kredit;
        echo "Kredit je dopunjen. Novo stanje: $this->kredit<br>";
    }

    public function surfuj(string $url, int $megabajta): bool
    {

        foreach($this->tarifniDodaci as $tarifniDodatak){
            if (stripos($url,$tarifniDodatak)!== false){

                $this->dodajListingUnos(new ListingUnos($url,$megabajta));

                $this->internetProvajder->zabeleziSaobracaj($this,$url,$megabajta);
                return true;
            }
        }

        $cenaPoMegabajtu = $this->tarifniPaket->getCenaPoMegabaju();
        $potrosenKredit = $megabajta * $cenaPoMegabajtu;

        if ($this->kredit - $potrosenKredit > 0) {
            $this->kredit -= $potrosenKredit;
            echo "skinuto: $potrosenKredit, Novo stanje kredita: {$this->getKredit()} <br>";
            return true;
        } else{
            echo 'Nema kredita za surf.<br>';
            return false;
        }
    }

    public function dodajTarifniDodatak(TarifniDodatak $tarifniDodatak)
    {
        $cenaDodatka = $tarifniDodatak->getCena();
        $tipDodatka = $tarifniDodatak->getTipDodatka();

        if (in_array($tipDodatka, $this->niz)) {
            if ($this->kredit - $cenaDodatka >= 0) {
                array_push($this->tarifniDodaci, $tipDodatka);
                echo "Dodatak $tipDodatka je uspesno dodat <BR>";

                $k = array_search($tipDodatka, $this->niz);
                unset($this->niz[$k]);
            } else {
                echo "Nemate dovoljno kredita za dodatak<BR>";
            }
        } else {
            echo "Greska pri dodadavanju dodatka <BR>";
        }
    }


    /**
     * @return float
     */
    public function getKredit(): float
    {
        return $this->kredit;
    }

}