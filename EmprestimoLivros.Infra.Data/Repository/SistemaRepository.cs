using EmprestimoLivros.Domain.Interfaces;
using EmprestimoLivros.Domain.SystemModels;
using EmprestimoLivros.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmprestimoLivros.Infra.Data.Repository
{
    public class SistemaRepository : ISistemaRepository
    {
        private readonly ApplicationDBContext _context;
        public SistemaRepository(ApplicationDBContext context)
        {
            _context = context;
        }
        public async Task<QuantidadeItens> SelecionarQtdItens()
        {
            var quantidadeItens = new QuantidadeItens();
            quantidadeItens.QtdLivro = await _context.Livro.CountAsync();
            quantidadeItens.QtdCliente = await _context.Cliente.CountAsync();
            quantidadeItens.QtdEmprestimo = await _context.Emprestimo.CountAsync();

            return quantidadeItens;

        }
    }
}
