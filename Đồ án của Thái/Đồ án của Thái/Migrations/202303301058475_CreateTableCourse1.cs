namespace Đồ_án_của_Thái.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateTableCourse1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Comics", "LecturerId", "dbo.AspNetUsers");
            DropIndex("dbo.Comics", new[] { "LecturerId" });
            DropColumn("dbo.Comics", "LecturerId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Comics", "LecturerId", c => c.String(nullable: false, maxLength: 128));
            CreateIndex("dbo.Comics", "LecturerId");
            AddForeignKey("dbo.Comics", "LecturerId", "dbo.AspNetUsers", "Id", cascadeDelete: true);
        }
    }
}
