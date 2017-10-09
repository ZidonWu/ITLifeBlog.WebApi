namespace DAL.Core.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v7 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Accounts", "Role_Id", "dbo.Roles");
            DropIndex("dbo.Accounts", new[] { "Role_Id" });
            RenameColumn(table: "dbo.Accounts", name: "Role_Id", newName: "RoleId");
            AlterColumn("dbo.Accounts", "RoleId", c => c.Int(nullable: false));
            CreateIndex("dbo.Accounts", "RoleId");
            AddForeignKey("dbo.Accounts", "RoleId", "dbo.Roles", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Accounts", "RoleId", "dbo.Roles");
            DropIndex("dbo.Accounts", new[] { "RoleId" });
            AlterColumn("dbo.Accounts", "RoleId", c => c.Int());
            RenameColumn(table: "dbo.Accounts", name: "RoleId", newName: "Role_Id");
            CreateIndex("dbo.Accounts", "Role_Id");
            AddForeignKey("dbo.Accounts", "Role_Id", "dbo.Roles", "Id");
        }
    }
}
