using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Projeto_InLock_WebAPI.Domains;
using Projeto_InLock_WebAPI.Interfaces;
using Projeto_InLock_WebAPI.Repositories;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;

namespace Projeto_InLock_WebAPI.Controllers
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

        [HttpPost]
        public IActionResult Cadastro (UsuarioDomain NovoUsuario)
        {
            _UsuarioRepository.CadastrarUsuario(NovoUsuario);

            return StatusCode(201);
        }

        [HttpPost("login")]
        public IActionResult Login (UsuarioDomain Login)
        {
            UsuarioDomain UsuarioBuscado = _UsuarioRepository.BuscarPorEmail(Login.Email, Login.Senha);

            if (UsuarioBuscado == null)
            {
                return NotFound("E-mail ou senha incorretos");
            }

            var claims = new[]
            {
                new Claim (JwtRegisteredClaimNames.Email, UsuarioBuscado.Email),
                new Claim (JwtRegisteredClaimNames.Jti, UsuarioBuscado.IdUsuario.ToString()),
                new Claim (ClaimTypes.Role, UsuarioBuscado.tipoUsuario.Titulo)
            };

            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("40028922"));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken
            (
            issuer: "Projeto_InLock_WebAPI",
            audience: "Projeto_InLock_WebAPI",
            claims: claims,
            expires: DateTime.Now.AddMinutes(30),
            signingCredentials: creds
            );

            return Ok(new
            {
                token = new JwtSecurityTokenHandler().WriteToken(token)
            });
        }
    }
}
