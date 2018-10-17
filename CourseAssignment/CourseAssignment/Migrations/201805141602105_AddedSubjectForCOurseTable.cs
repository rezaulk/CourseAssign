namespace CourseAssignment.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedSubjectForCOurseTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SubjectForCOurses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CourseId = c.Int(nullable: false),
                        SubjectName = c.String(),
                        SubjectCode = c.String(),
                        TeacherName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.SubjectForCOurses");
        }
    }
}
