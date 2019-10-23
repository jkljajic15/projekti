USE Gigatron;
GO

INSERT INTO Gradovi(ImeGrada)
VALUES 
(N'Beograd'),
(N'Novi Sad'),
(N'Niš'),
(N'Subotica'),
(N'Kraljevo');
GO

INSERT INTO Prodavnice(Adresa,TelefonProdavnice,GradID)
VALUES 
(N'Kirovljeva 17','0113541379',(SELECT GradID FROM Gradovi WHERE ImeGrada = 'Beograd')),
(N'Cara Nikolaja II 41','0113085715',(SELECT GradID FROM Gradovi WHERE ImeGrada = 'Beograd')),
(N'Žièka 18-20','0116304419',(SELECT GradID FROM Gradovi WHERE ImeGrada = 'Beograd')),
(N'Bulevar Mihajla Pupina 4','0114086039',(SELECT GradID FROM Gradovi WHERE ImeGrada = 'Beograd')),
(N'Sentandrejski put 11','0212701336',(SELECT GradID FROM Gradovi WHERE ImeGrada = 'Novi Sad')),
(N'Obrenoviæeva 42','018250299',(SELECT GradID FROM Gradovi WHERE ImeGrada = 'Niš')),
(N'Miloša Velikog 16','036201771',(SELECT GradID FROM Gradovi WHERE ImeGrada = 'Subotica')),
(N'Štrosmajerova 10','024551366',(SELECT GradID FROM Gradovi WHERE ImeGrada = 'Kraljevo'));
GO

INSERT INTO Proizvodjaci(ImeProizvodjaca)
VALUES 
(N'Acer'),
(N'Apple'),
(N'Dell'),
(N'HP'),
(N'Lenovo'),
(N'Samsung'),
(N'Toshiba'),
(N'A-Data'),
(N'AMD'),
(N'Antec'),
(N'Apacer'),
(N'Arctic'),
(N'AS Rock'),
(N'Asus'),
(N'Chieftec'),
(N'Cooler Master'),
(N'Corsair'),
(N'Creative'),
(N'Crucial'),
(N'Deep Cool'),
(N'Fast Asia'),
(N'G Skill'),
(N'Gigabyte'),
(N'Gigatech'),
(N'Hitachi'),
(N'Intel'),
(N'Kingston'),
(N'LC Power'),
(N'LG'),
(N'MS'),
(N'MSI'),
(N'SanDisk'),
(N'SiliconPower'),
(N'Transcend'),
(N'Western Digital'),
(N'Benq'),
(N'Asus'),
(N'Philips'),
(N'Huawei'),
(N'Tesla'),
(N'Vivax'),
(N'Vox'),
(N'Gorenje'),
(N'Beko'),
(N'Windows'),
(N'Razer'),
(N'Logitech'),
(N'Microsoft'),
(N'Steelseries'),
(N'Marvo');
GO

INSERT INTO Akcije(ImeAkcije,VaziOd,VaziDo,Popust)
VALUES
(N'Vikend akcija','2017-11-10','2017-11-12',0.15),
(N'Spremni za avanturu','2017-11-10','2017-12-10',0.10),
(N'Ne zaboravite Office','2017-11-08','2017-11-25',0.20),
(N'20% na televizore','2017-11-02','2017-11-02',0.20),
(N'15% na zvuènike','2017-11-02','2017-11-05',0.15);
GO

INSERT INTO Kategorije(ImeKategorije,AkcijaID)
VALUES
(N'Televizori',(SELECT AkcijaID FROM Akcije WHERE ImeAkcije = '20% na televizore')),
(N'Laptop racunari',NULL),
(N'Zvuènici',(SELECT AkcijaID FROM Akcije WHERE ImeAkcije = '15% na zvuènike')),
(N'Tastature',NULL),
(N'Telefoni',NULL),
(N'Komponente',NULL),
(N'Bela tehnika',NULL),
(N'Kuæni aparati',NULL);
GO

