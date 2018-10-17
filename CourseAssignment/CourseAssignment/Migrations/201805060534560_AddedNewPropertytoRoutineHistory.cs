namespace CourseAssignment.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedNewPropertytoRoutineHistory : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.RoutineHistories", "FridayClassTimes", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.RoutineHistories", "FridayClassTimes");
        }
    }
}
