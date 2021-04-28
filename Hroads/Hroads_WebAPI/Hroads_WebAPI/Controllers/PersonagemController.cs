using Hroads_WebAPI.Domains;
using Hroads_WebAPI.Interfaces;
using Hroads_WebAPI.Repositories;
using Microsoft.AspNetCore.Authorization;
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
    public class PersonagemController : ControllerBase
    {
        private IPersonagemRepository _personagemRepository { get; set; }

        public PersonagemController()
        {
            _personagemRepository = new PersonagemRepository();
        }

        [HttpGet("Listar")]
        public IActionResult GetClasse()
        {
            return Ok(_personagemRepository.ListarComClasse());
        }

        [Authorize(Roles = "1,2")]
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_personagemRepository.Listar());
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _personagemRepository.Deletar(id);

            return StatusCode(204);
        }

        [Authorize(Roles = "2")]
        [HttpPost]
        public IActionResult Post(Personagem Nome)
        {
            _personagemRepository.Cadastro(Nome);

            return StatusCode(201);
        }

        [HttpPut("{id}")]
        public IActionResult Put(Personagem Nome, int id)
        {
            _personagemRepository.Atualizar(Nome, id);

            return Ok();
        }

        [HttpGet("{id}")]
        public IActionResult GetBuscarId(int id)
        {
            return Ok(_personagemRepository.BuscarPorId(id));
        }
    }
}
