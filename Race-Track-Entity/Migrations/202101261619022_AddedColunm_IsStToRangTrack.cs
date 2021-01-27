namespace Raceing.Track.Entity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedColunm_IsStToRangTrack : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.RacingVehicleDetails", "IsSetToRacingTrack", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.RacingVehicleDetails", "IsSetToRacingTrack");
        }
    }
}
