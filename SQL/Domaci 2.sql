USE Gigatron;
GO

-- 1 view

CREATE VIEW BrProizvodaPoKategoriji
AS
SELECT ImeKategorije AS Kategorija, COUNT(ImeProizvoda) AS BrojProizvoda
FROM Kategorije AS k 
JOIN Proizvodi AS p
ON k.KategorijaID = p.KategorijaID
GROUP BY  ImeKategorije;
GO

SELECT * FROM BrProizvodaPoKategoriji;
GO

-- 2 Procedure

CREATE PROC dbo.InsertDemo
( @ImeProizvoda nvarchar(20), @Cena decimal, @KategorijaID int, @ProizvodjacID int, @AkcijaID int)
AS
BEGIN
	INSERT INTO dbo.Proizvodi
	VALUES (@ImeProizvoda, @Cena, @KategorijaID, @ProizvodjacID, @AkcijaID)
END;
GO

CREATE PROC dbo.UpdateDemo
(@ProizvodID int, @Cena decimal, @AkcijaID int)
AS
BEGIN
	UPDATE Proizvodi
	SET Cena = @Cena, AkcijaID = @AkcijaID
	WHERE ProizvodID = @ProizvodID
END;
GO

CREATE PROC dbo.DeleteDemo
(@ProizvodID int)
AS
BEGIN
	DELETE Proizvodi
	WHERE ProizvodID = @ProizvodID
END;
GO

CREATE PROC dbo.UpisGreske
AS
BEGIN
	INSERT INTO dbo.ErrorLog(BrojGreske,SadrzajGreske)
	VALUES(ERROR_NUMBER(),ERROR_MESSAGE());
END
GO

BEGIN TRY
	EXEC  dbo.InsertDemo @ImeProizvoda = 'TestProizvod', @Cena = 1250, @KategorijaID = 1, @ProizvodjacID = 1, @AkcijaID = null;
END TRY
BEGIN CATCH
	PRINT 'Error Number: ' + CAST(ERROR_NUMBER() AS varchar(10));
	PRINT 'Error Message: ' + ERROR_MESSAGE();
	EXEC dbo.UpisGreske;
END CATCH
GO

--3 Skalarna funkcija koja vraca vrednost korpe trazenog korisnika

CREATE FUNCTION dbo.VrednostKorpe(@Username nvarchar(20))
RETURNS decimal
AS
BEGIN
	DECLARE @Ukupno decimal
	SELECT @Ukupno = SUM(p.Cena * k.Kolicina)
	FROM Korpe AS k
	JOIN Korisnici AS kor ON kor.KorisnikID = k.KorisnikID 
	JOIN Proizvodi AS p ON p.ProizvodID = k.ProizvodID
	WHERE kor.Username = @Username;

	RETURN @Ukupno;
END;	 
GO

SELECT dbo.VrednostKorpe('jjovanovic') AS Ukupno;
GO

--4 inline table-valued funkcija koja vraca proizvode iz izabrane kategorije

CREATE FUNCTION dbo.PregledKategorije
(@BrKategorije int)
RETURNS TABLE
AS
RETURN (SELECT TOP 100 PERCENT ImeKategorije ,ImeProizvoda, Cena
		FROM Kategorije AS k
		JOIN Proizvodi AS p ON k.KategorijaID = p.KategorijaID
		WHERE k.KategorijaID = @BrKategorije
		ORDER BY Cena);
GO

BEGIN TRY
	SELECT * FROM dbo.PregledKategorije(1);
END TRY
BEGIN CATCH
	PRINT 'Error Number: ' + CAST(ERROR_NUMBER() AS varchar(10));
	PRINT 'Error Message: ' + ERROR_MESSAGE();
END CATCH
GO

--5 AFTER okidac prilikom unosenja korisnika, lozinka mora biti duza od 5 karaktera

CREATE TRIGGER AfterTrigerDemo
	ON dbo.Korisnici
	AFTER INSERT 
AS
BEGIN
	SET NOCOUNT ON;
	IF EXISTS( SELECT * FROM inserted AS i WHERE LEN(i.Lozinka) < 5 ) 
	BEGIN
		PRINT 'Lozinka mora biti duza od 5 karaktera.';
		ROLLBACK;           
	END;
END;
GO

INSERT INTO Korisnici
	(Ime,Prezime,Godine,Username,Email,Lozinka)
	VALUES ('Jovan','Kljajic', 20, 'jkljajic', 'jkljajic12@raf.rs','asd');
GO

SELECT * FROM Korisnici;
GO

--6 Instead of triger koji sprecava brisanje korisnika

CREATE TRIGGER InsteadOfTrigerDemo ON dbo.Korisnici
	INSTEAD OF DELETE
AS
BEGIN
	SET NOCOUNT ON;
	DECLARE @brojObrisanih int;
	SELECT @brojObrisanih = COUNT(*) FROM deleted;
	IF @brojObrisanih > 0
	BEGIN
		RAISERROR ('Nije dozvoljeno brisanje korisnika', 10, 1);
		IF @@TRANCOUNT > 0
			ROLLBACK TRAN;
	END;
END;
GO

DELETE Korisnici;
GO

--7 DDL okidac

CREATE TRIGGER DdlDemo
	ON DATABASE
	FOR DROP_TABLE
AS
	PRINT 'Brisanje tabela nije dozvoljeno!';
	ROLLBACK TRAN;
GO

DROP TABLE Komentari;
GO

--8 procedura sa obradom transakcije

BEGIN TRY
	BEGIN TRAN ObradaTransakcijeDemo
		EXEC  dbo.InsertDemo @ImeProizvoda = 'TestProizvod', @Cena = 'asd', @KategorijaID = 1, @ProizvodjacID = 1, @AkcijaID = null;
	COMMIT
END TRY
BEGIN CATCH
	PRINT 'Error Number: ' + CAST(ERROR_NUMBER() AS varchar(10));
	PRINT 'Error Message: ' + ERROR_MESSAGE();
	ROLLBACK
END CATCH

