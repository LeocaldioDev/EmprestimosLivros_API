using EmprestimoLivros.Application.DTOs;
using EmprestimoLivros.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EmprestimoLivros.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClienteController: ControllerBase
    {
        private readonly ICLienteServices _clienteServices;

        public ClienteController(ICLienteServices cLienteServices)
        {
            _clienteServices = cLienteServices;
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult> Incluir( ClienteDTOs clienteDTO)
        {
            var clienteDTOIncluido = await _clienteServices.Incluir(clienteDTO);
            if (clienteDTOIncluido == null)
            {
                return BadRequest("Ocorreu um erro ao incluir o cliente");
            }
            return Ok("Cliente incluido com sucesso!");
        }


        [HttpPut]
        public async Task<ActionResult> Alterar(ClienteDTOs clienteDTO)
        {
            var clienteDTOAlterado = await _clienteServices.Alterar(clienteDTO);
            if (clienteDTOAlterado == null)
            {
                return BadRequest("Ocorreu um erro ao Alterar o cliente");
            }
            return Ok("Cliente alterado com sucesso!");
        }


        [HttpDelete]
        public async Task<ActionResult> Excluir(int id)
        {
            var clienteDTOExcluido = await _clienteServices.Excluir(id);
            if (clienteDTOExcluido == null)
            {
                return BadRequest("Ocorreu um erro ao excluir o cliente");
            }
            return Ok("Cliente excluido com sucesso!");
        }


        [HttpGet("{id}")]
        public async Task<ActionResult> selecionar(int id)
        {
            var clienteDTO = await _clienteServices.SelecionarAsync(id);
            if (clienteDTO == null)
            {
                return BadRequest("Cliente não encontrado.");
            }
            return Ok(clienteDTO);
        }

        [HttpGet]
        public async Task<ActionResult> SelecionarTodos()
        {
            var clientesDTO = await _clienteServices.SelecionarTodosAsync();
           
            return Ok(clientesDTO);
        }

    }
}
