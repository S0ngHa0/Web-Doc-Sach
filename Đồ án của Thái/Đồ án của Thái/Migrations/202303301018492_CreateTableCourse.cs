namespace Đồ_án_của_Thái.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateTableCourse : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Comics",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        LecturerId = c.String(nullable: false, maxLength: 128),
                        NameComic = c.String(nullable: false, maxLength: 255),
                        Author = c.String(nullable: false, maxLength: 255),
                        Title = c.String(nullable: false, maxLength: 255),
                        Category = c.String(nullable: false, maxLength: 1000),
                        Picture = c.String(nullable: false, maxLength: 255),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.LecturerId, cascadeDelete: true)
                .Index(t => t.LecturerId);
            
            CreateTable(
                "dbo.Chapters",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ComicId = c.Int(nullable: false),
                        PictureChap = c.String(nullable: false, maxLength: 255),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Comics", t => t.ComicId, cascadeDelete: true)
                .Index(t => t.ComicId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Chapters", "ComicId", "dbo.Comics");
            DropForeignKey("dbo.Comics", "LecturerId", "dbo.AspNetUsers");
            DropIndex("dbo.Chapters", new[] { "ComicId" });
            DropIndex("dbo.Comics", new[] { "LecturerId" });
            DropTable("dbo.Chapters");
            DropTable("dbo.Comics");
        }
    }
}
