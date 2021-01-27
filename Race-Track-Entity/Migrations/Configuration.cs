namespace Raceing.Track.Entity.Migrations
{
    using Race.Track.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<CarRaceingDBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(CarRaceingDBContext context)
        {
            var racingVehicles = new List<RacingVehicleDetails>()
            {
                new RacingVehicleDetails()
                {
                    Id = Guid.NewGuid(),
                    Description = "Racing Vehicle-1",
                    Senstivity = 1,
                    Acceleration = 1,
                    Linearity = 1,
                    HorizonTilt = 1,
                    GearBox = 1,
                    Breaking = 1,
                    HandBreak = true,
                    TowStrap = true,
                    CanLift = 5,
                    VehichleImagePath= "../Images/Racing-Car-1.PNG",
                    IsSetToRacingTrack=true
                },
                new RacingVehicleDetails()
                {
                    Id = Guid.NewGuid(),
                    Description = "Racing Vehicle-2",
                    Senstivity = 1,
                    Acceleration = 1,
                    Linearity = 1,
                    HorizonTilt = 1,
                    GearBox = 1,
                    Breaking = 1,
                    HandBreak = true,
                    TowStrap = true,
                    CanLift = 5,
                    VehichleImagePath= "../Images/Racing-Car-2.PNG",
                    IsSetToRacingTrack=true
                },
                new RacingVehicleDetails()
                {
                    Id = Guid.NewGuid(),
                    Description = "Racing Vehicle-3",
                    Senstivity = 1,
                    Acceleration = 1,
                    Linearity = 1,
                    HorizonTilt = 1,
                    GearBox = 1,
                    Breaking = 1,
                    HandBreak = true,
                    TowStrap = true,
                    CanLift = 5,
                    VehichleImagePath= "../Images/Racing-Car-3.PNG",
                    IsSetToRacingTrack=true
                },
                new RacingVehicleDetails()
                {
                    Id = Guid.NewGuid(),
                    Description = "Racing Vehicle-4",
                    Senstivity = 1,
                    Acceleration = 1,
                    Linearity = 1,
                    HorizonTilt = 1,
                    GearBox = 1,
                    Breaking = 1,
                    HandBreak = true,
                    TowStrap = true,
                    CanLift = 5,
                    VehichleImagePath= "../Images/Racing-Car-4.PNG",
                    IsSetToRacingTrack=true
                },
                new RacingVehicleDetails()
                {
                    Id = Guid.NewGuid(),
                    Description = "Racing Vehicle-5",
                    Senstivity = 1,
                    Acceleration = 1,
                    Linearity = 1,
                    HorizonTilt = 1,
                    GearBox = 1,
                    Breaking = 1,
                    HandBreak = true,
                    TowStrap = true,
                    CanLift = 5,
                    VehichleImagePath= "../Images/Racing-Car-5.PNG",
                    IsSetToRacingTrack=false
                },
                new RacingVehicleDetails()
                {
                    Id = Guid.NewGuid(),
                    Description = "Racing Vehicle-7",
                    Senstivity = 1,
                    Acceleration = 1,
                    Linearity = 1,
                    HorizonTilt = 1,
                    GearBox = 1,
                    Breaking = 1,
                    HandBreak = true,
                    TowStrap = true,
                    CanLift = 5,
                    VehichleImagePath= "../Images/Racing-Car-1.PNG",
                    IsSetToRacingTrack=false
                },
                new RacingVehicleDetails()
                {
                    Id = Guid.NewGuid(),
                    Description = "Racing Vehicle-8",
                    Senstivity = 1,
                    Acceleration = 1,
                    Linearity = 1,
                    HorizonTilt = 1,
                    GearBox = 1,
                    Breaking = 1,
                    HandBreak = true,
                    TowStrap = true,
                    CanLift = 5,
                    VehichleImagePath= "../Images/Racing-Car-2.PNG",
                    IsSetToRacingTrack=false
                }
            };

            racingVehicles.ForEach(r => context.RacingVehicleDetails.Add(r));
            base.Seed(context);
        }
    }
}
