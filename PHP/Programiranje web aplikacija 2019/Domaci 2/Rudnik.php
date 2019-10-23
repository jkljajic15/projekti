<?php


class Rudnik extends Unapredjenje implements Potez, RadnoMesto{

    public function __construct($vrstaResursa){

        parent::__construct($naziv ='Rudnik'.$this->vrstaResursa = $vrstaResursa, $cena = 100); 

    }

    public function potez(Grad $grad){

        $resurs = $this->vrstaResursa; 
        $svota = 5;
        $grad->dodaj($resurs,$svota);

        echo "$resurs: + $svota <br>";
    }

    public function zavrseno(Grad $grad){

        echo 'Grad: '.$grad->getImeGrada().' je dobio rudnik za: '.$this->vrstaResursa.'<br>'; 
    }
    
    public function radi(Radnik $r , Grad $grad){

        $svota = $r->getSnaga();
        $resurs = $this->vrstaResursa;
        $grad->dodaj($resurs,$svota);
        echo'Radnik: '.$r->getIme().' proizveo: '.$resurs.' + '.$svota.'<br>';
    }
    
    public function getCena()
    {
        return $this->cena;
    }
}