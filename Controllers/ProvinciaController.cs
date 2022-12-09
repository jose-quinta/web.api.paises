using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using web.api.paises.Data;
using web.api.paises.Entities;

namespace web.api.paises.Controllers {
    [ApiController]
    [Route("api/[controller]")]
    public class ProvinciaController : ControllerBase {
        //public static List<Provincia> Provincias = new List<Provincia>();
        private readonly IContext _context;
        public ProvinciaController(IContext context) {
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult<List<Provincia>>> GetProvincias() {
            var response = await _context.GetProvincias();
            if(response == null) {
                return BadRequest("The provincias not exist!!!");
            }
            return Ok(response);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Provincia>> GetProvinciaById(int id) {
            var response = await _context.GetProvinciaById(id);
            if(response == null) {
                return BadRequest("The provincia not exist!!!");
            }
            return Ok(response);
        }
        [HttpPost]
        public async Task<ActionResult<List<Provincia>>> PostProvincia(ProvinciaDto request) {
            var provincia = new Provincia() {
                Name = request.Name,
                IdPais = request.IdPais
            };
            var response = await _context.PostProvincia(provincia);
            if(response == null) {
                return BadRequest("The provincia is wrong!!!");
            }
            return Ok(response);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<Provincia>> PutProvincia(int id, ProvinciaDto request) {
            var provincia = new Provincia() {
                Id = request.Id,
                Name = request.Name,
                IdPais = request.IdPais
            };
            var response = await _context.PutProvincia(id, provincia);
            if(response == null) {
                return BadRequest("The provincia not exist!!!");
            }
            return Ok(response);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<Provincia>> DeleteProvincia(int id) {
            var response = await _context.DeleteProvincia(id);
            if(response == null) {
                return BadRequest("The provincia not exist!!!");
            }
            return Ok(response);
        }
    }
}