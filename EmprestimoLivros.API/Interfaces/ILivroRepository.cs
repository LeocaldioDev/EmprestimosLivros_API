using EmprestimoLivros.API.Models;

namespace EmprestimoLivros.API.Interfaces
{
    public interface ILivroRepository
    {
        void Incluir(Livro cliente);
        void Alterar(Livro cliente);
        void Excluir(int id);
        Task<Livro> SelecionarByIdAsync(int id);
        Task<IEnumerable<Livro>> SelecionarTodosAsync();
    }
}
