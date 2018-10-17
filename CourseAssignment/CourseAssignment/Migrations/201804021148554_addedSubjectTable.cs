namespace CourseAssignment.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedSubjectTable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Courses", "TakenBy_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Courses", new[] { "TakenBy_Id" });
            CreateTable(
                "dbo.Subjects",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SubjectCode = c.String(),
                        SubjectName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Courses", "SubjectId", c => c.Int(nullable: false));
            CreateIndex("dbo.Courses", "SubjectId");
            AddForeignKey("dbo.Courses", "SubjectId", "dbo.Subjects", "Id", cascadeDelete: true);
            DropColumn("dbo.Courses", "TakenBy_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Courses", "TakenBy_Id", c => c.String(maxLength: 128));
            DropForeignKey("dbo.Courses", "SubjectId", "dbo.Subjects");
            DropIndex("dbo.Courses", new[] { "SubjectId" });
            DropColumn("dbo.Courses", "SubjectId");
            DropTable("dbo.Subjects");
            CreateIndex("dbo.Courses", "TakenBy_Id");
            AddForeignKey("dbo.Courses", "TakenBy_Id", "dbo.AspNetUsers", "Id");
        }
    }
}
