using Dapper;
using JobList.Entities.Helpers;
using JobList.Entities.Models;
using JobList.Repositories.Service;
using JobList.Resources;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobList.Repositories.Implementation
{
    public class GenerosRepository : IGenerosRepository
    {
        private readonly Dictionary<string, IDbConnection> connections;
        private readonly IDbConnection dbConnection;

        public GenerosRepository(Dictionary<string, IDbConnection> connections)
        {
            this.connections = connections;
            this.dbConnection = connections[ConfigResources.DefaultConnection];
        }

        // Tarea para devolver lista de generos
        public async Task<IEnumerable<ReadGenerosResponse>> readGeneros()
        {
            try
            {
                dbConnection.Open();
                var parameters = new DynamicParameters();

                var result = await dbConnection.QueryAsync<ReadGenerosResponse>(
                           sql: StoredProcedureResources.sp_Generos_Consultar,
                           param: parameters,
                           transaction: null,
                           commandTimeout: DatabaseHelper.TIMEOUT,
                           commandType: CommandType.StoredProcedure
                        );
                return result;
            }
            catch
            {
                return null;
            }
            finally
            {
                this.dbConnection?.Close();
            }
        }
    }
}
