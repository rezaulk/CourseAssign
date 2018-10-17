namespace CourseAssignment.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addeddaysfield : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.RoutineHistories", "Days", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.RoutineHistories", "Days");
        }
    }
}
