namespace JobList.Repositories.Implementation
{
    using Dapper;
    using JobList.Entities.Helpers;
    using JobList.Entities.Requests;
    using JobList.Repositories.Service;
    using JobList.Resources;
    using System.Data;
    using System.Threading.Tasks;

    public class CuentaEgresadoRepository : ICuentaEgresadoRepository
    {
        private readonly Dictionary<string, IDbConnection> connections;
        private readonly IDbConnection dbConnection;

        public CuentaEgresadoRepository(Dictionary<string, IDbConnection> connections)
        {
            this.connections = connections;
            this.dbConnection = connections[ConfigResources.DefaultConnection];
        }

        public async Task<bool> addConocimientoEgresado(insertConocimientoEgresadoRequest request)
        {
            try
            {
                dbConnection.Open();
                var parameters = new DynamicParameters();
                parameters.Add(StoredProcedureResources.idConocimiento, request.idConocimiento);
                parameters.Add(StoredProcedureResources.idUsuarioEgresado, request.idUsuarioEgresado);

                var result = await dbConnection.ExecuteAsync(
                           sql: StoredProcedureResources.sp_ConocimientosEgresado_Insertar,
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

        public async Task<bool> addEgresado(insertEgresadoRequest request)
        {
            try
            {
                dbConnection.Open();

                using (var transaction = dbConnection.BeginTransaction())
                {
                    try
                    {
                        var parameters = new DynamicParameters();
                        parameters.Add(StoredProcedureResources.Usuario, request.usuario);
                        parameters.Add(StoredProcedureResources.Password, request.password);
                        parameters.Add(StoredProcedureResources.idTipo, request.idTipo);
                        parameters.Add(StoredProcedureResources.idNuevoUsuario, request.idNuevoUsuario, direction: ParameterDirection.Output);


                        await dbConnection.ExecuteAsync(
                           sql: StoredProcedureResources.sp_Usuario_Insertar,
                           transaction: transaction,
                           param: parameters,
                           commandTimeout: DatabaseHelper.TIMEOUT,
                           commandType: CommandType.StoredProcedure);

                        request.idNuevoUsuario = parameters.Get<int>(StoredProcedureResources.idNuevoUsuario);

                        if (request.idNuevoUsuario > 0)
                        {
                            parameters = new DynamicParameters();
                            parameters.Add(StoredProcedureResources.idUsuario, request.idNuevoUsuario);
                            parameters.Add(StoredProcedureResources.Nombre, request.nombre);
                            parameters.Add(StoredProcedureResources.Apellido, request.apellido);
                            parameters.Add(StoredProcedureResources.idArea, request.idArea);
                            parameters.Add(StoredProcedureResources.idNuevoEgresado, request.idNuevoEgresado, direction: ParameterDirection.Output);


                            await dbConnection.ExecuteAsync(
                               sql: StoredProcedureResources.sp_Egresados_Agregar,
                               transaction: transaction,
                               param: parameters,
                               commandTimeout: DatabaseHelper.TIMEOUT,
                               commandType: CommandType.StoredProcedure);
                            request.idNuevoEgresado = parameters.Get<int>(StoredProcedureResources.idNuevoEgresado);
                        }

                        transaction.Commit();
                    }
                    catch (Exception s)
                    {
                        transaction.Rollback();
                    }
                }
                return request.idNuevoEgresado > 0;
            }
            catch
            {
                return false;
            }
            finally
            {
                dbConnection?.Close();
            }
        }

        public async Task<bool> addHabilidadEgresado(insertHabilidadEgresadoRequest request)
        {
            try
            {
                dbConnection.Open();
                var parameters = new DynamicParameters();
                parameters.Add(StoredProcedureResources.idHabilidad, request.idHabilidad);
                parameters.Add(StoredProcedureResources.idUsuarioEgresado, request.idUsuarioEgresado);

                var result = await dbConnection.ExecuteAsync(
                           sql: StoredProcedureResources.sp_HabilidadesEgresado_Insertar,
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
