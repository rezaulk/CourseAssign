namespace CourseAssignment.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedAcademicPlan2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.AcademicPlans", "SemesterId", "dbo.Semesters");
            DropIndex("dbo.AcademicPlans", new[] { "SemesterId" });
            AddColumn("dbo.AcademicPlans", "Season", c => c.String());
            DropColumn("dbo.AcademicPlans", "SemesterId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AcademicPlans", "SemesterId", c => c.Int(nullable: false));
            DropColumn("dbo.AcademicPlans", "Season");
            CreateIndex("dbo.AcademicPlans", "SemesterId");
            AddForeignKey("dbo.AcademicPlans", "SemesterId", "dbo.Semesters", "Id", cascadeDelete: true);
        }
    }
}
