using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace EmprestimoLivros.Application.DTOs
{
    public class ClienteDTOs
    {
        [IgnoreDataMember]
        public int id { get; set; }
        [Required]
       [StringLength(25, ErrorMessage = "O BI precisa de ter 25 caracteres!")]
        public string bi { get; set; }
        [Required]
       [StringLength(100, ErrorMessage = "O nome precisa de no maximo 100 caracteres!")]
        public string nome { get; set; }
        [Required]
        [StringLength(100, ErrorMessage = "O endereço precisa de no maximo 100 caracteres!")]
        public string endereco { get; set; }
        [Required]
        [StringLength(100, ErrorMessage = "A cidade precisa de no maximo 100 caracteres!")]
        public string cidade { get; set; }
        [Required]
        [StringLength(50, ErrorMessage = "O bairro precisa de no maximo 50 caracteres!")]
        public string bairro { get; set; }
        [Required]
        [StringLength(50, ErrorMessage = "O número precisa de no maximo 50 caracteres!")]
        public string numero { get; set; }
        [Required]
        [StringLength(50, ErrorMessage = "O telefone precisa de no maximo 50 caracteres!")]
        public string telefone { get; set; }
        [Required]
        [StringLength(50, ErrorMessage = "O telefone fixo precisa de no maximo 50 caracteres!")]
        public string telefoneFixo { get; set; }
    }
}
