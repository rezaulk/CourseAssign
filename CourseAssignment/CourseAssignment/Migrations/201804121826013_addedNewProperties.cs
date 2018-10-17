namespace CourseAssignment.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedNewProperties : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Courses", "ClassTimeIds", c => c.String());
            AddColumn("dbo.Courses", "WeekDayIds", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Courses", "WeekDayIds");
            DropColumn("dbo.Courses", "ClassTimeIds");
        }
    }
}
