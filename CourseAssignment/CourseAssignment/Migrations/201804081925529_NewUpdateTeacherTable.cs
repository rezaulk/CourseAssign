namespace CourseAssignment.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NewUpdateTeacherTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Courses", "TakenById", c => c.Int(nullable: false));
            CreateIndex("dbo.Courses", "TakenById");
            AddForeignKey("dbo.Courses", "TakenById", "dbo.Teachers", "Id", cascadeDelete: false);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Courses", "TakenById", "dbo.Teachers");
            DropIndex("dbo.Courses", new[] { "TakenById" });
            DropColumn("dbo.Courses", "TakenById");
        }
    }
}
