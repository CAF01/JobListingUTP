namespace JobList.Repositories.Implementation
{
    using Dapper;
    using JobList.Entities.Helpers;
    using JobList.Entities.Models;
    using JobList.Entities.Requests;
    using JobList.Entities.Responses;
    using JobList.Repositories.Service;
    using JobList.Resources;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.Options;
    using System.Collections.Generic;
    using System.Data;
    using System.Threading.Tasks;

    public class CuentaAdministradorRepository : ICuentaAdministradorRepository
    {
        private readonly Dictionary<string, IDbConnection> connections;
        private readonly ConfigurationPaging configuration;
        private readonly IDbConnection dbConnection;

        // Constructor
        public CuentaAdministradorRepository(Dictionary<string, IDbConnection> connections, IOptions<ConfigurationPaging> options)
        {
            this.connections = connections;
            this.configuration = options.Value;
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
        public async Task<ReadDetallesEmpresaResponse> readDetallesEmpresa(ReadDetallesEmpresaRequest request)
        {
            try
            {
                dbConnection.Open();
                var parameters = new DynamicParameters();
                parameters.Add(StoredProcedureResources.idUsuarioEmpresa, request.idUsuarioEmpresa);

                var result = await dbConnection.QueryFirstAsync<ReadDetallesEmpresaResponse>(
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
        public async Task<PaginationListResponse<ReadEmpresasAfiliadasResponse>> readEmpresasAfiliadas()
        {
            try
            {
                dbConnection.Open();
                var parameters = new DynamicParameters();

                var result = await dbConnection.QueryMultipleAsync(
                           sql: StoredProcedureResources.sp_Empresas_Consultar,
                           param: parameters,
                           transaction: null,
                           commandTimeout: DatabaseHelper.TIMEOUT,
                           commandType: CommandType.StoredProcedure
                        );
                var dynamicResult = result.Read<ReadEmpresasAfiliadasResponse>();

                return new PaginationListResponse<ReadEmpresasAfiliadasResponse>(dynamicResult, dynamicResult.Count(), configuration.PageSize);

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
        public async Task<PaginationListResponse<ReadOfertasActivasAdministradorResponse>> readOfertasActivasAdministrador()
        {
            try
            {
                dbConnection.Open();
                var parameters = new DynamicParameters();

                var result = await dbConnection.QueryMultipleAsync(
                           sql: StoredProcedureResources.sp_OfertasTrabajo_ActivasAdministrador_Consultar,
                           param: parameters,
                           transaction: null,
                           commandTimeout: DatabaseHelper.TIMEOUT,
                           commandType: CommandType.StoredProcedure
                        );

                var dynamicResult = result.Read<ReadOfertasActivasAdministradorResponse>();

                var data = new PaginationListResponse<ReadOfertasActivasAdministradorResponse>(dynamicResult, dynamicResult.Count(), configuration.PageSize);


                if (data != null && data.Data!=null && data.Data.Count()>0) 
                {
                    foreach (ReadOfertasActivasAdministradorResponse oferta in data.Data)
                    {
                        // amarillo: a partir de un postulante
                        if (oferta.numeroPostulantes >= 1)
                            oferta.semaforo = "amarillo";
                        // verde: no tiene postulantes
                        if (oferta.numeroPostulantes == 0)
                            oferta.semaforo = "verde";
                    }
                }                
                return data;
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
        public async Task<PaginationListResponse<ReadOfertasNuevasAdministradorResponse>> readOfertasNuevasAdministrador()
        {
            try
            {
                dbConnection.Open();
                var parameters = new DynamicParameters();

                var result = await dbConnection.QueryMultipleAsync(
                           sql: StoredProcedureResources.sp_OfertasTrabajo_NuevasAdministrador_Consultar,
                           param: parameters,
                           transaction: null,
                           commandTimeout: DatabaseHelper.TIMEOUT,
                           commandType: CommandType.StoredProcedure
                        );
                var dynamicResult = result.Read<ReadOfertasNuevasAdministradorResponse>();

                return new PaginationListResponse<ReadOfertasNuevasAdministradorResponse>(dynamicResult, dynamicResult.Count(), configuration.PageSize);
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
        public async Task<PaginationListResponse<ReadOfertasPublicadasEmpresaResponse>> readOfertasPublicadasEmpresa(ReadOfertasPublicadasEmpresaRequest request)
        {
            try
            {
                dbConnection.Open();
                var parameters = new DynamicParameters();
                parameters.Add(StoredProcedureResources.idUsuarioEmpresa, request.idUsuarioEmpresa);

                var result = await dbConnection.QueryMultipleAsync(
                           sql: StoredProcedureResources.sp_OfertasTrabajo_PerfilEmpresa_Consultar,
                           param: parameters,
                           transaction: null,
                           commandTimeout: DatabaseHelper.TIMEOUT,
                           commandType: CommandType.StoredProcedure
                        );
                var dynamicResult = result.Read<ReadOfertasPublicadasEmpresaResponse>();

                return new PaginationListResponse<ReadOfertasPublicadasEmpresaResponse>(dynamicResult, dynamicResult.Count(), configuration.PageSize);

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
        public async Task<PaginationListResponse<ReadSeguimientosPostulacionEgresadosResponse>> readSeguimientosPostulacionEgresados()
        {
            try
            {
                dbConnection.Open();
                var parameters = new DynamicParameters();

                var result = await dbConnection.QueryMultipleAsync(
                           sql: StoredProcedureResources.sp_Postulaciones_Consultar,
                           param: parameters,
                           transaction: null,
                           commandTimeout: DatabaseHelper.TIMEOUT,
                           commandType: CommandType.StoredProcedure
                        );
                var dynamicResult = result.Read<ReadSeguimientosPostulacionEgresadosResponse>();

                return new PaginationListResponse<ReadSeguimientosPostulacionEgresadosResponse>(dynamicResult, dynamicResult.Count(), configuration.PageSize);
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

        public async Task<bool> UpdateOfertaTrabajoValida(UpdateAdministradorOfertaValidacionRequest request)
        {
            try
            {
                dbConnection.Open();
                var parameters = new DynamicParameters();
                parameters.Add(StoredProcedureResources.idOferta, request.idOferta);
                parameters.Add(StoredProcedureResources.Status, request.estado);

                var expirationDateCalculated = MexicoDateHelper.obtainDate().AddDays(28);
                var actualDate = MexicoDateHelper.obtainDate();
                parameters.Add(StoredProcedureResources.FechaCaducidad, expirationDateCalculated);
                parameters.Add(StoredProcedureResources.FechaPublicacion, actualDate);

                var result = await dbConnection.ExecuteAsync(
                           sql: StoredProcedureResources.sp_Administrador_EstadoOferta_Actualizar,
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
