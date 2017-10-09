namespace DAL.Core.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v6 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Accounts", "RoleId", "dbo.Roles");
            DropIndex("dbo.Accounts", new[] { "RoleId" });
            RenameColumn(table: "dbo.Accounts", name: "RoleId", newName: "Role_Id");
            AddColumn("dbo.Articles", "Role_Id", c => c.Int());
            AlterColumn("dbo.Accounts", "Role_Id", c => c.Int());
            CreateIndex("dbo.Accounts", "Role_Id");
            CreateIndex("dbo.Articles", "Role_Id");
            AddForeignKey("dbo.Articles", "Role_Id", "dbo.Roles", "Id");
            AddForeignKey("dbo.Accounts", "Role_Id", "dbo.Roles", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Accounts", "Role_Id", "dbo.Roles");
            DropForeignKey("dbo.Articles", "Role_Id", "dbo.Roles");
            DropIndex("dbo.Articles", new[] { "Role_Id" });
            DropIndex("dbo.Accounts", new[] { "Role_Id" });
            AlterColumn("dbo.Accounts", "Role_Id", c => c.Int(nullable: false));
            DropColumn("dbo.Articles", "Role_Id");
            RenameColumn(table: "dbo.Accounts", name: "Role_Id", newName: "RoleId");
            CreateIndex("dbo.Accounts", "RoleId");
            AddForeignKey("dbo.Accounts", "RoleId", "dbo.Roles", "Id", cascadeDelete: true);
        }
    }
}
