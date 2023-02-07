namespace JobList.Repositories.Implementation
{
    using Dapper;
    using JobList.Entities.Helpers;
    using JobList.Entities.Requests;
    using JobList.Entities.Responses;
    using JobList.Repositories.Service;
    using JobList.Resources;
    using System.Data;
    using System.Threading.Tasks;

    public class CuentaDocenteRepository : ICuentaDocenteRepository
    {
        private readonly Dictionary<string, IDbConnection> connections;
        private readonly IDbConnection dbConnection;

        // Constructor
        public CuentaDocenteRepository(Dictionary<string, IDbConnection> connections)
        {
            this.connections = connections;
            this.dbConnection = connections[ConfigResources.DefaultConnection];
        }

        // Insertar un docente
        public async Task<int> addDocente(InsertDocenteRequest request)
        {
            try
            {
                dbConnection.Open();
                var idDocente = 0;
                using (var transaction = dbConnection.BeginTransaction())
                {
                    try
                    {
                        var parameters = new DynamicParameters();
                        parameters.Add(StoredProcedureResources.idTipoBuscado, 3);//Enumerador en SP esta definido 3 para docente
                        parameters.Add(StoredProcedureResources.idTipo, direction: ParameterDirection.Output);

                        await dbConnection.ExecuteAsync(
                           sql: StoredProcedureResources.sp_TiposUsuario_Buscar,
                           transaction: transaction,
                           param: parameters,
                           commandTimeout: DatabaseHelper.TIMEOUT,
                           commandType: CommandType.StoredProcedure);

                        var idTipo = parameters.Get<int>(StoredProcedureResources.idTipo);

                        parameters = new DynamicParameters();
                        parameters.Add(StoredProcedureResources.Usuario, request.usuario);
                        parameters.Add(StoredProcedureResources.Password, request.password);
                        parameters.Add(StoredProcedureResources.idTipo, idTipo);
                        parameters.Add(StoredProcedureResources.idNuevoUsuario, direction: ParameterDirection.Output);


                        await dbConnection.ExecuteAsync(
                           sql: StoredProcedureResources.sp_Usuario_Insertar,
                           transaction: transaction,
                           param: parameters,
                           commandTimeout: DatabaseHelper.TIMEOUT,
                           commandType: CommandType.StoredProcedure);

                        var idUsuario = parameters.Get<int>(StoredProcedureResources.idNuevoUsuario);

                        if (idUsuario > 0)
                        {
                            parameters = new DynamicParameters();
                            parameters.Add(StoredProcedureResources.idUsuario, idUsuario);
                            parameters.Add(StoredProcedureResources.Nombre, request.nombre);
                            parameters.Add(StoredProcedureResources.idNuevoDocente, direction: ParameterDirection.Output);


                            await dbConnection.ExecuteAsync(
                               sql: StoredProcedureResources.sp_Docentes_Insertar,
                               transaction: transaction,
                               param: parameters,
                               commandTimeout: DatabaseHelper.TIMEOUT,
                               commandType: CommandType.StoredProcedure);
                            idDocente = parameters.Get<int>(StoredProcedureResources.idNuevoDocente);
                        }

                        transaction.Commit();
                    }
                    catch (Exception s)
                    {
                        transaction.Rollback();
                    }
                }
                return idDocente;
            }
            catch
            {
                return 0;
            }
            finally
            {
                dbConnection?.Close();
            }
        }

        // Encontrar la cuenta de usuario de un docente
        public async Task<LoginDocenteResponse> findDocente(LoginDocenteRequest userLogin)
        {
            try
            {
                dbConnection.Open();
                var parameters = new DynamicParameters();
                parameters.Add(StoredProcedureResources.Usuario, userLogin.usuario);
                parameters.Add(StoredProcedureResources.Password, userLogin.password);

                return await dbConnection.QueryFirstAsync<LoginDocenteResponse>(
                    sql: StoredProcedureResources.sp_LoginDocente,
                    param: parameters,
                    transaction: null,
                    commandTimeout: DatabaseHelper.TIMEOUT,
                    commandType: CommandType.StoredProcedure);
            }
            catch
            {
                return null;
            }
            finally
            {
                dbConnection?.Close();
            }
        }
    }
}
