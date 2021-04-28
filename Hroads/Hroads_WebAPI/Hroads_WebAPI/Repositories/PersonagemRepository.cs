using Hroads_WebAPI.Domains;
using Hroads_WebAPI.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hroads_WebAPI.Repositories
{
    public class PersonagemRepository : IPersonagemRepository
    {
        SENAI_HROADS_TARDEContext ctx = new SENAI_HROADS_TARDEContext();

        public void Atualizar(Personagem Nome, int id)
        {
            Personagem PersonagemBuscado = ctx.Personagems.Find(id);

            if(Nome.NomePersonagem != null)
            {
                PersonagemBuscado.NomePersonagem = Nome.NomePersonagem;
                PersonagemBuscado.CapacidadeMana = Nome.CapacidadeMana;
                PersonagemBuscado.CapacidadeVida = Nome.CapacidadeVida;
                PersonagemBuscado.DataAtualização = Nome.DataAtualização;
                PersonagemBuscado.DataCriacao = Nome.DataCriacao;
                PersonagemBuscado.IdClasse = Nome.IdClasse;
            }

            ctx.Personagems.Update(PersonagemBuscado);

            ctx.SaveChanges();
        }

        public Personagem BuscarPorId(int id)
        {
            return ctx.Personagems.FirstOrDefault(p => p.IdPersonagem == id);
        }

        public void Cadastro(Personagem Nome)
        {
            ctx.Personagems.Add(Nome);

            ctx.SaveChanges();
        }

        public void Deletar(int id)
        {
            Personagem PersonagemBuscado = ctx.Personagems.Find(id);

            ctx.Personagems.Remove(PersonagemBuscado);

            ctx.SaveChanges();
        }

        public List<Personagem> Listar()
        {
            return ctx.Personagems.ToList();
        }
    }
}
