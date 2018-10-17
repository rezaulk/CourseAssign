namespace CourseAssignment.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedRoutineHistory : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.RoutineHistories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SemesterName = c.String(maxLength: 10),
                        SemesterNo = c.String(maxLength: 10),
                        year = c.String(maxLength: 10),
                        Room = c.String(maxLength: 10),
                        Campus = c.String(maxLength: 20),
                        Teachers = c.String(),
                        Subjects = c.String(),
                        AddedBy = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.RoutineHistories");
        }
    }
}
