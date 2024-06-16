using Dapper;
using Microsoft.VisualStudio.TestPlatform.Common.Telemetry;
using Questao5.Application.Commands.Requests;

namespace Questao5.Infrastructure.Database.Repository
{
    public class SaldoContaRepository : SqLiteBaseRepository
    {

        public async Task<double> RetornaSaldoConta(SaldoContaCommand command)
        {
            using (var cnn = SimpleDbConnection())
            {
                cnn.Open();

                var queryCreditos = "Select Sum(valor) as valor from movimento where idcontacorrente = " +
                    command.IdContaCorrente + " and tipomovimento = 'C'";

                var resultadoCreditos = cnn.Query(queryCreditos);

                var totalCreditos = 0;

                foreach (var creditos in resultadoCreditos)
                {
                    totalCreditos = totalCreditos + creditos.valor;
                }

                var queryDebitos = "Select Sum(valor) as valor from movimento where idcontacorrente = " +
                        command.IdContaCorrente + " and tipomovimento = 'D'";

                var resultadoDebitos = cnn.Query(queryDebitos);

                var totalDebitos = 0;

                foreach (var debitos in resultadoDebitos)
                {
                    totalDebitos = totalCreditos + debitos.valor;
                }

                /* calculo do saldo */
                var saldo = totalCreditos - totalDebitos;

                cnn.Close();

                return saldo;
            }
        }

        public async Task<string> BuscaTitular(string idContaCorrente)
        {
            var query = "select nome from contacorrente where " +
                      "idcontacorrente = " + idContaCorrente;

            var nome = string.Empty;

            using (var cnn = SimpleDbConnection())
            {
                cnn.Open();

                var resultado = cnn.Query(query);                

                foreach (var item in resultado)
                {
                    nome = item.nome;
                }
            }

            return nome;
        }
    }
}
