using MediatR;
using Microsoft.AspNetCore.Mvc;
using P1_Application;
using P1_Api.Models.Legions;
using AutoMapper;
using System.Diagnostics;
using P1_Application.UseCases;
using P1_Core.Interfaces;
using P1_Application.Exceptions;
using P1_Application.Boundaries;
using P1_Core.Entities;

namespace P1_Api.Controllers
{
    public class LegionController : BaseController
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public LegionController(ILogger<LegionController> logger, IMediator mediator, IMapper mapper, ApplicationContext context) : base(logger, context)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        [HttpPost("create-legion")]
        public async Task<IActionResult> CreateLegion([FromBody] AddOneEntityRequest<Legion> request)
        {
            try
            {
                var response = await _mediator.Send(request);
                return Ok(response != null ? response : null);
            }
            catch (P1Exception e)
            {
                _logger.LogError(e, $"An error occurred while creating legion: \"{e.Message}\"");
                return BadRequest();
            }
        }

        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        [HttpGet("get-legion/{id}")]
        public async Task<IActionResult> GetLegion([FromRoute] int id)
        {
            try
            {
                var response = await _mediator.Send(new GetOneEntityRequest<Legion>(id));
                return Ok(response);
            }
            catch (P1Exception e)
            {
                _logger.LogError(e, $"An error occurred while getting the legion with Id {id}. \"{e.Message}\"");
                return BadRequest();
            }
        }


        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        [HttpGet("get-all-legions")]
        public async Task<IActionResult> GetAllLegions()
        {
            try
            {
                var response = await _mediator.Send(new GetAllEntitiesRequest<Legion>());
                return Ok(response);
            }
            catch (P1Exception e)
            {
                _logger.LogError(e, $"An error occurred while getting all legions: \"{e.Message}\"");
                return BadRequest();
            }
        }

        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        [HttpPut("update-legion")]
        public async Task<IActionResult> UpdateLegion([FromBody] UpdateOneEntityRequest<Legion> request)
        {
            try
            {
                await _mediator.Send(request);
                return Ok();
            }
            catch (P1Exception e)
            {
                _logger.LogError(e, $"An error occurred while updating the legion with id {request.Entity.Id}. \"{e.Message}\"");
                return BadRequest();
            }
        }

        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        [HttpDelete("delete-legion/{id}")]
        public async Task<IActionResult> DeleteLegion([FromRoute] int id)
        {
            try
            {
                await _mediator.Send(id);
                return Ok();
            }
            catch (P1Exception e)
            {
                _logger.LogError(e, $"An error occurred while deleting the legion with Id {id}");
                return BadRequest();
            }
        }

    }
}