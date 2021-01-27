using Race.Track.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Race.Track.Repositories
{
    public interface IVehicleRepository
    {
        bool AddVehicle(RacingVehicleDetails vehicleDetails);

        bool SaveVehiclesOnRacingTrack(RacingVehicleDetails racingVehicleDetails);

        IEnumerable<RacingVehicleDetails> GetAllVehicles();
        IEnumerable<RacingVehicleDetails> GetVehiclesOnRacingTrack();
        RacingVehicleDetails GetVehicleById(string id);
    }
}
