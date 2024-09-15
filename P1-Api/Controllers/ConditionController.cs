using MediatR;
using Microsoft.AspNetCore.Mvc;
using P1_Core.Entities;

namespace P1_Api.Controllers
{
    public class ConditionController : BaseController
    {
        private readonly IMediator _mediator;

        public ConditionController(ILogger<ConditionController> logger, IMediator mediator) : base(logger)
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
                _logger.LogError(e, $"An error occurred while creating condition: \"{e.Message}\"");
                return BadRequest();
            }
        }

        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        [HttpPost("get-condition")]
        public async Task<IActionResult> GetCondition([FromBody] GetConditionRequest request)
        {
            try
            {
                await _mediator.Send(request);
                return Ok();
            }
            catch (Exception e)
            {
                // TODO clean this up and throw more specific exception
                _logger.LogError(e, $"An error occurred while getting the condition with Id {request.Id}. \"{e.Message}\"");
                return BadRequest();
            }
        }

        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        [HttpPost("get-all-conditions")]
        public async Task<IActionResult> GetAllConditions([FromBody] GetConditionRequest request)
        {
            try
            {
                await _mediator.Send(request);
                return Ok();
            }
            catch (Exception e)
            {
                // TODO clean this up and throw more specific exception
                _logger.LogError(e, $"An error occurred while getting all conditions: \"{e.Message}\"");
                return BadRequest();
            }
        }

        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        [HttpPost("update-condition")]
        public async Task<IActionResult> UpdateCondition([FromBody] UpdateConditionRequest request)
        {
            try
            {
                await _mediator.Send(request);
                return Ok();
            }
            catch (Exception e)
            {
                // TODO clean this up and throw more specific exception
                _logger.LogError(e, $"An error occurred while updating the condition with id {request.Condition.Id}. \"{e.Message}\"");
                return BadRequest();
            }
        }

        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        [HttpPost("delete-condition")]
        public async Task<IActionResult> DeleteCondition([FromBody] DeleteConditionRequest request)
        {
            try
            {
                await _mediator.Send(request);
                return Ok();
            }
            catch (Exception e)
            {
                // TODO clean this up and throw more specific exception
                _logger.LogError(e, $"An error occurred while deleting condition with Id {request.Condition.Id}");
                return BadRequest();
            }
        }

    }

    public class CreateConditionRequest
    {
        public Condition Condition { get; set; }
    }

    public class GetConditionRequest
    {
        public int Id { get; set; }
    }

    public class GetAllConditionsRequest
    {
        public List<Condition> Conditions { get; set; }
    }

    public class UpdateConditionRequest
    {
        public Condition Condition { get; set; }
    }

    public class DeleteConditionRequest
    {
        public Condition Condition { get; set; }
    }


    public class GetConditionResponse
    {
        public Condition Condition { get; set; }
    }
}