namespace DAL.Core.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v8 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Articles", "Role_Id", "dbo.Roles");
            DropIndex("dbo.Articles", new[] { "Role_Id" });
            DropColumn("dbo.Articles", "Role_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Articles", "Role_Id", c => c.Int());
            CreateIndex("dbo.Articles", "Role_Id");
            AddForeignKey("dbo.Articles", "Role_Id", "dbo.Roles", "Id");
        }
    }
}
