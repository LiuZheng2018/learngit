namespace SercicesMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Service : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Services",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        S_Name = c.String(nullable: false, unicode: false),
                        S_Path = c.String(nullable: false, unicode: false),
                        Pic_Path = c.String(unicode: false),
                        S_User = c.String(unicode: false),
                        S_Pwd = c.String(unicode: false),
                        S_CreatTime = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Services");
        }
    }
}
