namespace CourseAssignment.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddednewteacherProperty : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Teachers", new[] { "User_Id" });
            DropColumn("dbo.Teachers", "UserId");
            RenameColumn(table: "dbo.Teachers", name: "User_Id", newName: "UserId");
            AlterColumn("dbo.Teachers", "UserId", c => c.String(maxLength: 128));
            CreateIndex("dbo.Teachers", "UserId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Teachers", new[] { "UserId" });
            AlterColumn("dbo.Teachers", "UserId", c => c.Int(nullable: false));
            RenameColumn(table: "dbo.Teachers", name: "UserId", newName: "User_Id");
            AddColumn("dbo.Teachers", "UserId", c => c.Int(nullable: false));
            CreateIndex("dbo.Teachers", "User_Id");
        }
    }
}
