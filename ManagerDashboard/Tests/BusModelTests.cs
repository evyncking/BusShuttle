using System.Collections.Generic;
using System.Linq;
using ManagerDashboard.Controllers;
using ManagerDashboard.Models;
using ManagerDashboard.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace ManagerDashboard.Tests
{
    public class BusModelTests
    {
        private readonly Mock<IBusModelRepository> _mockRepo;
        private readonly BusController _controller;

        public BusModelTests()
        {
            _mockRepo = new Mock<IBusModelRepository>();
            _controller = new BusController(_mockRepo.Object);
        }

        [Fact]
        public void Index_ReturnsAViewResult_WithAListOfBuses()
        {
           
            var buses = new List<BusModel>
            {
                new BusModel { Id = 1, BusNumber = "Bus1" },
                new BusModel { Id = 2, BusNumber = "Bus2" },
            };
            _mockRepo.Setup(repo => repo.GetAllBuses()).Returns(buses);

           
            var result = _controller.Index();

           
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<IEnumerable<BusModel>>(viewResult.ViewData.Model);
            Assert.Equal(2, model.Count());
        }

        [Fact]
        public void Details_ReturnsNotFound_WhenBusIdIsNull()
        {
            

          
            var result = _controller.Details(null);

          
            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public void Details_ReturnsNotFound_WhenBusIsNotFound()
        {
        
            int nonExistentBusId = 999;
            _mockRepo.Setup(repo => repo.GetBusById(nonExistentBusId)).Returns((BusModel)null);

          
            var result = _controller.Details(nonExistentBusId);

         
            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public void Details_ReturnsViewResult_WhenBusIsFound()
        {
            
            int existingBusId = 1;
            var bus = new BusModel { Id = existingBusId, BusNumber = "Bus1" };
            _mockRepo.Setup(repo => repo.GetBusById(existingBusId)).Returns(bus);

            
            var result = _controller.Details(existingBusId);

            
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<BusModel>(viewResult.ViewData.Model);
            Assert.Equal(existingBusId, model.Id);
        }

        [Fact]
        public void Create_ReturnsViewResult()
        {
            

            
            var result = _controller.Create();

            
            Assert.IsType<ViewResult>(result);
        }

        [Fact]
        public void CreatePost_ReturnsARedirectToActionResult_WhenModelStateIsValid()
        {
            
            var bus = new BusModel { BusNumber = "TestBus" };

            
            var result = _controller.Create(bus);

            
            var redirectToActionResult = Assert.IsType<RedirectToActionResult>(result);
            Assert.Equal("Index", redirectToActionResult.ActionName);
        }

        [Fact]
        public void Edit_ReturnsNotFound_WhenBusIdIsNull()
        {

            
            var result = _controller.Edit(null);

            
            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public void Edit_ReturnsViewResult_WhenBusIsFound()
        {
        
            int existingBusId = 1;
            var bus = new BusModel { Id = existingBusId, BusNumber = "Bus1" };
            _mockRepo.Setup(repo => repo.GetBusById(existingBusId)).Returns(bus);

        
            var result = _controller.Edit(existingBusId);

            
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<BusModel>(viewResult.ViewData.Model);
            Assert.Equal(existingBusId, model.Id);
        }

        [Fact]
        public void Delete_ReturnsNotFound_WhenBusIdIsNull()
        {
            

            
            var result = _controller.Delete(null);

            
            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public void Delete_ReturnsViewResult_WhenBusIsFound()
        {
           
            int existingBusId = 1;
            var bus = new BusModel { Id = existingBusId, BusNumber = "Bus1" };
            _mockRepo.Setup(repo => repo.GetBusById(existingBusId)).Returns(bus);

          
            var result = _controller.Delete(existingBusId);

            
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<BusModel>(viewResult.ViewData.Model);
            Assert.Equal(existingBusId, model.Id);
        }
    }
}
