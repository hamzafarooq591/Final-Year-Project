namespace NashWebApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AppointmentAndPatientEntityUpdated : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Appointments", "IsBookingForMyself", c => c.Boolean(nullable: false));
            AddColumn("dbo.Appointments", "AppointmentPatientName", c => c.String());
            AddColumn("dbo.Appointments", "PatientPhoneNumber", c => c.String());
            AddColumn("dbo.Appointments", "PatientGender", c => c.String());
            AddColumn("dbo.Appointments", "PatientRelationship", c => c.String());
            AddColumn("dbo.Patients", "Gender", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Patients", "Gender");
            DropColumn("dbo.Appointments", "PatientRelationship");
            DropColumn("dbo.Appointments", "PatientGender");
            DropColumn("dbo.Appointments", "PatientPhoneNumber");
            DropColumn("dbo.Appointments", "AppointmentPatientName");
            DropColumn("dbo.Appointments", "IsBookingForMyself");
        }
    }
}
