namespace CourseAssignment.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedShiftTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Shifts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            Sql("INSERT INTO Shifts(Name) VALUES ('Day')");
            Sql("INSERT INTO Shifts(Name) VALUES ('Evening')");
        }
        
        public override void Down()
        {
            DropTable("dbo.Shifts");
            Sql("DELETE FROM Shifts WHERE ID in (1,2)");
        }
    }
}
