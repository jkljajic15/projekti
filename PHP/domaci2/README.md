Opis
Napisati PHP OOP aplikaciju kojom se opisuje rad internet provajdera u Srbiji. 
Korisnici u okviru paketa mogu dobiti ograničenu ili neograničenu količinu podataka sa definisanom maksimalnom brzinom protoka po definisanoj ceni. Korisnici mogu biti prepaid ili postpaid korisnici. 
Prepaid korisnike karakteriše unapred određen iznos kredita koji se može trošiti i dopunjavati. 
Postpaid korisnike karakteriše tarifni paket koji ima svoju fiksnu cenu i podrazumeva određeni broj MB uz definisanu cenu po prekoračenju, ili neograničen internet saobraćaj. Ukoliko korisnik, koristeći usluge, provajdera prekorači definisano ograničenje u okviru paketa, obračunava mu se dodatna naplata koja se čuva u posebnom atributu prekoracenje. 

U jednom trenutku (na kraju meseca), provajder obračunava račun za naplatu postpaid korisnika, sabirajući fiksnu cenu paketa sa iznosom za koji je prekoračeno ograničenje. 

Svaki korisnik može kupiti određeni tarifni dodatak po fiksnoj ceni. Prepaid korisnici mogu kupiti dodatke koji omogućuju besplatan saobraćaj za neke sajtove. Postpaid korisnici mogu u okviru paketa dokupiti i dodatke za IPTV i besplatnu fiksnu telefoniju. 
Svaka Internet sesija koju pojedinačni korisnik napravi se zabelezi kod provajdera. Takođe, za svakog korisnika se može izvući listing iskorišćenog saobraćaja po pojedinačnom sajtu.

Potrebno je implementirati sledeće klase i interfejse:

➔	InternetProvajder
  Karakterise je ime i ima listu/niz korisnika.
    ◆	generisiRacune( ) 1p
    Generiše račune za svakog postpaid korisnika, pozivom metoda generisiRacun() nad njima i ispisuje sve račune.
    ◆	zabeleziSaobracaj(Korisnik korisnik, String url, int mb) 
    Svaki uspeli internet saobraćaj se ispisuje na ekran, pozivom ove metode. 
    Za svaku internet sesiju ispisuje broj ugovora korisnika, url koji je posećen i broj potrošenih megabajta. Ova metoda se poziva kada korisnik surfuje.
    ◆	prikazPrepaidKorisnika( )
    Ispisuje svakog prepaid korisnika – broj ugovora, ime, prezime, stanje kredita i tarifne dodatke.
    ◆	prikazPostpaidKorisnika( )
    Ispisuje svakog postpaid korisnika – broj ugovora, ime, prezime, tarifni paket i tarifne dodatke.
    ◆	dodajKorisnika(Korisnik korisnik) 
    Dodaje novog korisnika, pri čemu vodi računa da se korisnik sa istim brojem ugovora ne može dodati više puta.

➔	ListingUnos 
  Opisuju ga url i megabajti.
    ◆	dodajMegabajte(int megabajti)
    Dodaje zadati broj megabajta na polje megabajti.

➔	TarifniPaket 
  Ima maksimalnu brzinu (int), cenu paketa (float), neogranicenSaobracaj (bool), megabajti (int), cena po megabajtu (float).

➔	TarifniDodatak 
  Svaki tarifni dodatak ima cenu i tip dodatka. Potrebno je voditi racuna da tip dodatka moze biti samo neka od seldecih vrednosti:
  ❖	Facebook	❖	Instagram	❖	IPTV
  ❖	Twitter	❖	Viber	❖	Fiksna_Telefonija

