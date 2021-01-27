namespace Raceing.Track.Entity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.RacingVehicleDetails",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Description = c.String(),
                        Senstivity = c.Int(nullable: false),
                        Acceleration = c.Int(nullable: false),
                        Linearity = c.Int(nullable: false),
                        HorizonTilt = c.Int(nullable: false),
                        GearBox = c.Int(nullable: false),
                        Breaking = c.Int(nullable: false),
                        HandBreak = c.Boolean(nullable: false),
                        TowStrap = c.Boolean(nullable: false),
                        CanLift = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.VehicleDetails",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                        Model = c.String(),
                        InternalColor = c.String(),
                        ExtrnalColor = c.String(),
                        SafteyRating = c.Int(nullable: false),
                        FuelType = c.String(),
                        TransmissionType = c.String(),
                        BodyType = c.String(),
                        FuelTankCapacity = c.Int(nullable: false),
                        MaxPower = c.Int(nullable: false),
                        MaxTorque = c.Int(nullable: false),
                        GearBox = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.VehicleDetails");
            DropTable("dbo.RacingVehicleDetails");
        }
    }
}
