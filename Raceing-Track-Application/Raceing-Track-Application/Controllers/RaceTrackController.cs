using Race.Track.Repositories;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Raceing.Track.Application.Controllers
{
    public class RaceTrackController : Controller
    {
        private readonly IVehicleRepository _vehicleRepository;
        private readonly int _totalVehiclesCanBeOnTrack = 0;

        public RaceTrackController(IVehicleRepository vehicleRepository)
        {
            _vehicleRepository = vehicleRepository;
            _totalVehiclesCanBeOnTrack = Convert.ToInt32(ConfigurationManager.AppSettings["TotalVehiclesCanBeOnTrack"]);
        }

        // GET: All vehicles
        public ActionResult GetVehiclesOnTrack()
        {
            var receTrackVehicles = _vehicleRepository.GetVehiclesOnRacingTrack();

            return View(receTrackVehicles);
        }

        // GET: vehicle on track
        public ActionResult GetAllVehicles()
        {
            var receTrackVehicles = _vehicleRepository.GetAllVehicles();

            return View(receTrackVehicles);
        }

        public ActionResult SetVehicleOnTrack(string id)
        {
            try
            {
                var vehiclesAlreadyOnTrack = _vehicleRepository.GetVehiclesOnRacingTrack();
                if (vehiclesAlreadyOnTrack != null && vehiclesAlreadyOnTrack.Count() > _totalVehiclesCanBeOnTrack)
                {
                    TempData["ExceededNumberOfVehiclesOnTrackMessage"]= $"You can not select more than {_totalVehiclesCanBeOnTrack} vehicles on track, first remove anyone and then try.";
                }
                else
                {
                    var vehicle = _vehicleRepository.GetVehicleById(id);
                    if (vehicle != null)
                    {
                        vehicle.IsSetToRacingTrack = true;
                        _vehicleRepository.SaveVehiclesSelection(vehicle);
                    }
                }

                return RedirectToAction("GetAllVehicles");
            }
            catch (Exception ex)
            {
                return View();
            }
        }

        public ActionResult RemoveVehicleFromTrack(string id)
        {
            try
            {
                var vehicle = _vehicleRepository.GetVehicleById(id);
                if (vehicle != null)
                {
                    vehicle.IsSetToRacingTrack = false;
                    _vehicleRepository.SaveVehiclesSelection(vehicle);
                }
                return RedirectToAction("GetAllVehicles");
            }
            catch
            {
                return View();
            }
        }
    }
}
