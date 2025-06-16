using TesteDev.Models;
using TesteDev.Services;

using System;
using TesteDev.Models;
using TesteDev.Services;
using Xunit;
using FluentAssertions;

namespace TesteDev.Tests
{
    public class CdbCalculatorServiceTests
    {
        private readonly CdbCalculatorService _service = new();

        [Theory]
        [InlineData(1000, 2)]
        [InlineData(5000, 6)]
        [InlineData(10000, 12)]
        [InlineData(2000, 25)]
        public void Calcular_DeveRetornarValorBrutoELiquido(decimal valorInicial, int prazoMeses)
        {
            var request = new CdbRequest { ValorInicial = valorInicial, PrazoMeses = prazoMeses };

            var result = _service.Calcular(request);

            result.ValorBruto.Should().BeGreaterThan(valorInicial);
            result.ValorLiquido.Should().BeLessThan(result.ValorBruto);
            result.ValorLiquido.Should().BeGreaterThan(valorInicial);
        }

        [Fact]
        public void Calcular_DeveLancarExcecao_QuandoValorInicialMenorOuIgualZero()
        {
            var request = new CdbRequest { ValorInicial = 0, PrazoMeses = 5 };

            Action act = () => _service.Calcular(request);

            act.Should().Throw<ArgumentException>().WithMessage("Valor inicial deve ser positivo.");
        }

        [Fact]
        public void Calcular_DeveLancarExcecao_QuandoPrazoMenorQue2()
        {
            var request = new CdbRequest { ValorInicial = 1000, PrazoMeses = 1 };

            Action act = () => _service.Calcular(request);

            act.Should().Throw<ArgumentException>().WithMessage("Prazo deve ser maior que 1 mês.");
        }

        [Theory]
        [InlineData(1000, 6, 0.225)]   // Até 6 meses
        [InlineData(1000, 12, 0.20)]   // Até 12 meses
        [InlineData(1000, 24, 0.175)]  // Até 24 meses
        [InlineData(1000, 36, 0.15)]   // Acima de 24 meses
        public void Calcular_DeveAplicarAliquotaCorreta(decimal valorInicial, int prazoMeses, double aliquotaEsperada)
        {
            var request = new CdbRequest { ValorInicial = valorInicial, PrazoMeses = prazoMeses };

            var result = _service.Calcular(request);

            // Calcula o imposto efetivamente aplicado
            var valorBruto = result.ValorBruto;
            var impostoEfetivo = Math.Round((valorBruto - valorInicial) * (decimal)aliquotaEsperada, 2);
            var valorLiquidoEsperado = Math.Round(valorBruto - impostoEfetivo, 2);

            result.ValorLiquido.Should().BeApproximately(valorLiquidoEsperado, 0.01M);

        }
    }
}
