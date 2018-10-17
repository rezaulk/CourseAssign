namespace CourseAssignment.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangetoDateTime : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Teachers", "joiningDate", c => c.DateTime(nullable: true));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Teachers", "joiningDate", c => c.String());
        }
    }
}
