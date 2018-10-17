namespace CourseAssignment.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateoutineHistoryTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.RoutineHistories", "BatchName", c => c.String(maxLength: 10));
        }
        
        public override void Down()
        {
            DropColumn("dbo.RoutineHistories", "BatchName");
        }
    }
}
