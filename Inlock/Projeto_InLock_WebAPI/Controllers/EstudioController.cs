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
    public class EstudioController : ControllerBase
    {
        private IEstudioRepository _estudioRepository { get; set; }

        public EstudioController()
        {
            _estudioRepository = new EstudioRepository();
        }

        [HttpGet]
        public IActionResult getJogo()
        {
            List<EstudioDomain> jogos = _estudioRepository.BuscarJogo();

            return Ok(jogos);
        }
    }
}
