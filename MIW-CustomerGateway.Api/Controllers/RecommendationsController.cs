// using System;
// using System.Collections.Generic;
// using System.Net.Mime;
// using System.Threading.Tasks;
// using Microsoft.AspNetCore.Http;
// using Microsoft.AspNetCore.Mvc;
// using MIW_CustomerGateway.Api.Dto;
// using MIW_CustomerGateway.Core.Models;
//
// namespace MIW_CustomerGateway.Api.Controllers
// {
//     [ApiController]
//     [Route("recommendations")]
//     public class RecommendationsController : ControllerBase
//     {
//         [HttpGet]
//         [Consumes(MediaTypeNames.Application.Json)]
//         [Produces(MediaTypeNames.Application.Json)]
//         [ProducesResponseType(typeof(ProductDto[]), StatusCodes.Status200OK)]
//         [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
//         [ProducesResponseType(StatusCodes.Status501NotImplemented)]
//         public async Task<IActionResult> GetAll()
//         {
//             try
//             {
//                 List<Product> products = await _productService.GetAll();
//                 return Ok(products);
//             }
//             catch (Exception e)
//             {
//                 _logger.LogError("{E}", e);
//                 return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
//             }
//         }
//     }
// }