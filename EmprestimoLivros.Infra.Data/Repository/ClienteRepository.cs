using EmprestimoLivros.Domain.Entities;
using EmprestimoLivros.Domain.Interfaces;
using EmprestimoLivros.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmprestimoLivros.Infra.Data.Repository
{
    public class ClienteRepository : IClienteRepository
    {


        public Task<Cliente> Alterar(Cliente cliente)
        {
            throw new NotImplementedException();
        }

        public Task<Cliente> Excluir(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Cliente> Incluir(Cliente cliente)
        {
            throw new NotImplementedException();
        }

        public Task<Cliente> SelecionarAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Cliente>> SelecionarTodosAsync()
        {
            throw new NotImplementedException();
        }
    }
}
