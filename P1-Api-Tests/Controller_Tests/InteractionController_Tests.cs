using NUnit.Framework;
using Moq;
using Microsoft.Extensions.Logging;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using P1_Api.Controllers;
using P1_Application.UseCases.AddCurrencyToUser;
using System;
using System.Threading.Tasks;

namespace P1_Api.Tests.Controllers
{
    [TestFixture]
    public class InteractionControllerTests
    {
        private Mock<ILogger<InteractionController>> _mockLogger;
        private Mock<IMediator> _mockMediator;
        private InteractionController _controller;

        [SetUp]
        public void Setup()
        {
            _mockLogger = new Mock<ILogger<InteractionController>>();
            _mockMediator = new Mock<IMediator>();
            _controller = new InteractionController(_mockLogger.Object, _mockMediator.Object);
        }

        [Test]
        public async Task AddCurrencyToUser_ReturnsOk_WhenMediatorSucceeds()
        {
            // Arrange
            var request = new AddCurrencyToUserRequest(1,11,2);
            _mockMediator.Setup(m => m.Send(It.IsAny<AddCurrencyToUserRequest>(), default));

            // Act
            var result = await _controller.AddCurrencyToUser(request);

            // Assert
            Assert.IsInstanceOf<OkResult>(result);
            var okResult = result as OkResult;
            Assert.AreEqual(200, okResult.StatusCode);
        }

        [Test]
        public async Task AddCurrencyToUser_ReturnsStatusCode500_WhenExceptionIsThrown()
        {
            // Arrange
            var request = new AddCurrencyToUserRequest(1,11,2);
            _mockMediator.Setup(m => m.Send(It.IsAny<AddCurrencyToUserRequest>(), default)).ThrowsAsync(new Exception("Test exception"));

            // Act
            var result = await _controller.AddCurrencyToUser(request);

            // Assert
            Assert.IsInstanceOf<StatusCodeResult>(result);
            var statusCodeResult = result as StatusCodeResult;
            Assert.AreEqual(500, statusCodeResult.StatusCode);
        }
    }
}