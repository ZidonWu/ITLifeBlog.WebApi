namespace DAL.Core.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v9 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ArticleComments", "ArticleId", "dbo.Articles");
            DropIndex("dbo.ArticleComments", new[] { "ArticleId" });
            CreateTable(
                "dbo.Albums",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        OldFileName = c.String(),
                        NewFileName = c.String(),
                        Extension = c.String(),
                        Url = c.String(),
                        Description = c.String(),
                        Size = c.Int(nullable: false),
                        CreateTime = c.DateTime(nullable: false),
                        AccountId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Accounts", t => t.AccountId, cascadeDelete: true)
                .Index(t => t.AccountId);
            
            DropTable("dbo.ArticleComments");
        }
        
        public override void Down()
        {
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
                .PrimaryKey(t => t.Id);
            
            DropForeignKey("dbo.Albums", "AccountId", "dbo.Accounts");
            DropIndex("dbo.Albums", new[] { "AccountId" });
            DropTable("dbo.Albums");
            CreateIndex("dbo.ArticleComments", "ArticleId");
            AddForeignKey("dbo.ArticleComments", "ArticleId", "dbo.Articles", "Id", cascadeDelete: true);
        }
    }
}
