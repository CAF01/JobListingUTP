namespace JobList.Repositories.Implementation
{
    using Dapper;
    using JobList.Entities.Helpers;
    using JobList.Entities.Models;
    using JobList.Entities.Requests;
    using JobList.Entities.Responses;
    using JobList.Repositories.Service;
    using JobList.Resources;
    using Microsoft.Extensions.Options;
    using System.Data;
    using System.Threading.Tasks;

    public class ConocimientosRepository : IConocimientosRepository
    {
        private readonly IDbConnection dbConnection;
        private readonly ConfigurationPaging configuration;

        // Constructor
        public ConocimientosRepository(IDbConnection connections, IOptions<ConfigurationPaging> configuration)
        {
            this.dbConnection = connections;
            this.configuration = configuration.Value;
        }

        // Insertar un conocimiento
        public async Task<int> addConocimiento(InsertConocimientoRequest request)
        {
            try
            {
                dbConnection.Open();
                var parameters = new DynamicParameters();
                parameters.Add(StoredProcedureResources.Descripcion, request.descripcion);
                parameters.Add(StoredProcedureResources.idNuevoConocimiento, direction: ParameterDirection.Output);

                await dbConnection.ExecuteAsync(
                           sql: StoredProcedureResources.sp_Conocimiento_Insertar,
                           param: parameters,
                           transaction: null,
                           commandTimeout: DatabaseHelper.TIMEOUT,
                           commandType: CommandType.StoredProcedure
                        );
                var result = parameters.Get<int>(StoredProcedureResources.idNuevoConocimiento);
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

        // Eliminar un conocimiento
        public async Task<bool> deleteConocimiento(DeleteConocimientoRequest request)
        {
            try
            {
                dbConnection.Open();
                var parameters = new DynamicParameters();
                parameters.Add(StoredProcedureResources.idConocimiento, request.idConocimiento);

                var result = await dbConnection.ExecuteAsync(
                           sql: StoredProcedureResources.sp_Conocimiento_Eliminar,
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

        // Actualizar un conocimiento
        public async Task<bool> updateConocimiento(UpdateConocimientoRequest request)
        {
            try
            {
                dbConnection.Open();
                var parameters = new DynamicParameters();
                parameters.Add(StoredProcedureResources.NuevaDescripcion, request.nuevaDescripcion);
                parameters.Add(StoredProcedureResources.idConocimiento, request.idConocimiento);

                var result = await dbConnection.ExecuteAsync(
                           sql: StoredProcedureResources.sp_Conocimiento_Actualizar,
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

        // Devolver lista de conocimientos
        public async Task<IEnumerable<ReadConocimientosResponse>> readConocimientos()
        {
            try
            {
                dbConnection.Open();
                var parameters = new DynamicParameters();

                var result = await dbConnection.QueryMultipleAsync(
                           sql: StoredProcedureResources.sp_Conocimientos_Consultar,
                           param: parameters,
                           transaction: null,
                           commandTimeout: DatabaseHelper.TIMEOUT,
                           commandType: CommandType.StoredProcedure
                        );

                var dynamicResult = result.Read<ReadConocimientosResponse>();
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
