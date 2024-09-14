using MediatR;
using Microsoft.AspNetCore.Mvc;
using P1_Application.UseCases.CreateCondition;
using P1_Core.Entities;

namespace P1_Api.Controllers {
    public class CreateConditionController : BaseController
    {
        private readonly IMediator _mediator;

        public CreateConditionController(ILogger<BaseController> logger, IMediator mediator) : base(logger)
        {
            _mediator = mediator;
        }

        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        [HttpPost("create-condition")]
        public async Task<IActionResult> CreateCondition([FromBody] CreateConditionRequest request)
        {
            try
            {
                await _mediator.Send(request);
                return Ok();
            }
            catch (Exception e)
            {
                // TODO clean this up and throw more specific exception
                _logger.LogError(e, "Error creating condition");
                return BadRequest();
            }
        }

    }
}