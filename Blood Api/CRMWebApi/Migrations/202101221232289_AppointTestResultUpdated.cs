namespace NashWebApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AppointTestResultUpdated : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.AppointmentTestResults", "AppointmentTestId", "dbo.AppointmentTests");
            DropIndex("dbo.AppointmentTestResults", new[] { "AppointmentTestId" });
            AddColumn("dbo.AppointmentTestResults", "AppointmentTestResultImageId", c => c.Int(nullable: false));
            CreateIndex("dbo.AppointmentTestResults", "AppointmentTestResultImageId");
            AddForeignKey("dbo.AppointmentTestResults", "AppointmentTestResultImageId", "dbo.ImageUploads", "Id");
            DropColumn("dbo.AppointmentTestResults", "AppointmentTestId");
            DropColumn("dbo.AppointmentTestResults", "AppointmenttestResultFile");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AppointmentTestResults", "AppointmenttestResultFile", c => c.String());
            AddColumn("dbo.AppointmentTestResults", "AppointmentTestId", c => c.Int(nullable: false));
            DropForeignKey("dbo.AppointmentTestResults", "AppointmentTestResultImageId", "dbo.ImageUploads");
            DropIndex("dbo.AppointmentTestResults", new[] { "AppointmentTestResultImageId" });
            DropColumn("dbo.AppointmentTestResults", "AppointmentTestResultImageId");
            CreateIndex("dbo.AppointmentTestResults", "AppointmentTestId");
            AddForeignKey("dbo.AppointmentTestResults", "AppointmentTestId", "dbo.AppointmentTests", "Id");
        }
    }
}
