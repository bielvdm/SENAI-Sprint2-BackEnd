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
    [Produces ("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class TipoUsuarioController : ControllerBase
    {
        private ITipoUsuarioRepository _TipoUsuarioRepository { get; set; }

        public TipoUsuarioController()
        {
            _TipoUsuarioRepository = new TipoUsuarioRepository ();
        }

        [Authorize(Roles = "1,2")]
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_TipoUsuarioRepository.Listar());
        }

        [Authorize(Roles = "1")]
        [HttpPost]
        public IActionResult Post (TipoUsuario Nome)
        {
            _TipoUsuarioRepository.Cadastro(Nome);

            return StatusCode(201);
        }

        [HttpPut("{id}")]
        public IActionResult Put (int id, TipoUsuario Nome)
        {
            _TipoUsuarioRepository.Atualizar(Nome, id);

            return Ok();
        }

        [HttpGet("{id}")]
        public IActionResult GetBuscarId (int id)
        {
            return Ok(_TipoUsuarioRepository.BuscarPorId(id));
        }


        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _TipoUsuarioRepository.Deletar(id);

            return StatusCode(204);
        }
    }
}
