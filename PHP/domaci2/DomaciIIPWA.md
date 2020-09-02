### <span class="c30">Opis</span>
<span class="c9">Napisati PHP OOP aplikaciju kojom se opisuje rad internet provajdera u Srbiji. </span>

<span class="c9">Korisnici u okviru paketa mogu dobiti ograničenu ili neograničenu količinu podataka sa definisanom maksimalnom brzinom protoka po definisanoj ceni. Korisnici mogu biti prepaid ili postpaid korisnici. </span>

<span class="c9">Prepaid korisnike karakteriše unapred određen iznos kredita koji se može trošiti i dopunjavati. </span>

<span class="c9">Postpaid korisnike karakteriše tarifni paket koji ima svoju fiksnu cenu i podrazumeva određeni broj MB uz definisanu cenu po prekoračenju, ili neograničen internet saobraćaj. Ukoliko korisnik, koristeći usluge, provajdera prekorači definisano ograničenje u okviru paketa, obračunava mu se dodatna naplata koja se čuva u posebnom atributu prekoracenje. </span>

<span class="c9"></span>

<span class="c9">U jednom trenutku (na kraju meseca), provajder obračunava račun za naplatu postpaid korisnika, sabirajući fiksnu cenu paketa sa iznosom za koji je prekoračeno ograničenje. </span>

<span class="c9"></span>

<span class="c9">Svaki korisnik može kupiti određeni tarifni dodatak po fiksnoj ceni. Prepaid korisnici mogu kupiti dodatke koji omogućuju besplatan saobraćaj za neke sajtove. Postpaid korisnici mogu u okviru paketa dokupiti i dodatke za IPTV i besplatnu fiksnu telefoniju. </span>

<span class="c9">Svaka Internet sesija koju pojedinačni korisnik napravi se zabelezi kod provajdera. Takođe, za svakog korisnika se može izvući listing iskorišćenog saobraćaja po pojedinačnom sajtu.</span>

<span class="c9"></span>

<span class="c9">Potrebno je implementirati sledeće klase i interfejse:</span>

- <h4 id="h.scqsv25pvn0e" style="display: inline;"><span class="c4">InternetProvajder</span></h4>

<span class="c9">Karakterise je ime i ima listu/niz korisnika.</span>

- <h5 id="h.hezhp1rmvbgc" style="display: inline;"><span class="c19">generisiRacune( ) 1p</span></h5>

