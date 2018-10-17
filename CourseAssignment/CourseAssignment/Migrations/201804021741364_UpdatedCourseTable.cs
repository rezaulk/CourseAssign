namespace CourseAssignment.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatedCourseTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Courses", "Campus", c => c.String(maxLength: 50));
            AddColumn("dbo.Courses", "RoomNo", c => c.String(maxLength: 50));
            AddColumn("dbo.Courses", "Days", c => c.String(maxLength: 50));
            DropColumn("dbo.Courses", "ClassTIme2");
            DropColumn("dbo.Courses", "ClassTime3");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Courses", "ClassTime3", c => c.String(maxLength: 50));
            AddColumn("dbo.Courses", "ClassTIme2", c => c.String(maxLength: 50));
            DropColumn("dbo.Courses", "Days");
            DropColumn("dbo.Courses", "RoomNo");
            DropColumn("dbo.Courses", "Campus");
        }
    }
}
