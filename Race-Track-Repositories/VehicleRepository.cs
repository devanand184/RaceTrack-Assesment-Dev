namespace Race.Track.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Race.Track.Models;
    using Raceing.Track.Entity;
    using Raceing.Track.Repositories.DBOperation;

    public class VehicleRepository : IVehicleRepository, IDisposable
    {
        private readonly ICarRacingDBContext _dbContext;
        private readonly IDbOperation<RacingVehicleDetails> _dbOperation;

        public VehicleRepository(ICarRacingDBContext dbContext, IDbOperation<RacingVehicleDetails> dbOperation)
        {
            _dbContext = dbContext;
            _dbOperation = dbOperation;
        }

        public bool AddVehicle(RacingVehicleDetails vehicleDetails)
        {
            vehicleDetails.Id = Guid.NewGuid();
            try
            {
                _dbOperation.Insert(vehicleDetails);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return true;
        }

        public RacingVehicleDetails GetVehicleById(string id)
        {
           return _dbOperation.Get()
                .FirstOrDefault(p => p.Id.ToString() == id);
        }

        public IEnumerable<RacingVehicleDetails> GetVehiclesOnRacingTrack()
        {
            return _dbOperation.Get()
                .Where(v => v.IsSetToRacingTrack);
        }

        public IEnumerable<RacingVehicleDetails> GetAllVehicles()
        {
            return _dbOperation.Get();
        }

        public bool SaveVehiclesSelection(RacingVehicleDetails racingVehicleDetails)
        {
            try
            {
                _dbOperation.Update(racingVehicleDetails);

                return true;
            }
            catch (Exception ex)
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
