namespace Raceing.Track.Entity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PropertyChangesInRacingVehicleDetails : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.RacingVehicleDetails", "Description", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.RacingVehicleDetails", "Description", c => c.String());
        }
    }
}
