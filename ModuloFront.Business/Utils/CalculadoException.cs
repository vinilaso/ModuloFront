using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModuloFront.Business.Utils
{
    public class CalculadoException : Exception
    {
        private static readonly string Mensagem = "Inicialize sua calculadora primeiro!";
        public CalculadoException() : base(Mensagem)
        {
        }
    }
}
