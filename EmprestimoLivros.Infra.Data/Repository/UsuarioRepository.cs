using EmprestimoLivros.Domain.Entities;
using EmprestimoLivros.Domain.Interfaces;
using EmprestimoLivros.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmprestimoLivros.Infra.Data.Repository
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private ApplicationDBContext _dbContext;

        public UsuarioRepository(ApplicationDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Usuario> Alterar(Usuario usuario)
        {
            _dbContext.Usuario.Update(usuario);
            await _dbContext.SaveChangesAsync();

            return usuario;
        }

        public async Task<Usuario> Excluir(int id)
        {
            Usuario usuario = _dbContext.Usuario.Find(id);
            await _dbContext.SaveChangesAsync();

            return usuario;
        }

        public async Task<Usuario> Incluir(Usuario usuario)
        {
            await _dbContext.Usuario.AddAsync(usuario);
            await _dbContext.SaveChangesAsync();
            return usuario;
        }

        public async Task<Usuario> SelecionarAsync(int id)
        {
            var usuario = await _dbContext.Usuario.FindAsync(id);

            return usuario;
        }

        public async Task<IEnumerable<Usuario>> SelecionarTodosAsync()
        {
            var usuarios = await _dbContext.Usuario.ToListAsync();


            return usuarios;
        }
    }
}

