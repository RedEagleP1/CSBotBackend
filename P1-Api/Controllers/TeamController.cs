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
                await _mediator.Send(new DeleteOneEntityRequest<DiscordCommand>(id));
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
        [HttpPost("{teamId}/add-game/{gameId}")]
        public async Task<IActionResult> AddMember([FromRoute] int teamId, [FromRoute] int gameId)
        {
            try
            {
                var request = new AddMemberToTeamRequestModel { GameId = gameId, TeamId = teamId };
                var requestModel = _mapper.Map<AddGameToTeamCommand>(request);
                await _mediator.Send(requestModel);
                return Ok();
            }
            catch (P1Exception e)
            {
                _logger.LogError(e, $"An error occurred while trying to add game with id {gameId} to team with id {teamId}. \"{e.Message}\"");
                return BadRequest();
            }
        }

        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        [HttpDelete("{teamId}/remove-game/{gameId}")]
        public async Task<IActionResult> RemoveCondition([FromRoute] int teamId, [FromRoute] int gameId)
        {
            try
            {
                var request = new AddMemberToTeamRequestModel { GameId = gameId, TeamId = teamId };
                var requestModel = _mapper.Map<RemoveGameFromTeamCommand>(request);
                await _mediator.Send(request);
                return Ok();
            }
            catch (P1Exception e)
            {
                _logger.LogError(e, $"An error occurred while trying to remove game with id {gameId} from team with id {teamId}. \"{e.Message}\"");
                return BadRequest();
            }
        }

        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        [HttpPost("{teamId}/add-member/{userId}")]
        public async Task<IActionResult> AddMember([FromRoute] int teamId, [FromRoute] ulong discordUserId)
        {
            try
            {
                var request = new AddMemberToTeamRequestModel{TeamId = teamId, DiscordUserId = discordUserId};
                var requestModel = _mapper.Map<AddMemberToTeamCommand>(request);
                await _mediator.Send(requestModel);
                return Ok();
            }
            catch (P1Exception e)
            {
                _logger.LogError(e, $"An error occurred while trying to add discord user with id {discordUserId} to team with id {teamId}. \"{e.Message}\"");
                return BadRequest();
            }
        }

        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        [HttpDelete("{teamId}/remove-member/{userId}")]
        public async Task<IActionResult> RemoveCondition([FromRoute] int teamId, [FromRoute] ulong discordUserId)
        {
            try
            {
                var request = new RemoveMemberFromTeamRequestModel{TeamId = teamId, DiscordUserId = discordUserId};
                var requestModel = _mapper.Map<RemoveMemberFromTeamCommand>(request);
                await _mediator.Send(request);
                return Ok();
            }
            catch (P1Exception e)
            {
                _logger.LogError(e, $"An error occurred while trying to remove discord user with id {discordUserId} from team with id {teamId}. \"{e.Message}\"");
                return BadRequest();
            }
        }
    }
}