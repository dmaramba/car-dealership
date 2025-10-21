using CarDealership.Models;
using CarDealership.Services;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.Tests
{
    public class VehicleServiceTests
    {
        private Mock<IVehicleService> _vehicleServiceMock;

        public VehicleServiceTests()
        {
            _vehicleServiceMock = new Mock<IVehicleService>();
        }

        [Fact]
        public void GetVehicles_Should_Return_VehicleList()
        {
            //arrange
            _vehicleServiceMock.Setup(x => x.GetAllVehicles()).Returns(new List<Models.Vehicle> {   new Vehicle
                  {
                      Make = "Toyota",
                      Model = "Corolla",
                      Year = 2021,
                      FuelType = "Petrol",
                      Condition = "Excellent",
                      Color = "White",
                      Description = "Reliable and fuel-efficient sedan.",
                      Price = 250000,
                      IsAvailable = true,
                      DateAdded = DateTime.Now
                  },
                  new Vehicle
                  {
                      Make = "Ford",
                      Model = "Ranger",
                      Year = 2020,
                      FuelType = "Diesel",
                      Condition = "Good",
                      Color = "Blue",
                      Description = "Strong double cab with off-road capability.",
                      Price = 480000,
                      IsAvailable = true,
                      DateAdded = DateTime.Now
                  },
            });

            //acti
            var vehicles=_vehicleServiceMock.Object.GetAllVehicles();


            //assert
            Assert.NotEmpty(vehicles);
            Assert.Equal(2, vehicles.Count);



        }

        [Fact]
        public void AddVehicle_Executes_The_AddVehicle_Method()
        {
            //Arrange
            _vehicleServiceMock.Setup(x => x.AddVehicle(It.IsAny<Vehicle>()));
            var vehicle = new Vehicle { Id = 1, Make = "Toyota" };

            //Act
            _vehicleServiceMock.Object.AddVehicle(vehicle);

            //Assert

            _vehicleServiceMock.Verify(x=>x.AddVehicle(It.IsAny<Vehicle>()), Times.Once);
        }

        [Fact]
        public void Get_Vehicle_Should_Return_A_Vehicle()
        {
            //Arrange
            var vehicle = new Vehicle { Id = 1, Make = "Toyota" };
            _vehicleServiceMock.Setup(x => x.GetVehicle(It.IsAny<int>())).Returns(vehicle);


            //Act
            var result = _vehicleServiceMock.Object.GetVehicle(1);

            //Assert
            Assert.NotNull(result);
            Assert.Equal(vehicle.Id, result.Id);
            Assert.Equal(vehicle.Make, result.Make);

        }
    }
}
