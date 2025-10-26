using EmprestimoLivros.Application.DTOs;
using EmprestimoLivros.Application.Interfaces;
using EmprestimoLivros.Infra.IOC;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EmprestimoLivros.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class EmprestimoController : Controller
    {
        private readonly IEmprestimoServices _emprestimoServices;
        public EmprestimoController(IEmprestimoServices emprestimoServices)
        {
            _emprestimoServices = emprestimoServices;
        }

        [HttpPost]

        public async Task<ActionResult> Incluir(EmprestimoPostDTOs emprestimoPostDTO)
        {

            var disponivel = await _emprestimoServices.VerificarDisponiblidadeAsync(emprestimoPostDTO.livroId);
            if (!disponivel)
                return BadRequest("Livro não está disponivel para emprestimo");

            emprestimoPostDTO.dataEmprestimo = DateTime.Now;
            emprestimoPostDTO.entregue = false;
            var emprestimoDTOIncluido = await _emprestimoServices.Incluir(emprestimoPostDTO);
            if (emprestimoDTOIncluido == null)
            {
                return BadRequest("Ocorreu um erro ao incluir o emprestimo");
            }

            return Ok("Emprestimo incluido com sucesso!");
        }


        [HttpPut]
        public async Task<ActionResult> Alterar(EmprestimoPutDTOs emprestimoPutDTO)
        {

            var emprestimoDTO = await _emprestimoServices.SelecionarAsync(emprestimoPutDTO.id);
            if (emprestimoDTO == null)
            {
                return BadRequest("Emprestimo não encontrado.");
            }
             emprestimoDTO.dataDevolucao = emprestimoPutDTO.dataDevolucao;
            emprestimoDTO.entregue = emprestimoPutDTO.entregue;
             

            var emprestimoDTOAlterado = await _emprestimoServices.Alterar(emprestimoDTO);
            if (emprestimoDTOAlterado == null)
            {
                return BadRequest("Ocorreu um erro ao Alterar o emprestimo");
            }
            return Ok("Emprestimo alterado com sucesso!");
        }


        [HttpDelete]
        public async Task<ActionResult> Excluir(int id)
        {
            var emprestimoDTOExcluido = await _emprestimoServices.Excluir(id);
            if (emprestimoDTOExcluido == null)
            {
                return BadRequest("Ocorreu um erro ao excluir o emprestimo");
            }
            return Ok("Emprestimo excluido com sucesso!");
        }


        [HttpGet("{id}")]
        public async Task<ActionResult> selecionar(int id)
        {
            var emprestimoDTO = await _emprestimoServices.SelecionarAsync(id);
            if (emprestimoDTO == null)
            {
                return BadRequest("Emprestimo não encontrado.");
            }
            return Ok(emprestimoDTO);
        }

        [HttpGet]
        public async Task<ActionResult> SelecionarTodos()
        {
            var emprestimosDTO = await _emprestimoServices.SelecionarTodosAsync();

            return Ok(emprestimosDTO);
        }

    }
}
