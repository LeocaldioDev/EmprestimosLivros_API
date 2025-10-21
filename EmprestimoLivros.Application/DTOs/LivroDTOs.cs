using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmprestimoLivros.Application.DTOs
{
    public class LivroDTOs
    {
        public int id { get;  set; }
        [MaxLength(50,ErrorMessage = "O nome do livro deve ter no maximo 50 caracteres")]
        [Required(ErrorMessage ="O campo Nome é obrigatorio")]
        public string nome { get;  set; }
        [MaxLength(200, ErrorMessage = "O Autor do livro deve ter no maximo 200 caracteres")]
        [Required(ErrorMessage = "O campo Autor é obrigatorio")]
        public string autor { get;  set; }
        [MaxLength(50, ErrorMessage = "A Editora deve ter no maximo 50 caracteres")]
        [Required(ErrorMessage = "O campo Editora é obrigatorio")]
        public string editora { get;  set; }
        [Required(ErrorMessage = "O campo Anode publicação é obrigatorio")]
        public DateTime anoPublicacao { get;  set; }

        [MaxLength(50, ErrorMessage = "A edição deve ter no maximo 50 caracteres")]
        [Required(ErrorMessage = "O campo edição é obrigatorio")]
        public string edicao { get;  set; }
    }
}
