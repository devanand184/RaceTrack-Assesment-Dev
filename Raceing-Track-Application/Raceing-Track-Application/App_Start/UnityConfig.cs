namespace Raceing.Track.Application
{
    using System.Web.Mvc;
    using Race.Track.Models;
    using Race.Track.Repositories;
    using Raceing.Track.Entity;
    using Raceing.Track.Repositories.DBOperation;
    using Raceing.Track.Repositories.DBOperation.RacingVehicle;
    using Unity;
    using Unity.Mvc5;

    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
            // register all your components with the container here
            // it is NOT necessary to register your controllers

            var container = new UnityContainer();

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
            container.RegisterType<IVehicleRepository, VehicleRepository>();
            container.RegisterType<ICarRacingDBContext, CarRaceingDBContext>();
            container.RegisterType<IDbOperation<RacingVehicleDetails>, RacingVehicleDbOperation>();
        }
    }
}