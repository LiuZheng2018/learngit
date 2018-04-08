namespace SercicesMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Service1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Services", "S_CreatTime", c => c.String(unicode: false));
            DropColumn("dbo.Services", "S_LastTime");
            DropColumn("dbo.Services", "S_Admin");
            DropColumn("dbo.Services", "S_Remark");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Services", "S_Remark", c => c.String(unicode: false));
            AddColumn("dbo.Services", "S_Admin", c => c.String(unicode: false));
            AddColumn("dbo.Services", "S_LastTime", c => c.DateTime(nullable: false, precision: 0));
            AlterColumn("dbo.Services", "S_CreatTime", c => c.DateTime(nullable: false, precision: 0));
        }
    }
}
