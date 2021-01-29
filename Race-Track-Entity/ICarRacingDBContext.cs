using Race.Track.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raceing.Track.Entity
{
    public interface ICarRacingDBContext
    {
        IDbSet<RacingVehicleDetails> RacingVehicleDetails { get; set; }
        int SaveChanges();
        DbEntityEntry Entry(object entity);
    }
}
