using System;
using System.Collections.Generic;
using System.Net.Mime;
using System.Threading.Tasks;
using MIW_CustomerGateway.Api.Dto;
using MIW_CustomerGateway.Api.Mappers;
using MIW_CustomerGateway.Core.Models;
using MIW_CustomerGateway.Core.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Serilog;

namespace MIW_CustomerGateway.Api.Controllers
{
    [ApiController]
    [Route("product")]
    public class ProductController : ControllerBase
    {
        private readonly ILogger<ProductController> _logger;
        private readonly IProductService _productService;

        public ProductController(ILogger<ProductController> logger, IProductService productService)
        {
            _logger = logger;
            _productService = productService;
        }

        [HttpGet]
        [Consumes(MediaTypeNames.Application.Json)]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(ProductDto[]), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status501NotImplemented)]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                List<Product> products = await _productService.GetAll();
                return Ok(products);
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
        [ProducesResponseType(typeof(ProductDto), StatusCodes.Status500InternalServerError)]
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
                return Ok(await _productService.Get(id));
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
        [ProducesResponseType(typeof(ProductDto), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status501NotImplemented)]
        public async Task<IActionResult> Post([FromBody] CreateProductDto createProductDto)
        {
            _logger.LogInformation("Post invoked");

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                return Ok(ProductMapper.ProductToProductDto(
                    await _productService.Create(
                        ProductMapper.CreateProductDtoToProduct(createProductDto))));
            }
            catch (Exception e)
            {
                _logger.LogError("{E}", e);
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }
    }
}