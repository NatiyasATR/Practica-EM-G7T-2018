namespace PracticaEM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateMatriculas : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AsignacionDocentes", "Grupo_Id", c => c.Int());
            AddColumn("dbo.Matriculas", "GrupoId", c => c.Int(nullable: false));
            AddColumn("dbo.Matriculas", "User_Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.AsignacionDocentes", "Grupo_Id");
            CreateIndex("dbo.Matriculas", "User_Id");
            AddForeignKey("dbo.AsignacionDocentes", "Grupo_Id", "dbo.GrupoClases", "Id");
            AddForeignKey("dbo.Matriculas", "User_Id", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Matriculas", "User_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.AsignacionDocentes", "Grupo_Id", "dbo.GrupoClases");
            DropIndex("dbo.Matriculas", new[] { "User_Id" });
            DropIndex("dbo.AsignacionDocentes", new[] { "Grupo_Id" });
            DropColumn("dbo.Matriculas", "User_Id");
            DropColumn("dbo.Matriculas", "GrupoId");
            DropColumn("dbo.AsignacionDocentes", "Grupo_Id");
        }
    }
}
