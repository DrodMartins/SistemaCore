using CaracteristicaContext.Domain.AggregatesModel.CaracteristicaAggregate;
using Core.Infrastructure.Repository;
using Dapper;
using System;
using System.Data;
using System.Threading.Tasks;

namespace CaracteristicaContext.Infrastructure.Repository
{
    public class CaracteristicaRepository : BaseRepository, ICaracteristicaRepository
    {
        public async Task<Caracteristica> ObterAsync(int CodCaracteristica)
        {
            try
            {
                var p = new DynamicParameters();
                p.Add("@CodCaracteristica", CodCaracteristica, DbType.Int32);

                return await ExecuteObject<Caracteristica>( "P_CARACTERISTICA_OBTER", p);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<int> IncluirAsync(Caracteristica entidade)
        {
            try
            {
                return await Connection(async c =>
                {
                    var p = new DynamicParameters();
                    p.Add("@Nome", entidade.Nome, DbType.String);
                    p.Add("@Descricao", entidade.Descricao, DbType.String);
                    p.Add("@CodUsuarioCadastro", entidade.CodUsuarioCadastro, DbType.Int16);

                    return await ExecuteObject<int>("P_CARACTERISTICA_INSERIR", p);
                });
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
