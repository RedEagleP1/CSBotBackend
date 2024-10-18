using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using P1_Api.Models.Rules;
using P1_Application;
using P1_Application.Boundaries;
using P1_Application.Exceptions;
using P1_Application.UseCases;
using P1_Application.UseCases.Rules.AddResultToRule;
using P1_Application.UseCases.Rules.EvaluateRule;
using P1_Core.Entities;
using P1_Core.Interfaces;

namespace P1_Api.Controllers
{

    public class RuleController : BaseController
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public RuleController(ILogger<RuleController> logger, IMediator mediator, ApplicationContext context, IMapper mapper) : base(logger, context)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        [HttpPost("evaluate-rule/{userId}")]
        public async Task<IActionResult> EvaluateRule([FromRoute] int userId, [FromBody] IEnumerable<int> ruleId)
        {
            try
            {
                await _mediator.Send(new EvaluateRuleCommand { UserId = userId, RuleId = ruleId });
            }
            catch (P1Exception e)
            {
                _logger.LogError(e, $"An error occurred while evaluating the rule with Id {ruleId}. \"{e.Message}\"");
                return BadRequest(e.Message);
            }
            return Ok();
        }

        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        [HttpPost("create-rule")]
        public async Task<IActionResult> CreateRule([FromBody] AddOneEntityRequest<Rule> request)
        {
            try
            {
                var response = await _mediator.Send(request);
                return Ok(response != null ? response : null);
            }
            catch (Exception e)
            {
                _logger.LogError(e, $"An error occurred while creating rule: \"{e.Message}\"");
                return BadRequest();
            }
        }

        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        [HttpGet("get-rule/{id}")]
        public async Task<IActionResult> GetRule([FromRoute] int id)
        {
            try
            {
                var response = await _mediator.Send(new GetOneEntityRequest<Rule>(id));
                return Ok(response);
            }
            catch (P1Exception e)
            {
                _logger.LogError(e, $"An error occurred while getting the rule with Id {id}. \"{e.Message}\"");
                return BadRequest();
            }
        }

        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        [HttpGet("get-all-rules")]
        public async Task<IActionResult> GetAllRules()
        {
            try
            {
                var response = await _mediator.Send(new GetAllEntitiesRequest<Rule>());
                return Ok(response);
            }
            catch (P1Exception e)
            {
                _logger.LogError(e, $"An error occurred while getting all rules \"{e.Message}\"");
                return BadRequest();
            }
        }

        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        [HttpPut("update-rule")]
        public async Task<IActionResult> UpdateRule([FromBody] UpdateOneEntityRequest<Rule> request)
        {
            try
            {
                await _mediator.Send(request);
                return Ok();
            }
            catch (P1Exception e)
            {
                _logger.LogError(e, $"An error occurred while updating the rule with id {request.Entity.Id}. \"{e.Message}\"");
                return BadRequest();
            }
        }

        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        [HttpDelete("delete-rule/{id}")]
        public async Task<IActionResult> DeleteRule([FromRoute] int id)
        {
            try
            {
                await _mediator.Send(new DeleteOneEntityRequest<Rule>(id));
                return Ok();
            }
            catch (P1Exception e)
            {
                _logger.LogError(e, $"An error occurred while deleting the rule with Id {id}");
                return BadRequest();
            }
        }

        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        [HttpPut("set-enabled-state")]
        public async Task<IActionResult> SetEnabledState([FromBody] SetRuleEnabledStateRequestModel request)
        {
            try
            {
                await _mediator.Send(request);
                return Ok();
            }
            catch (P1Exception e)
            {
                _logger.LogError(e, $"An error occurred while trying to set the enabled state of rule with id {request.RuleId} to {request.EnabledState}. \"{e.Message}\"");
                return BadRequest();
            }
        }

        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        [HttpPut("add-condition")]
        public async Task<IActionResult> AddCondition([FromBody] AddConditionToRuleRequestModel request)
        {
            try
            {
                await _mediator.Send(request);
                return Ok();
            }
            catch (P1Exception e)
            {
                _logger.LogError(e, $"An error occurred while trying to add condition with id {request.ConditionId} to rule with id {request.RuleId}. \"{e.Message}\"");
                return BadRequest();
            }
        }

        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        [HttpPut("remove-condition")]
        public async Task<IActionResult> RemoveCondition([FromBody] RemoveConditionFromRuleRequestModel request)
        {
            try
            {
                await _mediator.Send(request);
                return Ok();
            }
            catch (P1Exception e)
            {
                _logger.LogError(e, $"An error occurred while trying to remove condition with id {request.ConditionId} from rule with id {request.RuleId}. \"{e.Message}\"");
                return BadRequest();
            }
        }

        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        [HttpPut("add-result")]
        public async Task<IActionResult> AddResult([FromBody] AddResultToRuleRequestModel request)
        {
            try
            {
                var requestModel = _mapper.Map<AddResultToRuleCommand>(request);
                await _mediator.Send(requestModel);
                return Ok();
            }
            catch (P1Exception e)
            {
                _logger.LogError(e, $"An error occurred while trying to add result with id {request.ResultId} to rule with id {request.RuleId}. \"{e.Message}\"");
                return BadRequest();
            }
        }

        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        [HttpPut("remove-result")]
        public async Task<IActionResult> RemoveResult([FromBody] RemoveResultFromRuleRequestModel request)
        {
            try
            {
                await _mediator.Send(request);
                return Ok();
            }
            catch (P1Exception e)
            {
                _logger.LogError(e, $"An error occurred while trying to remove result with id {request.ResultId} from rule with id {request.RuleId}. \"{e.Message}\"");
                return BadRequest();
            }
        }

        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        [HttpPut("add-trigger")]
        public async Task<IActionResult> AddTrigger([FromBody] AddTriggerToRuleRequestModel request)
        {
            try
            {
                await _mediator.Send(request);
                return Ok();
            }
            catch (P1Exception e)
            {
                _logger.LogError(e, $"An error occurred while trying to add trigger with id {request.TriggerId} to rule with id {request.RuleId}. \"{e.Message}\"");
                return BadRequest();
            }
        }

        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        [HttpPut("remove-trigger")]
        public async Task<IActionResult> RemoveTrigger([FromBody] RemoveTriggerFromRuleRequestModel request)
        {
            try
            {
                await _mediator.Send(request);
                return Ok();
            }
            catch (P1Exception e)
            {
                _logger.LogError(e, $"An error occurred while trying to remove trigger with id {request.TriggerId} from rule with id {request.RuleId}. \"{e.Message}\"");
                return BadRequest();
            }
        }
    }


}