INSERT INTO Proizvodi(ImeProizvoda,Cena,KategorijaID,ProizvodjacID,AkcijaID)
VALUES
(N'IdeaPad 110-15IBR',28990,(SELECT KategorijaID FROM Kategorije WHERE ImeKategorije = 'Laptop racunari'),(SELECT ProizvodjacID FROM Proizvodjaci WHERE ImeProizvodjaca = 'Lenovo'),NULL),
(N'Aspire ES1-132 ',28990,(SELECT KategorijaID FROM Kategorije WHERE ImeKategorije = 'Laptop racunari'),(SELECT ProizvodjacID FROM Proizvodjaci WHERE ImeProizvodjaca = 'Acer'),NULL),
(N'Aspire ES1-432',28990,(SELECT KategorijaID FROM Kategorije WHERE ImeKategorije = 'Laptop racunari'),(SELECT ProizvodjacID FROM Proizvodjaci WHERE ImeProizvodjaca = 'Acer'),NULL),
(N'One 10 12X9',28890,(SELECT KategorijaID FROM Kategorije WHERE ImeKategorije = 'Laptop racunari'),(SELECT ProizvodjacID FROM Proizvodjaci WHERE ImeProizvodjaca = 'Acer'),NULL),
(N'Aspire ES1-533',29990,(SELECT KategorijaID FROM Kategorije WHERE ImeKategorije = 'Laptop racunari'),(SELECT ProizvodjacID FROM Proizvodjaci WHERE ImeProizvodjaca = 'Acer'),NULL),
(N'IdeaPad 110-16IBR',28890,(SELECT KategorijaID FROM Kategorije WHERE ImeKategorije = 'Laptop racunari'),(SELECT ProizvodjacID FROM Proizvodjaci WHERE ImeProizvodjaca = 'Lenovo'),NULL),
(N'15-bw006nm',32990,(SELECT KategorijaID FROM Kategorije WHERE ImeKategorije = 'Laptop racunari'),(SELECT ProizvodjacID FROM Proizvodjaci WHERE ImeProizvodjaca = 'HP'),NULL),
(N'255 G6-1WY47EA',32990,(SELECT KategorijaID FROM Kategorije WHERE ImeKategorije = 'Laptop racunari'),(SELECT ProizvodjacID FROM Proizvodjaci WHERE ImeProizvodjaca = 'HP'),NULL),
(N'250 G6-1WWY3EC',34990,(SELECT KategorijaID FROM Kategorije WHERE ImeKategorije = 'Laptop racunari'),(SELECT ProizvodjacID FROM Proizvodjaci WHERE ImeProizvodjaca = 'HP'),NULL),
(N'Inspirion 15 3552',42990,(SELECT KategorijaID FROM Kategorije WHERE ImeKategorije = 'Laptop racunari'),(SELECT ProizvodjacID FROM Proizvodjaci WHERE ImeProizvodjaca = 'Dell'),NULL),
(N'Inspirion 11 3168',43990,(SELECT KategorijaID FROM Kategorije WHERE ImeKategorije = 'Laptop racunari'),(SELECT ProizvodjacID FROM Proizvodjaci WHERE ImeProizvodjaca = 'Dell'),NULL),
(N'Inspirion 11 3553',42990,(SELECT KategorijaID FROM Kategorije WHERE ImeKategorije = 'Laptop racunari'),(SELECT ProizvodjacID FROM Proizvodjaci WHERE ImeProizvodjaca = 'Dell'),NULL),
(N'IdeaPad 320-16IBR',45990,(SELECT KategorijaID FROM Kategorije WHERE ImeKategorije = 'Laptop racunari'),(SELECT ProizvodjacID FROM Proizvodjaci WHERE ImeProizvodjaca = 'Lenovo'),NULL),
(N'15-ay019nm',53990,(SELECT KategorijaID FROM Kategorije WHERE ImeKategorije = 'Laptop racunari'),(SELECT ProizvodjacID FROM Proizvodjaci WHERE ImeProizvodjaca = 'HP'),NULL),
(N'Inspiron 15 5567',54990,(SELECT KategorijaID FROM Kategorije WHERE ImeKategorije = 'Laptop racunari'),(SELECT ProizvodjacID FROM Proizvodjaci WHERE ImeProizvodjaca = 'Dell'),NULL),
(N'Inspiron 15 3567',55990,(SELECT KategorijaID FROM Kategorije WHERE ImeKategorije = 'Laptop racunari'),(SELECT ProizvodjacID FROM Proizvodjaci WHERE ImeProizvodjaca = 'Dell'),NULL),
(N'IdeaPad 320-15ISK',56990,(SELECT KategorijaID FROM Kategorije WHERE ImeKategorije = 'Laptop racunari'),(SELECT ProizvodjacID FROM Proizvodjaci WHERE ImeProizvodjaca = 'Lenovo'),NULL),
(N'250 G6 - 1WY29EA',62990,(SELECT KategorijaID FROM Kategorije WHERE ImeKategorije = 'Laptop racunari'),(SELECT ProizvodjacID FROM Proizvodjaci WHERE ImeProizvodjaca = 'HP'),NULL),
(N'MacBook Pro 15"',440890,(SELECT KategorijaID FROM Kategorije WHERE ImeKategorije = 'Laptop racunari'),(SELECT ProizvodjacID FROM Proizvodjaci WHERE ImeProizvodjaca = 'Apple'),NULL),
(N'MacBook Pro 13"',304890,(SELECT KategorijaID FROM Kategorije WHERE ImeKategorije = 'Laptop racunari'),(SELECT ProizvodjacID FROM Proizvodjaci WHERE ImeProizvodjaca = 'Apple'),NULL),--20
(N'24LE110T2S2',15990,(SELECT KategorijaID FROM Kategorije WHERE ImeKategorije = 'Televizori'),(SELECT ProizvodjacID FROM Proizvodjaci WHERE ImeProizvodjaca = 'Vivax'),(SELECT AkcijaID FROM Akcije WHERE ImeAkcije = '20% na televizore')),
(N'24S306BH',15990,(SELECT KategorijaID FROM Kategorije WHERE ImeKategorije = 'Televizori'),(SELECT ProizvodjacID FROM Proizvodjaci WHERE ImeProizvodjaca = 'Tesla'),(SELECT AkcijaID FROM Akcije WHERE ImeAkcije = '20% na televizore')),
(N'32S55DA',18990,(SELECT KategorijaID FROM Kategorije WHERE ImeKategorije = 'Televizori'),(SELECT ProizvodjacID FROM Proizvodjaci WHERE ImeProizvodjaca = 'Vivax'),(SELECT AkcijaID FROM Akcije WHERE ImeAkcije = '20% na televizore')),
(N'32YD200',19490,(SELECT KategorijaID FROM Kategorije WHERE ImeKategorije = 'Televizori'),(SELECT ProizvodjacID FROM Proizvodjaci WHERE ImeProizvodjaca = 'Vox'),(SELECT AkcijaID FROM Akcije WHERE ImeAkcije = '20% na televizore')),
(N'32S55AT2',19490,(SELECT KategorijaID FROM Kategorije WHERE ImeKategorije = 'Televizori'),(SELECT ProizvodjacID FROM Proizvodjaci WHERE ImeProizvodjaca = 'Vivax'),(SELECT AkcijaID FROM Akcije WHERE ImeAkcije = '20% na televizore')),
(N'32DIG289B',19990,(SELECT KategorijaID FROM Kategorije WHERE ImeKategorije = 'Televizori'),(SELECT ProizvodjacID FROM Proizvodjaci WHERE ImeProizvodjaca = 'Vox'),(SELECT AkcijaID FROM Akcije WHERE ImeAkcije = '20% na televizore')),
(N'32DIS289B',20990,(SELECT KategorijaID FROM Kategorije WHERE ImeKategorije = 'Televizori'),(SELECT ProizvodjacID FROM Proizvodjaci WHERE ImeProizvodjaca = 'Vox'),(SELECT AkcijaID FROM Akcije WHERE ImeAkcije = '20% na televizore')),
(N'24PFS4022',21990,(SELECT KategorijaID FROM Kategorije WHERE ImeKategorije = 'Televizori'),(SELECT ProizvodjacID FROM Proizvodjaci WHERE ImeProizvodjaca = 'Philips'),(SELECT AkcijaID FROM Akcije WHERE ImeAkcije = '20% na televizore')),
(N'32S306BH',22990,(SELECT KategorijaID FROM Kategorije WHERE ImeKategorije = 'Televizori'),(SELECT ProizvodjacID FROM Proizvodjaci WHERE ImeProizvodjaca = 'Tesla'),(SELECT AkcijaID FROM Akcije WHERE ImeAkcije = '20% na televizore')),
(N'24PFS4032',22990,(SELECT KategorijaID FROM Kategorije WHERE ImeKategorije = 'Televizori'),(SELECT ProizvodjacID FROM Proizvodjaci WHERE ImeProizvodjaca = 'Philips'),(SELECT AkcijaID FROM Akcije WHERE ImeAkcije = '20% na televizore')), --30
(N'BT-777 (Plavi)',1590,(SELECT KategorijaID FROM Kategorije WHERE ImeKategorije = 'Zvuènici'),(SELECT ProizvodjacID FROM Proizvodjaci WHERE ImeProizvodjaca = 'Gigatech'),(SELECT AkcijaID FROM Akcije WHERE ImeAkcije = '15% na zvuènike')),
(N'BT-777 (Crni)',1590,(SELECT KategorijaID FROM Kategorije WHERE ImeKategorije = 'Zvuènici'),(SELECT ProizvodjacID FROM Proizvodjaci WHERE ImeProizvodjaca = 'Gigatech'),(SELECT AkcijaID FROM Akcije WHERE ImeAkcije = '15% na zvuènike')),
(N'BT-777 (Beli)',1590,(SELECT KategorijaID FROM Kategorije WHERE ImeKategorije = 'Zvuènici'),(SELECT ProizvodjacID FROM Proizvodjaci WHERE ImeProizvodjaca = 'Gigatech'),(SELECT AkcijaID FROM Akcije WHERE ImeAkcije = '15% na zvuènike')),
(N'S-150',2590,(SELECT KategorijaID FROM Kategorije WHERE ImeKategorije = 'Zvuènici'),(SELECT ProizvodjacID FROM Proizvodjaci WHERE ImeProizvodjaca = 'Logitech'),(SELECT AkcijaID FROM Akcije WHERE ImeAkcije = '15% na zvuènike')),
(N'S5000',2790,(SELECT KategorijaID FROM Kategorije WHERE ImeKategorije = 'Zvuènici'),(SELECT ProizvodjacID FROM Proizvodjaci WHERE ImeProizvodjaca = 'HP'),(SELECT AkcijaID FROM Akcije WHERE ImeAkcije = '15% na zvuènike')),--35
(N'G413 Silver',13990,(SELECT KategorijaID FROM Kategorije WHERE ImeKategorije = 'Tastature'),(SELECT ProizvodjacID FROM Proizvodjaci WHERE ImeProizvodjaca = 'Logitech'),NULL),
(N'G413 Carbon',13990,(SELECT KategorijaID FROM Kategorije WHERE ImeKategorije = 'Tastature'),(SELECT ProizvodjacID FROM Proizvodjaci WHERE ImeProizvodjaca = 'Logitech'),NULL),
(N'Apex M500',15990,(SELECT KategorijaID FROM Kategorije WHERE ImeKategorije = 'Tastature'),(SELECT ProizvodjacID FROM Proizvodjaci WHERE ImeProizvodjaca = 'Steelseries'),NULL),
(N'BlackWidow Ultimate',16290,(SELECT KategorijaID FROM Kategorije WHERE ImeKategorije = 'Tastature'),(SELECT ProizvodjacID FROM Proizvodjaci WHERE ImeProizvodjaca = 'Razer'),NULL),
(N'G810 ORION SPECTRUM',25590,(SELECT KategorijaID FROM Kategorije WHERE ImeKategorije = 'Tastature'),(SELECT ProizvodjacID FROM Proizvodjaci WHERE ImeProizvodjaca = 'Logitech'),NULL),--40
(N'P9 Lite',29990,(SELECT KategorijaID FROM Kategorije WHERE ImeKategorije = 'Telefoni'),(SELECT ProizvodjacID FROM Proizvodjaci WHERE ImeProizvodjaca = 'Huawei'),NULL),
(N'Y5',29990,(SELECT KategorijaID FROM Kategorije WHERE ImeKategorije = 'Telefoni'),(SELECT ProizvodjacID FROM Proizvodjaci WHERE ImeProizvodjaca = 'Huawei'),NULL),
(N'Galaxy Note 8',126990,(SELECT KategorijaID FROM Kategorije WHERE ImeKategorije = 'Telefoni'),(SELECT ProizvodjacID FROM Proizvodjaci WHERE ImeProizvodjaca = 'Samsung'),NULL),
(N'Galaxy S7 EDGE',74990,(SELECT KategorijaID FROM Kategorije WHERE ImeKategorije = 'Telefoni'),(SELECT ProizvodjacID FROM Proizvodjaci WHERE ImeProizvodjaca = 'Samsung'),NULL),
(N'GTX 1060',47990,(SELECT KategorijaID FROM Kategorije WHERE ImeKategorije = 'Komponente'),(SELECT ProizvodjacID FROM Proizvodjaci WHERE ImeProizvodjaca = 'Gigabyte'),NULL),
(N'TS128GSSD230S',5590,(SELECT KategorijaID FROM Kategorije WHERE ImeKategorije = 'Komponente'),(SELECT ProizvodjacID FROM Proizvodjaci WHERE ImeProizvodjaca = 'Transcend'),NULL),
(N'SA400S37',7690,(SELECT KategorijaID FROM Kategorije WHERE ImeKategorije = 'Komponente'),(SELECT ProizvodjacID FROM Proizvodjaci WHERE ImeProizvodjaca = 'Kingston'),NULL),
(N'G4560',8490,(SELECT KategorijaID FROM Kategorije WHERE ImeKategorije = 'Komponente'),(SELECT ProizvodjacID FROM Proizvodjaci WHERE ImeProizvodjaca = 'Intel'),NULL),
(N'DBL-5025',1990,(SELECT KategorijaID FROM Kategorije WHERE ImeKategorije = 'Kuæni aparati'),(SELECT ProizvodjacID FROM Proizvodjaci WHERE ImeProizvodjaca = 'Vox'),NULL),
(N'MOC20100W',6990,(SELECT KategorijaID FROM Kategorije WHERE ImeKategorije = 'Bela tehnika'),(SELECT ProizvodjacID FROM Proizvodjaci WHERE ImeProizvodjaca = 'Beko'),NULL);
GO

