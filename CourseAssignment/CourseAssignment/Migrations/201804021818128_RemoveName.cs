namespace CourseAssignment.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveName : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Courses", "Name");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Courses", "Name", c => c.String(maxLength: 50));
        }
    }
}
