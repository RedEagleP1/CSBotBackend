using MediatR;
using Microsoft.AspNetCore.Mvc;
using P1_Core.Entities;

namespace P1_Api.Controllers
{

    public class RuleController : BaseController
    {
        private readonly IMediator _mediator;
        public RuleController(ILogger<RuleController> logger, IMediator mediator) : base(logger)
        {
            _mediator = mediator;
        }

        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        [HttpPost("create-rule")]
        public async Task<IActionResult> CreateRule([FromBody] CreateRuleRequest request)
        {
            try
            {
                await _mediator.Send(request);
                return Ok();
            }
            catch (Exception e)
            {
                // TODO clean this up and throw more specific exception
                _logger.LogError(e, "Error creating rule");
                return BadRequest();
            }
        }

        public async Task<IActionResult> GetRule()
        {
            return Ok();
        }

    }

    public class CreateRuleRequest
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsEnabled { get; set; }
        public IList<Condition> Conditions { get; set; }
        public IList<Result> Results { get; set; }
    }
}