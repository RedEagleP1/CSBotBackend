using NUnit.Framework;
using Moq;
using Microsoft.Extensions.Logging;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using P1_Api.Controllers;
using P1_Api.Models;
using P1_Application;
using P1_Core.Interfaces;
//using P1_Application.UseCases.Conditions;
using System;
using System.Threading.Tasks;
using System.Data.Common;
using AutoMapper;
using P1_Api.Models.Conditions;
using P1_Application.UseCases;
using Microsoft.AspNetCore.Http.HttpResults;

namespace P1_Api.Tests.Controllers
{
    /*
    [TestFixture]
    public class ConditionControllerTests
    {
        private Mock<ILogger<ConditionController>> _mockLogger;
        private Mock<IMediator> _mockMediator;
        private Mock<IMapper> _mockMapper;

        private ConditionController _controller;

        [SetUp]
        public void Setup()
        {
            _mockLogger = new Mock<ILogger<ConditionController>>();
            _mockMediator = new Mock<IMediator>();
            _mockMapper = new Mock<IMapper>();

            _controller = new ConditionController(_mockLogger.Object, _mockMediator.Object, _mockMapper.Object);
        }

        [Test]
        public async Task CreateCondition_ReturnsOk_WhenMediatorSucceeds()
        {
            // Arrange
            var request = new CreateConditionRequestModel();
            _mockMediator.Setup(m => m.Send(It.IsAny<CreateConditionRequestModel>(), default));
            _mockMapper.Setup(m => m.Map<CreateConditionCommand>(request)).Returns(new CreateConditionCommand { Name = request.Name, Description = request.Description });

            // Act
            var result = await _controller.CreateCondition(request);

            // Assert
            Assert.IsInstanceOf<OkObjectResult>(result);
            var okResult = result as OkObjectResult;
            Assert.AreEqual(200, okResult.StatusCode);
        }

        [Test]
        public async Task CreateCondition_ReturnsStatusCode400_WhenExceptionIsThrown()
        {
            // Arrange
            var request = new CreateConditionRequestModel();
            _mockMediator.Setup(m => m.Send(It.IsAny<CreateConditionCommand>(), default)).ThrowsAsync(new P1Exception(_mockLogger.Object, "Test exception"));
            _mockMapper.Setup(m => m.Map<CreateConditionCommand>(request)).Returns(new CreateConditionCommand { Name = request.Name, Description = request.Description });

            // Act
            var result = await _controller.CreateCondition(request);

            // Assert
            Assert.IsInstanceOf<StatusCodeResult>(result);
            var statusCodeResult = result as StatusCodeResult;
            Assert.AreEqual(400, statusCodeResult.StatusCode);
        }

        [Test]
        public async Task GetCondition_ReturnsOk_WhenMediatorSucceeds()
        {
            // Arrange
            _mockMediator.Setup(m => m.Send(It.IsAny<int>(), default));

            // Act
            var result = await _controller.GetCondition(0);

            // Assert
            Assert.IsInstanceOf<OkObjectResult>(result);
            var okResult = result as OkObjectResult;
            Assert.AreEqual(200, okResult.StatusCode);
        }

        [Test]
        public async Task GetCondition_ReturnsStatusCode400_WhenExceptionIsThrown()
        {
            // Arrange
            _mockMediator.Setup(m => m.Send(It.IsAny<GetOneEntityRequest<Condition>>(), default)).ThrowsAsync(new P1Exception(_mockLogger.Object, "Test exception"));

            // Act
            var result = await _controller.GetCondition(0);

            // Assert
            Assert.IsInstanceOf<StatusCodeResult>(result);
            var statusCodeResult = result as StatusCodeResult;
            Assert.AreEqual(400, statusCodeResult.StatusCode);
        }

        [Test]
        public async Task GetAllConditions_ReturnsOk_WhenMediatorSucceeds()
        {
            // Arrange
            var request = new GetAllConditionsRequestModel();
            _mockMediator.Setup(m => m.Send(It.IsAny<GetAllConditionsQuery>(), default));
            _mockMapper.Setup(m => m.Map<GetAllConditionsQuery>(request)).Returns(new GetAllConditionsQuery());

            // Act
            var result = await _controller.GetAllConditions();

            // Assert
            Assert.IsInstanceOf<OkObjectResult>(result);
            var okResult = result as OkObjectResult;
            Assert.AreEqual(200, okResult.StatusCode);
        }

        [Test]
        public async Task GetAllConditions_ReturnsStatusCode400_WhenExceptionIsThrown()
        {
            // Arrange
            var request = new GetAllConditionsRequestModel();
            _mockMediator.Setup(m => m.Send(It.IsAny<GetAllConditionsQuery>(), default)).ThrowsAsync(new P1Exception(_mockLogger.Object, "Test exception"));
            _mockMapper.Setup(m => m.Map<GetAllConditionsQuery>(request)).Returns(new GetAllConditionsQuery());

            // Act
            var result = await _controller.GetAllConditions();

            // Assert
            Assert.IsInstanceOf<StatusCodeResult>(result);
            var statusCodeResult = result as StatusCodeResult;
            Assert.AreEqual(400, statusCodeResult.StatusCode);
        }

        [Test]
        public async Task UpdateCondition_ReturnsOk_WhenMediatorSucceeds()
        {
            // Arrange
            var request = new UpdateConditionRequestModel() { Condition = new Condition() { Id = 0 } };
            _mockMediator.Setup(m => m.Send(It.IsAny<UpdateConditionCommand>(), default));
            _mockMapper.Setup(m => m.Map<UpdateConditionCommand>(request)).Returns(new UpdateConditionCommand { Condition = new Condition() });

            // Act
            var result = await _controller.UpdateCondition(request);

            // Assert
            Assert.IsInstanceOf<OkResult>(result);
            var okResult = result as OkResult;
            Assert.AreEqual(200, okResult.StatusCode);
        }

        [Test]
        public async Task UpdateCondition_ReturnsStatusCode400_WhenExceptionIsThrown()
        {
            // Arrange
            var request = new UpdateConditionRequestModel() { Condition = new Condition() { Id = 0 } };
            _mockMediator.Setup(m => m.Send(It.IsAny<UpdateConditionCommand>(), default)).ThrowsAsync(new P1Exception(_mockLogger.Object, "Test exception"));
            _mockMapper.Setup(m => m.Map<UpdateConditionCommand>(request)).Returns(new UpdateConditionCommand { Condition = new Condition() });

            // Act
            var result = await _controller.UpdateCondition(request);

            // Assert
            Assert.IsInstanceOf<StatusCodeResult>(result);
            var statusCodeResult = result as StatusCodeResult;
            Assert.AreEqual(400, statusCodeResult.StatusCode);
        }

        [Test]
        public async Task DeleteCondition_ReturnsOk_WhenMediatorSucceeds()
        {
            // Arrange
            _mockMediator.Setup(m => m.Send(It.IsAny<int>(), default));

            // Act
            var result = await _controller.DeleteCondition(0);

            // Assert
            Assert.IsInstanceOf<OkResult>(result);
            var okResult = result as OkResult;
            Assert.AreEqual(200, okResult.StatusCode);
        }

        [Test]
        public async Task DeleteCondition_ReturnsStatusCode400_WhenExceptionIsThrown()
        {
            // Arrange
            _mockMediator.Setup(m => m.Send(It.IsAny<int>(), default)).ThrowsAsync(new P1Exception(_mockLogger.Object, "Test exception"));

            // Act
            var result = await _controller.DeleteCondition(0);

            // Assert
            Assert.IsInstanceOf<StatusCodeResult>(result);
            var statusCodeResult = result as StatusCodeResult;
            Assert.AreEqual(400, statusCodeResult.StatusCode);
        }
    }
    */
}