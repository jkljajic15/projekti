USE Gigatron;
GO
--2

BEGIN TRAN;

UPDATE Proizvodjaci SET ImeProizvodjaca = 'Test' WHERE ProizvodjacID = 1;

--4

UPDATE Korisnici SET Ime = 'Test' WHERE KorisnikID = 1;

SELECT * FROM Korisnici WHERE KorisnikID = 1;

SELECT * FROM Proizvodjaci WHERE ProizvodjacID = 1;

ROLLBACK TRAN