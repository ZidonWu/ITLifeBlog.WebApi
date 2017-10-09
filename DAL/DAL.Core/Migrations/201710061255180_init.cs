namespace DAL.Core.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Accounts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Password = c.String(),
                        RoleId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Roles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Articles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ArticleGuid = c.String(),
                        Title = c.String(),
                        Description = c.String(),
                        Content = c.String(),
                        CreateTime = c.DateTime(nullable: false),
                        LastUpdateTime = c.DateTime(),
                        Stars = c.Int(nullable: false),
                        ReadNum = c.Int(nullable: false),
                        CommentNum = c.Int(nullable: false),
                        IsPublish = c.Boolean(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        AccountId = c.Int(nullable: false),
                        CategoryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Accounts", t => t.AccountId, cascadeDelete: true)
                .ForeignKey("dbo.Categories", t => t.CategoryId, cascadeDelete: true)
                .Index(t => t.AccountId)
                .Index(t => t.CategoryId);
            
            CreateTable(
                "dbo.ArticleComments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Content = c.String(),
                        CreateTime = c.DateTime(),
                        ArticleId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Articles", t => t.ArticleId, cascadeDelete: true)
                .Index(t => t.ArticleId);
            
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        Order = c.Int(nullable: false),
                        Count = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Articles", "CategoryId", "dbo.Categories");
            DropForeignKey("dbo.ArticleComments", "ArticleId", "dbo.Articles");
            DropForeignKey("dbo.Articles", "AccountId", "dbo.Accounts");
            DropForeignKey("dbo.Accounts", "RoleId", "dbo.Roles");
            DropIndex("dbo.ArticleComments", new[] { "ArticleId" });
            DropIndex("dbo.Articles", new[] { "CategoryId" });
            DropIndex("dbo.Articles", new[] { "AccountId" });
            DropIndex("dbo.Accounts", new[] { "RoleId" });
            DropTable("dbo.Categories");
            DropTable("dbo.ArticleComments");
            DropTable("dbo.Articles");
            DropTable("dbo.Roles");
            DropTable("dbo.Accounts");
        }
    }
}