INSERT INTO Vesti(ImeVesti,DatumObjave)
VALUES
(N'Promena adrese','2017-11-06'),
(N'Capitol park','2017-10-17'),
(N'Beko katalog','2017-10-06'),
(N'Otvoranje G42','2017-09-13');
GO

INSERT INTO Katalozi(ImeKataloga,MesecKataloga)
VALUES
(N'Novembar','2017-11-01'),
(N'Oktobar','2017-10-01'),
(N'Septembar','2017-09-01'),
(N'Avgust','2017-08-01');
GO

INSERT INTO Korisnici(Ime,Prezime,Nadimak,Godine,Username,Email,Lozinka,Adresa,Grad,PostanskiBroj,TelefonKorisnika)
VALUES
(N'Jovan',N'Jovanoviæ',N'Joca',19,'jjovanovic',N'jjovanovic@gmail.com',N'lozinka123',N'Kralja Milana 6',N'Beograd',N'11000','0601234567'),
(N'Milan',N'Milanoviæ',NULL,18,'mmilanovic',N'mmilanovic@gmail.com',N'lozinka123',N'Jurija Gagarina 123',N'Beograd',N'11000','0611234567'),
(N'Miloš',N'Miloševiæ',N'Miša',25,'mmilosevic',N'mmilosevic@gmail.com',N'lozinka123',N'Kosovska 18',N'Beograd',N'11000','0621234567'),
(N'Petar',N'Petroviæ',N'Pera',34,'ppetrovic',N'ppetrovic@gmail.com',N'lozinka123',N'Paunova 6',N'Beograd',N'11000','0631234567'),
(N'Lazar',N'Lazareviæ',N'Laza',53,'llazarevic',N'llazarevic@gmail.com',N'lozinka123',N'Cvijiæeva 15',N'Beograd',N'11000','0641234567');
GO

