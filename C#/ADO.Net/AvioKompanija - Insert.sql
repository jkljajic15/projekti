USE AvioKompanija;
GO

INSERT INTO Putnik (Brlk,Ime,Prezime) VALUES
(1,'Aleksandar','Aleksandrovic'),
(2,'Boris','Borisavljevic'),
(3,'Vladimir','Vladimirovic'),
(4,'Dejan','Dejanovic'),
(5,'Goran','Goranovic')

INSERT INTO Karta(BrojKarte,DatIzd,VaziDO,Cena,Brlk) VALUES
(1,'20180101','20180102',5000,1),
(2,'20180103','20180105',10000,2),
(3,'20180104','20180106',6000,3),
(4,'20180105','20180107',8000,4),
(5,'20180106','20180109',20000,5)

INSERT INTO Linija(SifraLinije,NazivLinije) VALUES
(100,'Beograd Njujork'),
(101,'Beograd Berlin'),
(102,'Beograd London'),
(103,'Beograd Pariz'),
(104,'Beograd Madrid')

INSERT INTO Aerodrom(SifraAer,NazivAer) VALUES
(1,'Nikola Tesla'),
(2,'Berlin Tegel Airport '),
(3,'Heathrow'),
(4,'Charles de Gaulle'),
(5,'Madrid Barajas'),
(6,'John F. Kennedy')

INSERT INTO Letilica(RegBr,Tip,Naziv,Opis) VALUES
(1,'Putnicki','Airbus A350','Novi ekonomicni model aviona'),
(2,'Putnicki','Boeing 787 Dreamliner','Luksuzni putnicki avion'),
(3,'Purnicki','Airbus A380','Najveci putnicki avion na svetu'),
(4,'Putnicki','Boeing 747','Najpoznatiji putnicki avion'),
(5,'Putnicki','Boeing 737','Najprodavaniji putnicki avion')

INSERT INTO AvioRuta(SifraLinije,BrLeta,SifraPolAer,SifraOdrAer) VALUES
(100,1001,1,6),
(101,1002,1,2),
(102,1003,1,3),
(103,1004,1,4),
(104,1005,1,5)

INSERT INTO Let(SifraLinije,BrLeta,DatumVreme,RegBr) VALUES
(100,1001,'2018-01-01 12:00',1),
(101,1002,'2018-01-01 13:00',2),
(102,1003,'2018-01-01 14:00',3),
(103,1004,'2018-01-01 15:00',4),
(104,1005,'2018-01-01 16:00',5)

INSERT INTO Sediste(BrojSedista,RegBr) VALUES
(1,1),
(2,1),
(3,1),
(4,1),
(5,2),
(1,2),
(2,2),
(3,2),
(4,3),
(5,3),
(1,3),
(2,3),
(3,4),
(4,4),
(5,4),
(1,4),
(2,5),
(3,5),
(4,5),
(5,5)

INSERT INTO Kupon
(BrojKarte,BrojKupona,Klasa,StatusKupona,Komentar,SifraLinije,BrLeta,DatumVreme,BrojSedista,RegBr) 
VALUES
(1,1,'Biznis',0,'Neki komentar',100,1001,'2018-01-01 12:00',1,1),
(1,2,'Biznis',0,'Neki komentar',100,1001,'2018-01-01 12:00',1,1),
(2,3,'Ekonomska',0,'Neki komentar',101,1002,'2018-01-01 13:00',5,3),
(3,4,'Ekonomska',0,'Neki komentar',102,1003,'2018-01-01 14:00',4,5),
(3,5,'Ekonomska',0,'Neki komentar',102,1003,'2018-01-01 14:00',4,5),
(5,6,'Prva',0,'Neki komentar',103,1004,'2018-01-01 15:00',3,4)