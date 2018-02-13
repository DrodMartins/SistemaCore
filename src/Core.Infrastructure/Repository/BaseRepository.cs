using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Infrastructure.Repository
{
    public abstract class BaseRepository
    {
        private readonly string _ConnectionString;

        protected BaseRepository()
        {
            _ConnectionString = StringConexaoBancoDados();
        }

        protected async Task<T> Connection<T>(Func<IDbConnection, Task<T>> getData)
        {
            try
            {
                using (var connection = new SqlConnection(_ConnectionString))
                {
                    await connection.OpenAsync();
                    return await getData(connection);
                }
            }
            catch (TimeoutException ex)
            {
                throw new Exception($"{GetType().FullName}.Connection() experienced a SQL timeout", ex);
            }
            catch (SqlException ex)
            {
                throw new Exception($"{GetType().FullName}.Connection() experienced a SQL exception (not a timeout)", ex);
            }
        }

        protected async Task<T> ExecuteObject<T>(string procedure, DynamicParameters parametro)
        {
            return await Connection(async c => 
            {
                return (await c.QueryAsync<T>(sql: procedure, param: parametro, commandType: CommandType.StoredProcedure)).FirstOrDefault();
            });
        }

        private static string StringConexaoBancoDados()
        {
            var config = new ConfigurationBuilder()
               .SetBasePath(Directory.GetCurrentDirectory())
               .AddJsonFile("appsettings.json")
               .Build();

            return config.GetConnectionString("DefaultConnection");
        }
    }
}
