using System.Net;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using P1_Application.UseCases.AddCurrencyToUser;

namespace P1_Api.Controllers
{
    public class InteractionController : BaseController
    {
        private readonly IMediator _mediator;
        public InteractionController(ILogger<InteractionController> logger, IMediator mediator) : base(logger)
        {
            _mediator = mediator;
        }

        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [HttpPost("add-currency")]
        public async Task<IActionResult> AddCurrencyToUser([FromBody] AddCurrencyToUserRequest request)
        {
            try
            {
                await _mediator.Send(request);
                return Ok();
            }
            catch (Exception e)
            {
                // TODO clean this up and throw more specific exception
                _logger.LogError(e, "Error adding currency to user");
                return BadRequest();
            }
        }

        public async Task<IActionResult> GetCurrencyForUser()
        {
            return Ok();
        }

    }

}