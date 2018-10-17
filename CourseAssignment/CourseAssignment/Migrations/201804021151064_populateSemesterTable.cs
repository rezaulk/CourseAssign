namespace CourseAssignment.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class populateSemesterTable : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Semesters(Name) VALUES ('1st')");
            Sql("INSERT INTO Semesters(Name) VALUES ('2nd')");
            Sql("INSERT INTO Semesters(Name) VALUES ('3rd')");
            Sql("INSERT INTO Semesters(Name) VALUES ('4th')");
            Sql("INSERT INTO Semesters(Name) VALUES ('5th')");
            Sql("INSERT INTO Semesters(Name) VALUES ('6th')");
            Sql("INSERT INTO Semesters(Name) VALUES ('7th')");
            Sql("INSERT INTO Semesters(Name) VALUES ('8th')");
            Sql("INSERT INTO Semesters(Name) VALUES ('9th')");
            Sql("INSERT INTO Semesters(Name) VALUES ('10th')");
            Sql("INSERT INTO Semesters(Name) VALUES ('11th')");
            Sql("INSERT INTO Semesters(Name) VALUES ('12th')");
        }
        
        public override void Down()
        {
            Sql("DELETE FROM Semesters WHERE ID in (1,2,3,4,5,6,7,8,9,10,11,12)");
        }
    }
}
