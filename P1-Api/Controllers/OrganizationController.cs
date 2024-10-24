using MediatR;
using Microsoft.AspNetCore.Mvc;
using P1_Application;
using P1_Api.Models.Organizations;
using AutoMapper;
using System.Diagnostics;
using P1_Application.UseCases;
using P1_Core.Interfaces;
using P1_Application.Exceptions;
using P1_Application.Boundaries;
using P1_Core.Entities;
using P1_Application.UseCases.Teams.AddMemberToOrganization;
using P1_Application.UseCases.Teams.RemoveMemberFromOrganization;

namespace P1_Api.Controllers
{
    public class OrganizationController : BaseController
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public OrganizationController(ILogger<OrganizationController> logger, IMediator mediator, IMapper mapper, ApplicationContext context) : base(logger, context)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        [HttpPost("create-organization")]
        public async Task<IActionResult> CreateOrganization([FromBody] AddOneEntityRequest<Organization> request)
        {
            try
            {
                var response = await _mediator.Send(request);
                return Ok(response != null ? response : null);
            }
            catch (P1Exception e)
            {
                _logger.LogError(e, $"An error occurred while creating organization: \"{e.Message}\"");
                return BadRequest();
            }
        }

        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        [HttpGet("get-organization/{id}")]
        public async Task<IActionResult> GetOrganization([FromRoute] int id)
        {
            try
            {
                var response = await _mediator.Send(new GetOneEntityRequest<Organization>(id));
                return Ok(response);
            }
            catch (P1Exception e)
            {
                _logger.LogError(e, $"An error occurred while getting the organization with Id {id}. \"{e.Message}\"");
                return BadRequest();
            }
        }


        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        [HttpGet("get-all-organizations")]
        public async Task<IActionResult> GetAllOrganizations()
        {
            try
            {
                var response = await _mediator.Send(new GetAllEntitiesRequest<Organization>());
                return Ok(response);
            }
            catch (P1Exception e)
            {
                _logger.LogError(e, $"An error occurred while getting all organizations: \"{e.Message}\"");
                return BadRequest();
            }
        }

        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        [HttpPut("update-organization")]
        public async Task<IActionResult> UpdateOrganization([FromBody] UpdateOneEntityRequest<Organization> request)
        {
            try
            {
                await _mediator.Send(request);
                return Ok();
            }
            catch (P1Exception e)
            {
                _logger.LogError(e, $"An error occurred while updating the organization with id {request.Entity.Id}. \"{e.Message}\"");
                return BadRequest();
            }
        }

        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        [HttpDelete("delete-organization/{id}")]
        public async Task<IActionResult> DeleteOrganization([FromRoute] int id)
        {
            try
            {
                await _mediator.Send(id);
                return Ok();
            }
            catch (P1Exception e)
            {
                _logger.LogError(e, $"An error occurred while deleting the organization with Id {id}");
                return BadRequest();
            }
        }

        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        [HttpPost("add-member")]
        public async Task<IActionResult> AddMember([FromBody] AddMemberToOrganizationRequestModel request)
        {
            try
            {
                var requestModel = _mapper.Map<AddMemberToOrganizationCommand>(request);
                await _mediator.Send(requestModel);
                return Ok();
            }
            catch (P1Exception e)
            {
                _logger.LogError(e, $"An error occurred while trying to add team with id {request.TeamId} to organization with id {request.OrganizationId}. \"{e.Message}\"");
                return BadRequest();
            }
        }

        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        [HttpDelete("remove-member")]
        public async Task<IActionResult> RemoveCondition([FromBody] RemoveMemberFromOrganizationRequestModel request)
        {
            try
            {
                var requestModel = _mapper.Map<RemoveMemberFromOrganizationCommand>(request);
                await _mediator.Send(request);
                return Ok();
            }
            catch (P1Exception e)
            {
                _logger.LogError(e, $"An error occurred while trying to remove team with id {request.TeamId} from organization with id {request.OrganizationId}. \"{e.Message}\"");
                return BadRequest();
            }
        }

    }
}