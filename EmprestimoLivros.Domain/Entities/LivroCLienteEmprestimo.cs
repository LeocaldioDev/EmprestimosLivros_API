using EmprestimoLivros.Domain.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmprestimoLivros.Domain.Entities
{
    public class LivroCLienteEmprestimo
    {
        public int id { get; private set; }
        public int livroId { get; private set; }
        public int clienteId { get; private set; }
        public DateTime dataEmprestimo { get; private set; }
        public DateTime dataDevolucao { get; private set; }
        public bool entregue { get; private set; }
        public Cliente Cliente { get; set; }
        public Livro Livro { get; set; }


        public LivroCLienteEmprestimo(int id, int livroId, int clienteId, DateTime dataEmprestimo, DateTime dataDevolucao, bool entregue)
        {
            DomainExceptionValidation.when(id < 0, "O Id não pode ser um valor negativo");
            this.id = id;
            ValidateLivroClienteEmprestimo(livroId, clienteId, dataEmprestimo, dataDevolucao, entregue);
        }

        public void Update(int livroId, int clienteId, DateTime dataEmprestimo, DateTime dataDevolucao, bool entregue)
        {
            ValidateLivroClienteEmprestimo(livroId, clienteId, dataEmprestimo, dataDevolucao, entregue);
        }

        public void ValidateLivroClienteEmprestimo(int livroId, int clienteId, DateTime dataEmprestimo, DateTime dataDevolucao, bool entregue)
        {
            DomainExceptionValidation.when(livroId < 0, "O ID do livro deve ser maior que zero!");
            DomainExceptionValidation.when(clienteId < 0, "O ID do cliente deve ser maior que zero!");
            DomainExceptionValidation.when(dataEmprestimo > DateTime.Now, "A data de emprestimo nao pode ser maior que a data atual!");
            DomainExceptionValidation.when(dataDevolucao < dataEmprestimo, "A data de devolucao nao pode ser menor que a data de emprestimo!");


            this.livroId = livroId;
            this.clienteId = clienteId;
            this.dataEmprestimo = dataEmprestimo;
            this.dataDevolucao = dataDevolucao;
            this.entregue = entregue;



        }
    }
}
