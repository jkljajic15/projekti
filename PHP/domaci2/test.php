<?php
require_once 'TarifniPaket.php';
require_once 'IzradaListinga.php';
require_once 'InternetProvajder.php';
require_once 'TarifniDodatak.php';
require_once 'PostpaidKorisnik.php';
require_once 'PrepaidKorisnik.php';

$viber = new TarifniDodatak(20,'Viber');
$face = new TarifniDodatak(30,'Facebook');
$iptv = new TarifniDodatak(3000,'IPTV');
$fix = new TarifniDodatak(3000,'Fiksna_Telefonija');

$internetProvajder = new InternetProvajder('Vip');

$tarifniPaket = new TarifniPaket('Intarifa',20,2000,true,100,10);

$prepaidKorisnik = new PrepaidKorisnik($internetProvajder,'Jovan', 'Kljajic','asd',132,$tarifniPaket,300);
$prepaidKorisnik2 = new PrepaidKorisnik($internetProvajder,'Jovan2', 'Kljajic','asd',123,$tarifniPaket,200);

$postpaidKorisnik = new PostpaidKorisnik($internetProvajder,'Jovan','Kljajic','asd',324,$tarifniPaket,0);



//$prepaidKorisnik->dodajTarifniDodatak($viber);
//$prepaidKorisnik2->dodajTarifniDodatak($face);
//$prepaidKorisnik->getTarifniDodaci();
//var_dump($prepaidKorisnik2->getTarifniDodaci());
//$prepaidKorisnik2->surfuj('www.facebook.com',1);
//$prepaidKorisnik2->surfuj('www.facebook.com',1);
//$prepaidKorisnik2->surfuj('www.viber.com',1);
//$prepaidKorisnik2->surfuj('www.viber.com',100);
//$prepaidKorisnik->surfuj('www.facebook.com',1);
//$prepaidKorisnik->surfuj('www.facebook.com',1);
//var_dump($prepaidKorisnik->napraviListing());

//$postpaidKorisnik->dodajTarifniDodatak($iptv);
//$postpaidKorisnik->dodajTarifniDodatak($fix);
//$postpaidKorisnik->dodajTarifniDodatak($viber);
//$postpaidKorisnik->dodajTarifniDodatak($face);
//$postpaidKorisnik->surfuj('www.face.com',110);
//$postpaidKorisnik->surfuj('www.facebook.com',10);
//$postpaidKorisnik->surfuj('www.facebook.com',30);
//$postpaidKorisnik->ukupnoZaNaplatu();
//var_dump($postpaidKorisnik->getTarifniDodaci()); echo '<br>';
//$postpaidKorisnik->napraviListing();
//var_dump($postpaidKorisnik->napraviListing());
//$postpaidKorisnik->generisiRacun();

//$internetProvajder->dodajKorisnika($prepaidKorisnik);
//$internetProvajder->dodajKorisnika($prepaidKorisnik2);
//$internetProvajder->dodajKorisnika($postpaidKorisnik);
//$internetProvajder->prikazPrepaidKorisnika();
//$internetProvajder->prikazPostpaidKorisnika();
//$internetProvajder->generisiRacune();
