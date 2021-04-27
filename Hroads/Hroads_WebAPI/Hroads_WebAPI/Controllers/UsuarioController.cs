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
    public class UsuarioController : ControllerBase
    {
        private IUsuarioRepository _UsuarioRepository { get; set; }

        public UsuarioController()
        {
            _UsuarioRepository = new UsuarioRepository();
        }

        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(_UsuarioRepository.Listar());
        }

        [HttpGet("{id}")]
        public IActionResult Buscar(int id)
        {
            return Ok(_UsuarioRepository.BuscarPorId(id));
        }

        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            _UsuarioRepository.Deletar(id);

            return StatusCode(204);
        }

        [HttpPost]
        public IActionResult Cadastrar(Usuario NovoUsuario)
        {
            _UsuarioRepository.Cadastro(NovoUsuario);

            return StatusCode(201);
        }

        [HttpPut("{id}")]
        public IActionResult Atualizar(Usuario UsuarioAtualizado, int id)
        {
            _UsuarioRepository.Atualizar(UsuarioAtualizado, id);

            return Ok();
        }
    }
}
