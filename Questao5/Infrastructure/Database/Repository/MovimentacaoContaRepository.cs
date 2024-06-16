using Dapper;
using NSubstitute.Core;
using Questao5.Application.Commands.Requests;

namespace Questao5.Infrastructure.Database.Repository
{
    public class MovimentacaoContaRepository: SqLiteBaseRepository
    {
        public async Task GravaMovimento(MovimentacaoContaCommand conta)
        {
            using (var cnn = SimpleDbConnection())
            {
                cnn.Open();
                
                var query = "insert into movimento(idmovimento, idcontacorrente, datamovimento" +
                    "tipomovimento, valor Values(" + conta.IdMovimento + "," + conta.IdContaCorrente +
                    "," + Convert.ToString(DateTime.Now) + "," + conta.TipoMovimento + "," +
                    conta.Valor;

                cnn.Query(query);

                cnn.Close();
            }
        }

        public async Task<bool> ValidaConta(string idContaCorrente)
        {
            using (var cnn = SimpleDbConnection())
            {
                cnn.Open();

                var query = await RetornaQueryContas(idContaCorrente);

                var resultado = cnn.Query(query);

                if (resultado.Count() > 0) 
                { 
                    return true;
                }

                cnn.Close();
            }

            return false;
        }

        public async Task<bool> ValidaContaAtiva(string idContaCorrente)
        {
            using (var cnn = SimpleDbConnection())
            {
                cnn.Open();

                var query = await RetornaQueryContas(idContaCorrente, true);

                var resultado = cnn.Query(query);

                if (resultado.Count() > 0)
                {
                    return true;
                }

                cnn.Close();
            }

            return false;
        }

        private async Task<string> RetornaQueryContas(string idContaCorrente, bool ativo = false)
        {
            var query = "select idcontacorrente from contacorrente where " +
                      "idcontacorrente = " + idContaCorrente;

            if (ativo)
            {
                query = query + "and ativo = 0";
            }

            return query;
        }
    }
}
