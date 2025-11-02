using AutoMapper;
using EmprestimoLivros.Application.DTOs;
using EmprestimoLivros.Application.Interfaces;
using EmprestimoLivros.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmprestimoLivros.Application.Services
{
    public class SistemaServices : ISistemaServices
    {
        private readonly ISistemaRepository _sistemaRepository;
        private readonly IMapper _mapper;
        public SistemaServices(ISistemaRepository sistemaRepository, IMapper mapper)
        {
            _sistemaRepository = sistemaRepository;
            _mapper = mapper;
        }
        public async Task<QuantidadeItensDTO> SelecionarqtdsItens()
        {
            var qtdItens =await  _sistemaRepository.SelecionarQtdItens();

            var qtdItensDTO = _mapper.Map<QuantidadeItensDTO>(qtdItens);

            return qtdItensDTO;

        }
    }
}
