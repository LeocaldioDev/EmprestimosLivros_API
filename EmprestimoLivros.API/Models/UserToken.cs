namespace EmprestimoLivros.API.Models
{
    public class UserToken
    {
        public string Token { get; set; }
        public bool isAdmin { get; set; }
        public string email { get; set; }
    }
}
