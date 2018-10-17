namespace CourseAssignment.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedCoordinatorIdProperty : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Batches", "CoordinatorId", c => c.Int(nullable: true));
            AddColumn("dbo.ClassTimes", "CoordinatorId", c => c.Int(nullable: true));
            AddColumn("dbo.Semesters", "CoorinatorId", c => c.Int(nullable: true));
            AddColumn("dbo.Subjects", "CoordinatorId", c => c.Int(nullable: true));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Subjects", "CoordinatorId");
            DropColumn("dbo.Semesters", "CoorinatorId");
            DropColumn("dbo.ClassTimes", "CoordinatorId");
            DropColumn("dbo.Batches", "CoordinatorId");
        }
    }
}
