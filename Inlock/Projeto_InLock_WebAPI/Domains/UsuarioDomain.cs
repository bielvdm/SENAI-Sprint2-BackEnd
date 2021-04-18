using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto_InLock_WebAPI.Domains
{
    public class UsuarioDomain
    {
        public int IdUsuario { get; set; }

        [Required(ErrorMessage ="E-mail obrigatório")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Senha obrigatória")]
        public string Senha { get; set; }
        public int IdTpoUsuario { get; set; }
        public TipoUsuarioDomain tipoUsuario { get; set; }
    }
}