INSERT INTO Komentari(Sadrzaj,KorsnikID)
VALUES
('Kupio sam ovaj proizvod i veoma sam zadovoljan, preporucujem.',(SELECT KorisnikID FROM Korisnici WHERE Username = 'jjovanovic'));
GO

INSERT INTO Korpe(KorisnikID,ProizvodID,Kolicina)
VALUES 
((SELECT KorisnikID FROM Korisnici WHERE Username = 'jjovanovic'),(SELECT ProizvodID FROM Proizvodi WHERE ImeProizvoda = 'IdeaPad 110-15IBR'),1),
((SELECT KorisnikID FROM Korisnici WHERE Username = 'jjovanovic'),(SELECT ProizvodID FROM Proizvodi WHERE ImeProizvoda = '24LE110T2S2'),1),
((SELECT KorisnikID FROM Korisnici WHERE Username = 'mmilanovic'),(SELECT ProizvodID FROM Proizvodi WHERE ImeProizvoda = 'G413 Silver'),2);
GO

INSERT INTO ListeZelja(KorisnikID,ProizvodID)
VALUES
((SELECT KorisnikID FROM Korisnici WHERE Username = 'jjovanovic'),(SELECT ProizvodID FROM Proizvodi WHERE ImeProizvoda = 'MacBook Pro 13"')),
((SELECT KorisnikID FROM Korisnici WHERE Username = 'jjovanovic'),(SELECT ProizvodID FROM Proizvodi WHERE ImeProizvoda = 'DBL-5025')),
((SELECT KorisnikID FROM Korisnici WHERE Username = 'mmilanovic'),(SELECT ProizvodID FROM Proizvodi WHERE ImeProizvoda = 'MacBook Pro 13"')),
((SELECT KorisnikID FROM Korisnici WHERE Username = 'mmilanovic'),(SELECT ProizvodID FROM Proizvodi WHERE ImeProizvoda = 'G810 ORION SPECTRUM')),
((SELECT KorisnikID FROM Korisnici WHERE Username = 'jjovanovic'),(SELECT ProizvodID FROM Proizvodi WHERE ImeProizvoda = 'MOC20100W'));
GO

