using Hroads_WebAPI.Domains;
using Hroads_WebAPI.Interfaces;
using Hroads_WebAPI.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hroads_WebAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class ClasseController : ControllerBase
    {
        private IClasseRepository _classeRepository { get; set; }

        public ClasseController()
        {
            _classeRepository = new ClasseRepository();
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_classeRepository.Listar());
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _classeRepository.Deletar(id);

            return StatusCode(204);
        }

        [HttpPost]
        public IActionResult Post(Class Nome)
        {
            _classeRepository.Cadastro(Nome);

            return StatusCode(201);
        }

        [HttpPut("{id}")]
        public IActionResult Put(Class Nome, int id)
        {
            _classeRepository.Atualizar(Nome, id);

            return Ok();
        }

        [HttpGet("{id}")]
        public IActionResult GetBuscarId(int id)
        {
            return Ok(_classeRepository.BuscarPorId(id));
        }
    }
}
