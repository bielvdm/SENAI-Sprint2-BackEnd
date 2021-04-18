using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai_Filmes_WebApi.Domains;
using Senai_Filmes_WebApi.Interfaces;
using Senai_Filmes_WebApi.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai_Filmes_WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]  
    public class GeneroController : ControllerBase
    {
        private IGeneroRepository _generoRepository { get; set; }

        public GeneroController()
        {
            _generoRepository = new GeneroRepository();
        }

        [HttpGet]
        public IActionResult Get()
        {
            List<GeneroDomain> listagenero = _generoRepository.ListarTodos();

            return Ok(listagenero);
        }
    }
}
