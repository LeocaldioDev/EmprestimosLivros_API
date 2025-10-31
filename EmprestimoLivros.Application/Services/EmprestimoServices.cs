using AutoMapper;
using EmprestimoLivros.Application.DTOs;
using EmprestimoLivros.Application.Interfaces;
using EmprestimoLivros.Domain.Entities;
using EmprestimoLivros.Domain.Interfaces;
using EmprestimoLivros.Domain.Pagination;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmprestimoLivros.Application.Services
{
    public class EmprestimoServices : IEmprestimoServices
    {
        private readonly IEmprestimoRepository _emprestimoRepository;
        private readonly IMapper _mapper;

        public EmprestimoServices(IEmprestimoRepository emprestimoRepository, IMapper mapper)
        {
            _emprestimoRepository = emprestimoRepository;
            _mapper = mapper;
        }
        public async Task<EmprestimoDTOs> Alterar(EmprestimoDTOs emprestimoDTO)
        {
            var emprestimo = _mapper.Map<LivroCLienteEmprestimo>(emprestimoDTO);
            var emprestimoAlterado = await _emprestimoRepository.Alterar(emprestimo);
            return _mapper.Map<EmprestimoDTOs>(emprestimoAlterado);
        }

        public async Task<EmprestimoDTOs> Excluir(int id)
        {
            var emprestimoExcluir = await _emprestimoRepository.Excluir(id);
            return _mapper.Map<EmprestimoDTOs>(emprestimoExcluir);
        }

        public async Task<EmprestimoDTOs> Incluir(EmprestimoPostDTOs emprestimoPostDTO)
        {
            var emprestimo = _mapper.Map<LivroCLienteEmprestimo>(emprestimoPostDTO);
            var emprestimoIncluido = await _emprestimoRepository.Incluir(emprestimo);
            return _mapper.Map<EmprestimoDTOs>(emprestimoIncluido);
        }

        public async Task<EmprestimoDTOs> SelecionarAsync(int id)
        {
            var emprestimo = await _emprestimoRepository.SelecionarAsync(id);
            return _mapper.Map<EmprestimoDTOs>(emprestimo);
        }

        public async Task<PagedList<EmprestimoDTOs>> SelecionarTodosAsync(int pageNumber, int pageSize)
        {
            var clientes = await _emprestimoRepository.SelecionarTodosAsync(pageNumber, pageSize);
            var emprestimosDTO =_mapper.Map<IEnumerable<EmprestimoDTOs>>(clientes);
            return new PagedList<EmprestimoDTOs>(emprestimosDTO, pageNumber, pageSize, clientes.TotalCount);
        }

        public async Task<bool> VerificarDisponiblidadeAsync(int idLivro)
        {
           return await _emprestimoRepository.VerificarDisponiblidadeAsync(idLivro);


        }
    }
}
