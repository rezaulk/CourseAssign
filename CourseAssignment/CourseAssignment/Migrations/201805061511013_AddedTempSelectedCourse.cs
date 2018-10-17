namespace CourseAssignment.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedTempSelectedCourse : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TempSelectCourses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SemesterName = c.String(),
                        BatchName = c.String(),
                        Teacher = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.TempSelectCourses");
        }
    }
}
