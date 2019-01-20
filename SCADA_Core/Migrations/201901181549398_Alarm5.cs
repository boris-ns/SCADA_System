namespace SCADA_Core.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Alarm5 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Alarms", "Tag_TagName", "dbo.Tags");
            DropPrimaryKey("dbo.Alarms");
            DropPrimaryKey("dbo.Tags");
            AlterColumn("dbo.Alarms", "AlarmId", c => c.Int(nullable: false));
            AlterColumn("dbo.Tags", "TagName", c => c.String(nullable: false, maxLength: 128));
            AddPrimaryKey("dbo.Alarms", "AlarmId");
            AddPrimaryKey("dbo.Tags", "TagName");
            AddForeignKey("dbo.Alarms", "Tag_TagName", "dbo.Tags", "TagName");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Alarms", "Tag_TagName", "dbo.Tags");
            DropPrimaryKey("dbo.Tags");
            DropPrimaryKey("dbo.Alarms");
            AlterColumn("dbo.Tags", "TagName", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.Alarms", "AlarmId", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Tags", "TagName");
            AddPrimaryKey("dbo.Alarms", "AlarmId");
            AddForeignKey("dbo.Alarms", "Tag_TagName", "dbo.Tags", "TagName");
        }
    }
}
