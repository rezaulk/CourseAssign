namespace CourseAssignment.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveSubjects : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Courses", "SubjectId", "dbo.Subjects");
            DropIndex("dbo.Courses", new[] { "SubjectId" });
            DropColumn("dbo.Courses", "SubjectId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Courses", "SubjectId", c => c.Int(nullable: false));
            CreateIndex("dbo.Courses", "SubjectId");
            AddForeignKey("dbo.Courses", "SubjectId", "dbo.Subjects", "Id", cascadeDelete: true);
        }
    }
}
