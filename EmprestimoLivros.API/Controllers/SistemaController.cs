using EmprestimoLivros.Application.Interfaces;
using EmprestimoLivros.Application.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EmprestimoLivros.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SistemaController : Controller
    {
        private readonly IUsuarioServices _usuarioServices;
        private readonly ISistemaServices sistemaServices;
        public SistemaController(IUsuarioServices usuarioServices, ISistemaServices sistemaServices)
        {
            _usuarioServices = usuarioServices;
            this.sistemaServices = sistemaServices;
        }

        [HttpGet("VerificarPrimeiroUsuario")]
        public async Task<IActionResult> PrimeiroUsuario()
        {
            var usuario = await _usuarioServices.ExisteUsuarioCadastradoAsync();
            return Ok(new {PrimeiroUso = !usuario});
        }

        [HttpGet("Dashboard")]
        [Authorize]
        public async Task<IActionResult> Dashboard()
        {
            var qtdItensDTO = await sistemaServices.SelecionarqtdsItens();
            return Ok(qtdItensDTO);
        }




    }
}
