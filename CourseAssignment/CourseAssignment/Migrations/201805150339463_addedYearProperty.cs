namespace CourseAssignment.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedYearProperty : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Courses", "Year", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Courses", "Year");
        }
    }
}
