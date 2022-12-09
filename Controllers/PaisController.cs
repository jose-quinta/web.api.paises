using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using web.api.paises.Data;
using web.api.paises.Entities;

namespace web.api.paises.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PaisController : ControllerBase
    {
        //public static List<Pais> Paises = new List<Pais>();
        private readonly IContext _context;
        public PaisController(IContext context) {
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult<List<Pais>>> GetPaises() {
            var response = await _context.GetPaises();
            if(response == null) {
                return BadRequest("There are not countries!!!");
            }
            return Ok(response);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Pais>> GetPaisById(int id) {
            var response = await _context.GetPaisById(id);
            if(response == null) {
                return BadRequest($"The country with ID {id} not exist!!!");
            }
            return Ok(response);
        }
        [HttpPost]
        public async Task<ActionResult<List<Pais>>> PostPais(PaisDto request) {
            var pais = new Pais() {
                Name = request.Name
            };
            var response = await _context.PostPais(pais);
            if(response == null) {
                return BadRequest("The country is wrong or null.");
            }
            return Ok(response);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<Pais>> PutPais(int id, PaisDto request) {
            var pais = new Pais() {
                Id = request.Id,
                Name = request.Name
            };
            var response = await _context.PutPais(id, pais);
            if(response == null) {
                return BadRequest("The country is wrong!!");
            }
            return Ok(response);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<Pais>> DeletePais(int id) {
            var response = await _context.DeletePais(id);
            if(response == null) {
                return BadRequest("The country not exist!!");
            }
            return Ok(response);
        }
    }
}