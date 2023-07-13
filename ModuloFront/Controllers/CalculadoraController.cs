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
            double retorno = 0;
            {
                try {
                    switch (_calculadora.OperacaoAtual[0])
                    {
                        case '+':
                            retorno = _calculadora.Somar();
                            break;

                        case '-':
                            retorno = _calculadora.Subtrair();
                            break;
                        case '*':
                            retorno = _calculadora.Multiplicar();
                            break;
                        case '/':
                            retorno = _calculadora.Dividir();
                            break;
                        default:
                            return Ok("Valores inválidos!");
                            break;
                    }
                }
                catch (CalculadoException ex)
                {
                    return NotFound(ex.Message);
                }
                return Ok(retorno);
            }
        }
        
    }
}
