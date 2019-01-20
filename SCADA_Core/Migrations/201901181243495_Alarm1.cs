namespace SCADA_Core.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Alarm1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Alarms", "AlarmName", c => c.String());
            AddColumn("dbo.Alarms", "LowLimit", c => c.Single(nullable: false));
            AddColumn("dbo.Alarms", "HighLimit", c => c.Single(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Alarms", "HighLimit");
            DropColumn("dbo.Alarms", "LowLimit");
            DropColumn("dbo.Alarms", "AlarmName");
        }
    }
}
