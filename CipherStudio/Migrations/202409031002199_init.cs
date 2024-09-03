namespace CipherStudio.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Subjects", "StudentId", "dbo.Students");
            DropIndex("dbo.Subjects", new[] { "StudentId" });
            DropColumn("dbo.Subjects", "StudentId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Subjects", "StudentId", c => c.Int(nullable: false));
            CreateIndex("dbo.Subjects", "StudentId");
            AddForeignKey("dbo.Subjects", "StudentId", "dbo.Students", "StudentId", cascadeDelete: true);
        }
    }
}
