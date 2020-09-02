<?php
require_once 'Korisnik.php';
require_once 'TarifniPaket.php';
require_once 'TarifniDodatak.php';

class PostpaidKorisnik extends Korisnik
{
    private $prekoracenje;

    public function __construct($internetProvajder, $ime, $prezime, $adresa, $brUgovora, $tarifniPaket, $prekoracenje)
    {
        parent::__construct($internetProvajder, $ime, $prezime, $adresa, $brUgovora, $tarifniPaket);

        $this->prekoracenje = $prekoracenje;
    }

    public function ukupnoZaNaplatu()
    {
        $cenaPaketa = $this->tarifniPaket->getCenaPaketa();

        $cenaSvihTarifnihDodataka = 0;
        foreach ($this->tarifniDodaci as $dodatak) {
            $cenaSvihTarifnihDodataka += $dodatak->getCena();
        }
        return $cenaPaketa + $cenaSvihTarifnihDodataka + $this->prekoracenje;

    }

    public function surfuj(string $url, int $megabajta): bool
    {
        if ($this->tarifniPaket->isNeogranicenSaobracaj()) {

            $this->dodajListingUnos(new ListingUnos($url,$megabajta));

            $this->internetProvajder->zabeleziSaobracaj($this, $url, $megabajta);

            echo "Imam neogranicen surf<br>";
            return true;
        } else {
            foreach ($this->tarifniDodaci as $tarifniDodatak) {

                if (stripos($url, $tarifniDodatak->getTipDodatka()) !== false) {

                    $this->dodajListingUnos(new ListingUnos($url,$megabajta));

                    $this->internetProvajder->zabeleziSaobracaj($this, $url, $megabajta);

                    echo "Imam dodatak za neogranicen surf<br>";
                    return true;
                }
            }
            $brMegabajtaUPaketu = $this->tarifniPaket->getMegabajti();
            $preostalo = $brMegabajtaUPaketu - $megabajta;

            if ($preostalo < 0) {
                $this->prekoracenje += ($preostalo * -1 * $this->tarifniPaket->getCenaPoMegabaju());
            }

            $this->dodajListingUnos(new ListingUnos($url,$megabajta));

            $this->internetProvajder->zabeleziSaobracaj($this, $url, $megabajta);

            echo "Mb iz paketa: $brMegabajtaUPaketu, preostalo: $preostalo, prekoracenje: $this->prekoracenje<br>";
            return true;
        }
    }

    public function generisiRacun()
    {
        $brUgovora = $this->brUgovora;
        $ime = $this->ime;
        $prezime = $this->prezime;
        $cenaPaketa = $this->tarifniPaket->getCenaPaketa();

        echo "Br. ugovora: $brUgovora, ime: $ime, prezime: $prezime, cena paketa: $cenaPaketa Tarifni dodaci: {";

        foreach ($this->tarifniDodaci as $dodatak) {
            echo "{$dodatak->getTipdodatka()} - {$dodatak->getCena()} ";
        }

        echo "} Iznos prekoracenja: $this->prekoracenje, Ukupno za naplatu: {$this->ukupnoZaNaplatu()}<br>";
    }

    public function dodajTarifniDodatak(TarifniDodatak $tarifniDodatak)
    {
        if ($this->tarifniPaket->isNeogranicenSaobracaj()) {
            if ($tarifniDodatak->getTipDodatka() == 'IPTV')
                array_push($this->tarifniDodaci, $tarifniDodatak);
            elseif ($tarifniDodatak->getTipDodatka() == 'Fiksna_Telefonija')
                array_push($this->tarifniDodaci, $tarifniDodatak);
            else
                echo "Tarifni dodatak ne moze biti dodat <br>";

        } else {

            $prosledjenoImeDodatka = $tarifniDodatak->getTipDodatka();

            if (!in_array($prosledjenoImeDodatka, $this->tarifniDodaci)) {

                array_push($this->tarifniDodaci, $tarifniDodatak);
            } else {
                echo "Greska pri dodavanju tarifnog dodatka $prosledjenoImeDodatka<br>";
            }
        }


    }

}