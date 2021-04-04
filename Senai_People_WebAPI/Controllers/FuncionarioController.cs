using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SENAI_People_WebAPI.Domains;
using SENAI_People_WebAPI.Interfaces;
using SENAI_People_WebAPI.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SENAI_People_WebAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class FuncionarioController : ControllerBase
    {
        private IFuncionarioRepository _FuncionarioRepository { get; set; }

        public FuncionarioController() { _FuncionarioRepository = new FuncionarioRepository(); }

        [HttpGet]
        public IActionResult Get ()
        {
            List<FuncionarioDomain> Lista = _FuncionarioRepository.ListarTodos();

            return Ok(Lista);
        }

        [HttpPost]
        public IActionResult Postar (FuncionarioDomain Nomefuncinario, FuncionarioDomain SobrenomeFuncionario)
        {
            _FuncionarioRepository.InserirNovo(Nomefuncinario, SobrenomeFuncionario);

            return StatusCode(201);
        }
    }
}
