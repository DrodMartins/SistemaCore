using MediatR;

namespace CaracteristicaContext.Domain.AggregatesModel.CaracteristicaAggregate.Commands
{
    public abstract class BaseCaracteristicaCommand : IRequest
    {
        public int CodCaracteristica { get; protected set; }
        public string Nome { get; protected set; }
        public string Descricao { get; protected set; }
    }
}
