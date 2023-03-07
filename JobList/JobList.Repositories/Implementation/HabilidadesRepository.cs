namespace JobList.Repositories.Implementation
{
    using Dapper;
    using JobList.Entities.Helpers;
    using JobList.Entities.Models;
    using JobList.Entities.Requests;
    using JobList.Repositories.Service;
    using JobList.Resources;
    using System.Data;
    using System.Threading.Tasks;

    public class HabilidadesRepository : IHabilidadesRepository
    {
        private readonly IDbConnection dbConnection;

        // Constructor
        public HabilidadesRepository(IDbConnection connections)
        {
                this.dbConnection = connections;
            
        }

        // Insertar una habilidad
        public async Task<int> addHabilidad(InsertHabilidadRequest request)
        {
            try
            {
                dbConnection.Open();
                var parameters = new DynamicParameters();
                parameters.Add(StoredProcedureResources.Descripcion, request.descripcion);
                parameters.Add(StoredProcedureResources.idNuevaHabilidad, direction: ParameterDirection.Output);

                await dbConnection.ExecuteAsync(
                           sql: StoredProcedureResources.sp_Habilidad_Insertar,
                           param: parameters,
                           transaction: null,
                           commandTimeout: DatabaseHelper.TIMEOUT,
                           commandType: CommandType.StoredProcedure
                        );
                var result = parameters.Get<int>(StoredProcedureResources.idNuevaHabilidad);
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

        // Eliminar una habilidad
        public async Task<bool> deleteHabilidad(DeleteHabilidadRequest request)
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

        // Actualizar una habilidad
        public async Task<bool> updateHabilidad(UpdateHabilidadRequest request)
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

        // Devolver lista de habilidades
        public async Task<IEnumerable<ReadHabilidadesResponse>> readHabilidades()
        {
            try
            {
                dbConnection.Open();
                var parameters = new DynamicParameters();

                var result = await dbConnection.QueryMultipleAsync(
                           sql: StoredProcedureResources.sp_Habilidades_Consultar,
                           param: parameters,
                           transaction: null,
                           commandTimeout: DatabaseHelper.TIMEOUT,
                           commandType: CommandType.StoredProcedure
                        );
                var dynamicResult = result.Read<ReadHabilidadesResponse>();
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
