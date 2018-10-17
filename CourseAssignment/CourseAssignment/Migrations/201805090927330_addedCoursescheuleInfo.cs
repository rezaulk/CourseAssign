namespace CourseAssignment.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedCoursescheuleInfo : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CourseScheduleInfoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CourseId = c.Int(nullable: false),
                        Day = c.String(),
                        Time = c.String(),
                        FridayTime = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.CourseScheduleInfoes");
        }
    }
}
