using EmprestimoLivros.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmprestimoLivros.Application.DTOs
{
    public class EmprestimoDTOs
    {
        public int id { get;  set; }
        public int livroId { get;  set; }
        public int clienteId { get;  set; }
        public DateTime dataEmprestimo { get;  set; }
        public DateTime dataDevolucao { get;  set; }
        public bool entregue { get;  set; }
        public ClienteDTOs ClienteDTO { get; set; }
        public LivroDTOs LivroDTO { get; set; }
    }
}
