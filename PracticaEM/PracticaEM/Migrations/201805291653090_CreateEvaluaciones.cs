namespace PracticaEM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateEvaluaciones : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Matriculas", "CursoId", "dbo.Cursos");
            DropIndex("dbo.Matriculas", new[] { "CursoId" });
            DropColumn("dbo.Matriculas", "GrupoId");
            RenameColumn(table: "dbo.Matriculas", name: "ClaseId", newName: "GrupoId");
            RenameIndex(table: "dbo.Matriculas", name: "IX_ClaseId", newName: "IX_GrupoId");
            CreateTable(
                "dbo.Evaluaciones",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CursoId = c.Int(nullable: false),
                        UserId = c.String(maxLength: 128),
                        Convocatoria = c.Int(nullable: false),
                        Trabajo1 = c.Int(nullable: false),
                        Trabajo2 = c.Int(nullable: false),
                        Trabajo3 = c.Int(nullable: false),
                        Test = c.Int(nullable: false),
                        Practica = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cursos", t => t.CursoId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.CursoId)
                .Index(t => t.UserId);
            
            AddColumn("dbo.Matriculas", "Curso_Id", c => c.Int());
            AlterColumn("dbo.Matriculas", "CursoId", c => c.String());
            CreateIndex("dbo.Matriculas", "Curso_Id");
            AddForeignKey("dbo.Matriculas", "Curso_Id", "dbo.Cursos", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Matriculas", "Curso_Id", "dbo.Cursos");
            DropForeignKey("dbo.Evaluaciones", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Evaluaciones", "CursoId", "dbo.Cursos");
            DropIndex("dbo.Matriculas", new[] { "Curso_Id" });
            DropIndex("dbo.Evaluaciones", new[] { "UserId" });
            DropIndex("dbo.Evaluaciones", new[] { "CursoId" });
            AlterColumn("dbo.Matriculas", "CursoId", c => c.Int(nullable: false));
            DropColumn("dbo.Matriculas", "Curso_Id");
            DropTable("dbo.Evaluaciones");
            RenameIndex(table: "dbo.Matriculas", name: "IX_GrupoId", newName: "IX_ClaseId");
            RenameColumn(table: "dbo.Matriculas", name: "GrupoId", newName: "ClaseId");
            AddColumn("dbo.Matriculas", "GrupoId", c => c.Int(nullable: false));
            CreateIndex("dbo.Matriculas", "CursoId");
            AddForeignKey("dbo.Matriculas", "CursoId", "dbo.Cursos", "Id", cascadeDelete: true);
        }
    }
}
