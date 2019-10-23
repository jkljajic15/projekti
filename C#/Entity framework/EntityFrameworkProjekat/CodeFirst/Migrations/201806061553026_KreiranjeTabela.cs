namespace CodeFirst.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class KreiranjeTabela : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Predmet",
                c => new
                    {
                        PredmetID = c.Int(nullable: false, identity: false),
                        NazivPredmeta = c.String(),
                        Profesor_ProfesorID = c.Int(),
                    })
                .PrimaryKey(t => t.PredmetID)
                .ForeignKey("dbo.Profesor", t => t.Profesor_ProfesorID)
                .Index(t => t.Profesor_ProfesorID);
            
            CreateTable(
                "dbo.Profesor",
                c => new
                    {
                        ProfesorID = c.Int(nullable: false, identity: false),
                        Ime = c.String(),
                    })
                .PrimaryKey(t => t.ProfesorID);
            
            CreateTable(
                "dbo.Student",
                c => new
                    {
                        StudentID = c.Int(nullable: false, identity: false),
                        Ime = c.String(),
                    })
                .PrimaryKey(t => t.StudentID);
            
            CreateTable(
                "dbo.StudentPredmet",
                c => new
                    {
                        Student_StudentID = c.Int(nullable: false),
                        Predmet_PredmetID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Student_StudentID, t.Predmet_PredmetID })
                .ForeignKey("dbo.Student", t => t.Student_StudentID, cascadeDelete: true)
                .ForeignKey("dbo.Predmet", t => t.Predmet_PredmetID, cascadeDelete: true)
                .Index(t => t.Student_StudentID)
                .Index(t => t.Predmet_PredmetID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.StudentPredmets", "Predmet_PredmetID", "dbo.Predmets");
            DropForeignKey("dbo.StudentPredmets", "Student_StudentID", "dbo.Students");
            DropForeignKey("dbo.Predmets", "Profesor_ProfesorID", "dbo.Profesors");
            DropIndex("dbo.StudentPredmets", new[] { "Predmet_PredmetID" });
            DropIndex("dbo.StudentPredmets", new[] { "Student_StudentID" });
            DropIndex("dbo.Predmets", new[] { "Profesor_ProfesorID" });
            DropTable("dbo.StudentPredmets");
            DropTable("dbo.Students");
            DropTable("dbo.Profesors");
            DropTable("dbo.Predmets");
        }
    }
}
