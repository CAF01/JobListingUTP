namespace JobList.Repositories.Implementation
{
    using Dapper;
    using JobList.Entities.Helpers;
    using JobList.Entities.Models;
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

        // Eliminar una oferta activa
        public async Task<bool> deleteOfertaActiva(DeleteOfertaActivaDocenteRequest request)
        {
            try
            {
                dbConnection.Open();
                var parameters = new DynamicParameters();
                parameters.Add(StoredProcedureResources.idOferta, request.idOferta);

                var result = await dbConnection.ExecuteAsync(
                           sql: StoredProcedureResources.sp_OfertasTrabajoActivas_Cancelar,
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

        // Consultar detalles de una oferta de trabajo
        //public async Task<ReadDetallesOfertaResponse> readDetallesOferta(ReadDetallesOfertaRequest request)
        //{
        //    try
        //    {
        //        dbConnection.Open();
        //        var parameters = new DynamicParameters();
        //        parameters.Add(StoredProcedureResources.idOferta, request.idOferta);

        //        var result = await dbConnection.QueryAsync<ReadDetallesOfertaResponse>(
        //                   sql: StoredProcedureResources.sp_OfertasTrabajo_Detalles_Consultar,
        //                   param: parameters,
        //                   transaction: null,
        //                   commandTimeout: DatabaseHelper.TIMEOUT,
        //                   commandType: CommandType.StoredProcedure
        //                );
        //        return result;
        //    }
        //    catch
        //    {
        //        return null;
        //    }
        //    finally
        //    {
        //        this.dbConnection?.Close();
        //    }
        //}

        // Historial de ofertas de un docente
        public async Task<IEnumerable<ReadHistorialOfertasDocenteResponse>> readHistorialOfertasDocente(ReadHistorialOfertasDocenteRequest request)
        {
            try
            {
                dbConnection.Open();
                var parameters = new DynamicParameters();
                parameters.Add(StoredProcedureResources.idUsuarioDocente, request.idUsuarioDocente);

                var result = await dbConnection.QueryAsync<ReadHistorialOfertasDocenteResponse>(
                           sql: StoredProcedureResources.sp_OfertasTrabajo_HistorialDocente_Consultar,
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

        // Listado de ofertas activas de un docente
        public async Task<IEnumerable<ReadOfertasActivasDocenteResponse>> readOfertasActivasDocente(ReadOfertasActivasDocenteRequest request)
        {
            try
            {
                dbConnection.Open();
                var parameters = new DynamicParameters();
                parameters.Add(StoredProcedureResources.idUsuarioDocente, request.idUsuarioDocente);

                var result = await dbConnection.QueryAsync<ReadOfertasActivasDocenteResponse>(
                           sql: StoredProcedureResources.sp_OfertasTrabajo_ActivasDocente_Consultar,
                           param: parameters,
                           transaction: null,
                           commandTimeout: DatabaseHelper.TIMEOUT,
                           commandType: CommandType.StoredProcedure
                        );
                if (result != null)
                {
                    foreach (ReadOfertasActivasDocenteResponse oferta in result)
                    {
                        // amarillo: a partir de un postulante
                        if (oferta.numeroPostulantes >= 1)
                            oferta.semaforo = "amarillo";
                        // verde: no tiene postulantes
                        if (oferta.numeroPostulantes == 0)
                            oferta.semaforo = "verde";
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

        // Listado de ofertas en revisión de un docente
        public async Task<IEnumerable<ReadOfertasRevisionDocenteResponse>> readOfertasRevisionDocente(ReadOfertasRevisionDocenteRequest request)
        {
            try
            {
                dbConnection.Open();
                var parameters = new DynamicParameters();
                parameters.Add(StoredProcedureResources.idUsuarioDocente, request.idUsuarioDocente);

                var result = await dbConnection.QueryAsync<ReadOfertasRevisionDocenteResponse>(
                           sql: StoredProcedureResources.sp_OfertasTrabajo_EnRevisionDocente_Consultar,
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

        // Lista de postulantes de una oferta publicada por un docente
        public async Task<IEnumerable<ReadPostulacionesOfertaResponse>> readPostulacionesOferta(ReadPostulacionesOfertaRequest request)
        {
            try
            {
                dbConnection.Open();
                var parameters = new DynamicParameters();
                parameters.Add(StoredProcedureResources.idOferta, request.idOferta);

                var result = await dbConnection.QueryAsync<ReadPostulacionesOfertaResponse>(
                           sql: StoredProcedureResources.sp_Postulaciones_Oferta_Consultar,
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

        // Actualizar contraseña de la cuenta de un usuario docente
        public async Task<UpdatePasswordDocenteResponse> updatePassword(UpdatePasswordDocenteRequest request)
        {
            try
            {
                dbConnection.Open();
                var parameters = new DynamicParameters();
                parameters.Add(StoredProcedureResources.Password, request.password);
                parameters.Add(StoredProcedureResources.idUsuarioDocente, request.idUsuario);
                parameters.Add(StoredProcedureResources.EqualPassword, direction: ParameterDirection.Output);
                parameters.Add(StoredProcedureResources.Success, direction: ParameterDirection.Output);

                await dbConnection.ExecuteAsync(
                           sql: StoredProcedureResources.sp_Docentes_Password_Actualizar,
                           param: parameters,
                           transaction: null,
                           commandTimeout: DatabaseHelper.TIMEOUT,
                           commandType: CommandType.StoredProcedure
                        );
                var success = parameters.Get<sbyte>(StoredProcedureResources.Success);
                var equalpassword = parameters.Get<sbyte>(StoredProcedureResources.EqualPassword);
                return new UpdatePasswordDocenteResponse()
                {
                    success = ByteToBoolHelper.Convert(success),
                    EqualPassword = ByteToBoolHelper.Convert(equalpassword)
                };
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
