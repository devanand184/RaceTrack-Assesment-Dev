namespace Raceing.Track.Entity
{
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.ModelConfiguration.Conventions;
    using System.Linq;
    using Moq;
    using Race.Track.Models;

    public class CarRaceingDBContext : DbContext, ICarRacingDBContext
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public CarRaceingDBContext() : base("CarRaceingContext")
        {

        }

        /// <summary>
        /// RacingVehicleDetails db set.
        /// </summary>
        public IDbSet<RacingVehicleDetails> RacingVehicleDetails { get; set; }
       
        /// <summary>
        /// Typically this method define extension methods on this object that allow you to configure aspects of the model-
        /// that are specific to a given database.
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

        public virtual ICarRacingDBContext GetMockContext(IList<RacingVehicleDetails> racingVehicleDetails)
        {
            var dbSetGenres = GetMockDbSet<RacingVehicleDetails>(racingVehicleDetails);

            var mockContext = new Mock<ICarRacingDBContext>();
            mockContext.Setup(m => m.RacingVehicleDetails).Returns(dbSetGenres);

            return mockContext.Object;
        }

        protected virtual IDbSet<T> GetMockDbSet<T>(IList<T> data) where T : class
        {
            var queryable = data.AsQueryable();
            var mockSet = new Mock<IDbSet<T>>();
            mockSet.As<IQueryable<T>>().Setup(m => m.Provider).Returns(queryable.Provider);
            mockSet.As<IQueryable<T>>().Setup(m => m.Expression).Returns(queryable.Expression);
            mockSet.As<IQueryable<T>>().Setup(m => m.ElementType).Returns(queryable.ElementType);
            mockSet.As<IQueryable<T>>().Setup(m => m.GetEnumerator()).Returns(queryable.GetEnumerator());
            mockSet.Setup(d => d.Add(It.IsAny<T>())).Callback<T>((s) => data.Add(s));

            return mockSet.Object;
        }
    }
}
