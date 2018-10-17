namespace CourseAssignment.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatedCourseTable45 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Courses", "FridayClassTimes", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Courses", "FridayClassTimes");
        }
    }
}
