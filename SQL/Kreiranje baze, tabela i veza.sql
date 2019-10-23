CREATE DATABASE Gigatron;
GO

SELECT * FROM sys.databases;
GO

SELECT database_id, name, state_desc FROM sys.databases;
GO

USE Gigatron;
GO

SELECT file_id, name,
	size as SizeInPages, FILEPROPERTY(name,'SpaceUsed') as SpaceUsedInPages,
	physical_name
FROM sys.database_files;
GO

CREATE TABLE Gradovi
(GradID int IDENTITY(1,1) NOT NULL PRIMARY KEY, 
ImeGrada nvarchar(20) NOT NULL);

CREATE TABLE Prodavnice
(ProdavnicaID int IDENTITY(1,1) NOT NULL PRIMARY KEY,
Adresa nvarchar(50),
TelefonProdavnice varchar(10),
GradID int FOREIGN KEY REFERENCES Gradovi(GradID));

CREATE TABLE Proizvodjaci
(ProizvodjacID int IDENTITY(1,1) NOT NULL PRIMARY KEY,
 ImeProizvodjaca nvarchar(20) NOT NULL);

 CREATE TABLE Akcije
(AkcijaID int IDENTITY(1,1) PRIMARY KEY,
 ImeAkcije nvarchar(20),
 VaziOd date NOT NULL,
 VaziDo date NOT NULL,
 Popust decimal(2,2) NOT NULL);

 CREATE TABLE Kategorije
(KategorijaID int IDENTITY(1,1) NOT NULL PRIMARY KEY,
 ImeKategorije nvarchar(20) NOT NULL,
 AkcijaID int FOREIGN KEY REFERENCES Akcije(AkcijaID));

CREATE TABLE Proizvodi
(ProizvodID int IDENTITY(1,1) NOT NULL PRIMARY KEY,
 ImeProizvoda nvarchar(20) NOT NULL,
 Cena decimal(6,0) NOT NULL,
 KategorijaID int FOREIGN KEY REFERENCES Kategorije(KategorijaID) NOT NULL,
 ProizvodjacID int FOREIGN KEY REFERENCES Proizvodjaci(ProizvodjacID) NOT NULL,
 AkcijaID int FOREIGN KEY REFERENCES Akcije(AkcijaID));

CREATE TABLE Vesti
(VestID int IDENTITY (1,1) NOT NULL PRIMARY KEY,
ImeVesti nvarchar(20) NOT NULL,
DatumObjave date DEFAULT GETDATE());

CREATE TABLE Katalozi
(KatalogID int IDENTITY (1,1) NOT NULL PRIMARY KEY,
ImeKataloga nvarchar(20),
MesecKataloga date NOT NULL);

CREATE TABLE ProizvodiKatalozi
(ProizvodID int FOREIGN KEY REFERENCES Proizvodi(ProizvodID) NOT NULL,
KatalogID int FOREIGN KEY REFERENCES Katalozi(KatalogID) NOT NULL
PRIMARY KEY (ProizvodID,KatalogID))

CREATE TABLE Korisnici
(KorisnikID int IDENTITY (1,1) NOT NULL PRIMARY KEY,
Ime nvarchar(20) NOT NULL,
Prezime nvarchar(20) NOT NULL,
Nadimak nvarchar(20),
Godine decimal(3,0) NOT NULL,
Username nvarchar (20) NOT NULL,
Email varchar(320) NOT NULL,
Lozinka nvarchar(32) NOT NULL,
Adresa nvarchar(50),
Grad nvarchar(20),
PostanskiBroj varchar(5),
TelefonKorisnika varchar(10),
Verifikovan bit DEFAULT 0,
CHECK (Godine >= 18));

CREATE TABLE Komentari
(KomentarID int IDENTITY (1,1) NOT NULL PRIMARY KEY,
Sadrzaj nvarchar(255) NOT NULL,
DatumKomentara date DEFAULT GETDATE(),
KorsnikID int FOREIGN KEY REFERENCES Korisnici(KorisnikID) NOT NULL);

CREATE TABLE Korpe
(KorisnikID int FOREIGN KEY REFERENCES Korisnici(KorisnikID) NOT NULL,
ProizvodID int FOREIGN KEY REFERENCES Proizvodi(ProizvodID) NOT NULL,
Kolicina decimal(3,0) DEFAULT 1
PRIMARY KEY(KorisnikID,ProizvodID));

CREATE TABLE ListeZelja
(KorisnikID int FOREIGN KEY REFERENCES Korisnici(KorisnikID) NOT NULL,
ProizvodID int FOREIGN KEY REFERENCES Proizvodi(ProizvodID) NOT NULL,
PRIMARY KEY(KorisnikID,ProizvodID));
GO
 
 /*EXEC sp_msforeachtable "ALTER TABLE ? NOCHECK CONSTRAINT all"
 EXEC sp_MSforeachtable @command1 = "DROP TABLE ?"*/