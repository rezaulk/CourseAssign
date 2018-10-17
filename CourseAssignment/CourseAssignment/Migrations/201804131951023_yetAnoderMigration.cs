namespace CourseAssignment.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class yetAnoderMigration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Courses", "SemesterName", c => c.String());
            DropColumn("dbo.Courses", "ClassTimeIds");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Courses", "ClassTimeIds", c => c.String());
            DropColumn("dbo.Courses", "SemesterName");
        }
    }
}
