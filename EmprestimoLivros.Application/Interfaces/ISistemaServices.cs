using EmprestimoLivros.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmprestimoLivros.Application.Interfaces
{
    public interface ISistemaServices
    {
        Task<QuantidadeItensDTO> SelecionarqtdsItens();
    }
}
