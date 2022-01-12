using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MIW_CustomerGateway.Api.Dto;
using MIW_CustomerGateway.Core.Models;
using MIW_CustomerGateway.Core.Services.Interfaces;

namespace MIW_CustomerGateway.Api.Controllers
{
    [ApiController]
    [Route("recommendations")]
    public class RecommendationsController : ControllerBase
    {
        private readonly ILogger<RecommendationsController> _logger;
        private readonly IRecommendationsService _recommendationsService;

        public RecommendationsController(ILogger<RecommendationsController> logger,
            IRecommendationsService recommendationsService)
        {
            _logger = logger;
            _recommendationsService = recommendationsService;
        }

        [HttpGet]
        [Consumes(MediaTypeNames.Application.Json)]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(ProductDto[]), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status501NotImplemented)]
        public async Task<IActionResult> GetRecommendations([FromQuery] long[] productIds)
        {
            try
            {
                List<Product> recommendations = await _recommendationsService
                    .GetRecommendations(productIds.ToList());
                return Ok(recommendations);
            }
            catch (Exception e)
            {
                _logger.LogError("{E}", e);
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }
        
        [HttpGet("basket")]
        [Consumes(MediaTypeNames.Application.Json)]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(ProductDto[]), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status501NotImplemented)]
        public async Task<IActionResult> GetRecommendationsByBasketId(long basketId)
        {
            try
            {
                List<Product> recommendations = await _recommendationsService.GetRecommendationsByBasketId(basketId);
                return Ok(recommendations);
            }
            catch (Exception e)
            {
                _logger.LogError("{E}", e);
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }
    }
}