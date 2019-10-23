<?php


class Zidine extends Unapredjenje implements RadnoMesto{

    public function __construct(){
        
        parent::__construct($naziv = 'Zidine', $cena = 50);
    }

    public function zavrseno(Grad $grad){

        echo 'Izgradnja zidina je zavrsena.<br>';
        $grad->pojacajOdbranu(30);
    }

    public function radi(Radnik $r, Grad $grad){
        
        $grad->pojacajOdbranu($r->getSnaga());
        echo "Vrednost odbrane je: ".$grad->getOdbrana().'<br>'; 
    }

    public function getCena()
    {
        return $this->cena;
    }
}