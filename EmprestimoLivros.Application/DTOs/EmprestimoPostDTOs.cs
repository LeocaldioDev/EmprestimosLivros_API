using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace EmprestimoLivros.Application.DTOs
{
    public class EmprestimoPostDTOs
    {
        [Required(ErrorMessage = "O Livro é obrigatorio")]
        [Range(1, int.MaxValue, ErrorMessage = "Livro não encotrado")]
        public int livroId { get; set; }
        [Required(ErrorMessage = "O cliente é obrigatorio")]
        [Range(1, int.MaxValue, ErrorMessage = "Cliente não encotrado")]
        public int clienteId { get; set; }
        [Required(ErrorMessage = "A Data de entrega é obrigatorio")]
        public DateTime dataDevolucao { get; set; }
        [JsonIgnore]
        public DateTime dataEmprestimo { get; set; }
        [JsonIgnore]
        public bool entregue { get; set; }
    }
}
