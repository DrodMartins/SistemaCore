namespace CaracteristicaContext.Domain.AggregatesModel.CaracteristicaAggregate
{
    public class CaracteristicaComposicao
    {
        public int CodCaracteristicaComposicao { get; set; }

        public int CodCaracteristica { get; set; }

        public int? CodTipoValorCaracteristica { get; set; }

        public int? CodTipoUnidadeMedida { get; set; }

        public string Nome { get; set; }

        public string Sigla { get; set; }

        public string Descricao { get; set; }

        public string ValorTexto { get; set; }

        public decimal ValorNumerico { get; set; }
    }
}
