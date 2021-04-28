using Hroads_WebAPI.Domains;
using Hroads_WebAPI.Interfaces;
using Hroads_WebAPI.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Hroads_WebAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private IUsuarioRepository _UsuarioRepository { get; set; }

        public LoginController()
        {
            _UsuarioRepository = new UsuarioRepository();
        }

        [HttpPost]
        public IActionResult Login (Usuario Login)
        {
            Usuario usuarioBuscado = _UsuarioRepository.Login(Login.Email, Login.Senha);

            if (usuarioBuscado == null)
            {
                return NotFound("Email e/ou Senha não encontrados no nosso sistema");
            }

            var claim = new[]
            {
                new Claim (JwtRegisteredClaimNames.Email, usuarioBuscado.Email),
                new Claim (JwtRegisteredClaimNames.Jti, usuarioBuscado.IdTipoUsuario.ToString()),
                new Claim (ClaimTypes.Role, usuarioBuscado.IdTipoUsuario.ToString())
            };

            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("hroads-webapi-token"));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            
            var token = new JwtSecurityToken
            (
                issuer: "Hroads_WebAPI",
                audience: "Hroads_WebAPI",
                claims: claim,
                expires: DateTime.Now.AddMinutes(20),
                signingCredentials: creds
            );

            return Ok(new
            {
                token = new JwtSecurityTokenHandler().WriteToken(token)
            });
        }

    }
}
