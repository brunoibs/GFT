namespace GFT.Api.Model
{
    public class InvestimentoMensalResponse
    {
        public decimal ValorInicial { get; set; }
        public decimal ValorFinal { get; set; }
        public int Mes { get; set; }
        public int Ano { get; set; }
        public DateTime Dt { get; set; }
    }
}
