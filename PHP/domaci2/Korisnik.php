<?php
require_once 'InternetProvajder.php';
require_once 'TarifniPaket.php';
require_once 'ListingUnos.php';

abstract class Korisnik implements IzradaListinga
{
    protected $internetProvajder;
    protected $ime;
    protected $prezime;
    protected $adresa;
    protected $brUgovora;
    protected $tarifniDodaci = [];
    protected $tarifniPaket;
    protected $listaListingUnosa = [];

    public function __construct(InternetProvajder $internetProvajder,string $ime,string $prezime,string $adresa,int $brUgovora,TarifniPaket $tarifniPaket)
    {
        $this->internetProvajder = $internetProvajder;
        $this->ime = $ime;
        $this->prezime = $prezime;
        $this->adresa = $adresa;
        $this->brUgovora = $brUgovora;
        $this->tarifniPaket=$tarifniPaket;
    }

    public function dodajListingUnos(ListingUnos $listingUnos){

        foreach($this->listaListingUnosa as $listing){
            if ($listingUnos->getUrl() == $listing->getUrl()){

                $listing->dodajMegabajte($listingUnos->getMegabajti());
                return;
            }
        }


        array_push($this->listaListingUnosa,$listingUnos);
    }

    public function napraviListing():string {


        $megabajti = array();

        foreach ($this->listaListingUnosa as $key => $listing){

            $megabajti[$key] = $listing->getMegabajti();
        }
        array_multisort($megabajti,SORT_DESC, $this->listaListingUnosa);

        $string="";
        foreach ($this->listaListingUnosa as $listing){
            $string .= "Url: {$listing->getUrl()} Potroseni megabajti: {$listing->getMegabajti()}\r\n<br>";

        }
            return  $string;
    }

    public abstract function surfuj(string $url, int $megabajta):bool;

    public abstract function dodajTarifniDodatak(TarifniDodatak $tarifniDodatak);

    /**
     * @return mixed
     */
    public function getBrUgovora()
    {
        return $this->brUgovora;
    }

    /**
     * @return string
     */
    public function getPrezime(): string
    {
        return $this->prezime;
    }

    /**
     * @return string
     */
    public function getIme(): string
    {
        return $this->ime;
    }

    /**
     * @return array
     */
    public function getTarifniDodaci(): array
    {
        return $this->tarifniDodaci;
    }


    /**
     * @return string
     */
    public function getTarifniPaketIme(): string
    {
        return $this->tarifniPaket->getImePaketa();
    }

}