<?php

class Grad{


    protected $imeGrada;
    private $zalihe = array(
        "Drvo" => 0,
        "Kamen" => 0,
        "Zlato" => 0
    );
    private $nizUnapredjenja = array();
    private $redCekanja = array();
    protected $odbrana; 

    public function __construct($imeGrada,$zalihe,$odbrana=0){

        $this->imeGrada = $imeGrada;
        $this->zalihe = $zalihe;
        $this->odbrana = $odbrana;

    }

    public function dodajUProizvodnju(Unapredjenje $unapredjenje){

        $this->redCekanja[]=$unapredjenje;
    }

    public function nadjiRadnoMesto(){
        
        $ovajNiz = $this->nizUnapredjenja;
        $max = count($ovajNiz);
        
        if ($max > 0) {

            $ovajNiz = $this->nizUnapredjenja;
            $k = array_rand($ovajNiz);
            $izabranoUnapredjenje = $ovajNiz[$k];

            if ($izabranoUnapredjenje instanceof RadnoMesto) { 
                
                return $izabranoUnapredjenje;
            } 
            else {
                return NULL;
            }
        }
        
        
    }

    public function naplati($resurs,$svota){

        $rezultat = $resurs - $svota;
        if($rezultat >= 0 ){

            $this->setZlato($rezultat);
            return true;
        }
        else{

            return false;
        }
    }
    
    public function dodaj($resurs, $svota){

        $this->zalihe[$resurs] += $svota;
    }

    public function odigrajPotez(){

        $niz = $this->nizUnapredjenja;
        foreach($niz as $unapredjenje){

            if($unapredjenje instanceof Potez){
                
                $unapredjenje->potez($this);
            }
            
            
        }

        if(count($this->redCekanja) > 0){
            
            $prviClan = current($this->redCekanja);
            $cena = $prviClan->getCena();
            $budzet = $this->zalihe["Zlato"];
            $rezultat = $this->naplati($budzet,$cena);
             
            if($rezultat){

                $prviClan = current($this->redCekanja);
                $this->nizUnapredjenja[] = $prviClan;
                $prviClan->zavrseno($this);

                array_shift($this->redCekanja);
                
            }
        }
    }

    public function pojacajOdbranu($poeni){

        $this->odbrana += $poeni;
    }

    public function ispisiStanje(){

        echo 'Ime grada: '.$this->imeGrada .'<br>';
        foreach ($this->zalihe as $key => $value) {
            echo "Zalihe resursa: $key su: $value <br>";
        }
        echo "Snaga odbrane: $this->odbrana<br>";

    }

    public function getOdbrana()
    {
        return $this->odbrana;
    }

    public function getImeGrada()
    {
        return $this->imeGrada;
    }

    public function setZlato($novaKolicina)
    {
        $this->zalihe["Zlato"] = $novaKolicina;
    }
}