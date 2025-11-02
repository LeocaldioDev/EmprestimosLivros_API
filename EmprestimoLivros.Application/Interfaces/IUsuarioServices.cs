using EmprestimoLivros.Application.DTOs;
using EmprestimoLivros.Domain.Pagination;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmprestimoLivros.Application.Interfaces
{
    public interface IUsuarioServices
    {
        Task<UsuarioDTOs> Incluir(UsuarioDTOs usuarioDTO);
        Task<UsuarioPutDTO> Alterar(UsuarioPutDTO usuarioDTO);
        Task<UsuarioDTOs> Excluir(int id);
        Task<UsuarioDTOs> SelecionarAsync(int id);
        Task<PagedList<UsuarioDTOs>> SelecionarTodosAsync(int pageNumber, int pageSize);
        Task<bool> ExisteUsuarioCadastradoAsync();
    }
}
