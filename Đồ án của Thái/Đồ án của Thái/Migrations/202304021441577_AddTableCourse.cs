namespace Đồ_án_của_Thái.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTableCourse : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Follows",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ComicId = c.Int(nullable: false),
                        FolloweeId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Comics", t => t.ComicId)
                .ForeignKey("dbo.AspNetUsers", t => t.FolloweeId)
                .Index(t => t.ComicId)
                .Index(t => t.FolloweeId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Follows", "FolloweeId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Follows", "ComicId", "dbo.Comics");
            DropIndex("dbo.Follows", new[] { "FolloweeId" });
            DropIndex("dbo.Follows", new[] { "ComicId" });
            DropTable("dbo.Follows");
        }
    }
}
