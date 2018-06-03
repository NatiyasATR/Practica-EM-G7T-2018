namespace PracticaEM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateAsignacionDocente2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AsignacionDocentes", "UserId", c => c.String());
            AddColumn("dbo.AsignacionDocentes", "Usuario_Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.AsignacionDocentes", "Usuario_Id");
            AddForeignKey("dbo.AsignacionDocentes", "Usuario_Id", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AsignacionDocentes", "Usuario_Id", "dbo.AspNetUsers");
            DropIndex("dbo.AsignacionDocentes", new[] { "Usuario_Id" });
            DropColumn("dbo.AsignacionDocentes", "Usuario_Id");
            DropColumn("dbo.AsignacionDocentes", "UserId");
        }
    }
}
