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

    public class CuentaAdministradorRepository : ICuentaAdministradorRepository
    {
        private readonly Dictionary<string, IDbConnection> connections;
        private readonly IDbConnection dbConnection;

        public CuentaAdministradorRepository(Dictionary<string, IDbConnection> connections)
        {
            this.connections = connections;
            this.dbConnection = connections[ConfigResources.DefaultConnection];
        }


        public async Task<int> addAdministrador(InsertAdminRequest request)
        {
            try
            {
                dbConnection.Open();
                var idadmin = 0;
                using (var transaction = dbConnection.BeginTransaction())
                {
                    try
                    {
                        var parameters = new DynamicParameters();
                        parameters.Add(StoredProcedureResources.Usuario, request.usuario);
                        parameters.Add(StoredProcedureResources.Password, request.password);
                        parameters.Add(StoredProcedureResources.idTipo, request.idTipo);
                        parameters.Add(StoredProcedureResources.idNuevoUsuario, direction: ParameterDirection.Output);
                        

                        await dbConnection.ExecuteAsync(
                           sql: StoredProcedureResources.sp_Usuario_Insertar,
                           transaction: transaction,
                           param: parameters,
                           commandTimeout: DatabaseHelper.TIMEOUT,
                           commandType: CommandType.StoredProcedure);

                        var idUsuario = parameters.Get<int>(StoredProcedureResources.idNuevoUsuario);
                        if(idUsuario > 0)
                        {
                            parameters = new DynamicParameters();
                            parameters.Add(StoredProcedureResources.idUsuario, idUsuario);
                            parameters.Add(StoredProcedureResources.Nombre, request.nombre);
                            parameters.Add(StoredProcedureResources.idNuevoAdministrador, direction: ParameterDirection.Output);


                            await dbConnection.ExecuteAsync(
                               sql: StoredProcedureResources.sp_Administrador_Insertar,
                               transaction: transaction,
                               param: parameters,
                               commandTimeout: DatabaseHelper.TIMEOUT,
                               commandType: CommandType.StoredProcedure);
                            idadmin = parameters.Get<int>(StoredProcedureResources.idNuevoAdministrador);
                        }

                        transaction.Commit();
                    }
                    catch (Exception s)
                    {
                        transaction.Rollback();
                    }
                }
                return idadmin;
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

        public async Task<AdminInfo> findAdministrador(LoginAdminRequest userLogin)
        {
            try
            {
                dbConnection.Open();
                var parameters = new DynamicParameters();
                parameters.Add(StoredProcedureResources.Usuario, userLogin.usuario);
                parameters.Add(StoredProcedureResources.Password, userLogin.password);

                return await dbConnection.QueryFirstAsync<AdminInfo>(
                    sql: StoredProcedureResources.sp_LoginAdmin,
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
