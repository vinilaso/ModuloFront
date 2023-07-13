using Microsoft.AspNetCore.Mvc;
using ModuloFront.Business.Utils;
using ModuloFront.Models;
using System.Linq.Expressions;

namespace ModuloFront.Controllers
{
    [ApiController]
    [Route("api/Calculadora")]
    public class CalculadoraController : Controller
    {
        private static Calculadora _calculadora = new Calculadora();

        // Inicializa a calculadora
        [HttpPost("Inicializar")]
        public IActionResult Inicializar([FromBody]CalculadoraModel calculadora)
        {
            _calculadora = new Calculadora
            {
                ValoresAtuais = calculadora.ValoresIniciais,
                OperacaoAtual = calculadora.OperacaoInicial
            };
            return Ok("Calculadora inicializada.");
        }

        // Realiza a operação inicializada
        [HttpGet("Calcular")]
        public IActionResult Calcular()
        {
            try
            {
                return Ok(_calculadora.Calcular());
            } 
            catch(Exception ex) when (ex is CalculadoException || ex is FormatException)
            {
                return NotFound(ex.Message);
            }
            
        }
        
    }
}
