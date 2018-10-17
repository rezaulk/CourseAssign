namespace CourseAssignment.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedClassTimeTable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Courses", "CategoryId", "dbo.Categories");
            DropIndex("dbo.Courses", new[] { "CategoryId" });
            CreateTable(
                "dbo.ClassTimes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Courses", "ClassTimeId", c => c.Int(nullable: false));
            CreateIndex("dbo.Courses", "ClassTimeId");
            AddForeignKey("dbo.Courses", "ClassTimeId", "dbo.ClassTimes", "Id", cascadeDelete: true);
            DropColumn("dbo.Courses", "Description");
            DropColumn("dbo.Courses", "CategoryId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Courses", "CategoryId", c => c.Int(nullable: false));
            AddColumn("dbo.Courses", "Description", c => c.String(maxLength: 120));
            DropForeignKey("dbo.Courses", "ClassTimeId", "dbo.ClassTimes");
            DropIndex("dbo.Courses", new[] { "ClassTimeId" });
            DropColumn("dbo.Courses", "ClassTimeId");
            DropTable("dbo.ClassTimes");
            CreateIndex("dbo.Courses", "CategoryId");
            AddForeignKey("dbo.Courses", "CategoryId", "dbo.Categories", "Id", cascadeDelete: true);
        }
    }
}
