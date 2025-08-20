using AutoMapper;
using EmprestimoLivros.Application.DTOs;
using EmprestimoLivros.Application.Interfaces;
using EmprestimoLivros.Domain.Entities;
using EmprestimoLivros.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmprestimoLivros.Application.Services
{
    public class ClienteServices : ICLienteServices
    {
        private readonly IClienteRepository _clienteRepository;
        private readonly IMapper _mapper;

        public ClienteServices(IClienteRepository clienteRepository, IMapper mapper)
        {
            _clienteRepository = clienteRepository;
            _mapper = mapper;
        }
        public async Task<ClienteDTOs> Alterar(ClienteDTOs clienteDTO)
        {
           var cliente = _mapper.Map<Cliente>(clienteDTO);
            var clienteAlterado = await _clienteRepository.Alterar(cliente);
            return _mapper.Map<ClienteDTOs>(clienteAlterado);
        }

        public async Task<ClienteDTOs> Excluir(int id)
        {
            var clienteExcluir = await _clienteRepository.Excluir(id);
            return _mapper.Map<ClienteDTOs>(clienteExcluir);
        }

        public async Task<ClienteDTOs> Incluir(ClienteDTOs clienteDTO)
        {
            var cliente = _mapper.Map<Cliente>(clienteDTO);
            var clienteIncluido = await _clienteRepository.Incluir(cliente);
            return _mapper.Map<ClienteDTOs>(clienteIncluido);
        }

        public async Task<ClienteDTOs> SelecionarAsync(int id)
        {
            var cliente= await _clienteRepository.SelecionarAsync(id);
            return _mapper.Map<ClienteDTOs>(cliente);
        }

        public async Task<IEnumerable<ClienteDTOs>> SelecionarTodosAsync()
        {
            var clientes = await _clienteRepository.SelecionarTodosAsync();
            return _mapper.Map<IEnumerable<ClienteDTOs>>(clientes);
        }
    }
}
