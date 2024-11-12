using MediatR;
using Microsoft.AspNetCore.Mvc;
using P1_Application;
using P1_Api.Models.Results;
using AutoMapper;
using System.Diagnostics;
using P1_Application.UseCases;
using P1_Core.Interfaces;
using P1_Application.Exceptions;
using P1_Application.Boundaries;
using P1_Core.Entities;

namespace P1_Api.Controllers
{
    public class ResultController : BaseController
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public ResultController(ILogger<ResultController> logger, IMediator mediator, IMapper mapper, ApplicationContext context) : base(logger, context)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        [HttpPost("create-result")]
        public async Task<IActionResult> CreateResult([FromBody] AddOneEntityRequest<Result> request)
        {
            try
            {
                var response = await _mediator.Send(request);
                return Ok(response != null ? response : null);
            }
            catch (P1Exception e)
            {
                _logger.LogError(e, $"An error occurred while creating result: \"{e.Message}\"");
                return BadRequest();
            }
        }

        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        [HttpGet("get-result/{id}")]
        public async Task<IActionResult> GetResult([FromRoute] int id)
        {
            try
            {
                var response = await _mediator.Send(new GetOneEntityRequest<Result>(id));
                return Ok(response);
            }
            catch (P1Exception e)
            {
                _logger.LogError(e, $"An error occurred while getting the result with Id {id}. \"{e.Message}\"");
                return BadRequest();
            }
        }


        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        [HttpGet("get-all-results")]
        public async Task<IActionResult> GetAllResults()
        {
            try
            {
                var response = await _mediator.Send(new GetAllEntitiesRequest<Result>());
                return Ok(response);
            }
            catch (P1Exception e)
            {
                _logger.LogError(e, $"An error occurred while getting all results: \"{e.Message}\"");
                return BadRequest();
            }
        }

        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        [HttpPut("update-result")]
        public async Task<IActionResult> UpdateResult([FromBody] UpdateOneEntityRequest<Result> request)
        {
            try
            {
                await _mediator.Send(request);
                return Ok();
            }
            catch (P1Exception e)
            {
                _logger.LogError(e, $"An error occurred while updating the result with id {request.Entity.Id}. \"{e.Message}\"");
                return BadRequest();
            }
        }

        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        [HttpDelete("delete-result/{id}")]
        public async Task<IActionResult> DeleteResult([FromRoute] int id)
        {
            try
            {
                await _mediator.Send(new DeleteOneEntityRequest<DiscordCommand>(id));
                return Ok();
            }
            catch (P1Exception e)
            {
                _logger.LogError(e, $"An error occurred while deleting the result with Id {id}");
                return BadRequest();
            }
        }

    }
}