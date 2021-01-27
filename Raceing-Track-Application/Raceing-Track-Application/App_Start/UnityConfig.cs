using Race.Track.Repositories;
using Raceing.Track.Entity;
using System.Web.Mvc;
using Unity;
using Unity.Mvc5;

namespace Raceing.Track.Application
{
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
        }
    }
}