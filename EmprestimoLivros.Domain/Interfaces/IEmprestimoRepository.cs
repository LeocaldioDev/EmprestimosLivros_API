using EmprestimoLivros.Domain.Entities;
using EmprestimoLivros.Domain.Pagination;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmprestimoLivros.Domain.Interfaces
{
    public interface IEmprestimoRepository
    {
        Task<LivroCLienteEmprestimo> Incluir(LivroCLienteEmprestimo emprestimo);
        Task<LivroCLienteEmprestimo> Alterar(LivroCLienteEmprestimo emprestimo);
        Task<LivroCLienteEmprestimo> Excluir(int id);
        Task<LivroCLienteEmprestimo> SelecionarAsync(int id);
        Task<PagedList<LivroCLienteEmprestimo>> SelecionarTodosAsync(int pageNumber, int pageSize);
        Task<bool> VerificarDisponiblidadeAsync(int idLivro);
    }
}
