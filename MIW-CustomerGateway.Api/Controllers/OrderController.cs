using System;
using System.Collections.Generic;
using System.Net.Mime;
using System.Threading.Tasks;
using MIW_CustomerGateway.Api.Dto;
using MIW_CustomerGateway.Core.Models;
using MIW_CustomerGateway.Core.Services.Interfaces;
using MIW_CustomerGateway.Grpc;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MIW_CustomerGateway.Api.Mappers;
using Serilog;
using ILogger = Serilog.ILogger;

namespace MIW_CustomerGateway.Api.Controllers
{
    [ApiController]
    [Route("order")]
    public class OrderController : ControllerBase
    {
        private readonly ILogger<OrderController> _logger;
        private readonly IOrderService _orderService;

        public OrderController(ILogger<OrderController> logger, IOrderService orderService)
        {
            _logger = logger;
            _orderService = orderService;
        }
        
        [HttpGet]
        [Consumes(MediaTypeNames.Application.Json)]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(OrderDto[]), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status501NotImplemented)]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                List<Order> orders = await _orderService.GetAll();
                return Ok(orders);
            }
            catch (Exception e)
            {
                _logger.LogError("{E}", e);
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }
        
        [HttpGet]
        [Route("{id}")]
        [Consumes(MediaTypeNames.Application.Json)]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(OrderDto), StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status501NotImplemented)]
        public async Task<IActionResult> Get([FromRoute] long id)
        {
            _logger.LogInformation("Get Invoked with id: {Id}", id);

            if (id < 1)
                return BadRequest($"Value of {nameof(id)} must be above 0");

            try
            {
                return Ok(await _orderService.Get(id));
            }
            catch (Exception e)
            {
                _logger.LogError("{E}", e);
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        [HttpPost]
        [Consumes(MediaTypeNames.Application.Json)]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(OrderDto), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status501NotImplemented)]
        public async Task<IActionResult> Post([FromBody] CreateOrderDto createOrderDto)
        {
            _logger.LogInformation("Post invoked");

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                return Ok(OrderMapper.OrderToOrderDto(
                    await _orderService.Create(
                        OrderMapper.CreateOrderDtoToOrder(createOrderDto))));
            }
            catch (Exception e)
            {
                _logger.LogError("{E}", e);
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }
    }
}