namespace JobList.Repositories.Implementation
{
    using Dapper;
    using JobList.Entities.Helpers;
    using JobList.Entities.Requests;
    using JobList.Repositories.Service;
    using JobList.Resources;
    using System.Data;
    using System.Threading.Tasks;

    public class HabilidadesRepository : IHabilidadesRepository
    {
        private readonly Dictionary<string, IDbConnection> connections;
        private readonly IDbConnection dbConnection;

        public HabilidadesRepository(Dictionary<string, IDbConnection> connections)
        {
                this.connections = connections;
                this.dbConnection = connections[ConfigResources.DefaultConnection];
            
        }

        public async Task<bool> addHabilidad(insertHabilidadRequest request)
        {
            try
            {
                dbConnection.Open();
                var parameters = new DynamicParameters();
                parameters.Add(StoredProcedureResources.Descripcion, request.descripcion);
                parameters.Add(StoredProcedureResources.idNuevaHabilidad, request.idNuevaHabilidad, direction: ParameterDirection.Output);

                await dbConnection.ExecuteAsync(
                           sql: StoredProcedureResources.sp_Habilidad_Insertar,
                           param: parameters,
                           transaction: null,
                           commandTimeout: DatabaseHelper.TIMEOUT,
                           commandType: CommandType.StoredProcedure
                        );
                request.idNuevaHabilidad = parameters.Get<int>(StoredProcedureResources.idNuevaHabilidad);
                return request.idNuevaHabilidad > 0;
            }
            catch
            {
                return false;
            }
            finally
            {
                this.dbConnection?.Close();
            }
        }

        public async Task<bool> deleteHabilidad(deleteHabilidadRequest request)
        {
            try
            {
                dbConnection.Open();
                var parameters = new DynamicParameters();
                parameters.Add(StoredProcedureResources.idHabilidad, request.idHabilidad);

                var result = await dbConnection.ExecuteAsync(
                           sql: StoredProcedureResources.sp_Habilidad_Eliminar,
                           param: parameters,
                           transaction: null,
                           commandTimeout: DatabaseHelper.TIMEOUT,
                           commandType: CommandType.StoredProcedure
                        );
                return result > 0;
            }
            catch
            {
                return false;
            }
            finally
            {
                this.dbConnection?.Close();
            }
        }

        public async Task<bool> updateHabilidad(updateHabilidadRequest request)
        {
            try
            {
                dbConnection.Open();
                var parameters = new DynamicParameters();
                parameters.Add(StoredProcedureResources.NuevaDescripcion, request.nuevaDescripcion);
                parameters.Add(StoredProcedureResources.idHabilidad, request.idHabilidad);

                var result = await dbConnection.ExecuteAsync(
                           sql: StoredProcedureResources.sp_Habilidad_Actualizar,
                           param: parameters,
                           transaction: null,
                           commandTimeout: DatabaseHelper.TIMEOUT,
                           commandType: CommandType.StoredProcedure
                        );
                return result > 0;
            }
            catch
            {
                return false;
            }
            finally
            {
                this.dbConnection?.Close();
            }
        }
    }
}
