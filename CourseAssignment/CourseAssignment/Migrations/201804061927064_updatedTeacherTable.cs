namespace CourseAssignment.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatedTeacherTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Teachers", "TeacherId", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Teachers", "TeacherId");
        }
    }
}
