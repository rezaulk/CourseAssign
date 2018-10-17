namespace CourseAssignment.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class regeneratedTeacherTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Teachers", "TeacherShortName", c => c.String());
            DropColumn("dbo.Teachers", "TeacherId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Teachers", "TeacherId", c => c.String());
            DropColumn("dbo.Teachers", "TeacherShortName");
        }
    }
}
