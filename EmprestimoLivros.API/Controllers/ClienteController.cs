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
            var clientes = await _clienteRepository.SelecionarTodosAsync();

            var clientesDTO = _mapper.Map<IEnumerable<ClienteDTO>>(clientes);
            return Ok( clientesDTO);

        }


        [HttpPost]
        public async Task<ActionResult> CadastrarCliente(ClienteDTO cliente)
        {
            var clienteDTO = _mapper.Map<Cliente>(cliente);
            _clienteRepository.Incluir(clienteDTO);
            if (await _clienteRepository.SaveAllAsync()) return Ok("Cliente cadastrado com sucsso!");
            else return BadRequest("Ocorreu algum erro ao salvar CLiente!");
        }
        [HttpPut]
        public async Task<ActionResult> AlterarCLiente(ClienteDTO cliente)
        {
            if(cliente.Id == 0)
            {
                return BadRequest("Cliente não encontrado, informe o ID");
                
            }
            var clienteInexistente = await _clienteRepository.SelecionarByIdAsync(cliente.Id);
            if(clienteInexistente == null)
            {
                return BadRequest("Cliente não encontrado");
            }

            var clienteDTO = _mapper.Map<Cliente>(cliente);
            _clienteRepository.Alterar(clienteDTO);
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
