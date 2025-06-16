using TesteDev.Domain;
using TesteDev.Models;

namespace TesteDev.Services
{
    public class CdbCalculatorService : ICdbCalculatorService
    {
        public CdbResult Calcular(CdbRequest request)
        {
            if (request.ValorInicial <= 0)
                throw new ArgumentException("Valor inicial deve ser positivo.");
            if (request.PrazoMeses < 2)
                throw new ArgumentException("Prazo deve ser maior que 1 mês.");

            decimal valor = request.ValorInicial;
            for (int i = 0; i < request.PrazoMeses; i++)
            {
                decimal rendimentoMes = valor * (TaxaCdb.CDI * TaxaCdb.TB);
                valor += rendimentoMes;
            }

            decimal valorBruto = valor;
            decimal imposto = (valorBruto - request.ValorInicial) * ImpostoRenda.ObterAliquota(request.PrazoMeses);
            decimal valorLiquido = valorBruto - imposto;

            return new CdbResult
            {
                ValorBruto = Math.Round(valorBruto, 2),
                ValorLiquido = Math.Round(valorLiquido, 2)
            };
        }
    }
}
