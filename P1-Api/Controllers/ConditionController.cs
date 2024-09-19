using MediatR;
using Microsoft.AspNetCore.Mvc;
using P1_Application;
using P1_Api.Models.Conditions;
using P1_Application.UseCases.Conditions.CreateCondition;
using P1_Application.UseCases.Conditions.GetAllConditions;
using P1_Application.UseCases.Conditions.UpdateCondition;
using AutoMapper;
using System.Diagnostics;
using P1_Application.UseCases;
using P1_Core.Entities;

namespace P1_Api.Controllers
{
    public class ConditionController : BaseController
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public ConditionController(ILogger<ConditionController> logger, IMediator mediator, IMapper mapper) : base(logger)
        {
            _mediator = mediator;

            _mapper = mapper;
        }

        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        [HttpPost("create-condition")]
        public async Task<IActionResult> CreateCondition([FromBody] CreateConditionRequestModel request)
        {
            try
            {
                var requestMapped = _mapper.Map<CreateConditionCommand>(request);
                var response = await _mediator.Send(requestMapped);
                return Ok(response != null ? response : null);
            }
            catch (P1Exception e)
            {
                _logger.LogError(e, $"An error occurred while creating condition: \"{e.Message}\"");
                return BadRequest();
            }
        }

        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        [HttpGet("get-condition/{id}")]
        public async Task<IActionResult> GetCondition([FromRoute] int id)
        {
            try
            {
                var response = await _mediator.Send(new GetOneEntityRequest<Condition>(id));
                return Ok(response);
            }
            catch (P1Exception e)
            {
                _logger.LogError(e, $"An error occurred while getting the condition with Id {id}. \"{e.Message}\"");
                return BadRequest();
            }
        }


        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        [HttpGet("get-all-conditions")]
        public async Task<IActionResult> GetAllConditions()
        {
            try
            {
                var response = await _mediator.Send(new GetAllConditionsQuery());
                return Ok(response);
            }
            catch (P1Exception e)
            {
                _logger.LogError(e, $"An error occurred while getting all conditions: \"{e.Message}\"");
                return BadRequest();
            }
        }

        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        [HttpPut("update-condition")]
        public async Task<IActionResult> UpdateCondition([FromBody] UpdateConditionRequestModel request)
        {
            try
            {
                var requestMapped = _mapper.Map<UpdateConditionCommand>(request);
                await _mediator.Send(requestMapped);
                return Ok();
            }
            catch (P1Exception e)
            {
                _logger.LogError(e, $"An error occurred while updating the condition with id {request.Condition.Id}. \"{e.Message}\"");
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
                _logger.LogError(e, $"An error occurred while deleting the condition with Id {id}");
                return BadRequest();
            }
        }

    }
}