using MediatR;
using Microsoft.AspNetCore.Mvc;
using P1_Application;
using P1_Api.Models.Teams;
using AutoMapper;
using System.Diagnostics;
using P1_Application.UseCases;
using P1_Core.Interfaces;
using P1_Application.Exceptions;
using P1_Application.Boundaries;
using P1_Core.Entities;
using P1_Application.UseCases.Teams.AddMemberToTeam;
using P1_Application.UseCases.Teams.RemoveMemberFromTeam;
using P1_Application.UseCases.Teams.AddGameToTeam;
using P1_Application.UseCases.Teams.RemoveGameFromTeam;

namespace P1_Api.Controllers
{
    public class TeamController : BaseController
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public TeamController(ILogger<TeamController> logger, IMediator mediator, IMapper mapper, ApplicationContext context) : base(logger, context)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        [HttpPost("create-team")]
        public async Task<IActionResult> CreateTeam([FromBody] AddOneEntityRequest<Team> request)
        {
            try
            {
                var response = await _mediator.Send(request);
                return Ok(response != null ? response : null);
            }
            catch (P1Exception e)
            {
                _logger.LogError(e, $"An error occurred while creating team: \"{e.Message}\"");
                return BadRequest();
            }
        }

        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        [HttpGet("get-team/{id}")]
        public async Task<IActionResult> GetTeam([FromRoute] int id)
        {
            try
            {
                var response = await _mediator.Send(new GetOneEntityRequest<Team>(id));
                return Ok(response);
            }
            catch (P1Exception e)
            {
                _logger.LogError(e, $"An error occurred while getting the team with Id {id}. \"{e.Message}\"");
                return BadRequest();
            }
        }


        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        [HttpGet("get-all-teams")]
        public async Task<IActionResult> GetAllTeams()
        {
            try
            {
                var response = await _mediator.Send(new GetAllEntitiesRequest<Team>());
                return Ok(response);
            }
            catch (P1Exception e)
            {
                _logger.LogError(e, $"An error occurred while getting all teams: \"{e.Message}\"");
                return BadRequest();
            }
        }

        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        [HttpPut("update-team")]
        public async Task<IActionResult> UpdateTeam([FromBody] UpdateOneEntityRequest<Team> request)
        {
            try
            {
                await _mediator.Send(request);
                return Ok();
            }
            catch (P1Exception e)
            {
                _logger.LogError(e, $"An error occurred while updating the team with id {request.Entity.Id}. \"{e.Message}\"");
                return BadRequest();
            }
        }

        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        [HttpDelete("delete-team/{id}")]
        public async Task<IActionResult> DeleteTeam([FromRoute] int id)
        {
            try
            {
                await _mediator.Send(id);
                return Ok();
            }
            catch (P1Exception e)
            {
                _logger.LogError(e, $"An error occurred while deleting the team with Id {id}");
                return BadRequest();
            }
        }

        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        [HttpPost("add-game")]
        public async Task<IActionResult> AddMember([FromBody] AddGameToTeamRequestModel request)
        {
            try
            {
                var requestModel = _mapper.Map<AddGameToTeamCommand>(request);
                await _mediator.Send(requestModel);
                return Ok();
            }
            catch (P1Exception e)
            {
                _logger.LogError(e, $"An error occurred while trying to add game with id {request.GameId} to team with id {request.TeamId}. \"{e.Message}\"");
                return BadRequest();
            }
        }

        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        [HttpDelete("remove-game")]
        public async Task<IActionResult> RemoveCondition([FromBody] RemoveGameFromTeamRequestModel request)
        {
            try
            {
                var requestModel = _mapper.Map<RemoveGameFromTeamCommand>(request);
                await _mediator.Send(request);
                return Ok();
            }
            catch (P1Exception e)
            {
                _logger.LogError(e, $"An error occurred while trying to remove game with id {request.GameId} from team with id {request.TeamId}. \"{e.Message}\"");
                return BadRequest();
            }
        }

        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        [HttpPost("add-member")]
        public async Task<IActionResult> AddMember([FromBody] AddMemberToTeamRequestModel request)
        {
            try
            {
                var requestModel = _mapper.Map<AddMemberToTeamCommand>(request);
                await _mediator.Send(requestModel);
                return Ok();
            }
            catch (P1Exception e)
            {
                _logger.LogError(e, $"An error occurred while trying to add discord user with id {request.DiscordUserId} to team with id {request.TeamId}. \"{e.Message}\"");
                return BadRequest();
            }
        }

        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        [HttpDelete("remove-member")]
        public async Task<IActionResult> RemoveCondition([FromBody] RemoveMemberFromTeamRequestModel request)
        {
            try
            {
                var requestModel = _mapper.Map<RemoveMemberFromTeamCommand>(request);
                await _mediator.Send(request);
                return Ok();
            }
            catch (P1Exception e)
            {
                _logger.LogError(e, $"An error occurred while trying to remove discord user with id {request.DiscordUserId} from team with id {request.TeamId}. \"{e.Message}\"");
                return BadRequest();
            }
        }
    }
}