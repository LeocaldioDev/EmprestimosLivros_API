using AutoMapper;
using EmprestimoLivros.Application.DTOs;
using EmprestimoLivros.Application.Interfaces;
using EmprestimoLivros.Domain.Entities;
using EmprestimoLivros.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace EmprestimoLivros.Application.Services
{
    public class UsuarioServices : IUsuarioServices
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IMapper _mapper;

        public UsuarioServices(IUsuarioRepository usuarioRepository, IMapper mapper)
        {
            _usuarioRepository = usuarioRepository;
            _mapper = mapper;
        }
        public async Task<UsuarioDTOs> Alterar(UsuarioDTOs usuarioDTO)
        {
            var usuario = _mapper.Map<Usuario>(usuarioDTO);
            var usuarioAlterado = await _usuarioRepository.Alterar(usuario);
            return _mapper.Map<UsuarioDTOs>(usuarioAlterado);
        }

        public async Task<UsuarioDTOs> Excluir(int id)
        {
            var usuario = await _usuarioRepository.Excluir(id);
            return _mapper.Map<UsuarioDTOs>(usuario);
        }

        public async Task<UsuarioDTOs> Incluir(UsuarioDTOs usuarioDTO)
        {
            var usuario = _mapper.Map<Usuario>(usuarioDTO);

            if(usuarioDTO.password != null)
            {
                using var hmac = new HMACSHA512();
                byte[] passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(usuarioDTO.password));
                byte[] passwordSalt = hmac.Key;

                usuario.AlterarSenha(passwordHash, passwordSalt);
            }


            var usuarioincluido = await _usuarioRepository.Incluir(usuario);
            return _mapper.Map<UsuarioDTOs>(usuarioincluido);
        }

        public async Task<UsuarioDTOs> SelecionarAsync(int id)
        {
            var usuario = await _usuarioRepository.SelecionarAsync(id);
            return _mapper.Map<UsuarioDTOs>(usuario);
        }

        public async Task<IEnumerable<UsuarioDTOs>> SelecionarTodosAsync()
        {
            var usuarios  = await _usuarioRepository.SelecionarTodosAsync();
            return _mapper.Map<IEnumerable<UsuarioDTOs>>(usuarios);
        }

        public async Task<bool> ExisteUsuarioCadastradoAsync()
        {
            return await _usuarioRepository.ExisteUsuarioCadastradoAsync();
        }
    }
}
