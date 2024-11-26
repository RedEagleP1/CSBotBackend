using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using P1_Api.Models.DiscordCommands;
using P1_Application.Boundaries;
using P1_Application.Exceptions;
using P1_Application.UseCases;
using P1_Application.UseCases.DiscordCommands.CreateDiscordCommand;
using P1_Core.Entities;

namespace P1_Api.Controllers
{

    public class DiscordCommandController : BaseController
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;


        public DiscordCommandController(ILogger<DiscordCommandController> logger, ApplicationContext context, IMediator mediator, IMapper mapper) : base(logger, context)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpPost("create-discord-command")]
        public async Task<IActionResult> CreateCommand(CreateDiscordCommandRequest request)
        {
            try
            {
                var response = await _mediator.Send(request);
                return Ok(response != null ? response : null);
            }
            catch (P1Exception e)
            {
                _logger.LogError(e, $"An error occurred while creating discord command: \"{e.Message}\"");
                return BadRequest();
            }
        }

        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        [HttpGet("get-discord-command/{id}")]
        public async Task<IActionResult> GetDiscordCommand([FromRoute] int id)
        {
            try
            {
                var response = await _mediator.Send(new GetOneEntityRequest<DiscordCommand>(id));
                return Ok(response != null ? response : null);
            }
            catch (P1Exception e)
            {
                _logger.LogError(e, $"An error occurred while getting the discord command with Id {id}. \"{e.Message}\"");
                return BadRequest();
            }
        }


        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        [HttpGet("get-all-discord-commands")]
        public async Task<IActionResult> GetAllDiscordCommands()
        {
            try
            {
                var response = await _mediator.Send(new GetAllEntitiesRequest<DiscordCommand>());
                return Ok(response != null ? response : null);
            }
            catch (P1Exception e)
            {
                _logger.LogError(e, $"An error occurred while getting all discord commands: \"{e.Message}\"");
                return BadRequest();
            }
        }

        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        [HttpPut("update-discord-command")]
        public async Task<IActionResult> UpdateDiscordCommand([FromBody] UpdateOneEntityRequest<DiscordCommand> request)
        {
            try
            {
                await _mediator.Send(request);
                return Ok();
            }
            catch (P1Exception e)
            {
                _logger.LogError(e, $"An error occurred while updating the discord command with id {request.Entity.Id}. \"{e.Message}\"");
                return BadRequest();
            }
        }

        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        [HttpDelete("delete-discord-command/{id}")]
        public async Task<IActionResult> DeleteDiscordCommand([FromRoute] int id)
        {
            try
            {
                await _mediator.Send(new DeleteOneEntityRequest<DiscordCommand>(id));
                return Ok();
            }
            catch (P1Exception e)
            {
                _logger.LogError(e, $"An error occurred while deleting the discord command with Id {id}");
                return BadRequest();
            }
        }

    }
}