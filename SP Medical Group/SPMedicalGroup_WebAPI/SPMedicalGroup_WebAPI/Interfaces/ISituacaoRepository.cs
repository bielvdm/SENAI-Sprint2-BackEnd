﻿using SPMedicalGroup_WebAPI.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SPMedicalGroup_WebAPI.Interfaces
{
    interface ISituacaoRepository
    {
        List<Situacao> ListarTodos();
        void Cadastrar(Situacao Dados);
        void Deletar(int id);
        void Atualizar(int id, Situacao Dados);
        Situacao BuscarId(int id);
    }
}
