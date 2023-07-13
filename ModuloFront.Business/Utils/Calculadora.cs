using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModuloFront.Business.Utils
{
    public class Calculadora
    {
        public List<int> ValoresAtuais { get; set; } = new List<int>();
        public string OperacaoAtual { get; set; } = "";
        public bool Calculado { get; set; } = false;

        public double Calcular()
        {
            double retorno = 0;
            {
                switch (OperacaoAtual[0])
                {
                    case '+':
                        retorno = Somar();
                        break;
                    case '-':
                        retorno = Subtrair();
                        break;
                    case '*':
                        retorno = Multiplicar();
                        break;
                    case '/':
                        retorno = Dividir();
                        break;
                    default:
                        throw new FormatException("Valor informado inválido!");
                        break;
                }
                return retorno;
            }
        }

        public double Somar()
        {
            if (Calculado)
            {
                throw new CalculadoException();
            }

            double resultado = 0;
            foreach (int valor in ValoresAtuais)
            {
                resultado += valor;
            }

            Calculado = true;
            return resultado;
        }

        public double Subtrair()
        {
            if (Calculado)
            {
                throw new CalculadoException();
            }

            double resultado = ValoresAtuais[0];
            for (int i = 1; i < ValoresAtuais.Count; i++)
            {
                resultado -= ValoresAtuais[i];
            }
            Calculado = true;
            return resultado;

        }

        public double Multiplicar()
        {
            if (Calculado)
            {
                throw new CalculadoException();
            }

            double resultado = 1;
            foreach (int valor in ValoresAtuais)
            {
                resultado *= valor;
            }
            Calculado = true;
            return resultado;
        }

        public double Dividir()
        {
            if (Calculado)
            {
                throw new CalculadoException();
            }

            double resultado = ValoresAtuais[0];
            for (int i = 1; i < ValoresAtuais.Count; i++)
            {
                resultado /= ValoresAtuais[i];
            }
            Calculado = true;
            return resultado;
        }
    }
}
