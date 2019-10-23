using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace CodeFirst
{
    public class Student
    {
        public int StudentID { get; set; }
        public string Ime { get; set; }
        public IList<Predmet> Predmet { get; set; }
    };

    public class Predmet
    {
        public int PredmetID { get; set; }
        public string NazivPredmeta { get; set; }
        public Profesor Profesor { get; set; }
        public IList<Student> Student { get; set; }
    };

    public class Profesor
    {
        public int ProfesorID { get; set; }
        public string Ime { get; set; }

    };

    public class EntityDBCodeFirstContext : DbContext
    {
        public DbSet<Student> Student { get; set; }
        public DbSet<Predmet> Predmet { get; set; }
        public DbSet<Profesor> Profesor { get; set; }
    }
}
