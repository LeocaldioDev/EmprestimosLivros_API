using EmprestimoLivros.Domain.Entities;

namespace EmprestimoLivros.Domain.Account
{
    public interface IAuthenticate
    {
        public Task<bool> AuthenticateAsync(string email, string senha);
       public  Task<bool> UserExists(string email);
        public string GenerateToken(int id,string email);
        public Task<Usuario> GetUserByEmail(string email);
    }
}
