using EmprestimoLivros.API.Extensions;
using EmprestimoLivros.API.Models;
using EmprestimoLivros.Application.DTOs;
using EmprestimoLivros.Application.Interfaces;
using EmprestimoLivros.Application.Services;
using EmprestimoLivros.Domain.Account;
using EmprestimoLivros.Domain.Pagination;
using EmprestimoLivros.Infra.IOC;
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

            var existeUsuariocadastrado = await _usuarioServices.ExisteUsuarioCadastradoAsync();

            if (!existeUsuariocadastrado)
            {
                usuarioDTO.isAdmin = true;
            }
            else
            {
                if (User.FindFirst("id") ==null)
                {
                    return Unauthorized("Acesso negado");
                }

                var usuarioId = User.GetId();
                var usuarioLogado = await _usuarioServices.SelecionarAsync(usuarioId);
                if (usuarioLogado == null || !usuarioLogado.isAdmin)
                {
                    return Unauthorized("Voce não tem permissão para incluir novos usuarios");
                }
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

        [HttpGet("Usuarios")]
        [Authorize]
        public async Task<ActionResult> SelecionarTodosAsync([FromQuery] PaginationParams paginationParams)
        {
            if(User.FindFirst("id") == null)
            {
               return Unauthorized("Acesso negado");
            }

            var usuarioId = User.GetId();
            var usuarioLogado = await _usuarioServices.SelecionarAsync(usuarioId);
            if (usuarioLogado == null || !usuarioLogado.isAdmin)
            {
                return Unauthorized("Voce não tem permissão para acessar a lista de usuarios");
            }

            var usuarios = await _usuarioServices.SelecionarTodosAsync(paginationParams.PageNumber,paginationParams.PageSize);
            Response.AddPaginationHeader(new PaginationHeader(
                usuarios.CurrentPage,
                usuarios.Pagesize,
                usuarios.TotalCount,
                usuarios.TotalPages
                ));

            return Ok(usuarios);
        }

        [HttpGet("Usuario{id}")]
        [Authorize]
        public async Task<ActionResult<UsuarioDTOs>> SelecionarAsync(int id)
        {
            if (User.FindFirst("id") == null)
            {
                return Unauthorized("Acesso negado");
            }

            var usuarioId = User.GetId();
            var usuarioLogado = await _usuarioServices.SelecionarAsync(usuarioId);

            if(id ==0)
                id = usuarioId;



            if (!usuarioLogado.isAdmin && usuarioLogado.id != id)
            {
                return Unauthorized("Voce não tem permissão para acessar este usuario");
            }

            var usuario = await _usuarioServices.SelecionarAsync(id);
            if (usuario == null)
            {
                return NotFound("Usuario nao encontrado");
            }


                return Ok(usuario);
            
            
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
                isAdmin = usuario.isAdmin,
                email = usuario.email
            };
        }

        [HttpDelete("{id}")]
        [Authorize]
        public async Task<ActionResult> Excluir(int id)
        {
            if (User.FindFirst("id") == null)
            {
                return Unauthorized("Acesso negado");
            }

            var usuarioId = User.GetId();
            var usuarioLogado = await _usuarioServices.SelecionarAsync(usuarioId);
            if (usuarioLogado == null || !usuarioLogado.isAdmin)
            {
                return Unauthorized("Voce não tem permissão para excluir usuarios");
            }

            var usuarioExcluido = await _usuarioServices.Excluir(id);
            if (usuarioExcluido == null)
            {
                return BadRequest("Ocorreu um erro ao excluir o usuario");
            }
            return Ok("Usuario excluido com sucesso!");
        }


        [HttpPut("Alterar")]
        [Authorize]
        public async Task<ActionResult> Alterar(UsuarioPutDTO usuarioPutDTO)
        {
            if (User.FindFirst("id") == null)
            {
                return Unauthorized("Acesso negado");
            }

            var usuarioId = User.GetId();
            var usuarioLogado = await _usuarioServices.SelecionarAsync(usuarioId);

            if (!usuarioLogado.isAdmin && usuarioLogado.id != usuarioPutDTO.id)
            {
                return Unauthorized("Voce não tem permissão para alterar este usuario");
            } 
            if (!usuarioLogado.isAdmin && usuarioPutDTO.id ==usuarioId && usuarioPutDTO.isAdmin)
            {
                return Unauthorized("Voce não tem permissão para se definir como administrador");
            }

            var usuarioAlterado = await _usuarioServices.Alterar(usuarioPutDTO);
            if (usuarioAlterado == null)
            {
                return BadRequest("Ocorreu um erro ao Alterar o usuario");
            }
            return Ok(new { message ="Usuario alterado com sucesso!"});
        }
}
}
