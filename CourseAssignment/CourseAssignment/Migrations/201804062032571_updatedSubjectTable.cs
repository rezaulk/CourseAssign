namespace CourseAssignment.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatedSubjectTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Subjects", "SemesterId", c => c.Int(nullable: false));
            CreateIndex("dbo.Subjects", "SemesterId");
            AddForeignKey("dbo.Subjects", "SemesterId", "dbo.Semesters", "Id", cascadeDelete: false);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Subjects", "SemesterId", "dbo.Semesters");
            DropIndex("dbo.Subjects", new[] { "SemesterId" });
            DropColumn("dbo.Subjects", "SemesterId");
        }
    }
}
