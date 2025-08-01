using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmprestimoLivros.API.DTOs
{
    public class ClienteDTO
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(25)]
        [MinLength(14,ErrorMessage = "O BI deve ter no mínimo 14 caracteres")]
        public string Bi { get; set; }

        [Required]
        [StringLength(100)]
        public string Nome { get; set; }

        [Required]
        [StringLength(50)]
        public string Endereco { get; set; }

        [Required]
        [StringLength(50)]
        public string Cidade { get; set; }

        [Required]
        [StringLength(50)]
        public string Bairro { get; set; }

        [Required]
        [StringLength(50)]
        public string Numero { get; set; }


        [StringLength(50)]
        public string Telefone { get; set; }


        [StringLength(50)]
        public string TelefoneFixo { get; set; }

    }
}
