namespace Raceing.Track.Repositories.DBOperation.RacingVehicle
{
    using Race.Track.Models;
    using Raceing.Track.Entity;
    using System.Data.Entity;

    public class RacingVehicleDbOperation : IDbOperation<RacingVehicleDetails>
    {
        private readonly ICarRacingDBContext _dbContext;

        public RacingVehicleDbOperation(ICarRacingDBContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IDbSet<RacingVehicleDetails> Get()
        {
            return _dbContext.RacingVehicleDetails;
        }

        public int Insert(RacingVehicleDetails entity)
        {
            _dbContext.RacingVehicleDetails.Add(entity);
            return _dbContext.SaveChanges();
        }

        public int Update(RacingVehicleDetails entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            return _dbContext.SaveChanges();
        }
    }
}
