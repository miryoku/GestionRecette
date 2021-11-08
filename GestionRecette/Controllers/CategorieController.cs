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
    public class CategorieController : ControllerBase
    {
        private ICategorieService _service;

        public CategorieController(ICategorieService categorieService)
        {
            _service = categorieService;
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
                Categorie c = _service.GetById(id); 
                if(c is null)
                {
                    return NotFound();
                }
                return Ok(c);
            }
            catch (Exception ex)
            {

                return Problem(ex.Message);
            }
        }

        [HttpPost]
        [Authorize("user")]
        public IActionResult Post([FromBody] Categorie form)
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
        public IActionResult Put([FromBody] Categorie form)
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
