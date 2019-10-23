<Query Kind="Statements">
  <Connection>
    <ID>80610a42-8343-4ef3-bc1a-38974e36d45d</ID>
    <Persist>true</Persist>
    <Server>.</Server>
    <Database>EntityDBCodeFirst</Database>
    <NoPluralization>true</NoPluralization>
  </Connection>
</Query>

// insert
Predmet noviPredmet = new Predmet(){
	PredmetID = 99,
	NazivPredmeta = "Istorija Racunarstva",
	Profesor_ProfesorID = 2
	};
	
Predmet.InsertOnSubmit(noviPredmet);
SubmitChanges();

// update
Predmet izmeniPredmet = 
	(from p in Predmet
	where p.PredmetID == 99
	select p).Single();
	
izmeniPredmet.Profesor_ProfesorID = 1;
SubmitChanges();

// delete
Predmet brisanjePredmeta = Predmet.Where(p=>p.PredmetID == 2).Single();
Predmet.DeleteOnSubmit(brisanjePredmeta);
SubmitChanges();

// projekcija - sve vrednosti iz kolone NazivPredmeta
var predmeti =
	from p in Predmet
	select p.NazivPredmeta;
predmeti.Dump();

// filtriranje - svi predmeti od istog profesora
var predmetiOdProfesora =
	from p in Predmet
	where p.Profesor_ProfesorID == 1
	select p.NazivPredmeta;
predmeti.Dump();

// grupisanje - grupisanje po stranom kljucu
var grupePredmeta =
	from p in Predmet
	group p by p.Profesor_ProfesorID;
grupePredmeta.Dump();

// partitioning - uzimanje prva dva studenta iz tabele
var part = Student.Take(2);
part.Dump();

// ordering - imena studenata poredjana po abecednom redu
var ordered = 
	from s in Student
	orderby s.Ime
	select s;
ordered.Dump();

// count - prebrojavanje redova u tabeli student
(from s in Student
select s).Count().Dump();

// distinct - sva razlicita imena studenata
(from s in Student
select s.Ime).Distinct().Dump();

// group join
var j = 
	from p in Profesor
	join pr in Predmet 
	on p.ProfesorID equals pr.Profesor_ProfesorID into pGroup
	select new { Profesor = p, Predmet = pGroup };
j.Dump();

// inner join
var ij = from pr in Profesor
		join p in Predmet on pr.ProfesorID  equals p.Profesor_ProfesorID
		select new { ImeProfesora = pr.Ime, ImePredmeta = p.NazivPredmeta };
ij.Dump();

/* 
left outer join
var lj = from p in Profesor
		join pr in Predmet
		on p.ProfesorID equals pr.Profesor_ProfesorID into prGroup
		from pr in prGroup.DeafaultIfEmpty()
		select new { ImeProfesora = p.Ime, NazivPredmeta = pr == null ? "Nema predmete" : pr.NazivPredmeta };
lj.Dump();
*/