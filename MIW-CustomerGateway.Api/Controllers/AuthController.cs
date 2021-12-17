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

namespace MIW_CustomerGateway.Api.Controllers
{
    [ApiController]
    [Route("/auth")]
    public class AuthController : ControllerBase
    {
        private readonly ILogger<AuthController> _logger;
        private readonly IAuthService _authService;

        public AuthController(ILogger<AuthController> logger, IAuthService authService)
        {
            _logger = logger;
            _authService = authService;
        }

        [HttpPost]
        [Route("login")]
        [Consumes(MediaTypeNames.Application.Json)]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Login([FromBody] CredentialsDto credentialsDto)
        {
            _logger.LogInformation("Login Invoked for email: {E}", credentialsDto.Email);
            
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            
            try
            {
                return Ok(_authService.Login(
                    AuthMapper.CredentialsDtoToCredentials(credentialsDto)));
            }
            catch (Exception e)
            {
                _logger.LogError("{E}", e);
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }
        
        [HttpPost]
        [Route("register")]
        [Consumes(MediaTypeNames.Application.Json)]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Register([FromBody] RegisterCredentialsDto registerCredentialsDto)
        {
            _logger.LogInformation("Register Invoked for email: {E}", registerCredentialsDto.Email);
            
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            
            if (!registerCredentialsDto.Password.Equals(registerCredentialsDto.ConfirmPassword))
                throw new ArgumentException("Password inputs do not match");
            
            try
            {
                return Ok(_authService.Register(
                    AuthMapper.RegisterCredentialsDtoToCredentials(registerCredentialsDto)));
            }
            catch (Exception e)
            {
                _logger.LogError("{E}", e);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}