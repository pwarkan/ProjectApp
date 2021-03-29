using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using Moq;
using References;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Tests
{
    public class ClientsControllerTest
    {
        private readonly ClientsFakeController _controller;
        private readonly Mock<IClientRepository> _mockClientRepo;
        public ClientsControllerTest()
        {
            _mockClientRepo = new Mock<IClientRepository>();
            _controller = new  ClientsFakeController(_mockClientRepo.Object);
        }

        [Fact]
        public void Get_WhenCalled_ReturnsAllItems()
        {
            _mockClientRepo.Setup(repo => repo.GetAllClients(false))
                .Returns(new List<Client>() { new Client(), new Client()});

            //Act
            var okResult = _controller.GetAllClients().Result as OkObjectResult;

            //Assert
            var items = Assert.IsType<List<Client>>(okResult.Value);
            Assert.Equal(2, items.Count);
        }

        [Fact]
        public void Get_WhenCalled_ReturnsOkResult()
        {
            //Act
            var okResult = _controller.GetAllClients().Result;

            //Assert
            Assert.IsType<OkObjectResult>(okResult);
        }

        [Fact]
        public void GetById_UnknownId_ReturnsNotFoundResult()
        {
            // Act
            var result = _controller.GetClient(0);

            // Assert
            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public void GetById_PassedId_ReturnsOkResult()
        {
            //Arrange
            _mockClientRepo.Setup(repo => repo.GetClient(5, false))
               .Returns(new Client());

            // Act
            var okResult = _controller.GetClient(5);

            // Assert
            Assert.IsType<OkObjectResult>(okResult);
        }

        [Fact]
        public void Add_InvalidObjectPassed_ReturnsBadRequest()
        {
            // Arrange
            var item = new Client()
            {
                Id = 1,
                FirstName = "Mike",
                //LastName = "Lakonelli",
                MiddleName = "Sergeevich",
                Email = "mike12la@gmail.com",
                PhoneNumber = "+79002345612"
            };

            _controller.ModelState.AddModelError("LastName", "Required");

            // Act
            var badResponse = _controller.AddClient(item);

            // Assert
            Assert.IsType<BadRequestResult>(badResponse);
        }

        [Fact]
        public void Add_ValidObjectPassed_ReturnsOkResponse()
        {
            // Arrange
            var item = new Client()
            {
                Id = 1,
                FirstName = "Mike",
                //LastName = "Lakonelli",
                MiddleName = "Sergeevich",
                Email = "mike12la@gmail.com",
                PhoneNumber = "+79002345612"
            };

            // Act
            var okResponse = _controller.AddClient(item);

            // Assert
            Assert.IsType<OkObjectResult>(okResponse);
        }

        [Fact]
        public void Remove_NotExistingCar_ReturnsNotFoundResponse()
        {
            // Arrange
            var item = new Client()
            {
                Id = 1,
                FirstName = "Mike",
                LastName = "Lakonelli",
                MiddleName = "Sergeevich",
                Email = "mike12la@gmail.com",
                PhoneNumber = "+79002345612"
            };

            // Act
            var badResponse = _controller.RemoveClient(item);

            // Assert
            Assert.IsType<NotFoundResult>(badResponse);
        }

        [Fact]
        public void Remove_ExistingIdPassed_ReturnsNoContent()
        {
            // Arrange
            var item = new Client()
            {
                Id = 1,
                FirstName = "Mike",
                LastName = "Lakonelli",
                MiddleName = "Sergeevich",
                Email = "mike12la@gmail.com",
                PhoneNumber = "+79002345612"
            };

            _mockClientRepo.Setup(repo => repo.GetClient(1, false))
                        .Returns(item);

            // Act
            var badResponse = _controller.RemoveClient(item);

            // Assert
            Assert.IsType<NoContentResult>(badResponse);
        }
    }
}
