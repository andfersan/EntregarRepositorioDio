﻿using Api_Domain.Dtos.User;
using Api_Domain.Entities;
using Api_Domain.Interfaces.Services.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace ApiApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        [AllowAnonymous]
        [HttpPost]
        public async Task<object> Login([FromBody] LoginDto loginDto, [FromServices] ILoginService service)
        {
            // Se ModelState for inválida, retorna um BadRequest.
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if(loginDto == null)
            {
                return BadRequest();
            }
            try
            {
                var result = await service.FindByLogin(loginDto);
                if(result != null)
                {
                    return Ok(result);
                }
                else
                {
                    return NotFound();
                }
            }
            catch (ArgumentException e)
            {

                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }

    }
}
