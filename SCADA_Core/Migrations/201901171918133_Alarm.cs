namespace SCADA_Core.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Alarm : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Alarms");
            AlterColumn("dbo.Alarms", "AlarmId", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Alarms", "AlarmId");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.Alarms");
            AlterColumn("dbo.Alarms", "AlarmId", c => c.String(nullable: false, maxLength: 128));
            AddPrimaryKey("dbo.Alarms", "AlarmId");
        }
    }
}
