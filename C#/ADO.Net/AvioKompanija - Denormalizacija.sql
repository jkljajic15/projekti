USE AvioKompanija;
GO

CREATE TABLE KartaDenormalizovana
(
	BrojKarte int NOT NULL CONSTRAINT PK_BrojKarteDenormalizovane PRIMARY KEY,
	DatIzd date NOT NULL,
	VaziDO date NOT NULL,
	Cena decimal(18,2),
	Ime nvarchar(30) NULL,
	Prezime nvarchar (30) NULL,
	Brlk int NOT NULL
		CONSTRAINT FK_KartaDenormalizovana_Brlk
		FOREIGN KEY
		REFERENCES Putnik(Brlk)
);

GO

CREATE TRIGGER ZabranaUpdate
ON dbo.KartaDenormalizovana
INSTEAD OF UPDATE 
AS IF UPDATE(Brlk) OR UPDATE(Ime) OR UPDATE(Prezime)
BEGIN
RAISERROR('Nije dozvoljeno azuriranje', 16,1)
END;
GO

CREATE TRIGGER AzuriranjeImenaIPrezimenaInsert
ON dbo.KartaDenormalizovana
AFTER INSERT AS
BEGIN
SET NOCOUNT ON;
DECLARE
	@Brlk_nova  int,
	@Ime nvarchar(30),
	@Prezime nvarchar (30);
SELECT @Brlk_nova = Brlk FROM INSERTED;
SELECT @Ime = Ime FROM Putnik
WHERE Brlk = @Brlk_nova;
SELECT @Prezime = Prezime FROM Putnik
WHERE Brlk = @Brlk_nova;
UPDATE KartaDenormalizovana
SET Ime = @Ime, Prezime = @Prezime
WHERE Brlk = @Brlk_nova;
END
GO

CREATE TRIGGER AzuriranjeImenaUpdate
ON dbo.Putnik
AFTER UPDATE
AS IF UPDATE(Ime) 
BEGIN
ALTER TABLE KartaDenormalizovana DISABLE TRIGGER ZabranaUpdate
SET NOCOUNT ON;
DECLARE
	@novo_ime nvarchar(30),
	@brlk int;
SELECT @novo_ime = Ime, @brlk = Brlk 
FROM INSERTED
UPDATE KartaDenormalizovana
SET KartaDenormalizovana.Ime = @novo_ime
WHERE KartaDenormalizovana.Brlk = @brlk;
ALTER TABLE KartaDenormalizovana ENABLE TRIGGER ZabranaUpdate
END
GO

CREATE TRIGGER AzuriranjePrezimenaUpdate
ON dbo.Putnik
AFTER UPDATE
AS IF UPDATE(Prezime)
BEGIN
ALTER TABLE KartaDenormalizovana DISABLE TRIGGER ZabranaUpdate
SET NOCOUNT ON;
DECLARE
	@novo_prezime nvarchar(30),
	@brlk int;
SELECT @novo_prezime = Prezime, @brlk = Brlk 
FROM INSERTED
UPDATE KartaDenormalizovana
SET KartaDenormalizovana.Prezime = @novo_prezime
WHERE KartaDenormalizovana.Brlk = @brlk;
ALTER TABLE KartaDenormalizovana ENABLE TRIGGER ZabranaUpdate
END
GO 