<?php


class TarifniDodatak
{
    private $cena;
    private $tipDodatka;


    /**
     * TarifniDodatak constructor.
     * @param float $cena
     * @param string $tipDodatka
     */
    public function __construct($cena, $tipDodatka)
    {
        $niz = ['Facebook', 'Instagram', 'IPTV', 'Twitter', 'Viber', 'Fiksna_Telefonija'];

        if (!in_array($tipDodatka, $niz)) {

            echo'Tarifni dodatak sa unetim imenom ne postoji.';
        } else {

            $this->cena = $cena;
            $this->tipDodatka = $tipDodatka;
        }
    }

    /**
     * @return string
     */
    public function getTipDodatka(): string
    {
        return $this->tipDodatka;
    }

    /**
     * @return float
     */
    public function getCena(): float
    {
        return $this->cena;
    }

}