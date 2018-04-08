namespace SercicesMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Service2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Services", "S_LastTime", c => c.String(unicode: false));
            AddColumn("dbo.Services", "S_Admin", c => c.String(unicode: false));
            AddColumn("dbo.Services", "S_Remark", c => c.String(unicode: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Services", "S_Remark");
            DropColumn("dbo.Services", "S_Admin");
            DropColumn("dbo.Services", "S_LastTime");
        }
    }
}
