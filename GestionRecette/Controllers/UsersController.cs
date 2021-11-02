using Microsoft.AspNetCore.Mvc;
using BusinessLogicLayer.Interface;
using System;
using BusinessLogicLayer.Models;
using Microsoft.AspNetCore.Authorization;
using TokenTools;
using GestionRecette.Tools;

namespace GestionRecette.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private IUsersService _service;
        private readonly ITokenManager _tokenManager;

        public UsersController(IUsersService userService, ITokenManager tokenManager)
        {
            _service = userService;
            _tokenManager = tokenManager;
        }



        [HttpGet]
        [Authorize("admin")]
        public IActionResult GetAll()
        {
            try
            {
                return Ok(_service.GetAll());
            }
            catch (Exception ex)
            {

                return Problem(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public IActionResult Get([FromRoute] int id)
        {
            try
            {
                Users u = _service.GetById(id);
                if (u is null)
                {
                    return NotFound();
                }
                return Ok(u);
            }
            catch (Exception ex)
            {

                return Problem(ex.Message);
            }
        }

        [HttpPost]
        public IActionResult Post([FromBody] Users form)
        {
            try
            {
                _service.Insert(form);
                return NoContent();
            }
            catch (Exception ex)
            {

                return Problem(ex.Message);
            }
        }

        [HttpPut("{id}")]
        [Authorize("user")]
        public IActionResult Put([FromBody] Users form)
        {
            try
            {

                _service.Update(form);
                return NoContent();
            }
            catch (Exception ex)
            {

                return Problem(ex.Message);
            }
        }
        [HttpDelete("{id}")]
        [Authorize("user")]
        public IActionResult Delete([FromRoute] int id)
        {
            try
            {
                _service.Delete(id);
                return NoContent();
            }
            catch (Exception ex)
            {

                return Problem(ex.Message);
            }
        }

        [HttpPost]
        [Route("login")]
        public IActionResult Login([FromBody] Users login)
        {
            try
            {
                if (login is null) return BadRequest("user null");
                Console.WriteLine(_service.Login(login).ToToken());
                User userLogin = _tokenManager.Authenticate(_service.Login(login).ToToken());
                if (login is null) return new ForbidResult("interdit");
                // return Ok(new { token = userLogin.Token });
                return Ok(userLogin);
            }
            catch (Exception ex)
            {

                return Problem(ex.Message);
            }
        }
    }

}
