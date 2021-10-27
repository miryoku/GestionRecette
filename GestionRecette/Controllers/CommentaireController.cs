using BusinessLogicLayer.Interface;
using BusinessLogicLayer.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace GestionRecette.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentaireController : ControllerBase
    {
        private ICommentaireService _service;

        public CommentaireController(ICommentaireService service)
        {
            _service = service;
        }

        [HttpGet("{id}")]
        public IActionResult GetAll([FromRoute] int id)
        {
            try
            {
                IEnumerable<Commentaires> u = _service.GetAll(id);
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
        [Authorize("user")]
        public IActionResult Post([FromBody] Commentaires form)
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
        public IActionResult Put([FromBody] Commentaires form)
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
    }
}