➔	Korisnik 
  Apstraktna klasa, implementira interfejs IzradaListinga.
  Korisnik ima internet provajdera. Za svakog korisnika treba da cuvamo ime, prezime, adresu i broj ugovora. 
  Takodje, korisnik moze da poseduje 0 ili vise tarfnih dodataka. Napomena: Kosntruktor prima: InternetProvajder, String String, String, String, TarifniPaket.
  Napomena 2: Zbog velikog broj pitanja na ovu temu -> Korinsik ima i niz listing unosa! Ovo je atribut koji je trebalo da izvucete iz konteksta.
    ◆	dodajListingUnos(ListingUnos listingUnos) 2p
    Dodaje listingUnos u listu listing unosa, ili ukoliko već postoji unos sa istim url, postojećem unosu dodaje megabajte.
    ◆	napraviListing( )  : String 
    Sortira listu listing unosa po broju potrošenih megabajta opadajuće, a zatim formira i vraća string u kome je u svakom redu po jedan listing unos, 
    koji sadrži url i broj potrošenih megabajta.
    ◆	abstract surfuj(String url, int megabjati) : bool
    ◆	abstract dodajTarifniDodatak(TarifniDodatak tartifniDodatak)

➔	PrepaidKorisnik 
  Nasleđuje apstraktnu klasu Korisnik. Ima dodatan atribut kredit (float).
    ◆	dopuniKredit(float kredit) 
    Dodaje zadati iznos kredita na kredit korisnika.
    ◆	surfuj(String url, int megabajta) 3p
    Prvo proverava da li korisnik ima tarifni dodatak za besplatan surf na zadatom url (da li url sadrži naziv tipa dodatka). 
    Ako ima, samo beleži saobraćaj kod provajdera i dodaje unos u listing. Ako nema, računa iznos potrošenog kredita kao broj megabajta * cenaPoMegabajtu iz tarifnog paketa.
    Ako ima dovoljno kredita, umanjuje kredit za potrošeni iznos, beleži saobraćaj kod provajdera i dodaje unos u listing. 
    Metoda vraća true ako je saobraćaj uspešan, false ako nema dovoljno kredita.
    ◆	dodajTarifniDodatak(TarifniDodatak tarifniDodatak) 2p
    Proverava cenu tarifnog dodatka i ako korisnik ima dovoljno kredita, umanjuje kredit za tu cenu i dodaje tarifni dodatak u svoju listu tarifnih dodataka. 
    Tip tarifnog dodatka ne sme biti IPTV ni FIKSNA_TELEFONIJA.

➔	PostpaidKorisnik 
  Nasleđuje apstraktnu klasu Korisnik. Ima dodatan atribut prekoracenje (float).
    ◆	ukupnoZaNaplatu( ) 1p
    Računa i vraća ukupan iznos za naplatu kao zbir cene paketa, cena svih tarifnih dodataka i cene prekoračenja definisanog saobraćaja (ukoliko postoji).
    ◆	surfuj(String url, int megabajta) 3p
    Prvo proverava da li korisnik ima tarifni paket sa neograničenim saobraćajem. Ako ima, beleži saobraćaj kod provajdera i dodaje unos u listing. 
    Ako nema, proverava da li korisnik ima tarifni dodatak za surf na zadatom url (da li url sadrži naziv tipa dodatka). 
    Ako ima, beleži saobraćaj kod provajdera i dodaje unos u listing. Ako nema, umanjuje broj megabajta u paketu za broj iskorišćenih megabajta,
    a ukoliko je dostupan broj megabajta prekoračen, iznos prekoračenja (preostali broj megabajta * cenaPoMegabajtu iz paketa) dodaje na polje prekoracenje.
    Zatim beleži saobraćaj kod provajdera i dodaje unos u listing. Metoda uvek vraća true.
    ◆	generisiRacun( )  
    Generiše string koji sadrži: broj ugovora, ime i prezime, cenu paketa, ime i cenu svakog tarifnog dodatka, iznos prekoračenja i ukupnu cenu (ukupnoZaNaplatu()).
    ◆	dodajTarifniDodatak(TarifniDodatak tarifniDodatak) 
    Dodaje tarifni dodatak u listu tarifnih dodataka. Ako korisnik ima tarifni paket sa neograničenim saobraćajem, 
    tarifni dodatak koji se dodaje može biti samo IPTV ili FIKSNA_TELEFONIJA.

➔	IzradaListinga - interfejs
◆	napraviListing( ) : String 

Testiranje
  Napraviti poseban .php fajl u kome cete instancirati oba tipa korisnika i ostale klase, simulirati kupovinu tarifnih dodataka, surfovati, generisati racune itd.  
  Potrebno je svaku metodu propratiti ispisom na ekran sta se desava. 
