using EmprestimoLivros.Domain.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmprestimoLivros.Domain.Entities
{
    public class Livro
    {
        public int id { get; private set; }
        public string nome { get; private set; }
        public string autor { get; private set; }
        public string editora { get; private set; }
        public DateTime anoPublicacao {  get; private set; }
        public string edicao { get; private set; }

        public Livro(int id,string nome, string autor,string editora,DateTime anoPublicacao,string edicao)
        {
            DomainExceptionValidation.when(id < 0, "O id do livro precisa ser maior que zero!");
            this.id = id;
            ValidateLivro(nome, autor, editora, anoPublicacao, edicao);
        }

        public Livro(string nome, string autor, string editora, DateTime anoPublicacao, string edicao)
        {
            ValidateLivro(nome, autor, editora, anoPublicacao, edicao);
        }

        public void Update(string nome, string autor, string editora, DateTime anoPublicacao, string edicao)
        {
            ValidateLivro(nome, autor, editora, anoPublicacao, edicao);
        }

        public void ValidateLivro(string nome, string autor, string editora, DateTime anoPublicacao, string edicao)
        {
            DomainExceptionValidation.when(nome.Length > 100, "O nome do livro precisa de no maximo 100 caracteres!");
            DomainExceptionValidation.when(autor.Length > 100, "O nome do autor precisa de no maximo 100 caracteres!");
            DomainExceptionValidation.when(editora.Length > 50, "O nome da editora precisa de no maximo 50 caracteres!");
            DomainExceptionValidation.when(edicao.Length > 50, "A edicao do livro precisa de no maximo 50 caracteres!");
            DomainExceptionValidation.when(anoPublicacao > DateTime.Now, "O ano de publicacao nao pode ser maior que o ano atual!");


            this.nome = nome;
            this.autor = autor;
            this.editora = editora;
            this.anoPublicacao = anoPublicacao;
            this.edicao = edicao;
        }

    }
}
