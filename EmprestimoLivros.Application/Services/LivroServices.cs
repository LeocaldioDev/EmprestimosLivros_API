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
    public class LivroServices : ILivroServices
    {
        private readonly ILivroRepository _livroRepository;
        private readonly IMapper _mapper;
        public LivroServices(ILivroRepository livroRepository, IMapper mapper)
        {
            _livroRepository = livroRepository;
            _mapper = mapper;
        }

        public async Task<LivroDTOs> Alterar(LivroDTOs livroDTO)
        {
            var livro = _mapper.Map<Livro>(livroDTO);
            var livroAlterado = await _livroRepository.Alterar(livro);
            return _mapper.Map<LivroDTOs>(livroAlterado);
        }

        public async Task<LivroDTOs> Excluir(int id)
        {
            var livroExcluir = await _livroRepository.Excluir(id);
            return _mapper.Map<LivroDTOs>(livroExcluir);
        }

        public async Task<LivroDTOs> Incluir(LivroDTOs livroDTO)
        {
            var livro = _mapper.Map<Livro>(livroDTO);
            var livroIncluido = await _livroRepository.Incluir(livro);
            return _mapper.Map<LivroDTOs>(livroIncluido);
        }

        public async Task<LivroDTOs> SelecionarAsync(int id)
        {
            var livro = await _livroRepository.SelecionarAsync(id);
            return _mapper.Map<LivroDTOs>(livro);
        }

        public async Task<PagedList<LivroDTOs>> SelecionarTodosAsync(int PageNumber, int PageSize)
        {
            var livros = await _livroRepository.SelecionarTodosAsync(PageNumber,PageSize);
            var livrosDTOS = _mapper.Map<IEnumerable<LivroDTOs>>(livros);
            return new PagedList<LivroDTOs>(livrosDTOS, PageNumber, PageSize, livros.TotalCount);
        }
    }
}
