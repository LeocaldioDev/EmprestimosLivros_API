using EmprestimoLivros.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmprestimoLivros.Application.Interfaces
{
    public interface ILivroServices
    {
        Task<LivroDTOs> Incluir(LivroDTOs livroDTO);
        Task<LivroDTOs> Alterar(LivroDTOs livroDTO);
        Task<LivroDTOs> Excluir(int id);
        Task<LivroDTOs> SelecionarAsync(int id);
        Task<IEnumerable<LivroDTOs>> SelecionarTodosAsync();
    }
}
