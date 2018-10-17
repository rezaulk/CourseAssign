namespace CourseAssignment.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedNewTabletoSaveCourseTeacher : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SubjectSelectedByTeacherInCourses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CourseId = c.Int(nullable: false),
                        SubjectName = c.String(),
                        SemesterNo = c.Int(nullable: false),
                        SemesterName = c.String(),
                        BatchName = c.String(),
                        TeacherName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.CourseScheduleInfoes", "isAvailable", c => c.Boolean(nullable: false));
            AddColumn("dbo.CourseScheduleInfoes", "SelectedBy", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.CourseScheduleInfoes", "SelectedBy");
            DropColumn("dbo.CourseScheduleInfoes", "isAvailable");
            DropTable("dbo.SubjectSelectedByTeacherInCourses");
        }
    }
}
