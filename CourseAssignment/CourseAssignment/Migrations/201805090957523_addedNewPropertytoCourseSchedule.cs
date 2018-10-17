namespace CourseAssignment.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedNewPropertytoCourseSchedule : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CourseScheduleInfoes", "Room", c => c.String());
            DropColumn("dbo.CourseScheduleInfoes", "FridayTime");
        }
        
        public override void Down()
        {
            AddColumn("dbo.CourseScheduleInfoes", "FridayTime", c => c.String());
            DropColumn("dbo.CourseScheduleInfoes", "Room");
        }
    }
}
