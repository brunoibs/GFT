using GFT.Api.Model;

namespace GFT.Api.Service
{
    public interface IInvestimentoService
    {
        InvestimentoResponse CalcularInvestimento(InvestimentoRequest request);
    }

    public class InvestimentoService : IInvestimentoService
    {
        private const decimal TB = 1.08m;
        private const decimal CDI = 0.009m;

        public InvestimentoResponse CalcularInvestimento(InvestimentoRequest request)
        {
            decimal valorFinal = request.ValorInicial;

            for (int i = 0; i < request.Prazo; i++)
            {
                valorFinal *= (1 + (CDI * TB));
            }

            decimal valorBruto = valorFinal;
            decimal aliquota = CalcularAliquota(request.Prazo);

            decimal imposto = (valorFinal - request.ValorInicial) * aliquota;
            decimal valorLiquido = valorFinal - imposto;

            return new InvestimentoResponse
            {
                ValorBruto = valorBruto,
                ValorLiquido = valorLiquido
            };
        }

        private decimal CalcularAliquota(int prazo)
        {
            switch (prazo)
            {
                case int n when (n <= 6):
                    return 0.225m;
                case int n when (n <= 12):
                    return 0.20m;
                case int n when (n <= 24):
                    return 0.175m;
                default:
                    return 0.15m;
            }
        }
    }
}
