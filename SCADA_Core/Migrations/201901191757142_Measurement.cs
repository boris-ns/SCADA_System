namespace SCADA_Core.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Measurement : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Alarms", "Tag_TagName", "dbo.Tags");
            RenameColumn(table: "dbo.Alarms", name: "Tag_TagName", newName: "InputTag_TagName");
            RenameIndex(table: "dbo.Alarms", name: "IX_Tag_TagName", newName: "IX_InputTag_TagName");
            DropPrimaryKey("dbo.Alarms");
            DropPrimaryKey("dbo.Tags");
            CreateTable(
                "dbo.Measurements",
                c => new
                    {
                        TagName = c.String(nullable: false, maxLength: 128),
                        Value = c.Single(nullable: false),
                        TimeStamp = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.TagName);
            
            AlterColumn("dbo.Alarms", "AlarmId", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.Tags", "TagName", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.Tags", "IOAddress", c => c.Int(nullable: false));
            AlterColumn("dbo.Tags", "ScanTime", c => c.Int());
            AddPrimaryKey("dbo.Alarms", "AlarmId");
            AddPrimaryKey("dbo.Tags", "TagName");
            AddForeignKey("dbo.Alarms", "InputTag_TagName", "dbo.Tags", "TagName");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Alarms", "InputTag_TagName", "dbo.Tags");
            DropPrimaryKey("dbo.Tags");
            DropPrimaryKey("dbo.Alarms");
            AlterColumn("dbo.Tags", "ScanTime", c => c.Single());
            AlterColumn("dbo.Tags", "IOAddress", c => c.String());
            AlterColumn("dbo.Tags", "TagName", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.Alarms", "AlarmId", c => c.Int(nullable: false));
            DropTable("dbo.Measurements");
            AddPrimaryKey("dbo.Tags", "TagName");
            AddPrimaryKey("dbo.Alarms", "AlarmId");
            RenameIndex(table: "dbo.Alarms", name: "IX_InputTag_TagName", newName: "IX_Tag_TagName");
            RenameColumn(table: "dbo.Alarms", name: "InputTag_TagName", newName: "Tag_TagName");
            AddForeignKey("dbo.Alarms", "Tag_TagName", "dbo.Tags", "TagName");
        }
    }
}
