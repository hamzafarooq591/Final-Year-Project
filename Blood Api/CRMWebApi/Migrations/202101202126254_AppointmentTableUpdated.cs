namespace NashWebApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AppointmentTableUpdated : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Appointments", "AppointmentStatus", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Appointments", "AppointmentStatus");
        }
    }
}
