using EmprestimoLivros.Application.DTOs;
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
        Task<UsuarioDTOs> Alterar(UsuarioDTOs usuarioDTO);
        Task<UsuarioDTOs> Excluir(int id);
        Task<UsuarioDTOs> SelecionarAsync(int id);
        Task<IEnumerable<UsuarioDTOs>> SelecionarTodosAsync();
        Task<bool> ExisteUsuarioCadastradoAsync();
    }
}
