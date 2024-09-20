using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using P1_Api.Models.Rules;
using P1_Application;
using P1_Application.UseCases;
using P1_Application.UseCases.Rules.EvaluateRule;


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
        //[ProducesResponseType(500)]
        [HttpGet("evaluate-rule/{userId}/{ruleId}")]
        public async Task<IActionResult> EvaluateRule([FromRoute] int userId, [FromRoute] IEnumerable<int> ruleId)
        {
            await _mediator.Send(new EvaluateRuleCommand { UserId = userId, RuleId = ruleId });
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
        [HttpDelete("delete-condition")]
        public async Task<IActionResult> DeleteCondition([FromRoute] int id)
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

    }


}