namespace CourseAssignment.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateCategoryTable : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Categories(Name) VALUES ('Theory')");
            Sql("INSERT INTO Categories(Name) VALUES ('Lab')");
        }
        
        public override void Down()
        {
            Sql("DELETE FROM Categories WHERE ID in (1,2)");
        }
    }
}
