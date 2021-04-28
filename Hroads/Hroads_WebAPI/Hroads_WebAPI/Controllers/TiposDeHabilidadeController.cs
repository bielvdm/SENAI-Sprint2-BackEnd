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
    public class TiposDeHabilidadeController : ControllerBase
    {
        private ITipoDeHabilidadeRepository _tipoDeHabilidadeRepository { get; set; }

        public TiposDeHabilidadeController()
        {
            _tipoDeHabilidadeRepository = new TipoDeHabilidadeRepository();
        }

        [Authorize(Roles = "1,2")]
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_tipoDeHabilidadeRepository.Listar());
        }

        [Authorize(Roles = "1")]
        [HttpPost]
        public IActionResult Post(TipoDeHabilidade Nome)
        {
            _tipoDeHabilidadeRepository.Cadastro(Nome);

            return StatusCode(201);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, TipoDeHabilidade Nome)
        {
            _tipoDeHabilidadeRepository.Atualizar(Nome, id);

            return Ok();
        }

        [HttpGet("{id}")]
        public IActionResult GetBuscarId(int id)
        {
            return Ok(_tipoDeHabilidadeRepository.BuscarPorId(id));
        }


        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _tipoDeHabilidadeRepository.Deletar(id);

            return StatusCode(204);
        }
    }
}
