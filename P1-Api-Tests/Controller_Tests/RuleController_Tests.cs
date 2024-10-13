using NUnit.Framework;
using Moq;
using Microsoft.Extensions.Logging;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using P1_Api.Controllers;
using P1_Core.Interfaces;
//using P1_Application.UseCases.Rules;
using System;
using System.Threading.Tasks;
using System.Data.Common;
using AutoMapper;

namespace P1_Api.Tests.Controllers
{
    /*
    [TestFixture]
    public class RuleControllerTests
    {
        private Mock<ILogger<ConditionController>> _mockLogger;
        private Mock<IMediator> _mockMediator;
        private Mock<IMapper> _mapper;
        private RuleController _controller;


        [SetUp]
        public void Setup()
        {
            _mockLogger = new Mock<ILogger<ConditionController>>();
            _mockMediator = new Mock<IMediator>();
            _controller = new RuleController(_mockLogger.Object, _mockMediator.Object);
        }

        [Test]
        public async Task CreateCondition_ReturnsOk_WhenMediatorSucceeds()
        {
            // Arrange
            var request = new CreateConditionRequest();
            _mockMediator.Setup(m => m.Send(It.IsAny<CreateConditionRequest>(), default));

            // Act
            var result = await _controller.CreateCondition(request);

            // Assert
            Assert.IsInstanceOf<OkResult>(result);
            var okResult = result as OkResult;
            Assert.AreEqual(200, okResult.StatusCode);
        }

        [Test]
        public async Task CreateCondition_ReturnsStatusCode400_WhenExceptionIsThrown()
        {
            // Arrange
            var request = new CreateConditionRequest();
            _mockMediator.Setup(m => m.Send(It.IsAny<CreateConditionRequest>(), default)).ThrowsAsync(new Exception("Test exception"));

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
            var request = new GetConditionRequest() { Id = 0 };
            _mockMediator.Setup(m => m.Send(It.IsAny<GetConditionRequest>(), default));

            // Act
            var result = await _controller.GetCondition(request);

            // Assert
            Assert.IsInstanceOf<OkResult>(result);
            var okResult = result as OkResult;
            Assert.AreEqual(200, okResult.StatusCode);
        }

        [Test]
        public async Task GetCondition_ReturnsStatusCode400_WhenExceptionIsThrown()
        {
            // Arrange
            var request = new GetConditionRequest() { Id = 0 };
            _mockMediator.Setup(m => m.Send(It.IsAny<GetConditionRequest>(), default)).ThrowsAsync(new Exception("Test exception"));

            // Act
            var result = await _controller.GetCondition(request);

            // Assert
            Assert.IsInstanceOf<StatusCodeResult>(result);
            var statusCodeResult = result as StatusCodeResult;
            Assert.AreEqual(400, statusCodeResult.StatusCode);
        }

        [Test]
        public async Task GetAllConditions_ReturnsOk_WhenMediatorSucceeds()
        {
            // Arrange
            var request = new GetAllConditionsRequest();
            _mockMediator.Setup(m => m.Send(It.IsAny<GetAllConditionsRequest>(), default));

            // Act
            var result = await _controller.GetAllConditions(request);

            // Assert
            Assert.IsInstanceOf<OkResult>(result);
            var okResult = result as OkResult;
            Assert.AreEqual(200, okResult.StatusCode);
        }

        [Test]
        public async Task GetAllConditions_ReturnsStatusCode400_WhenExceptionIsThrown()
        {
            // Arrange
            var request = new GetAllConditionsRequest();
            _mockMediator.Setup(m => m.Send(It.IsAny<GetAllConditionsRequest>(), default)).ThrowsAsync(new Exception("Test exception"));

            // Act
            var result = await _controller.GetAllConditions(request);

            // Assert
            Assert.IsInstanceOf<StatusCodeResult>(result);
            var statusCodeResult = result as StatusCodeResult;
            Assert.AreEqual(400, statusCodeResult.StatusCode);
        }

        [Test]
        public async Task UpdateCondition_ReturnsOk_WhenMediatorSucceeds()
        {
            // Arrange
            var request = new UpdateConditionRequest() { Condition = new Condition() { Id = 0 } };
            _mockMediator.Setup(m => m.Send(It.IsAny<UpdateConditionRequest>(), default));

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
            var request = new UpdateConditionRequest() { Condition = new Condition() { Id = 0 } };
            _mockMediator.Setup(m => m.Send(It.IsAny<UpdateConditionRequest>(), default)).ThrowsAsync(new Exception("Test exception"));

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
            var request = new DeleteConditionRequest() { Condition = new Condition() { Id = 0 } };
            _mockMediator.Setup(m => m.Send(It.IsAny<UpdateConditionRequest>(), default));

            // Act
            var result = await _controller.DeleteCondition(request);

            // Assert
            Assert.IsInstanceOf<OkResult>(result);
            var okResult = result as OkResult;
            Assert.AreEqual(200, okResult.StatusCode);
        }

        [Test]
        public async Task DeleteCondition_ReturnsStatusCode400_WhenExceptionIsThrown()
        {
            // Arrange
            var request = new DeleteConditionRequest() { Condition = new Condition() { Id = 0 } };
            _mockMediator.Setup(m => m.Send(It.IsAny<DeleteConditionRequest>(), default)).ThrowsAsync(new Exception("Test exception"));

            // Act
            var result = await _controller.DeleteCondition(request);

            // Assert
            Assert.IsInstanceOf<StatusCodeResult>(result);
            var statusCodeResult = result as StatusCodeResult;
            Assert.AreEqual(400, statusCodeResult.StatusCode);
        }
    }

    */
}