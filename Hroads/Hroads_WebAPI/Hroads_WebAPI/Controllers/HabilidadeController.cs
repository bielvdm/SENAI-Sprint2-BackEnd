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
    public class HabilidadeController : ControllerBase
    {
        private IHabilidadeRepository _habilidadeRepository { get; set; }

        public HabilidadeController()
        {
            _habilidadeRepository = new HabilidadeRepository();
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_habilidadeRepository.Listar());
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _habilidadeRepository.Deletar(id);

            return StatusCode(204);
        }

        [HttpPost]
        public IActionResult Post(Habilidade Nome)
        {
            _habilidadeRepository.Cadastro(Nome);

            return StatusCode(201);
        }

        [HttpPut("{id}")]
        public IActionResult Put(Habilidade Nome, int id)
        {
            _habilidadeRepository.Atualizar(Nome, id);

            return Ok();
        }

        [HttpGet("{id}")]
        public IActionResult GetBuscarId(int id)
        {
            return Ok(_habilidadeRepository.BuscarPorId(id));
        }
    }
}
