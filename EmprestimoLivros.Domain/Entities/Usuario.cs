using EmprestimoLivros.Domain.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmprestimoLivros.Domain.Entities
{
    public class Usuario
    {
        public int id { get; private set; }
        public string nome { get; private set; }
        public string email { get; private set; }
        public byte[] passwordHash { get; private set; }
        public byte[] passwordSalt { get; private set; }


        public Usuario(int id, string nome, string email)
        {
           DomainExceptionValidation.when(id < 0, "O id não pode ser negativo!");

            this.id = id;
           ValidateDomain(nome, email);
        }
        public Usuario( string nome, string email)
        {
           ValidateDomain(nome, email);
        }

        public void AlterarSenha(byte[] passwordHash, byte[] passwordSalt)
        {
            this.passwordHash = passwordHash;
            this.passwordSalt = passwordSalt;
        }

        private void ValidateDomain(string nome, string email)
        { 
            DomainExceptionValidation.when(string.IsNullOrEmpty(nome), "O nome é obrigatorio");
            DomainExceptionValidation.when(string.IsNullOrEmpty(email), "O email é obrigatorio");
            DomainExceptionValidation.when(nome.Length > 200, "O nome não pode passar dos 100 caracteres!");
            DomainExceptionValidation.when(email.Length > 200, "O email não pode passar os 100 caracteres!");

            this.nome = nome;
            this.email = email;
        }
    }
}
