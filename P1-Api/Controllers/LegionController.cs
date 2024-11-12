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
using P1_Application.UseCases.Teams.AddMemberToLegion;
using P1_Application.UseCases.Teams.RemoveMemberFromLegion;

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
                await _mediator.Send(new DeleteOneEntityRequest<DiscordCommand>(id));
                return Ok();
            }
            catch (P1Exception e)
            {
                _logger.LogError(e, $"An error occurred while deleting the legion with Id {id}");
                return BadRequest();
            }
        }

        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        [HttpPost("{legionId}/add-organization/{orgId}")]
        public async Task<IActionResult> AddOrganization([FromRoute] int legionId, [FromRoute] int orgId)
        {
            try
            {
                var request = new AddOrgToLegionRequestModel { OrganizationId = orgId, TeamId = teamId };
                var requestModel = _mapper.Map<AddMemberToLegionCommand>(request);
                await _mediator.Send(requestModel);
                return Ok();
            }
            catch (P1Exception e)
            {
                _logger.LogError(e, $"An error occurred while trying to add organization with id {orgId} to legion with id {legionId}. \"{e.Message}\"");
                return BadRequest();
            }
        }

        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        [HttpDelete("{legionId}/remove-organization/{orgId}")]
        public async Task<IActionResult> RemoveOrganization([FromRoute] int legionId, [FromRoute] int orgId)
        {
            try
            {
                var request = new RemoveOrgFromLegionRequestModel { OrganizationId = orgId, TeamId = teamId };
                var requestModel = _mapper.Map<RemoveMemberFromLegionCommand>(request);
                await _mediator.Send(request);
                return Ok();
            }
            catch (P1Exception e)
            {
                _logger.LogError(e, $"An error occurred while trying to remove organization with id {orgId} from legion with id {legionId}. \"{e.Message}\"");
                return BadRequest();
            }
        }
    }
}