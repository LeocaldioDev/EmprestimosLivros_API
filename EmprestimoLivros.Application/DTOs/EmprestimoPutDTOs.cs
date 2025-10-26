using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmprestimoLivros.Application.DTOs
{
    public class EmprestimoPutDTOs
    {
        [Required(ErrorMessage ="O identificador do emprestimo é obrigatorio")]
        [Range(1, int.MaxValue, ErrorMessage = "O identificador do emprestimo é invalido")]
        public int id { get; set; }
        [Required(ErrorMessage = "Defina uma data de devolução")]
        public DateTime dataDevolucao { get; set; }
        [Required(ErrorMessage = "O estado da entrega é obigratorio")]
        public bool entregue { get; set; }
    }
}
