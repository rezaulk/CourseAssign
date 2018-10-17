namespace CourseAssignment.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CourseTableRemodified : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Courses", "TakenById", "dbo.Teachers");
            DropIndex("dbo.Courses", new[] { "TakenById" });
            CreateTable(
                "dbo.WeekDays",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Courses", "WeekDayId", c => c.Int(nullable: false));
            CreateIndex("dbo.Courses", "WeekDayId");
            AddForeignKey("dbo.Courses", "WeekDayId", "dbo.WeekDays", "Id", cascadeDelete: true);
            DropColumn("dbo.Courses", "Days");
            DropColumn("dbo.Courses", "TakenById");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Courses", "TakenById", c => c.Int(nullable: false));
            AddColumn("dbo.Courses", "Days", c => c.String(maxLength: 50));
            DropForeignKey("dbo.Courses", "WeekDayId", "dbo.WeekDays");
            DropIndex("dbo.Courses", new[] { "WeekDayId" });
            DropColumn("dbo.Courses", "WeekDayId");
            DropTable("dbo.WeekDays");
            CreateIndex("dbo.Courses", "TakenById");
            AddForeignKey("dbo.Courses", "TakenById", "dbo.Teachers", "Id", cascadeDelete: true);
        }
    }
}
