namespace CourseAssignment.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ReformPreviouslyCreatedTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.SubjectSelectedByTeacherInCourses", "ClassTime", c => c.String());
            AddColumn("dbo.SubjectSelectedByTeacherInCourses", "Day", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.SubjectSelectedByTeacherInCourses", "Day");
            DropColumn("dbo.SubjectSelectedByTeacherInCourses", "ClassTime");
        }
    }
}
