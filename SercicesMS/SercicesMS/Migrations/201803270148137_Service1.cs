namespace SercicesMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Service1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Services", "S_Pwd", c => c.String(unicode: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Services", "S_Pwd", c => c.Int(nullable: false));
        }
    }
}
