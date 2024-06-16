namespace Questao5.Application.Queries.Responses
{
    public class SaldoContaResponse
    {
        public string IdContaCorrente { get; set; }
        public string Titular { get; set; }
        public DateTime DataHoraConsulta { get; set; }
        public double Valor { get; set; }        
    }
}