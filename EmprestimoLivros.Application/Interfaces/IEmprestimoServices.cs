using EmprestimoLivros.Application.DTOs;
using EmprestimoLivros.Domain.Pagination;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmprestimoLivros.Application.Interfaces
{
    public interface IEmprestimoServices
    {
        Task<EmprestimoDTOs> Incluir(EmprestimoPostDTOs emprestimoPostDTO);
        Task<EmprestimoDTOs> Alterar(EmprestimoDTOs emprestimoDTO);
        Task<EmprestimoDTOs> Excluir(int id);
        Task<EmprestimoDTOs> SelecionarAsync(int id);
        Task<PagedList<EmprestimoDTOs>> SelecionarTodosAsync(int pageNumber, int pageSize);
        Task<bool> VerificarDisponiblidadeAsync(int idLivro);
    }
}
