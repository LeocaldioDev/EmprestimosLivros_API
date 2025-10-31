using EmprestimoLivros.Domain.Entities;
using EmprestimoLivros.Domain.Pagination;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmprestimoLivros.Domain.Interfaces
{
    public interface ILivroRepository
    {
        Task<Livro> Incluir(Livro livro);
        Task<Livro> Alterar(Livro livro);
        Task<Livro> Excluir(int id);
        Task<Livro> SelecionarAsync(int id);
        Task<PagedList<Livro>> SelecionarTodosAsync(int PageNumber, int PageSize);
    }
}
