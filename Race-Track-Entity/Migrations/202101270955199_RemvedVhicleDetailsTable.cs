namespace Raceing.Track.Entity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemvedVhicleDetailsTable : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.VehicleDetails");
        }
        
        public override void Down()
        {
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
    }
}
