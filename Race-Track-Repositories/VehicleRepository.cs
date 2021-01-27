using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Race.Track.Models;
using Raceing.Track.Entity;

namespace Race.Track.Repositories
{
    public class VehicleRepository : IVehicleRepository, IDisposable
    {
        private readonly ICarRacingDBContext _dbContext;

        public VehicleRepository(ICarRacingDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public bool AddVehicle(RacingVehicleDetails vehicleDetails)
        {
            vehicleDetails.Id = Guid.NewGuid();
            _dbContext.RacingVehicleDetails.Add(vehicleDetails);
            _dbContext.SaveChanges();

            return true;
        }

        public RacingVehicleDetails GetVehicleById(string id)
        {
            return _dbContext.RacingVehicleDetails.FirstOrDefault(p => p.Id.ToString() == id);
        }

        public IEnumerable<RacingVehicleDetails> GetVehiclesOnRacingTrack()
        {
            return _dbContext.RacingVehicleDetails.Where(v => v.IsSetToRacingTrack);
        }

        public IEnumerable<RacingVehicleDetails> GetAllVehicles()
        {
            return _dbContext.RacingVehicleDetails;
        }

        public bool SaveVehiclesOnRacingTrack(RacingVehicleDetails racingVehicleDetails)
        {
            try
            {
                _dbContext.RacingVehicleDetails.Attach(racingVehicleDetails);
                _dbContext.SaveChanges();

                return true;
            }
            catch
            {
                return false;
            }

        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
