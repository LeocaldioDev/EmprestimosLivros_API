using EmprestimoLivros.API.Models;
using EmprestimoLivros.Application.DTOs;
using EmprestimoLivros.Application.Interfaces;
using EmprestimoLivros.Application.Services;
using EmprestimoLivros.Domain.Account;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.HttpLogging;
using Microsoft.AspNetCore.Mvc;

namespace EmprestimoLivros.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuarioController : Controller
    {
        private readonly IAuthenticate _authenticateServices;
        private readonly IUsuarioServices _usuarioServices;

        public UsuarioController(IAuthenticate authenticateServices, IUsuarioServices usuarioServices)
        {
            _authenticateServices = authenticateServices;
            _usuarioServices = usuarioServices;
        }

        [HttpPost("register")]
        
        public async Task<ActionResult<UserToken>> Incluir(UsuarioDTOs usuarioDTO)
        {
            if(usuarioDTO == null) return BadRequest("Dados invalidos");

            var emailExiste = await _authenticateServices.UserExists(usuarioDTO.email);

            if (emailExiste)
            {
                return BadRequest("este email, ja possui um cadastro");
            }
            var usuario = await _usuarioServices.Incluir(usuarioDTO);
            if(usuario == null)
            {
                return BadRequest("Ocorreu um erro ao cadastrar");
            }

            var token = _authenticateServices.GenerateToken(usuario.id, usuario.email);

            return new UserToken
            {
                Token = token,
            };
        }

        [HttpPost("login")]

        public async Task<ActionResult<UserToken>> Selecionar(LoginModel loginModel)
        {
            var existe = await _authenticateServices.UserExists(loginModel.Email);

            if (!existe)
            {
                return Unauthorized("Usuario nao existe");
            }

            var resultado = await _authenticateServices.AuthenticateAsync(loginModel.Email, loginModel.Senha);
            if (!resultado)
            {
                return Unauthorized("Usuario ou senha invalida");
            }
            var usuario = await _authenticateServices.GetUserByEmail(loginModel.Email);

            var token = _authenticateServices.GenerateToken(usuario.id, usuario.email);

            return new UserToken
            {
                Token = token,
            };
        }

    }
}
