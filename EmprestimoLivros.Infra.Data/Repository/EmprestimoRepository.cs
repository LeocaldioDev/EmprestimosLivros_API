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
    public class EmprestimoRepository : IEmprestimoRepository
    {
        private ApplicationDBContext _dbContext;

        public EmprestimoRepository(ApplicationDBContext dbContext)
        {
            _dbContext = dbContext;
        }



        public async Task<LivroCLienteEmprestimo> Alterar(LivroCLienteEmprestimo emprestimo)
        {
            _dbContext.Emprestimo.Update(emprestimo);
            await _dbContext.SaveChangesAsync();

            return emprestimo;
        }

        public async Task<LivroCLienteEmprestimo> Excluir(int id)
        {
            LivroCLienteEmprestimo emprestimo = _dbContext.Emprestimo.Find(id);
            _dbContext.Emprestimo.Remove(emprestimo);
            await _dbContext.SaveChangesAsync();

            return emprestimo;
        }

        public async Task<LivroCLienteEmprestimo> Incluir(LivroCLienteEmprestimo emprestimo)
        {
            await _dbContext.Emprestimo.AddAsync(emprestimo);
            await _dbContext.SaveChangesAsync();
            return emprestimo;
        }

        public async Task<LivroCLienteEmprestimo> SelecionarAsync(int id)
        {
            var emprestimo = await _dbContext.Emprestimo.Include(x => x.Livro).Include(x => x.Cliente).AsNoTracking().FirstOrDefaultAsync(x =>x.id == id);

            return emprestimo;
        }

        public async Task<PagedList<LivroCLienteEmprestimo>> SelecionarTodosAsync(int pageNumber, int pageSize)
        {
            var query = _dbContext.Emprestimo.Include(x =>x.Livro).Include(x=>x.Cliente).AsQueryable();
            return await PaginationHelper.CreateAsync<LivroCLienteEmprestimo>(query, pageNumber, pageSize);

        }

        public async Task<bool> VerificarDisponiblidadeAsync(int idLivro)
        {
          var existeEmprestimo = await _dbContext.Emprestimo.
                Where(x => x.livroId == idLivro && x.entregue == false).AnyAsync();

            return !existeEmprestimo;
        }
    }
}
