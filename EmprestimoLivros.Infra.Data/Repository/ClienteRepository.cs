using EmprestimoLivros.Domain.Entities;
using EmprestimoLivros.Domain.Interfaces;
using EmprestimoLivros.Infra.Data.Context;
using EmprestimoLivros.Infra.Data.Migrations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmprestimoLivros.Infra.Data.Repository
{
    public class ClienteRepository : IClienteRepository
    {
                private ApplicationDBContext _dbContext;

        public ClienteRepository(ApplicationDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        

        public async Task<Cliente> Alterar(Cliente cliente)
        {
            _dbContext.Cliente.Update(cliente);
            await _dbContext.SaveChangesAsync(); 

            return cliente;
        }

        public async Task<Cliente> Excluir(int id)
        {
           Cliente cliente = _dbContext.Cliente.Find(id);
             _dbContext.Cliente.Remove(cliente);
            await _dbContext.SaveChangesAsync();

            return cliente;
        }

        public async Task<Cliente> Incluir(Cliente cliente)
        {
            await _dbContext.Cliente.AddAsync(cliente); 
            await _dbContext.SaveChangesAsync();        
            return cliente;
        }

        public async Task<Cliente> SelecionarAsync(int id)
        {
            var cliente = await _dbContext.Cliente.FindAsync(id);

            return cliente;
        }

        public async Task<IEnumerable<Cliente>> SelecionarTodosAsync()
        {
            var clientes = await _dbContext.Cliente.ToListAsync();
            
           
            return clientes;
        }
    }
}
