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
    public class EtapeController : ControllerBase
    {
        private IEtapeService _service;

        public EtapeController(IEtapeService service)
        {
            _service = service;
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
                Etapes u = _service.GetById(id);
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

     
        [HttpGet("intermediaire/{id}")]
        public IActionResult GetIntermediaire([FromRoute] int id)
        {
            try
            {
                return Ok(_service.GetByIdTEtape(id));
            }
            catch (Exception ex)
            {

                return Problem(ex.Message);
            }
        }



        [HttpPost]
        [Authorize("user")]
        public IActionResult Post([FromBody] Etapes form)
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
        public IActionResult Put([FromBody] Etapes form)
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
