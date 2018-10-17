namespace CourseAssignment.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newUpdates : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Courses", "Rooms", c => c.String());
            AddColumn("dbo.Courses", "ClassTimes", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Courses", "ClassTimes");
            DropColumn("dbo.Courses", "Rooms");
        }
    }
}
