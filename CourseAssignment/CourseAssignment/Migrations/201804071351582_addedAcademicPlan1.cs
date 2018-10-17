namespace CourseAssignment.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedAcademicPlan1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AcademicPlans",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ClassCommence = c.String(),
                        Midterm = c.String(),
                        Final = c.String(),
                        NextClass = c.String(),
                        SemesterId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Semesters", t => t.SemesterId, cascadeDelete: true)
                .Index(t => t.SemesterId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AcademicPlans", "SemesterId", "dbo.Semesters");
            DropIndex("dbo.AcademicPlans", new[] { "SemesterId" });
            DropTable("dbo.AcademicPlans");
        }
    }
}
