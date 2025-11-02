using EmprestimoLivros.Domain.SystemModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmprestimoLivros.Domain.Interfaces
{
    public interface ISistemaRepository
    {
        Task<QuantidadeItens> SelecionarQtdItens();
    }
}
