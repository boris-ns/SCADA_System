namespace SCADA_Core.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InputTag : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Alarms", "AlarmType", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Alarms", "AlarmType");
        }
    }
}
