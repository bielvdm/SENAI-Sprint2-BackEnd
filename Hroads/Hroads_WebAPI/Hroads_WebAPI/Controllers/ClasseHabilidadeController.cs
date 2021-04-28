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
    public class ClasseHabilidadeController : ControllerBase
    {
        private IClasseHabilidadeRepository _classeHabilidadeRepository { get; set; }

        public ClasseHabilidadeController()
        {
            _classeHabilidadeRepository = new ClasseHabilidadeRepository();
        }

        [Authorize(Roles = "1,2")]
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_classeHabilidadeRepository.Listar());
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _classeHabilidadeRepository.Deletar(id);

            return StatusCode(204);
        }

        [Authorize(Roles = "1")]
        [HttpPost]
        public IActionResult Post(ClassesHabilidade Nome)
        {
            _classeHabilidadeRepository.Cadastro(Nome);

            return StatusCode(201);
        }

        [HttpPut("{id}")]
        public IActionResult Put(ClassesHabilidade Nome, int id)
        {
            _classeHabilidadeRepository.Atualizar(id, Nome);

            return Ok();
        }

        [HttpGet("{id}")]
        public IActionResult GetBuscarId(int id)
        {
            return Ok(_classeHabilidadeRepository.BuscarPorId(id));
        }
    }
}
