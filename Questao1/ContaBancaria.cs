using System;
using System.Globalization;
using System.Text;

namespace Questao1
{
    public class ContaBancaria {
        
        private const double TAXA = 3.5;

        public int Numero { get; set; }
        public string Titular { get; set; }
        public double Saldo { get; set; }

        public ContaBancaria(int numero, string titular, double depositoInicial = 0)
        {
            Numero = numero;
            Titular = titular;
            Saldo = depositoInicial;            
        }

        public ContaBancaria(int numero, string titular) 
        {
            Numero = numero;
            Titular = titular;
        }

        public void Deposito(double quantia)
        {
            Saldo = Saldo + quantia;
        }
        
        public void Saque(double quantia)
        {
            Saldo = Saldo - quantia - TAXA;            
        }

        public string ImprimirSaldo(int numero, string titular, double saldo)
        {
            StringBuilder imprimir = new StringBuilder();

            imprimir.Append("Conta ");
            imprimir.Append(numero);
            imprimir.Append(", Titular: ");
            imprimir.Append(titular);
            imprimir.Append(", Saldo: $");
            imprimir.Append(saldo);
            
            return imprimir.ToString();
        }
    }
}
