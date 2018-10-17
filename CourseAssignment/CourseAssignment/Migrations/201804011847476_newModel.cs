namespace CourseAssignment.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Courses", "TakenBy_Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.Courses", "TakenBy_Id");
            AddForeignKey("dbo.Courses", "TakenBy_Id", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Courses", "TakenBy_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Courses", new[] { "TakenBy_Id" });
            DropColumn("dbo.Courses", "TakenBy_Id");
        }
    }
}
