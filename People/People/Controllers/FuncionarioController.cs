using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using People.Domains;
using People.Interfaces;
using People.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace People.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class FuncionarioController : ControllerBase
    {
        private IFuncionarioRepository _FuncionarioRepository { get; set; }

        public FuncionarioController()
        {
            _FuncionarioRepository = new FuncionarioRepository();
        }

        [HttpPost]
        public IActionResult Post(FuncionarioDomain NovoNome)
        {
            _FuncionarioRepository.InserirNovo(NovoNome);

            return StatusCode(201);
        }


        [HttpPut("{id}")]
        public IActionResult PutAtualizarURL(int id, FuncionarioDomain Nome)
        {
            FuncionarioDomain Buscado = _FuncionarioRepository.BuscarPorId(id);
            if (Buscado == null)
            {
                return NotFound("Funcionario não encontrado");
            }

            try
            {
                _FuncionarioRepository.AtualizarURL(id, Nome);

                return NoContent();
            }
            catch (Exception CodErro)
            {
                return BadRequest(CodErro);
            }

        }


        [HttpPut]
        public IActionResult AtualizarCorpo(FuncionarioDomain Nome)
        {
            FuncionarioDomain Buscado = _FuncionarioRepository.BuscarPorId(Nome.IdFuncionario);

            if (Buscado != null)
            {
                try
                {
                    _FuncionarioRepository.Atualizar(Nome);

                    return NoContent();
                }
                catch (Exception CodErro)
                {
                    return BadRequest(CodErro);
                }
            }

            return NotFound("Funcionario não encontrado");

        }


        [HttpPut("{Nome}")]
        public IActionResult AtualizarUnico (FuncionarioDomain Nome)
        {
            FuncionarioDomain FuncionarioBuscado = _FuncionarioRepository.AtualizarUnico(Nome);
        }

        [HttpGet]
        public IActionResult Get ()
        {
            List <FuncionarioDomain> Lista = _FuncionarioRepository.ListarTodos();

            return Ok(Lista);
        }


        [HttpGet("{id}")]
        public IActionResult GetBuscarPorId (int id)
        {
            FuncionarioDomain FuncionarioBuscado = _FuncionarioRepository.BuscarPorId(id);

            if (FuncionarioBuscado == null)
            {
                return NotFound("Funcionário não encontrado");
            }
            return Ok(FuncionarioBuscado);
        }


        [HttpDelete("{id}")]
        public IActionResult Delete (int id)
        {
            _FuncionarioRepository.Deletar(id);

            return StatusCode(204);
        }
    }
}
