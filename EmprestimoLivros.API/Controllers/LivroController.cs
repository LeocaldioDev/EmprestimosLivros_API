using EmprestimoLivros.API.Extensions;
using EmprestimoLivros.API.Models;
using EmprestimoLivros.Application.DTOs;
using EmprestimoLivros.Application.Interfaces;
using EmprestimoLivros.Application.Services;
using EmprestimoLivros.Infra.IOC;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EmprestimoLivros.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
   [Authorize]
    public class LivroController : Controller
    {
        private readonly ILivroServices _livroServices;
        public LivroController(ILivroServices livroServices)
        {
            _livroServices = livroServices;
        }
        [HttpPost]

        public async Task<ActionResult> Incluir(LivroDTOs livroDTO)
        {
            var livroDTOIncluido = await _livroServices.Incluir(livroDTO);
            if (livroDTOIncluido == null)
            {
                return BadRequest("Ocorreu um erro ao incluir o livro");
            }

            return Ok("Livro incluido com sucesso!");
        }


        [HttpPut]
        public async Task<ActionResult> Alterar(LivroDTOs livroDTO)
        {
            var livroDTOAlterado = await _livroServices.Alterar(livroDTO);
            if (livroDTOAlterado == null)
            {
                return BadRequest("Ocorreu um erro ao Alterar o livro");
            }
            return Ok("Livro alterado com sucesso!");
        }


        [HttpDelete]
        public async Task<ActionResult> Excluir(int id)
        {
            var livroDTOExcluido = await _livroServices.Excluir(id);
            if (livroDTOExcluido == null)
            {
                return BadRequest("Ocorreu um erro ao excluir o livro");
            }
            return Ok("Livro excluido com sucesso!");
        }


        [HttpGet("{id}")]
        public async Task<ActionResult> selecionar(int id)
        {
            var livroDTO = await _livroServices.SelecionarAsync(id);
            if (livroDTO == null)
            {
                return BadRequest("Livro não encontrado.");
            }
            return Ok(livroDTO);
        }

        [HttpGet]
        public async Task<ActionResult> SelecionarTodos([FromQuery] PaginationParams paginationParams)
        {
            var livrosDTO = await _livroServices.SelecionarTodosAsync(paginationParams.PageNumber,paginationParams.PageSize);
            Response.AddPaginationHeader(new PaginationHeader
            (
                livrosDTO.CurrentPage,
                livrosDTO.Pagesize,
                livrosDTO.TotalCount,
                livrosDTO.TotalPages
            ));

            return Ok(livrosDTO);
        }

    }
}
