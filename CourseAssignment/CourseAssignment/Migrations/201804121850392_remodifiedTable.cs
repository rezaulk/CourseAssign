namespace CourseAssignment.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class remodifiedTable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Courses", "ClassTimeId", "dbo.ClassTimes");
            DropForeignKey("dbo.Courses", "WeekDayId", "dbo.WeekDays");
            DropIndex("dbo.Courses", new[] { "ClassTimeId" });
            DropIndex("dbo.Courses", new[] { "WeekDayId" });
            DropColumn("dbo.Courses", "ClassTimeId");
            DropColumn("dbo.Courses", "WeekDayId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Courses", "WeekDayId", c => c.Int(nullable: false));
            AddColumn("dbo.Courses", "ClassTimeId", c => c.Int(nullable: false));
            CreateIndex("dbo.Courses", "WeekDayId");
            CreateIndex("dbo.Courses", "ClassTimeId");
            AddForeignKey("dbo.Courses", "WeekDayId", "dbo.WeekDays", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Courses", "ClassTimeId", "dbo.ClassTimes", "Id", cascadeDelete: true);
        }
    }
}
