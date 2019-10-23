<?php


class Radnik extends Unapredjenje implements Potez{


    private $snaga;
    private $imeRadnika;

    public function __construct($snaga,$imeRadnika){

        parent::__construct($naziv = $imeRadnika,$cena = 50); 
        $this->imeRadnika = $imeRadnika;
        $this->snaga = $snaga;
    }

    public function getSnaga()
    {
        return $this->snaga;
    }

    public function getIme()
    {
        return $this->imeRadnika;
    }

    public function zavrseno(Grad $grad){

        echo 'Radnik: '.$this->imeRadnika.' je stigao u grad: '.$grad->getImeGrada().'<br>'; //getImeGrada
    }

    public function potez(Grad $grad){

        $obj = $grad->nadjiRadnoMesto();
        
        if(is_object($obj)){
            
            if($obj instanceof Rudnik){
                
                $obj->radi($this,$grad);
            }
            if($obj instanceof Zidine){
                
                $obj->radi($this,$grad);
            }

        }
        
    }

    public function getCena()
    {
        return $this->cena;
    }
}

