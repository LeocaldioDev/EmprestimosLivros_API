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
    public class LivroRepository : ILivroRepository
    {
        private readonly ApplicationDBContext _dbContext;
        public LivroRepository(ApplicationDBContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Livro> Alterar(Livro livro)
        {
            _dbContext.Livro.Update(livro);
            await _dbContext.SaveChangesAsync();

            return livro;
        }

        public async Task<Livro> Excluir(int id)
        {
            Livro livro = _dbContext.Livro.Find(id);
            _dbContext.Livro.Remove(livro);
            await _dbContext.SaveChangesAsync();

            return livro;
        }

        public async Task<Livro> Incluir(Livro livro)
        {
            await _dbContext.Livro.AddAsync(livro);
            await _dbContext.SaveChangesAsync();
            return livro;
        }

        public async Task<Livro> SelecionarAsync(int id)
        {
            var livro = await _dbContext.Livro.FindAsync(id);

            return livro;
        }

        public async Task<PagedList<Livro>> SelecionarTodosAsync(int PageNumber, int PageSize)
        {
            var query = _dbContext.Livro.AsQueryable();
            return await PaginationHelper.CreateAsync<Livro>(query, PageNumber, PageSize);
        }
    }
}
