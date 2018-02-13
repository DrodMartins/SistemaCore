using System.Threading.Tasks;

namespace CaracteristicaContext.Domain.AggregatesModel.CaracteristicaAggregate
{
    public interface ICaracteristicaRepository
    {
        Task<Caracteristica> ObterAsync(int CodCaracteristica);
        Task<int> IncluirAsync(Caracteristica entidade);
    }
}
