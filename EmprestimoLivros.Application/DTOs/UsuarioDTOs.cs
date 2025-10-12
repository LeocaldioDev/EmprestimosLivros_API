using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmprestimoLivros.Application.DTOs
{
    public class UsuarioDTOs
    {
         public int id { get;  set; }
        [Required(ErrorMessage = "O nome é obrigatório")]
        [MaxLength(200, ErrorMessage = "O nome não pode passar dos 100 caracteres")]
        public string nome { get;  set; }
        [Required(ErrorMessage = "O email é obrigatório")]
        [MaxLength(200, ErrorMessage = "O email não pode passar dos 100 caracteres")]
        public string email { get;  set; }
        [Required(ErrorMessage = "A senha é obrigatória")]
        [MaxLength(200, ErrorMessage = "A senha deve ter no máximo 100 caracteres")]
        [NotMapped]
        public string password { get;  set; }



    }
}
