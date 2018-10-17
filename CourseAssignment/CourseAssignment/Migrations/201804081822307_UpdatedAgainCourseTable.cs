namespace CourseAssignment.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatedAgainCourseTable : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Courses", "ClassTime1");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Courses", "ClassTime1", c => c.String(maxLength: 50));
        }
    }
}
