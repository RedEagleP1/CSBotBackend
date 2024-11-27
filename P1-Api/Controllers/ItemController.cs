using MediatR;
using Microsoft.AspNetCore.Mvc;
using P1_Application;
using P1_Api.Models.Items;
using AutoMapper;
using System.Diagnostics;
using P1_Application.UseCases;
using P1_Core.Interfaces;
using P1_Application.Exceptions;
using P1_Application.Boundaries;
using P1_Core.Entities;
using P1_Application.UseCases.BaseUseCases;

namespace P1_Api.Controllers
{
    public class ItemController : BaseController
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public ItemController(ILogger<ItemController> logger, IMediator mediator, IMapper mapper, ApplicationContext context) : base(logger, context)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        [HttpPost("create-item")]
        public async Task<IActionResult> CreateItem([FromBody] AddOneEntityRequest<Item> request)
        {
            try
            {
                var response = await _mediator.Send(request);
                return Ok(response != null ? response : null);
            }
            catch (P1Exception e)
            {
                _logger.LogError(e, $"An error occurred while creating item: \"{e.Message}\"");
                return BadRequest();
            }
        }

        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        [HttpGet("get-item/{id}")]
        public async Task<IActionResult> GetItem([FromRoute] int id)
        {
            try
            {
                var response = await _mediator.Send(new GetOneEntityRequest<Item>(id));
                return Ok(response != null ? response : null);
            }
            catch (P1Exception e)
            {
                _logger.LogError(e, $"An error occurred while getting the item with Id {id}. \"{e.Message}\"");
                return BadRequest();
            }
        }


        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        [HttpGet("get-all-items")]
        public async Task<IActionResult> GetAllItems()
        {
            try
            {
                var response = await _mediator.Send(new GetAllEntitiesRequest<Item>());
                return Ok(response != null ? response : null);
            }
            catch (P1Exception e)
            {
                _logger.LogError(e, $"An error occurred while getting all items: \"{e.Message}\"");
                return BadRequest();
            }
        }

        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        [HttpPut("update-item")]
        public async Task<IActionResult> UpdateItem([FromBody] UpdateOneEntityRequest<Item> request)
        {
            try
            {
                await _mediator.Send(request);
                return Ok();
            }
            catch (P1Exception e)
            {
                _logger.LogError(e, $"An error occurred while updating the item with id {request.Entity.Id}. \"{e.Message}\"");
                return BadRequest();
            }
        }

        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        [HttpDelete("delete-item/{id}")]
        public async Task<IActionResult> DeleteItem([FromRoute] int id)
        {
            try
            {
                await _mediator.Send(new DeleteOneEntityRequest<DiscordCommand>(id));
                return Ok();
            }
            catch (P1Exception e)
            {
                _logger.LogError(e, $"An error occurred while deleting the item with Id {id}");
                return BadRequest();
            }
        }

    }
}