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
                Rule newRule = new Rule
                {
                    Name = request.Name,
                    Description = request.Description,
                    Conditions = request.Conditions,
                };

                await _mediator.Send(request);
                return Ok();
            }
            catch (Exception e)
            {
                // TODO clean this up and throw more specific exception
                _logger.LogError(e, $"An error occurred while creating rule: \"{e.Message}\"");
                return BadRequest();
            }
        }

<<<<<<< HEAD
        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        [HttpPost("get-rule")]
        public async Task<IActionResult> GetRule([FromBody] GetRuleRequest request)
        {
            try
            {
                await _mediator.Send(request);
                return Ok();
            }
            catch (Exception e)
            {
                // TODO clean this up and throw more specific exception
                _logger.LogError(e, $"An error occurred while getting the rule with Id {request.Id}. \"{e.Message}\"");
                return BadRequest();
            }
        }

        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        [HttpPost("get-all-rules")]
        public async Task<IActionResult> GetAllRules([FromBody] GetRuleRequest request)
        {
            try
            {
                await _mediator.Send(request);
                return Ok();
            }
            catch (Exception e)
            {
                // TODO clean this up and throw more specific exception
                _logger.LogError(e, $"An error occurred while getting all rules: \"{e.Message}\"");
                return BadRequest();
            }
        }

        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        [HttpPost("update-rule")]
        public async Task<IActionResult> UpdateRule([FromBody] UpdateRuleRequest request)
        {
            try
            {
                await _mediator.Send(request);
                return Ok();
            }
            catch (Exception e)
            {
                // TODO clean this up and throw more specific exception
                _logger.LogError(e, $"An error occurred while updating the rule with id {request.Rule.Id}. \"{e.Message}\"");
                return BadRequest();
            }
        }

        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        [HttpPost("delete-rule")]
        public async Task<IActionResult> DeleteRule([FromBody] DeleteRuleRequest request)
        {
            try
            {
                await _mediator.Send(request);
                return Ok();
            }
            catch (Exception e)
            {
                // TODO clean this up and throw more specific exception
                _logger.LogError(e, $"An error occurred while deleting rule with Id {request.Id}");
                return BadRequest();
            }
        }
=======
>>>>>>> development
    }


    public class CreateRuleRequest
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<Condition> Conditions { get; set; }
        // TODO Need to add to join table for this condition to allow multiple conditions
        // public int ConditionId { get; set; }
        public int RewardId { get; set; }
    }

    public class GetRuleRequest : IRequest<int>
    {
        public int Id { get; set; }
    }

    public class GetAllRulesRequest : IRequest<List<Rule>>
    {

    }

    public class UpdateRuleRequest
    {
        public Rule Rule { get; set; }
    }

    public class DeleteRuleRequest
    {
        public int Id { get; set; }
    }
}