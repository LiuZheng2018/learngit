namespace EduMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EMSDB : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Courses",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        C_Id = c.Int(nullable: false),
                        C_Name = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Scores",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        score = c.Int(nullable: false),
                        Course_ID = c.Int(),
                        Student_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Courses", t => t.Course_ID)
                .ForeignKey("dbo.Students", t => t.Student_ID)
                .Index(t => t.Course_ID)
                .Index(t => t.Student_ID);
            
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        S_Id = c.Int(nullable: false),
                        S_Name = c.String(unicode: false),
                        S_Sex = c.String(unicode: false),
                        S_Age = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Teachers",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        T_Id = c.Int(nullable: false),
                        T_Name = c.String(unicode: false),
                        Course_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Courses", t => t.Course_ID)
                .Index(t => t.Course_ID);
            
            CreateTable(
                "dbo.StudentCourses",
                c => new
                    {
                        Student_ID = c.Int(nullable: false),
                        Course_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Student_ID, t.Course_ID })
                .ForeignKey("dbo.Students", t => t.Student_ID, cascadeDelete: true)
                .ForeignKey("dbo.Courses", t => t.Course_ID, cascadeDelete: true)
                .Index(t => t.Student_ID)
                .Index(t => t.Course_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Teachers", "Course_ID", "dbo.Courses");
            DropForeignKey("dbo.Scores", "Student_ID", "dbo.Students");
            DropForeignKey("dbo.StudentCourses", "Course_ID", "dbo.Courses");
            DropForeignKey("dbo.StudentCourses", "Student_ID", "dbo.Students");
            DropForeignKey("dbo.Scores", "Course_ID", "dbo.Courses");
            DropIndex("dbo.StudentCourses", new[] { "Course_ID" });
            DropIndex("dbo.StudentCourses", new[] { "Student_ID" });
            DropIndex("dbo.Teachers", new[] { "Course_ID" });
            DropIndex("dbo.Scores", new[] { "Student_ID" });
            DropIndex("dbo.Scores", new[] { "Course_ID" });
            DropTable("dbo.StudentCourses");
            DropTable("dbo.Teachers");
            DropTable("dbo.Students");
            DropTable("dbo.Scores");
            DropTable("dbo.Courses");
        }
    }
}