INSERT INTO ProizvodiKatalozi (KatalogID,ProizvodID)
VALUES
((SELECT KatalogID FROM Katalozi WHERE ImeKataloga = 'Avgust'),(SELECT ProizvodID FROM Proizvodi WHERE ImeProizvoda = 'MacBook Pro 13"')),
((SELECT KatalogID FROM Katalozi WHERE ImeKataloga = 'Avgust'),(SELECT ProizvodID FROM Proizvodi WHERE ImeProizvoda = 'DBL-5025')),
((SELECT KatalogID FROM Katalozi WHERE ImeKataloga = 'Avgust'),(SELECT ProizvodID FROM Proizvodi WHERE ImeProizvoda = 'G810 ORION SPECTRUM')),
((SELECT KatalogID FROM Katalozi WHERE ImeKataloga = 'Avgust'),(SELECT ProizvodID FROM Proizvodi WHERE ImeProizvoda = 'MOC20100W'));
/*
UPDATE Korisnici
SET Nadimak = N'Miæa'
WHERE Ime = 'Milan';
GO

UPDATE Korisnici
SET Lozinka = 'lozinka321'
WHERE KorisnikID = 1;
GO

DELETE FROM Proizvodi
WHERE ProizvodID = 45;
GO

DELETE FROM Proizvodi
WHERE ImeProizvoda = 'Blackwidow Ultimate';
GO
*/

