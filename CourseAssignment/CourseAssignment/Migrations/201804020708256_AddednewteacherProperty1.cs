namespace CourseAssignment.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddednewteacherProperty1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Teachers", "TeacherOrder", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Teachers", "TeacherOrder", c => c.String());
        }
    }
}
