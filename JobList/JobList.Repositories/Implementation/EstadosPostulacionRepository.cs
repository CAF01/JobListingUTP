namespace JobList.Repositories.Implementation
{
    using Dapper;
    using JobList.Entities.Helpers;
    using JobList.Entities.Requests;
    using JobList.Repositories.Service;
    using JobList.Resources;
    using System.Data;
    using System.Threading.Tasks;

    public class EstadosPostulacionRepository : IEstadosPostulacionRepository
    {
        private readonly IDbConnection dbConnection;

        public EstadosPostulacionRepository(IDbConnection connections)
        {
            this.dbConnection = connections;
        }
        public async Task<int> addEstadoPostulacion(InsertEstadoPostulacionRequest request)
        {
            try
            {
                dbConnection.Open();
                var parameters = new DynamicParameters();
                parameters.Add(StoredProcedureResources.Descripcion, request.descripcion);
                parameters.Add(StoredProcedureResources.idNuevoEstadoPostulacion, direction: ParameterDirection.Output);

                await dbConnection.ExecuteAsync(
                           sql: StoredProcedureResources.sp_adminEstadosPostulacion,
                           param: parameters,
                           transaction: null,
                           commandTimeout: DatabaseHelper.TIMEOUT,
                           commandType: CommandType.StoredProcedure
                        );
                var result = parameters.Get<int>(StoredProcedureResources.idNuevoEstadoPostulacion);
                return result;
            }
            catch
            {
                return 0;
            }
            finally
            {
                this.dbConnection?.Close();
            }
        }
    }
}
