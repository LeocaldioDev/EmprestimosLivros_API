using EmprestimoLivros.Domain.Entities;
using EmprestimoLivros.Domain.Interfaces;
using EmprestimoLivros.Domain.Pagination;
using EmprestimoLivros.Infra.Data.Context;
using EmprestimoLivros.Infra.Data.Helpes;
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

            var local = _dbContext.Usuario.Local.FirstOrDefault(x => x.id == usuario.id);
            if (local != null)
            {

                _dbContext.Entry(local).State = EntityState.Detached;
            }

            if (usuario.passwordSalt == null || usuario.passwordHash == null)
            {
                var passwordCripgrafado = await _dbContext.Usuario
                    .AsNoTracking()
                    .Where(x => x.id == usuario.id)
                    .Select(x => new { x.passwordHash, x.passwordSalt })
                    .FirstOrDefaultAsync();

                usuario.AlterarSenha(passwordCripgrafado.passwordHash, passwordCripgrafado.passwordSalt);
            }

            _dbContext.Usuario.Update(usuario);
            await _dbContext.SaveChangesAsync();

            return usuario;
        }



        public async Task<Usuario> Excluir(int id)
        {
            Usuario usuario =await _dbContext.Usuario.FindAsync(id);
            if (usuario != null)
            {
                _dbContext.Usuario.Remove(usuario);
                await _dbContext.SaveChangesAsync();
                return usuario;
            }

            return null;
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

        public async Task<PagedList<Usuario>> SelecionarTodosAsync(int pageNumber, int pageSize)
        {
            var query = _dbContext.Usuario.AsQueryable();
            return await PaginationHelper.CreateAsync<Usuario>(query, pageNumber, pageSize);
        }

       public async Task<bool> ExisteUsuarioCadastradoAsync()
        {
            return await _dbContext.Usuario.AnyAsync();
        }
    }
}

