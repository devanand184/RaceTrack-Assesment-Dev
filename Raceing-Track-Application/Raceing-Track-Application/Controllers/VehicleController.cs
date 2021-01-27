﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Race.Track.Models;
using Race.Track.Repositories;
using Raceing.Track.Entity;

namespace Raceing.Track.Application.Controllers
{
    public class VehicleController : Controller
    {
        private readonly IVehicleRepository _vehicleRepository;
        public VehicleController(IVehicleRepository vehicleRepository)
        {
            _vehicleRepository = vehicleRepository;
        }

        // GET: Vehicle/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Vehicle/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Description,Senstivity,Acceleration,Linearity,HorizonTilt,GearBox,Breaking,HandBreak,TowStrap,CanLift,VehichleImagePath,IsSetToRacingTrack")] RacingVehicleDetails racingVehicleDetails)
        {
            if (ModelState.IsValid)
            {
                racingVehicleDetails.Id = Guid.NewGuid();

                _vehicleRepository.AddVehicle(racingVehicleDetails);
               
                return RedirectToAction("GetAllVehicles", "RaceTrack");
            }

            return View(racingVehicleDetails);
        }
    }
}
