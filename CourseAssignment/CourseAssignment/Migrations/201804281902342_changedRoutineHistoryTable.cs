namespace CourseAssignment.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changedRoutineHistoryTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.RoutineHistories", "ClassTimes", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.RoutineHistories", "ClassTimes");
        }
    }
}
