using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmprestimoLivros.Application.DTOs
{
    public class UsuarioPutDTO
    {
        [Required(ErrorMessage = "O Id é obrigatório")]
        public int id { get; set; }
        [Required(ErrorMessage = "O nome é obrigatório")]
        [MaxLength(250, ErrorMessage = "O nome não pode ter mais de 250 caracteres")]
        public string nome { get; set; }
        [Required(ErrorMessage = "O E-mail é obrigatório")]
        [MaxLength(250, ErrorMessage = "O E-mail não pode ter mais de 200 caracteres")]
        public string email { get; set; }
        [MaxLength(100, ErrorMessage = "A senha deve ter, no máximo, 100 caracteres.")]
        [MinLength(8, ErrorMessage = "A senha deve ter, no mínimo, 8 caracteres.")]
        [NotMapped]
        public string password { get; set; }
        //[JsonIgnore]
        public bool isAdmin { get; set; }
        public bool Ativo { get; set; } = true;
    }
}
