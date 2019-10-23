CREATE DATABASE AvioKompanija;
GO

USE AvioKompanija;
GO

CREATE TABLE Putnik
(
	Brlk int NOT NULL CONSTRAINT PK_Brlk PRIMARY KEY,
	Ime nvarchar(30) NOT NULL,
	Prezime nvarchar(30) NOT NULL

); 

CREATE TABLE Karta
(
	BrojKarte int NOT NULL CONSTRAINT PK_BrojKarte PRIMARY KEY,
	DatIzd date NOT NULL,
	VaziDO date NOT NULL,
	Cena decimal(18,2) NOT NULL,
	Brlk int NOT NULL
		CONSTRAINT FK_Karta_Brlk
		FOREIGN KEY
		REFERENCES Putnik(Brlk)
);

CREATE TABLE Linija
(
	SifraLinije int NOT NULL CONSTRAINT PK_Linija PRIMARY KEY,
	NazivLinije nvarchar(30) NOT NULL
);

CREATE TABLE Aerodrom
(	
	SifraAer int NOT NULL CONSTRAINT PK_Aerodrom PRIMARY KEY,
	NazivAer nvarchar(50) NOT NULL
);

CREATE TABLE Letilica
(
	RegBr int NOT NULL CONSTRAINT PK_Letilica PRIMARY KEY,
	Tip nvarchar(20) NOT NULL,
	Naziv nvarchar(50) NOT NULL,
	Opis nvarchar(100)
);

CREATE TABLE AvioRuta
(
	SifraLinije int NOT NULL,
	BrLeta int NOT NULL,
	SifraPolAer int NOT NULL,
	SifraOdrAer int NOT NULL,
	CONSTRAINT PK_AvioRuta PRIMARY KEY(SifraLinije,Brleta),
	CONSTRAINT FK_AvioRuta_PolAer 
		FOREIGN KEY (SifraPolAer) 
		REFERENCES Aerodrom(SifraAer),
	CONSTRAINT FK_AvioRuta_OdrAer 
		FOREIGN KEY (SifraOdrAer) 
		REFERENCES Aerodrom(SifraAer),
	CONSTRAINT FK_Linija_AvioRuta 
		FOREIGN KEY (SifraLinije) 
		REFERENCES Linija(SifraLinije)
);

CREATE TABLE Let
(
	SifraLinije int NOT NULL,
	BrLeta int NOT NULL,
	DatumVreme smalldatetime NOT NULL,
	CONSTRAINT PK_Let PRIMARY KEY(SifraLinije,BrLeta,DatumVreme),
	RegBr int NOT NULL
	CONSTRAINT FK_Let_RegBr
		FOREIGN KEY
		REFERENCES Letilica(RegBr),
	CONSTRAINT FK_AvioRuta_Let 
		FOREIGN KEY (SifraLinije,BrLeta)
		REFERENCES AvioRuta(SifraLinije,Brleta)
);

CREATE TABLE Sediste
(
	RegBr int NOT NULL,
	BrojSedista int NOT NULL,
	CONSTRAINT PK_Sediste PRIMARY KEY(RegBr,BrojSedista),
	CONSTRAINT FK_Letilica_Sediste FOREIGN KEY (RegBr) REFERENCES Letilica(RegBR)
);

CREATE TABLE Kupon
(
	BrojKarte int NOT NULL,
	BrojKupona int NOT NULL,
	Klasa NVARCHAR(20) NOT NULL,
	StatusKupona bit NOT NULL DEFAULT 0,
	Komentar NVARCHAR(144),
	CONSTRAINT PK_Kupon PRIMARY KEY (BrojKarte,BrojKupona),
	CONSTRAINT FK_Karta_Kupon 
		FOREIGN KEY (BrojKarte) 
		REFERENCES Karta(BrojKarte),
	SifraLinije int NOT NULL,
	BrLeta int NOT NULL,
	DatumVreme smalldatetime NOT NULL,
	CONSTRAINT FK_Let_Kupon 
		FOREIGN KEY (SifraLinije,BRLeta,DatumVreme)
		REFERENCES Let(SifraLinije,BRLeta,DatumVreme),
	BrojSedista int NOT NULL,
	RegBr int NOT NULL,
	CONSTRAINT FK_Sediste_Kupon 
		FOREIGN KEY (RegBr,BrojSedista)
		REFERENCES Sediste(RegBr,BrojSedista)
);







