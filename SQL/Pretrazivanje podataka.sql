USE Gigatron;
GO

--1 Pretrazivanje prodavnica u istom gradu
SELECT p.Adresa, p.TelefonProdavnice
FROM Gradovi AS g 
JOIN Prodavnice AS p 
ON g.GradID = p.GradID
WHERE g.ImeGrada = 'Beograd';
GO

--2 Proizvodi u katalogu
SELECT  ImeKataloga, ImeProizvoda
FROM Katalozi AS k 
JOIN ProizvodiKatalozi AS pk 
ON k.KatalogID = pk.KatalogID 
JOIN Proizvodi AS p 
ON p.ProizvodID = pk.ProizvodID
ORDER BY ImeKataloga,ImeProizvoda;
GO
   
--3 Proizvodi od istog proizvodjaca
SELECT ImeKategorije,ImeProizvoda
FROM Proizvodjaci AS pr
JOIN Proizvodi AS p
ON pr.ProizvodjacID = p.ProizvodjacID
JOIN Kategorije AS k
ON k.KategorijaID = p.KategorijaID
WHERE ImeProizvodjaca = 'HP'
ORDER BY ImeKategorije,ImeProizvoda;
GO

--4 Kategorije proizvoda na popustu
SELECT ImeAkcije,Popust,VaziOd,VaziDo,ImeKategorije
FROM Akcije AS a
JOIN Kategorije AS k
ON a.AkcijaID = k.AkcijaID;
GO

--5 Korpe korisnika
SELECT Username, ImeProizvoda, Cena, Kolicina
FROM Korisnici AS k
JOIN Korpe AS ko
ON k.KorisnikID = ko.KorisnikID
JOIN Proizvodi AS p
ON  p.ProizvodID = ko.ProizvodID;
GO

--6 Lista zelja
SELECT Username, ImeProizvoda, Cena 
FROM Korisnici AS k
JOIN ListeZelja AS l
ON k.KorisnikID = l.KorisnikID
JOIN Proizvodi AS p
ON  p.ProizvodID = l.ProizvodID
ORDER BY Username,Cena; 
GO

--7 Komentari prvo najnoviji
SELECT k.Username,Sadrzaj, DatumKomentara
FROM Korisnici AS k
JOIN Komentari AS ko
ON k.KorisnikID = ko.KorsnikID
ORDER BY k.Username, DatumKomentara DESC;
GO
 
--8 Proizvodi po kategoriji
SELECT ImeKategorije,ImeProizvoda
FROM Kategorije AS k
JOIN Proizvodi AS p
ON k.KategorijaID = p.KategorijaID
ORDER BY ImeKategorije;
GO

--9 Spisak proizvoda
SELECT ImeKategorije,ImeProizvodjaca, ImeProizvoda, Cena
FROM Kategorije AS k
JOIN Proizvodi AS p
ON k.KategorijaID = p.KategorijaID
JOIN Proizvodjaci AS pr
ON pr.ProizvodjacID = p.ProizvodjacID
ORDER BY ImeKategorije, ImeProizvodjaca, ImeProizvoda, Cena;
GO

--10 Sve prodavnice
SELECT ImeGrada, Adresa, TelefonProdavnice
FROM Gradovi AS g
JOIN Prodavnice AS p
ON g.GradID = p.GradID
ORDER BY ImeGrada, Adresa;
GO

--1 Offset-fetch proizvodi po ceni rastuce, 10 prvih rezultata
SELECT ImeProizvoda,Cena
FROM Proizvodi AS p
JOIN Proizvodjaci AS pr
ON pr.ProizvodjacID = p.ProizvodjacID
WHERE ImeProizvodjaca IN(
	SELECT ImeProizvodjaca
	FROM Proizvodjaci 
	WHERE ProizvodjacID = p.ProizvodjacID)
ORDER BY Cena
OFFSET 0 ROWS FETCH NEXT 10 ROWS ONLY;
GO

--2 Exists: pokazuje komentar gde postoji
SELECT Username,Sadrzaj
FROM Komentari AS k
JOIN Korisnici AS kor
ON kor.KorisnikID = k.KorsnikID
WHERE EXISTS (
	SELECT * 
	FROM Korisnici AS ko 
	WHERE k.KorsnikID = ko.KorisnikID);
GO

--3 Skalarni: id poslednjeg ubacenog proizvoda
SELECT MAX(ProizvodID) AS PoslednjiProizvod
FROM Proizvodi;
GO

--4 Vise-vrednosni: svi proizvodi navedenog proizvodjaca
SELECT ImeProizvoda,Cena
FROM Proizvodi AS p
JOIN Proizvodjaci AS pr
ON pr.ProizvodjacID = p.ProizvodjacID
WHERE ImeProizvodjaca IN(
	SELECT ImeProizvodjaca
	FROM Proizvodjaci 
	WHERE ImeProizvodjaca = 'Samsung');
GO

--5 Korelativni: Proizvodi skuplji od prosecne cene
SELECT ImeProizvoda, Cena
FROM Proizvodi
WHERE Cena > (
	SELECT AVG(Cena)
	FROM Proizvodi)
ORDER BY Cena;
GO

