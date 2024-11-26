using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using P1_Api.Models.ContainerRegistry;
using P1_Application.Boundaries;
using P1_Application.Exceptions;
using P1_Application.UseCases.ContainerRegistry.CreateContainer;
using P1_Core.Enums;

namespace P1_Api.Controllers
{
    /// <summary>
    /// A controller for organization, legion, etc.
    /// </summary>
    public class ContainerRegistryController : BaseController
    {
        private IMapper _mapper { get; set; }
        private readonly IMediator _mediator;
        public ContainerRegistryController(ILogger<DiscordCommandController> logger, ApplicationContext context, IMapper mapper, IMediator mediatr) : base(logger, context)
        {
            _mapper = mapper;
            _mediator = mediatr;
        }

        [HttpPost("AddContainer")]
        public async Task<IActionResult> CreateContainer([FromBody] ContainerRequestModel request)
        {
            var command = _mapper.Map<ContainerRequestCommand>(request);
            try
            {
                await _mediator.Send(command);
                return Ok();
            }
            catch (P1Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}