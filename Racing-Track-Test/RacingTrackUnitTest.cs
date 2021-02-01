namespace Racing_Track_Test
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;
    using Race.Track.Models;
    using Race.Track.Repositories;
    using Raceing.Track.Entity;
    using Raceing.Track.Repositories.DBOperation;

    [TestClass]
    public class RacingTrackUnitTest
    {
        #region local

        private IVehicleRepository _vehicleRepository;
        private ICarRacingDBContext _mockedCarRaceingDBContext;
        private Mock<IDbOperation<RacingVehicleDetails>> _dbOperation;
        private IList<RacingVehicleDetails> _mockedVehiclesOnRaceTrack;

        #endregion

        private void Setup()
        {
            CarRaceingDBContext carRaceingDBContext = new CarRaceingDBContext();
            _mockedVehiclesOnRaceTrack = new List<RacingVehicleDetails>()
            {
                new RacingVehicleDetails()
                {
                    Acceleration = 1,
                    Breaking = 1,
                    CanLift = 5,
                    Description = "Vehicle-Test-1",
                    GearBox = 1,
                    HandBreak = true,
                    HorizonTilt = 1,
                    Id = Guid.NewGuid(),
                    IsSetToRacingTrack = true,
                    Linearity = 1,
                    Senstivity = 1,
                    TowStrap = true
                },
                new RacingVehicleDetails()
                {
                    Acceleration = 1,
                    Breaking = 1,
                    CanLift = 5,
                    Description = "Vehicle-Test-2",
                    GearBox = 1,
                    HandBreak = true,
                    HorizonTilt = 1,
                    Id = Guid.NewGuid(),
                    IsSetToRacingTrack = false,
                    Linearity = 1,
                    Senstivity = 1,
                    TowStrap = true
                }
            };

            //Get mocked object
            _mockedCarRaceingDBContext = carRaceingDBContext.GetMockContext(_mockedVehiclesOnRaceTrack);

            _dbOperation = new Mock<IDbOperation<RacingVehicleDetails>>();

            _dbOperation.Setup(d => d.Get()).Returns(() => _mockedCarRaceingDBContext.RacingVehicleDetails);

            _vehicleRepository = new VehicleRepository(_mockedCarRaceingDBContext, _dbOperation.Object);
        }

        [TestMethod]
        public void Should_Get_VehicleOnTrack()
        {
            //Arrange
            Setup();

            //Act
            var vehiclesOnTrack = _vehicleRepository.GetVehiclesOnRacingTrack();

            //Assert
            Assert.IsTrue(vehiclesOnTrack.Any());
        }

        [TestMethod]
        public void Should_Get_AllVehiclesk()
        {
            //Arrange
            Setup();

            //Act
            var vehiclesOnTrack = _vehicleRepository.GetAllVehicles();

            //Assert
            Assert.IsTrue(vehiclesOnTrack.Count() > 0);
        }

        [TestMethod]
        public void Should_Add_Vehicle()
        {
            //Arrange
            Setup();

            //Act
            var isAdded = _vehicleRepository.AddVehicle(_mockedVehiclesOnRaceTrack[0]);

            //Assert
            Assert.IsTrue(isAdded);
        }

        [TestMethod]
        public void Should_Set_VehicleOnTrack()
        {
            //Arrange
            Setup();

            //Act
            var mockedVehicleToSet = _mockedVehiclesOnRaceTrack[0];
            mockedVehicleToSet.IsSetToRacingTrack = false;

            var isSet = _vehicleRepository.SaveVehiclesSelection(mockedVehicleToSet);

            //Assert
            Assert.IsTrue(isSet);
        }

        [TestMethod]
        public void Should_Remove_VehicleOnTrack()
        {
            //Arrange
            Setup();

            //Act
            var mockedVehicleToSet = _mockedVehiclesOnRaceTrack[0];
            mockedVehicleToSet.IsSetToRacingTrack = true;

            var isRemoved = _vehicleRepository.SaveVehiclesSelection(mockedVehicleToSet);

            //Assert
            Assert.IsTrue(isRemoved);
        }
    }
}
