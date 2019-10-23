<?php

require 'interface.php';
require 'Grad.php';
require 'Unapredjenje.php';
require 'Radnik.php';
require 'Zidine.php';
require 'Rudnik.php';

$bg = new Grad('Beograd',["Drvo" => 500,"Kamen" => 500,"Zlato" => 500]);
$pera = new Radnik(10,'Pera');
$zika = new Radnik(10,'Zika');
$mika = new Radnik(10,'Mika');
$zidine = new Zidine();
$rudnik1 = new Rudnik('Drvo');
var_dump($rudnik1);
$rudnik2 = new Rudnik('Kamen');
$rudnik3 = new Rudnik('Zlato');


$bg->dodajUProizvodnju($pera);
$bg->dodajUProizvodnju($zika);
$bg->dodajUProizvodnju($mika);
$bg->dodajUProizvodnju($zidine);
$bg->dodajUProizvodnju($rudnik1);
$bg->dodajUProizvodnju($rudnik2);
$bg->dodajUProizvodnju($rudnik3);


for ($i=0; $i < 10; $i++) { 
    $bg->odigrajPotez();
    $bg->ispisiStanje();
    echo'<br>';
    var_dump($rudnik1);
    echo'<br>';
}


