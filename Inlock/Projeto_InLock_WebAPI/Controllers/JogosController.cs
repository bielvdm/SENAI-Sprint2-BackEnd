using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Projeto_InLock_WebAPI.Domains;
using Projeto_InLock_WebAPI.Interfaces;
using Projeto_InLock_WebAPI.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto_InLock_WebAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class JogosController : ControllerBase
    {
        private IJogosRepository _JogosRepository { get; set; }

        public JogosController()
        {
            _JogosRepository = new JogosRepository();
        }

        [HttpGet]
        public IActionResult ListarGet()
        {
            List<JogosDomain> Listando = _JogosRepository.ListarJogos();

            return Ok(Listando);
        }

        [Authorize(Roles = "1")]
        [HttpPost]
        public IActionResult CadastrarPost(JogosDomain NovoJogo)
        {
            _JogosRepository.Cadastrar(NovoJogo);

            return StatusCode(201);
        }
    }
}
