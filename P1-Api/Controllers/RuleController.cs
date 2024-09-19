using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using P1_Api.Models.Rules;
using P1_Application;
using P1_Application.UseCases;
using P1_Application.UseCases.Rules.CreateRule;
using P1_Application.UseCases.Rules.EvaluateRule;
using P1_Application.UseCases.Rules.GetAllRules;
using P1_Application.UseCases.Rules.UpdateRule;

using P1_Core.Entities;

namespace P1_Api.Controllers
{

    public class RuleController : BaseController
    {
        private readonly IMediator _mediator;

        private readonly IMapper _mapper;


        public RuleController(ILogger<RuleController> logger, IMediator mediator, IMapper mapper) : base(logger)
        {
            _mediator = mediator;

            _mapper = mapper;
        }

        [ProducesResponseType(200)]
        //[ProducesResponseType(500)]
        [HttpGet("evaluate-rule/{userId}/{ruleId}")]
        public async Task<IActionResult> EvaluateRule([FromRoute] int userId, [FromRoute] int ruleId)
        {
            var result = await _mediator.Send(new EvaluateRuleCommand { UserId = userId, RuleId = ruleId });


            return Ok();
        }

        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        [HttpPost("create-rule")]
        public async Task<IActionResult> CreateRule([FromBody] CreateRuleRequestModel request)
        {
            try
            {
                var requestMapped = _mapper.Map<CreateRuleCommand>(request);
                var response = await _mediator.Send(requestMapped);
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
                var response = await _mediator.Send(new GetAllRulesRequestModel());
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
        public async Task<IActionResult> UpdateRule([FromBody] UpdateRuleRequestModel request)
        {
            try
            {
                var requestMapped = _mapper.Map<UpdateRuleCommand>(request);
                await _mediator.Send(requestMapped);
                return Ok();
            }
            catch (P1Exception e)
            {
                _logger.LogError(e, $"An error occurred while updating the rule with id {request.Rule.Id}. \"{e.Message}\"");
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
                await _mediator.Send(id);
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