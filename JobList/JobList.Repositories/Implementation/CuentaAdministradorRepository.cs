namespace JobList.Repositories.Implementation
{
    using Dapper;
    using JobList.Entities.Helpers;
    using JobList.Entities.Models;
    using JobList.Entities.Requests;
    using JobList.Repositories.Service;
    using JobList.Resources;
    using System.Collections.Generic;
    using System.Data;
    using System.Threading.Tasks;

    public class CuentaAdministradorRepository : ICuentaAdministradorRepository
    {
        private readonly Dictionary<string, IDbConnection> connections;
        private readonly IDbConnection dbConnection;

        // Constructor
        public CuentaAdministradorRepository(Dictionary<string, IDbConnection> connections)
        {
            this.connections = connections;
            this.dbConnection = connections[ConfigResources.DefaultConnection];
        }

        // Insertar una cuenta de usuario administrador
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
                        parameters.Add(StoredProcedureResources.idTipoBuscado, 2);//Enumerador en SP esta definido 2 para administrador
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

        // Login administardor
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

        // Consultar detalles de una empresa
        public async Task<IEnumerable<ReadDetallesEmpresaResponse>> readDetallesEmpresa(ReadDetallesEmpresaRequest request)
        {
            try
            {
                dbConnection.Open();
                var parameters = new DynamicParameters();
                parameters.Add(StoredProcedureResources.idUsuarioEmpresa, request.idUsuarioEmpresa);

                var result = await dbConnection.QueryAsync<ReadDetallesEmpresaResponse>(
                           sql: StoredProcedureResources.sp_Empresa_Detalles_Consultar,
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

        // Listado de empresas afiliadas
        public async Task<IEnumerable<ReadEmpresasAfiliadasResponse>> readEmpresasAfiliadas()
        {
            try
            {
                dbConnection.Open();
                var parameters = new DynamicParameters();

                var result = await dbConnection.QueryAsync<ReadEmpresasAfiliadasResponse>(
                           sql: StoredProcedureResources.sp_Empresas_Consultar,
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

        // Listado de ofertas activas (de todos los usuarios)
        public async Task<IEnumerable<ReadOfertasActivasAdministradorResponse>> readOfertasActivasAdministrador()
        {
            try
            {
                dbConnection.Open();
                var parameters = new DynamicParameters();

                var result = await dbConnection.QueryAsync<ReadOfertasActivasAdministradorResponse>(
                           sql: StoredProcedureResources.sp_OfertasTrabajo_ActivasAdministrador_Consultar,
                           param: parameters,
                           transaction: null,
                           commandTimeout: DatabaseHelper.TIMEOUT,
                           commandType: CommandType.StoredProcedure
                        );
                
                if(result != null) 
                {
                    foreach (ReadOfertasActivasAdministradorResponse oferta in result)
                    {
                        // amarillo: a partir de un postulante
                        if (oferta.numeroPostulantes >= 1)
                            oferta.semaforo = "amarillo";
                        // verde: no tiene postulantes
                        if (oferta.numeroPostulantes == 0)
                            oferta.semaforo = "verde";
                        // rojo: postulante contactado
                        if (oferta.estadoPostulacion == "Aceptada")
                            oferta.semaforo = "rojo";
                    }
                }                

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

        // Listado de nuevas ofertas, esperando a ser validadas por el administrador
        public async Task<IEnumerable<ReadOfertasNuevasAdministradorResponse>> readOfertasNuevasAdministrador()
        {
            try
            {
                dbConnection.Open();
                var parameters = new DynamicParameters();

                var result = await dbConnection.QueryAsync<ReadOfertasNuevasAdministradorResponse>(
                           sql: StoredProcedureResources.sp_OfertasTrabajo_NuevasAdministrador_Consultar,
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

        // Listado de ofertas publicadas por una empresa
        public async Task<IEnumerable<ReadOfertasPublicadasEmpresaResponse>> readOfertasPublicadasEmpresa(ReadOfertasPublicadasEmpresaRequest request)
        {
            try
            {
                dbConnection.Open();
                var parameters = new DynamicParameters();
                parameters.Add(StoredProcedureResources.idUsuarioEmpresa, request.idUsuarioEmpresa);

                var result = await dbConnection.QueryAsync<ReadOfertasPublicadasEmpresaResponse>(
                           sql: StoredProcedureResources.sp_OfertasTrabajo_PerfilEmpresa_Consultar,
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

        // Listado de seguimientos de postulacion de todos los egresados 
        public async Task<IEnumerable<ReadSeguimientosPostulacionEgresadosResponse>> readSeguimientosPostulacionEgresados()
        {
            try
            {
                dbConnection.Open();
                var parameters = new DynamicParameters();

                var result = await dbConnection.QueryAsync<ReadSeguimientosPostulacionEgresadosResponse>(
                           sql: StoredProcedureResources.sp_Postulaciones_Consultar,
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
