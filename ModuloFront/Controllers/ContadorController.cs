using Microsoft.AspNetCore.Mvc;
using ModuloFront.Business.Utils;
using ModuloFront.Models;

namespace ModuloFront.Controllers
{
    [ApiController]
    [Route("api/Contador")]
    public class ContadorController : Controller
    {
        private static Contador _contador = new Contador();

        [HttpGet("AddValueGet")]
        public IActionResult AddValueGet(int value)
        {
            _contador.ContagemAtual += value;
            return Ok(_contador.ContagemAtual);
        }

        [HttpPost("Inicialize")]
        public IActionResult Inicialize([FromBody]ContadorModel contador)
        {
            _contador = new Contador();
            _contador.ContagemAtual = contador.ValorInicial;
            return Ok("O contador foi inicializado com sucesso!");
        }
    }
}
