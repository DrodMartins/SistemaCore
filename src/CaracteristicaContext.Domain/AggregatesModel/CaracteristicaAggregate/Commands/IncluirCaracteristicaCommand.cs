using MediatR;

namespace CaracteristicaContext.Domain.AggregatesModel.CaracteristicaAggregate.Commands
{
    public class IncluirCaracteristicaCommand : BaseCaracteristicaCommand
    {
        public IncluirCaracteristicaCommand(string nome, string descricao)
        {
            nome = Nome;
            descricao = Descricao;
        }
    }
}
