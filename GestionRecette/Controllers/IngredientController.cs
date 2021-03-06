using BusinessLogicLayer.Interface;
using BusinessLogicLayer.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace GestionRecette.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IngredientController : ControllerBase
    {
        private IIngredientService _service;

        public IngredientController(IIngredientService service)
        {
            _service = service;
        }

        [HttpGet]
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
                Ingredient u = _service.GetById(id);
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
        public IActionResult Post([FromBody] Ingredient form)
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
        [Authorize("admin")]
        public IActionResult Put([FromBody] Ingredient form)
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
        [Authorize("admin")]
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

        [HttpPut("intermediaire/{id}")]
        [Authorize("user")]
        public IActionResult PutIntermediaire([FromBody] Intermediaire form)
        {
            try
            {
                _service.UpdateUstensile(form);

                return NoContent();
            }
            catch (Exception ex)
            {

                return Problem(ex.Message);
            }
        }

        [HttpDelete("intermediaire/{id}")]
        [Authorize("user")]
        public IActionResult DeleteIntermediaire([FromRoute] int id)
        {
            try
            {
                _service.DeleteUstensile(id);
                return NoContent();
            }
            catch (Exception ex)
            {

                return Problem(ex.Message);
            }
        }

        [HttpGet("intermediaire/{id}")]
        public IActionResult GetIntermediaire([FromRoute] int id)
        {
            try
            {
                return Ok(_service.GetByIdIntermediaire(id));
            }
            catch (Exception ex)
            {

                return Problem(ex.Message);
            }
        }

        [HttpPost]
        [Route("intermediaire")]
        [Authorize("user")]
        public IActionResult PostIntermediaire([FromBody] Intermediaire form)
        {
            try
            {
                _service.InsertUstensile(form);
                return NoContent();
            }
            catch (Exception ex)
            {

                return Problem(ex.Message);
            }
        }

    }
}
