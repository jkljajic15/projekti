USE Gigatron;
GO
--1

BEGIN TRAN;

UPDATE Korisnici SET Ime = 'Test' WHERE KorisnikID = 1;

--3

UPDATE Proizvodjaci SET ImeProizvodjaca = 'Test' WHERE ProizvodjacID = 1;

SELECT * FROM Korisnici WHERE KorisnikID = 1;

SELECT * FROM Proizvodjaci WHERE ProizvodjacID = 1;

ROLLBACK TRAN