﻿using EmprestimoLivros.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmprestimoLivros.Domain.Interfaces
{
    public interface IUsuarioRepository
    {
        Task<Usuario> Incluir(Usuario cliente);
        Task<Usuario> Alterar(Usuario cliente);
        Task<Usuario> Excluir(int id);
        Task<Usuario> SelecionarAsync(int id);
        Task<IEnumerable<Usuario>> SelecionarTodosAsync();
    }
}
