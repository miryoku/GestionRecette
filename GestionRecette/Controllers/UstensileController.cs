using BusinessLogicLayer.Interface;
using BusinessLogicLayer.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace GestionRecette.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UstensileController : ControllerBase
    {
        private IUstensileService _service;

        public UstensileController(IUstensileService service)
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
                Ustensiles u = _service.GetById(id);
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
        public IActionResult Post([FromBody] Ustensiles form)
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

        [HttpPost]
        [Route("intermediaire")]
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

        [HttpPut("{id}")]
        public IActionResult Put([FromBody] Ustensiles form)
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
                Intermediaire u = _service.GetByIdIntermediaire(id);
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


    }
}