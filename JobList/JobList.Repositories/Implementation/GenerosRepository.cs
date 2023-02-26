namespace JobList.Repositories.Implementation
{
    using Dapper;
    using JobList.Entities.Helpers;
    using JobList.Entities.Models;
    using JobList.Repositories.Service;
    using JobList.Resources;
    using System.Data;

    public class GenerosRepository : IGenerosRepository
    {
        private readonly IDbConnection dbConnection;

        public GenerosRepository(IDbConnection connections)
        {
            this.dbConnection = connections;
        }

        // Tarea para devolver lista de generos
        public async Task<IEnumerable<ReadGenerosResponse>> readGeneros()
        {
            try
            {
                dbConnection.Open();
                var parameters = new DynamicParameters();

                var result = await dbConnection.QueryMultipleAsync(
                           sql: StoredProcedureResources.sp_Generos_Consultar,
                           param: parameters,
                           transaction: null,
                           commandTimeout: DatabaseHelper.TIMEOUT,
                           commandType: CommandType.StoredProcedure
                        );
                var dynamicResult = result.Read<ReadGenerosResponse>();
                return dynamicResult;
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
