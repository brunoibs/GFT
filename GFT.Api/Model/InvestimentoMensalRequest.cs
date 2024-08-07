namespace GFT.Api.Model
{
    public class InvestimentoMensalRequest
    {
        public decimal ValorInicial { get; set; }
        public decimal ValorFinal { get; set; }
        public int QtdMes { get; set; }
        public DateTime Dt { get; set; }
    }
}
