using EmprestimoLivros.API.Models;

namespace EmprestimoLivros.API.Interfaces
{
    public interface IClienteRepository
    {
       public void Incluir(Cliente cliente);
      public  void Alterar(Cliente cliente);
       public void Excluir(Cliente cliente);
      public Task<Cliente> SelecionarByIdAsync(int id);
      public  Task<IEnumerable<Cliente>> SelecionarTodosAsync();
     public   Task<bool> SaveAllAsync();
    }
}
