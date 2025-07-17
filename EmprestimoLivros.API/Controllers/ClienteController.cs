using AutoMapper;
using EmprestimoLivros.API.DTOs;
using EmprestimoLivros.API.Interfaces;
using EmprestimoLivros.API.Models;
using EmprestimoLivros.API.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace EmprestimoLivros.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClienteController : Controller
    {
        private readonly IClienteRepository _clienteRepository;
        private readonly IMapper _mapper;
        public ClienteController(IClienteRepository clienteRepository, IMapper mapper)
        {
            _mapper = mapper;
            _clienteRepository = clienteRepository;
        }   

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cliente>>> SelecionarTodosClientes()
        {
            return Ok(await _clienteRepository.SelecionarTodosAsync());

        }


        [HttpPost]
        public async Task<ActionResult> CadastrarCliente(Cliente cliente)
        {

            _clienteRepository.Incluir(cliente);
            if (await _clienteRepository.SaveAllAsync()) return Ok("Cliente cadastrado com sucsso!");
            else return BadRequest("Ocorreu algum erro ao salvar CLiente!");
        }
        [HttpPut]
        public async Task<ActionResult> AlterarCLiente(Cliente cliente)
        {
            _clienteRepository.Alterar(cliente);
            if (await _clienteRepository.SaveAllAsync()) return Ok("Cliente alterado com sucesso!");
            else return BadRequest("Ocorreu algum erro ao alterar Cliente!");
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> ExcluirCLiente(int id)
        {
           var cliente = await _clienteRepository.SelecionarByIdAsync(id);

            if (cliente == null) return NotFound("Cliente não encontrado!");

            _clienteRepository.Excluir(cliente);

            if (await _clienteRepository.SaveAllAsync())
            {
                return Ok("Cliente eclido com sucesso!");
            }
            return BadRequest("Falha ao excluir cliente");
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> SelecionarPorId(int id)
        {
            var cliente = await _clienteRepository.SelecionarByIdAsync(id);
            if (cliente == null)
            {
                return NotFound("Cliente não encontrado!");
            }
            
            var clienteDTO = _mapper.Map<ClienteDTO>(cliente);
            return Ok(clienteDTO);
            
        }
    }
}
