using EmprestimoLivros.Application.DTOs;
using EmprestimoLivros.Domain.Pagination;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmprestimoLivros.Application.Interfaces
{
    public interface ICLienteServices
    {
        Task<ClienteDTOs> Incluir(ClienteDTOs clienteDTO);
        Task<ClienteDTOs> Alterar(ClienteDTOs clienteDTO);
        Task<ClienteDTOs> Excluir(int id);
        Task<ClienteDTOs> SelecionarAsync(int id);
        Task<PagedList<ClienteDTOs>> SelecionarTodosAsync(int pageNumber,int pageSize);
    }
}
