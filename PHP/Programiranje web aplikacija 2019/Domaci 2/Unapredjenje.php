<?php



abstract class Unapredjenje{ 

    protected $naziv;
    protected $cena;

    public function __construct($naziv,$cena){

        $this->naziv = $naziv;
        $this->cena = $cena;
    }

    public abstract function zavrseno(Grad $grad);

}
