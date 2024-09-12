using MediatR;
using Microsoft.AspNetCore.Mvc;
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
                return StatusCode(500);
            }
        }
    }
    
}