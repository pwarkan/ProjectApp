using AutoMapper;
using Entities;
using Entities.Models;
using LoggerService;
using Microsoft.AspNetCore.Mvc;
using Moq;
using ProjectApp.Controllers;
using References;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Tests
{
    public class CarsControllerTest
    {
        private readonly CarsFakeController _controller;
        private readonly Mock<ICarRepository> _mockCarRepo;
        public CarsControllerTest()
        {
            _mockCarRepo = new Mock<ICarRepository>();
            _controller = new CarsFakeController(_mockCarRepo.Object);
        }

        [Fact]
        public void Get_WhenCalled_ReturnsAllItems()
        {
            _mockCarRepo.Setup(repo => repo.GetAllCars(false))
                .Returns(new List<Car>() { new Car(), new Car(), new Car() });

            //Act
            var okResult = _controller.GetAllCars().Result as OkObjectResult;

            //Assert
            var items = Assert.IsType<List<Car>>(okResult.Value);
            Assert.Equal(3, items.Count);
        }

        [Fact]
        public void Get_WhenCalled_ReturnsOkResult()
        {
            //Act
            var okResult = _controller.GetAllCars().Result;

            //Assert
            Assert.IsType<OkObjectResult>(okResult);
        }

        [Fact]
        public void GetById_UnknownId_ReturnsNotFoundResult()
        {
            // Act
            var result = _controller.GetCar(0);

            // Assert
            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public void GetById_PassedId_ReturnsOkResult()
        {
            //Arrange
            _mockCarRepo.Setup(repo => repo.GetCar(1, false))
               .Returns(new Car());

            // Act
            var okResult = _controller.GetCar(1);

            // Assert
            Assert.IsType<OkObjectResult>(okResult);
        }

        [Fact]
        public void Add_InvalidObjectPassed_ReturnsBadRequest()
        {
            // Arrange
            var item = new Car()
            {
                Id = 1,
                //Model = "Acura",
                Brand = "Honda",
                VIN = "1FTFW1CT1DKF67722",
                RegistrationPlate = "E-2572",
                ManufacturedMonth = new DateTime(2020, 02, 11),
                ManufacturedYear = new DateTime(2020, 02, 11)
            };

            _controller.ModelState.AddModelError("Model", "Required");

            // Act
            var badResponse = _controller.AddCar(item);

            // Assert
            Assert.IsType<BadRequestResult>(badResponse);
        }

        [Fact]
        public void Add_ValidObjectPassed_ReturnsOkResponse()
        {
            // Arrange
            var item = new Car()
            {
                Id = 1,
                Model = "Acura",
                Brand = "Honda",
                VIN = "1FTFW1CT1DKF67722",
                RegistrationPlate = "E-2572",
                ManufacturedMonth = new DateTime(2020, 02, 11),
                ManufacturedYear = new DateTime(2020, 02, 11)
            };

            // Act
            var okResponse = _controller.AddCar(item);

            // Assert
            Assert.IsType<OkObjectResult>(okResponse);
        }

        [Fact]
        public void Remove_NotExistingCar_ReturnsNotFoundResponse()
        {
            // Arrange
            var item = new Car()
            {
                Id = 1,
                Model = "Acura",
                Brand = "Honda",
                VIN = "1FTFW1CT1DKF67722",
                RegistrationPlate = "E-2572",
                ManufacturedMonth = new DateTime(2020, 02, 11),
                ManufacturedYear = new DateTime(2020, 02, 11)
            };

            // Act
            var badResponse = _controller.RemoveCar(item);

            // Assert
            Assert.IsType<NotFoundResult>(badResponse);
        }

        [Fact]
        public void Remove_ExistingIdPassed_ReturnsNoContent()
        {
            // Arrange
            var item = new Car()
            {
                Id = 1,
                Model = "Acura",
                Brand = "Honda",
                VIN = "1FTFW1CT1DKF67722",
                RegistrationPlate = "E-2572",
                ManufacturedMonth = new DateTime(2020, 02, 11),
                ManufacturedYear = new DateTime(2020, 02, 11)
            };

            _mockCarRepo.Setup(repo => repo.GetCar(1, false))
                        .Returns(item);

            // Act
            var badResponse = _controller.RemoveCar(item);

            // Assert
            Assert.IsType<NoContentResult>(badResponse);
        }
    }
}
