namespace CourseAssignment.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedCourseTakenTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CourseTakens",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TeacherName = c.String(),
                        SemesterNo = c.String(),
                        SemesterName = c.String(),
                        Batch = c.String(),
                        SubjectNames = c.String(),
                        SubjectCodes = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.CourseTakens");
        }
    }
}