<span>Generiše račune za svakog postpaid korisnika, </span><span>pozivom metoda </span><span class="c23">[generisiRacun()](#h.3libqhiqva63)</span><span class="c9">&nbsp;nad njima i ispisuje sve račune.</span>

- <h5 id="h.4qf9yacxyuhb" style="display: inline;"><span class="c18">zabeleziSaobracaj(Korisnik korisnik, String url, int mb) </span></h5>

<span class="c9">Svaki uspeli internet saobraćaj se ispisuje na ekran, pozivom ove metode. Za svaku internet sesiju ispisuje broj ugovora korisnika, url koji je posećen i broj potrošenih megabajta. Ova metoda se poziva kada korisnik surfuje.</span>

- <h5 id="h.lyjz9fgncwu" style="display: inline;"><span class="c18">prikazPrepaidKorisnika( )</span></h5>

<span>I</span><span class="c9">spisuje svakog prepaid korisnika – broj ugovora, ime, prezime, stanje kredita i tarifne dodatke.</span>

- <h5 id="h.otfhnw56jtjw" style="display: inline;"><span class="c18">prikazPostpaidKorisnika( )</span></h5>

<span>I</span><span class="c9">spisuje svakog postpaid korisnika – broj ugovora, ime, prezime, tarifni paket i tarifne dodatke.</span>

- <h5 id="h.pmsbn7dyx1t3" style="display: inline;"><span class="c18">dodajKorisnika(Korisnik korisnik) </span></h5>

<span>D</span><span class="c9">odaje novog korisnika, pri čemu vodi računa da se korisnik sa istim brojem ugovora ne može dodati više puta.</span>

- <h4 id="h.xwlzh7oz2cul" style="display: inline;"><span class="c19">ListingUnos</span><span class="c10">&nbsp;</span></h4>

<span class="c9">Opisuju ga url i megabajti.</span>

- <h5 id="h.1uy8k94mfsv6" style="display: inline;"><span class="c18">dodajMegabajte(int megabajti)</span></h5>

<span>D</span><span class="c9">odaje zadati broj megabajta na polje megabajti.</span>

- <h4 id="h.ma6vfmow8176" style="display: inline;"><span class="c19">TarifniPaket</span><span class="c10">&nbsp;</span></h4>

<span class="c9">Ima maksimalnu brzinu (int), cenu paketa (float), neogranicenSaobracaj (bool), megabajti (int), cena po megabajtu (float).</span>

- <h4 id="h.6ctfzsmafbyt" style="display: inline;"><span class="c19">TarifniDodatak</span><span class="c10">&nbsp;</span></h4>

<span class="c9">Svaki tarifni dodatak ima cenu i tip dodatka. Potrebno je voditi racuna da tip dodatka moze biti samo neka od seldecih vrednosti:</span>

[]()[]()<table class="c43"><tbody><tr class="c25"><td class="c1" colspan="1" rowspan="1">

- <span class="c9">Facebook</span>

</td><td class="c36" colspan="1" rowspan="1">

- <span class="c9">Instagram</span>

</td><td class="c17" colspan="1" rowspan="1">

- <span class="c9">IPTV</span>

</td></tr><tr class="c26"><td class="c1" colspan="1" rowspan="1">

- <span class="c9">Twitter</span>

</td><td class="c36" colspan="1" rowspan="1">

- <span class="c9">Viber</span>

</td><td class="c17" colspan="1" rowspan="1">

- <span class="c9">Fiksna_Telefonija</span>

</td></tr></tbody></table>

- <h4 id="h.933tl87e7im" style="display: inline;"><span class="c19">Korisnik</span><span class="c10">&nbsp;</span></h4>

<span>Apstraktna klasa, implementira interfejs </span><span class="c23">[IzradaListinga](#h.ebqhw3anst94)</span><span class="c18">.</span>

<span>K</span><span>orisnik ima internet provajdera. Za svakog korisnika treba da cuvamo ime, prezime, adresu i broj ugovora. Takodje, korisnik moze da poseduje 0 ili vise tarfnih dodataka. </span><span class="c15">Napomena</span><span class="c23">:</span><span class="c9">&nbsp;Kosntruktor prima: InternetProvajder, String String, String, String, TarifniPaket.</span>

<span class="c15">Napomena 2</span><span class="c21">:</span><span class="c9">&nbsp;Zbog velikog broj pitanja na ovu temu -&gt; Korinsik ima i niz listing unosa! Ovo je atribut koji je trebalo da izvucete iz konteksta.</span>

- <h5 id="h.a9nthh9hu4qr" style="display: inline;"><span class="c19">dodajListingUnos(</span><span class="c19 c23">[ListingUnos](#h.xwlzh7oz2cul)</span><span class="c18">&nbsp;listingUnos) 2p</span></h5>

<span>Dodaje listingUnos u listu listing unosa, ili ukoliko već postoji unos sa istim url, postojećem unosu</span><span class="c23">[&nbsp;dodaje megabajte.](#h.1uy8k94mfsv6)</span>

- <h5 id="h.gzl2rir5mlu1" style="display: inline;"><span class="c18">napraviListing( ) &nbsp;: String </span></h5>

<span class="c9">Sortira listu listing unosa po broju potrošenih megabajta opadajuće, a zatim formira i vraća string u kome je u svakom redu po jedan listing unos, koji sadrži url i broj potrošenih megabajta.</span>

- <h5 id="h.q18qbswhxjmr" style="display: inline;"><span class="c19 c21">abstract</span><span class="c19">&nbsp;</span><span class="c19 c21">surfuj(String url, int megabjati)</span><span class="c19">&nbsp;: bool</span></h5>
- <h5 id="h.icl7z3pufmcl" style="display: inline;"><span class="c19 c21">abstract</span><span class="c19">&nbsp;</span><span class="c19 c21">dodajTarifniDodatak(</span><span class="c8">[TarifniDodatak](#h.6ctfzsmafbyt)</span><span class="c19 c21">&nbsp;tartifniDodatak)</span></h5>

<span class="c9"></span>

- <h4 id="h.7kjbphloc39w" style="display: inline;"><span class="c4">PrepaidKorisnik </span></h4>

<span class="c9">Nasleđuje apstraktnu klasu Korisnik. Ima dodatan atribut kredit (float).</span>

- <h5 id="h.728h8vyp2dqy" style="display: inline;"><span class="c18">dopuniKredit(float kredit) </span></h5>

<span class="c9">Dodaje zadati iznos kredita na kredit korisnika.</span>

- <h5 id="h.6sag1eary2e0" style="display: inline;"><span class="c18">surfuj(String url, int megabajta) 3p</span></h5>

<span>P</span><span>rvo proverava da li korisnik ima tarifni dodatak za besplatan surf na zadatom url (da li url sadrži naziv tipa dodatka). Ako ima, samo </span><span class="c23">[beleži saobraćaj kod provajdera](#h.4qf9yacxyuhb)</span><span>&nbsp;i dodaje unos </span><span class="c23">[u listing](#h.a9nthh9hu4qr)</span><span class="c9">. Ako nema, računa iznos potrošenog kredita kao broj megabajta * cenaPoMegabajtu iz tarifnog paketa.</span>

<span class="c9">Ako ima dovoljno kredita, umanjuje kredit za potrošeni iznos, beleži saobraćaj kod provajdera i dodaje unos u listing. Metoda vraća true ako je saobraćaj uspešan, false ako nema dovoljno kredita.</span>

- <h5 id="h.k3expt64uwxl" style="display: inline;"><span class="c19">dodajTarifniDodatak(</span><span class="c23 c19">[TarifniDodatak](#h.6ctfzsmafbyt)</span><span class="c18">&nbsp;tarifniDodatak) 2p</span></h5>

<span class="c9">Proverava cenu tarifnog dodatka i ako korisnik ima dovoljno kredita, umanjuje kredit za tu cenu i dodaje tarifni dodatak u svoju listu tarifnih dodataka. Tip tarifnog dodatka ne sme biti IPTV ni FIKSNA_TELEFONIJA.</span>

- <h4 id="h.4y0cutf7as5k" style="display: inline;"><span class="c4">PostpaidKorisnik </span></h4>

<span class="c9">Nasleđuje apstraktnu klasu Korisnik. Ima dodatan atribut prekoracenje (float).</span>

- <h5 id="h.xlq8t7gjytn2" style="display: inline;"><span class="c18">ukupnoZaNaplatu( ) 1p</span></h5>

<span class="c9">Računa i vraća ukupan iznos za naplatu kao zbir cene paketa, cena svih tarifnih dodataka i cene prekoračenja definisanog saobraćaja (ukoliko postoji).</span>

- <h5 id="h.8xd0psys1zs5" style="display: inline;"><span class="c19">surfuj(String url, int megabajta)</span><span class="c18">&nbsp;3p</span></h5>

<span>Prvo proverava da li korisnik ima tarifni paket sa neograničenim saobraćajem. Ako ima, beleži saobraćaj kod provajdera i dodaje unos u listing. Ako nema, proverava da li korisnik ima tarifni dodatak za surf na zadatom url (da li url sadrži naziv tipa dodatka). Ako ima, beleži saobraćaj kod provajdera i dodaje unos u listing. Ako nema, umanjuje broj megabajta u paketu za broj iskorišćenih megabajta, a ukoliko je dostupan broj megabajta prekoračen, iznos prekoračenja (preostali broj megabajta * cenaPoMegabajtu iz paketa) dodaje na polje prekoracenje. Zatim </span><span class="c23">[beleži saobraćaj kod provajdera](#h.4qf9yacxyuhb)</span><span class="c9">&nbsp;i dodaje unos u listing. Metoda uvek vraća true.</span>

- <h5 id="h.3libqhiqva63" style="display: inline;"><span class="c18">generisiRacun( ) &nbsp;</span></h5>

<span class="c21">G</span><span>eneriše string koji sadrži: broj ugovora, ime i prezime, cenu paketa, ime i cenu svakog tarifnog dodatka, iznos prekoračenja i ukupnu cenu (</span><span class="c23">[ukupnoZaNaplatu()](#h.xlq8t7gjytn2)</span><span class="c9">).</span>

- <h5 id="h.pboyzx7c31ri" style="display: inline;"><span class="c19">dodajTarifniDodatak(</span><span class="c23 c19">[TarifniDodatak](#h.6ctfzsmafbyt)</span><span class="c18">&nbsp;tarifniDodatak) </span></h5>

<span class="c9">Dodaje tarifni dodatak u listu tarifnih dodataka. Ako korisnik ima tarifni paket sa neograničenim saobraćajem, tarifni dodatak koji se dodaje može biti samo IPTV ili FIKSNA_TELEFONIJA.</span>

<span class="c9"></span>

- <h4 id="h.ebqhw3anst94" style="display: inline;"><span class="c19">IzradaListinga</span><span class="c10">&nbsp;- interfejs</span></h4>
- <h5 id="h.448nrothayao" style="display: inline;"><span class="c19">napraviListing( ) : String </span></h5>

<span class="c9"></span>
### <span class="c30">Testiranje</span>
<span class="c9">Napraviti poseban .php fajl u kome cete instancirati oba tipa korisnika i ostale klase, simulirati kupovinu tarifnih dodataka, surfovati, generisati racune itd. &nbsp;Potrebno je svaku metodu propratiti ispisom na ekran sta se desava. </span>
### <span class="c30">Predaja</span>
<span>Zadatak se predaje putem mail-a na </span><span class="c23">[tmihajlovic@raf.rs](mailto:tmihajlovic@raf.rs)</span><span class="c9">. PHP projekat imenovati na sledeći način: “pwa_d2_2020_ime_prezime_ind”. Npr. “pwa_d2_2020_pera_peric_s16_16”.</span>

<span class="c9">U tekstu mail-a obavezno navesti:</span>

- <span class="c9">Ime i prezime</span>
- <span class="c9">Broj indeksa</span>
- <span class="c9">Grupa, po zvaničnom spisku</span>
- <span class="c9">Razvojno okruženje</span>

<span class="c9">Subject mail-a mora da bude u obliku: “[PWA 2020] D2 ime_prezime_ind”.</span>

<span class="c9">Npr. “[PWA 2020] D2 pera_peric_s16_16”</span>

<span class="c9">Naziv arhive mora da bude u obliku: “pwa_2020_d2_ime_prezime_ind.zip”</span>

<span class="c9">Npr. “pwa_2020_d2_pera_peric_s16_16.zip”</span>

<span class="c9">Rok za predaju je:</span>

- <span class="c9">Ponedeljak, 11. maj 23:59:59</span>

<span class="c9">Neće se pregledati zadaci (tj. biće dodeljeno 0 poena) ako se desi bilo koje od:</span>

- <span class="c9">Sadržaj mail-a nije po navedenom obliku.</span>
- <span class="c9">Subject mail-a nije po navedenom obliku.</span>
- <span class="c9">Naziv arhive nije po navedenom obliku.</span>
- <span class="c9">Predaja se desi nakon navedenog roka.</span>

### <span class="c32">Odbrana</span>
<span class="c9">Odbrana domaćih zadataka je obavezna. Termin za odbranu drugog domaćeg zadatka će biti naknadno objavljen. Odbrane će se vršiti po grupama. Ako ste iz bilo kog razloga sprečeni da prisustvujete odbrani, obavezno to najavite što pre, kako bismo mogli da zakažemo vanredni termin za odbranu. </span>

<span class="c9">Svrha odbrane je da se pokaže autentičnost zadatka. Ovo podrazumeva odgovaranje na pitanja u vezi načina izrade zadatka, ili izvršavanje neke izmene nad zadatkom na licu mesta. U slučaju da odbrana nije uspešna, dodeljuje se -20 poena na domaćem zadatku.</span>

<span>Zadatak je moguće raditi parcijalno, ali obavezno je da može da se pokrene.</span>