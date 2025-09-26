using EmprestimoLivros.Domain.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace EmprestimoLivros.Domain.Entities
{
    public class Cliente
    {
       public int id { get; private set; }
       public string  bi { get; private set; }
       public string nome { get; private set; }
       public string endereco { get; private set; }
       public string cidade { get; private set; }
       public string bairro { get; private set; }
       public string numero { get; private set; }
       public string telefone { get; private set; } 
       public string telefoneFixo { get; private set; }
        public ICollection<LivroCLienteEmprestimo> Emprestimos { get; set; }

        public Cliente(int id, string bi, string nome, string endereco, string cidade,
            string bairro, string numero, string telefone, string telefoneFixo)
        {
            DomainExceptionValidation.when(id < 0, "O id do cliente precisa ser maior que zero!");
            this.id = id;
            ValidateDomain(bi, nome, endereco, cidade, bairro, numero, telefone, telefoneFixo);
        }

        public Cliente(string bi, string nome, string endereco, string cidade,
            string bairro, string numero, string telefone, string telefoneFixo)
        {
            ValidateDomain(bi, nome, endereco, cidade, bairro, numero, telefone, telefoneFixo);
        }
        public void Update(string bi, string nome, string endereco, string cidade,
            string bairro, string numero, string telefone, string telefoneFixo)
        {
            ValidateDomain(bi, nome, endereco, cidade, bairro, numero, telefone, telefoneFixo);

        }

        public void ValidateDomain(string bi, string nome, string endereco, string cidade,
            string bairro, string numero, string telefone, string telefoneFixo)
        {

           DomainExceptionValidation.when(bi.Length < 5 || bi.Length > 25, "O BI precisa ter entre 5 e 25 caracteres!");
           DomainExceptionValidation.when( nome.Length < 5 || nome.Length > 100, "O nome precisa de no maximo 100 caracteres!");
           DomainExceptionValidation.when(endereco.Length < 5 || endereco.Length > 100, "O endere;o precisa de no maximo 50 caracteres!");
           DomainExceptionValidation.when(cidade.Length < 5 || cidade.Length > 100, "A Cidade precisa de no maximo 50 caracteres!");
           DomainExceptionValidation.when(bairro.Length < 5 || bairro.Length > 50, "O Bairro precisa de no maximo 50 caracteres!");
           DomainExceptionValidation.when(numero.Length < 5 || numero.Length > 50, "O Numero precisa de no maximo 50 caracteres!");
           DomainExceptionValidation.when(telefone.Length < 5 || telefone.Length > 50, "O Telefone precisa de no maximo 50 caracteres!");
           DomainExceptionValidation.when(telefoneFixo.Length < 5 || telefoneFixo.Length > 50, "O Telefone Fixo precisa de no maximo 50 caracteres!");
            

            this.bi = bi;
            this.nome = nome;
            this.endereco = endereco;
            this.cidade = cidade;
            this.bairro = bairro;
            this.numero = numero;
            this.telefone = telefone;
            this.telefoneFixo = telefoneFixo;
        }
    }
}
