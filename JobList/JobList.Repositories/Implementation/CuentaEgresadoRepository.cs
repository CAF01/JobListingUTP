namespace JobList.Repositories.Implementation
{
    using Dapper;
    using JobList.Entities.Helpers;
    using JobList.Entities.Models;
    using JobList.Entities.Requests;
    using JobList.Entities.Responses;
    using JobList.Repositories.Service;
    using JobList.Resources;
    using MediatR;
    using Microsoft.Extensions.Options;
    using System.Data;
    using System.Threading.Tasks;

    public class CuentaEgresadoRepository : ICuentaEgresadoRepository
    {
        private readonly ConfigurationPaging configuration;
        private readonly IDbConnection dbConnection;

        public CuentaEgresadoRepository(IDbConnection connections,IOptions<ConfigurationPaging> options)
        {
            this.configuration = options.Value;
            this.dbConnection = connections;
        }

        public async Task<int> addConocimientoEgresado(InsertConocimientoEgresadoRequest request)
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

        public async Task<int> addEgresado(InsertEgresadoRequest request)
        {
            try
            {
                dbConnection.Open();
                var idEgresado = 0;
                using (var transaction = dbConnection.BeginTransaction())
                {
                    try
                    {
                        var parameters = new DynamicParameters();
                        parameters.Add(StoredProcedureResources.idTipoBuscado, 1);//Enumerador en SP esta definido 1 para egresados
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
                            parameters.Add(StoredProcedureResources.Apellido, request.apellido);
                            parameters.Add(StoredProcedureResources.idArea, request.idArea);
                            parameters.Add(StoredProcedureResources.Sexo, request.sexo);
                            parameters.Add(StoredProcedureResources.Generacion, request.generacion);
                            parameters.Add(StoredProcedureResources.idNuevoEgresado, direction: ParameterDirection.Output);


                            await dbConnection.ExecuteAsync(
                               sql: StoredProcedureResources.sp_Egresados_Agregar,
                               transaction: transaction,
                               param: parameters,
                               commandTimeout: DatabaseHelper.TIMEOUT,
                               commandType: CommandType.StoredProcedure);
                            idEgresado = parameters.Get<int>(StoredProcedureResources.idNuevoEgresado);
                        }

                        transaction.Commit();
                    }
                    catch (Exception s)
                    {
                        transaction.Rollback();
                    }
                }
                return idEgresado;
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

        public async Task<int> addExperienciaLaboral(InsertEgresadoExpLaboralRequest request)
        {
            try
            {
                dbConnection.Open();
                var parameters = new DynamicParameters();
                parameters.Add(StoredProcedureResources.idUsuarioEgresado, request.idUsuarioEgresado);
                parameters.Add(StoredProcedureResources.Empresa, request.empresa);
                parameters.Add(StoredProcedureResources.Cargo, request.cargo);
                parameters.Add(StoredProcedureResources.Periodo, request.periodo);
                parameters.Add(StoredProcedureResources.Salario, request.salario);
                parameters.Add(StoredProcedureResources.idNuevaExperiencia,direction:ParameterDirection.Output);

                await dbConnection.ExecuteAsync(
                           sql: StoredProcedureResources.sp_HabilidadesEgresado_Insertar,
                           param: parameters,
                           transaction: null,
                           commandTimeout: DatabaseHelper.TIMEOUT,
                           commandType: CommandType.StoredProcedure
                        );

                var idNuevaExperiencia = parameters.Get<int>(StoredProcedureResources.idNuevoUsuario);
                return idNuevaExperiencia;
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

        public async Task<int> addHabilidadEgresado(InsertHabilidadEgresadoRequest request)
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

        public async Task<LoginEgresadoResponse> findEgresado(LoginEgresadoRequest request)
        {
            try
            {
                dbConnection.Open();
                var parameters = new DynamicParameters();
                parameters.Add(StoredProcedureResources.Usuario, request.usuario);
                parameters.Add(StoredProcedureResources.Password, request.password);

                var result = await dbConnection.QueryFirstAsync<LoginEgresadoResponse>(
                    sql: StoredProcedureResources.sp_LoginEgresado,
                    param: parameters,
                    transaction: null,
                    commandTimeout: DatabaseHelper.TIMEOUT,
                    commandType: CommandType.StoredProcedure);
                return result;
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

        public async Task<GetEgresadoBasicInfoResponse> GetBasicInfo(GetEgresadoBasicInfoRequest request)
        {
            try
            {
                dbConnection.Open();
                var parameters = new DynamicParameters();
                parameters.Add(StoredProcedureResources.idUsuario, request.idUsuario);

                var result = await dbConnection.QueryFirstAsync<GetEgresadoBasicInfoResponse>(
                    sql: StoredProcedureResources.sp_Egresado_Informacion_Basica_Consultar,
                    param: parameters,
                    transaction: null,
                    commandTimeout: DatabaseHelper.TIMEOUT,
                    commandType: CommandType.StoredProcedure);
                return result;
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

        public async Task<GetEgresadoInfoPersonalResponse> getInfoEgresado(GetEgresadoInfoPersonalRequest request)
        {
            try
            {
                dbConnection.Open();
                var parameters = new DynamicParameters();
                parameters.Add(StoredProcedureResources.idUsuario, request.idUsuario);

                var result = await dbConnection.QueryFirstAsync<GetEgresadoInfoPersonalResponse>(
                    sql: StoredProcedureResources.sp_Egresado_DatosPersonales_Consultar,
                    param: parameters,
                    transaction: null,
                    commandTimeout: DatabaseHelper.TIMEOUT,
                    commandType: CommandType.StoredProcedure);
                return result;
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

        public async Task<GetEgresadoInfoPerfilResponse> getInfoPerfilEgresado(GetEgresadoInfoPerfilRequest request)
        {
            try
            {
                var result = new GetEgresadoInfoPerfilResponse();

                dbConnection.Open();
                using (var transaction = dbConnection.BeginTransaction())
                {
                    try
                    {
                        var parameters = new DynamicParameters(); 
                        parameters.Add(StoredProcedureResources.idUsuario, request.idUsuario);

                        result.personal = await dbConnection.QueryFirstAsync<GetEgresadoInfoPersonalResponse>(
                           sql: StoredProcedureResources.sp_Egresado_DatosPersonales_Consultar,
                           transaction: transaction,
                           param: parameters,
                           commandTimeout: DatabaseHelper.TIMEOUT,
                           commandType: CommandType.StoredProcedure);

                        result.habilidades = await dbConnection.QueryAsync<GetEgresadoHabilidadesResponse>(
                            sql: StoredProcedureResources.sp_Egresado_Habilidades_Consultar,
                            transaction: transaction,
                            param: parameters,
                            commandTimeout: DatabaseHelper.TIMEOUT,
                            commandType: CommandType.StoredProcedure
                            );

                        result.conocimientos = await dbConnection.QueryAsync<GetEgresadoConocimientosResponse>(
                            sql: StoredProcedureResources.sp_Egresado_Conocimientos_Consultar,
                            transaction: transaction,
                            param: parameters,
                            commandTimeout: DatabaseHelper.TIMEOUT,
                            commandType: CommandType.StoredProcedure
                            );

                        result.experienciasLaborales = await dbConnection.QueryAsync<GetEgresadoExpLaboralResponse>(
                            sql: StoredProcedureResources.sp_Egresado_ExperienciasLaborales_Consultar,
                            transaction: transaction,
                            param: parameters,
                            commandTimeout: DatabaseHelper.TIMEOUT,
                            commandType: CommandType.StoredProcedure
                            );

                        transaction.Commit();
                    }
                    catch (Exception s)
                    {
                        transaction.Rollback();
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
                dbConnection?.Close();
            }
        }

        public async Task<PaginationListResponse<GetEgresadoListaOfertasActivasResponse>> getOfertasActivasEgresado(GetEgresadoListaOfertasActivasRequest request)
        {
            try
            {
                PaginationListResponse<GetEgresadoListaOfertasActivasResponse> paginator = null;
                dbConnection.Open();
                using (var transaction = dbConnection.BeginTransaction())
                {
                    try
                    {
                        var parameters = new DynamicParameters();
                        parameters.Add(StoredProcedureResources.idUsuario, request.idUsuario);
                        parameters.Add(StoredProcedureResources.Skip,request.Skip);
                        parameters.Add(StoredProcedureResources.Take, request.Take);

                        var result = await dbConnection.QueryMultipleAsync(
                            sql: StoredProcedureResources.sp_OfertasTrabajo_ActivasEgresado_Consultar,
                            transaction: transaction,
                            param: parameters,
                            commandTimeout: DatabaseHelper.TIMEOUT,
                            commandType: CommandType.StoredProcedure
                            );

                        var dynamicResult = result.Read<GetEgresadoListaOfertasActivasResponse>();

                        paginator = new PaginationListResponse<GetEgresadoListaOfertasActivasResponse>(dynamicResult, dynamicResult.Count(), configuration.PageSize);

                        if(result!= null && paginator.Data!=null && paginator.Data.Count()>0)
                        {
                            foreach (var ofertaActiva in paginator.Data)
                            {
                                if(ofertaActiva.postulantes>0)
                                {
                                    ofertaActiva.tienePostulantes = true;

                                    parameters = new DynamicParameters();
                                    parameters.Add(StoredProcedureResources.idOferta, ofertaActiva.idOferta);

                                    ofertaActiva.ListaPostulantes = await dbConnection.QueryAsync<PostulanteOferta>(
                                        sql: StoredProcedureResources.sp_OfertasTrabajo_Lista_Postulaciones,
                                        transaction: transaction,
                                        param: parameters,
                                        commandTimeout: DatabaseHelper.TIMEOUT,
                                        commandType: CommandType.StoredProcedure
                                        );
                                }
                               
                            }
                        }

                        transaction.Commit();
                    }
                    catch (Exception s)
                    {
                        transaction.Rollback();
                    }
                }
                return paginator;
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

        public async Task<PaginationListResponse<GetEgresadoOfertasHistorialResponse>> getOfertasHistorialEgresado(GetEgresadoOfertasHistorialRequest request)
        {
            try
            {
                dbConnection.Open();

                var parameters = new DynamicParameters();
                parameters.Add(StoredProcedureResources.idUsuario, request.idUsuario);
                parameters.Add(StoredProcedureResources.Skip, request.Skip);
                parameters.Add(StoredProcedureResources.Take, request.Take);

                var result = await dbConnection.QueryMultipleAsync(
                    sql: StoredProcedureResources.sp_OfertasTrabajo_HistorialEgresado_Consultar,
                    transaction: null,
                    param: parameters,
                    commandTimeout: DatabaseHelper.TIMEOUT,
                    commandType: CommandType.StoredProcedure
                    );

                var dynamicResult = result.Read<GetEgresadoOfertasHistorialResponse>();
                return new PaginationListResponse<GetEgresadoOfertasHistorialResponse>(dynamicResult,dynamicResult.Count(),configuration.PageSize);
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

        public async Task<PaginationListResponse<GetEmpresaOfertasRevisionResponse>> getOfertasRevisionEgresado(GetEgresadoOfertasRevisionRequest request)
        {
            try
            {
                dbConnection.Open();

                var parameters = new DynamicParameters();
                parameters.Add(StoredProcedureResources.idUsuario, request.idUsuario);
                parameters.Add(StoredProcedureResources.Skip, request.Skip);
                parameters.Add(StoredProcedureResources.Take, request.Take);

                var result = await dbConnection.QueryMultipleAsync(
                    sql: StoredProcedureResources.sp_OfertasTrabajo_EnRevisionEgresado_Consultar,
                    transaction: null,
                    param: parameters,
                    commandTimeout: DatabaseHelper.TIMEOUT,
                    commandType: CommandType.StoredProcedure
                    );

                var dynamicResult = result.Read<GetEmpresaOfertasRevisionResponse>();
                return new PaginationListResponse<GetEmpresaOfertasRevisionResponse>(dynamicResult, dynamicResult.Count(), configuration.PageSize);
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

        public async Task<PaginationListResponse<GetEgresadoPostulacionesResponse>> getPostulacionesEgresado(GetEgresadoPostulacionesRequest request)
        {
            try
            {
                PaginationListResponse<GetEgresadoPostulacionesResponse> pagination = null;
                dbConnection.Open();
                using (var transaction = dbConnection.BeginTransaction())
                {
                    try
                    {
                        var parameters = new DynamicParameters();
                        parameters.Add(StoredProcedureResources.idUsuario, request.idUsuario);
                        parameters.Add(StoredProcedureResources.Skip, request.Skip);
                        parameters.Add(StoredProcedureResources.Take, request.Take);

                        var result = await dbConnection.QueryMultipleAsync(
                            sql: StoredProcedureResources.sp_Postulaciones_Egresado_Consultar,
                            param: parameters,
                            transaction: transaction,
                            commandTimeout: DatabaseHelper.TIMEOUT,
                            commandType: CommandType.StoredProcedure);

                        var dynamicResult = result.Read<GetEgresadoPostulacionesResponse>();
                        pagination = new PaginationListResponse<GetEgresadoPostulacionesResponse>(dynamicResult, dynamicResult.Count(), configuration.PageSize);

                        if (result != null && pagination.Data!=null && pagination.Data.Count() > 0)
                        {
                            foreach (var datoContacto in pagination.Data)
                            {
                                if (datoContacto.estadoPostulacion == StoredProcedureResources.OfertaAceptada)
                                {
                                    parameters = new DynamicParameters();
                                    parameters.Add(StoredProcedureResources.idPostulacion, datoContacto.idPostulacion);
                                    datoContacto.datoContacto = await dbConnection.QueryFirstAsync<DatosContactoAceptado>(
                                        sql: StoredProcedureResources.sp_DetallesContacto_PostulacionAceptada_Consultar,
                                        param: parameters,
                                        transaction: transaction,
                                        commandTimeout: DatabaseHelper.TIMEOUT,
                                        commandType: CommandType.StoredProcedure);
                                    datoContacto.datoContacto.success = true;
                                }
                            }
                        }
                        transaction.Commit();
                    }
                    catch
                    {
                        transaction.Rollback();
                        return null;
                    }
                    return pagination;
                }
            }
            catch (Exception)
            {
                return null;
            }
            finally
            {
                dbConnection?.Close();
            }
        }

        public async Task<string> getUrlById(int idUsuario)
        {
            try
            {
                dbConnection.Open();
                var parameters = new DynamicParameters();
                parameters.Add(StoredProcedureResources.idUsuario, idUsuario);

                var result = await dbConnection.QueryFirstAsync<string>(
                    sql: StoredProcedureResources.sp_Egresados_get_imgUrl,
                    param: parameters,
                    transaction: null,
                    commandTimeout: DatabaseHelper.TIMEOUT,
                    commandType: CommandType.StoredProcedure);
                return result;
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

        public async Task<PaginationListResponse<ReadOfertasActivasFiltroEgresadoResponse>> readOfertasActivasFiltroEgresado(ReadOfertasActivasFiltroEgresadoRequest request)
        {
            try
            {
                PaginationListResponse<ReadOfertasActivasFiltroEgresadoResponse> pagination = null;
                dbConnection.Open();

                var parameters = new DynamicParameters();
                parameters.Add(StoredProcedureResources.idUsuarioEgresado, request.idUsuarioEgresado);
                parameters.Add(StoredProcedureResources.Skip, request.Skip);
                parameters.Add(StoredProcedureResources.Take, request.Take);

                var result = await dbConnection.QueryMultipleAsync(
                    sql: StoredProcedureResources.sp_OfertasTrabajo_FiltroEgresado_Consultar,
                    transaction: null,
                    param: parameters,
                    commandTimeout: DatabaseHelper.TIMEOUT,
                    commandType: CommandType.StoredProcedure
                    );

                var dynamicResult = result.Read<ReadOfertasActivasFiltroEgresadoResponse>();

                pagination = new PaginationListResponse<ReadOfertasActivasFiltroEgresadoResponse>(dynamicResult, dynamicResult.Count(), configuration.PageSize);

                if (result != null && pagination!=null && pagination.Data!=null && pagination.Data.Count()>0)
                {
                    foreach (ReadOfertasActivasFiltroEgresadoResponse oferta in pagination.Data)
                    {
                        // amarillo: a partir de un postulante
                        if (oferta.postulantes >= 1)
                            oferta.semaforo = "amarillo";
                        // verde: no tiene postulantes
                        if (oferta.postulantes == 0)
                            oferta.semaforo = "verde";
                    }
                }

                return pagination;
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

        public async Task<bool> updateDatosPersonales(UpdateEgresadoDatosPersonalesRequest request)
        {
            try
            {
                dbConnection.Open();
                var parameters = new DynamicParameters();
                parameters.Add(StoredProcedureResources.idUsuario, request.idUsuario);
                parameters.Add(StoredProcedureResources.Correo, request.correo);
                parameters.Add(StoredProcedureResources.idGenero, request.genero);
                parameters.Add(StoredProcedureResources.Edad, request.edad);
                parameters.Add(StoredProcedureResources.Telefono, request.telefono);
                parameters.Add(StoredProcedureResources.DescripcionEgresado, request.descripcionEgresado);
                parameters.Add(StoredProcedureResources.idArea, request.idArea);
                parameters.Add(StoredProcedureResources.Nombre, request.nombre);
                parameters.Add(StoredProcedureResources.Apellido, request.apellido);
                parameters.Add(StoredProcedureResources.Generacion, request.generacion);

                var result = await dbConnection.ExecuteAsync(
                           sql: StoredProcedureResources.sp_Egresados_DatosPersonales_Actualizar,
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
                dbConnection?.Close();
            }
        }

        public async Task<updateEgresadoFotoResponse> updateFoto(updateEgresadoFotoRequest request)
        {
            try
            {
                dbConnection.Open();
                var parameters = new DynamicParameters();
                parameters.Add(StoredProcedureResources.idUsuario, request.idUsuario);
                parameters.Add(StoredProcedureResources.ImgUrl, request.path);

                var result = await dbConnection.ExecuteAsync(
                           sql: StoredProcedureResources.sp_updateFotoEgresado,
                           param: parameters,
                           transaction: null,
                           commandTimeout: DatabaseHelper.TIMEOUT,
                           commandType: CommandType.StoredProcedure
                        );
                return new updateEgresadoFotoResponse() { success = (result > 0) };
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

        public async Task<UpdatePasswordEgresadoResponse> updatePassword(UpdatePasswordEgresadoRequest request)
        {
            try
            {
                dbConnection.Open();
                var parameters = new DynamicParameters();
                parameters.Add(StoredProcedureResources.Password, request.password);
                parameters.Add(StoredProcedureResources.idUsuarioEgresado, request.idUsuario);
                parameters.Add(StoredProcedureResources.EqualPassword, direction: ParameterDirection.Output);
                parameters.Add(StoredProcedureResources.Success, direction: ParameterDirection.Output);

                await dbConnection.ExecuteAsync(
                           sql: StoredProcedureResources.sp_Egresados_Password_Actualizar,
                           param: parameters,
                           transaction: null,
                           commandTimeout: DatabaseHelper.TIMEOUT,
                           commandType: CommandType.StoredProcedure
                        );
                var success = parameters.Get<sbyte>(StoredProcedureResources.Success);
                var equalpassword = parameters.Get<sbyte>(StoredProcedureResources.EqualPassword);
                return new UpdatePasswordEgresadoResponse()
                {
                    success =  ByteToBoolHelper.Convert(success),
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

        public async Task<UpdatePerfilEgresadoResponse> updatePerfil(UpdatePerfilEgresadoRequest request)
        {
            try
            {
                var result = new UpdatePerfilEgresadoResponse();

                dbConnection.Open();
                using (var transaction = dbConnection.BeginTransaction())
                {
                    try
                    {
                        var parameters = new DynamicParameters(); //Actualizar datos personales de egresado
                        parameters.Add(StoredProcedureResources.idUsuario, request.idUsuario);
                        parameters.Add(StoredProcedureResources.Correo, request.correo);
                        parameters.Add(StoredProcedureResources.idGenero, request.genero);
                        parameters.Add(StoredProcedureResources.Edad, request.edad);
                        parameters.Add(StoredProcedureResources.Telefono, request.telefono);
                        parameters.Add(StoredProcedureResources.DescripcionEgresado, request.descripcionEgresado);
                        parameters.Add(StoredProcedureResources.idArea, request.idArea);
                        parameters.Add(StoredProcedureResources.Nombre, request.nombre);
                        parameters.Add(StoredProcedureResources.Apellido, request.apellido);
                        parameters.Add(StoredProcedureResources.ImgUrl, request.imgUrl);
                        parameters.Add(StoredProcedureResources.Generacion, request.generacion);

                        var registrosModificados = await dbConnection.ExecuteAsync(
                           sql: StoredProcedureResources.sp_Egresados_DatosPersonales_Actualizar,
                           transaction: transaction,
                           param: parameters,
                           commandTimeout: DatabaseHelper.TIMEOUT,
                           commandType: CommandType.StoredProcedure);
                        if (registrosModificados > 0)
                            result.successPerfil = true;

                        if (request.ListHabilidadesNuevas.Count > 0)
                        {
                            foreach (var nuevaHabilidad in request.ListHabilidadesNuevas)
                            {
                                parameters = new DynamicParameters(); //Añadir nuevas habilidades
                                parameters.Add(StoredProcedureResources.idUsuarioEgresado, nuevaHabilidad.idUsuarioEgresado);
                                parameters.Add(StoredProcedureResources.idHabilidad, nuevaHabilidad.idHabilidad);
                                await dbConnection.ExecuteAsync(
                                   sql: StoredProcedureResources.sp_HabilidadesEgresado_Insertar,
                                   transaction: transaction,
                                   param: parameters,
                                   commandTimeout: DatabaseHelper.TIMEOUT,
                                   commandType: CommandType.StoredProcedure);
                            }
                            result.successHabilidades = true;
                        }
                        if (request.ListConocimientosNuevos.Count > 0)
                        {
                            foreach (var nuevoConocimiento in request.ListConocimientosNuevos)
                            {
                                parameters = new DynamicParameters(); //Añadir nuevos conocimientos
                                parameters.Add(StoredProcedureResources.idUsuarioEgresado, nuevoConocimiento.idUsuarioEgresado);
                                parameters.Add(StoredProcedureResources.idConocimiento, nuevoConocimiento.idConocimiento);
                                await dbConnection.ExecuteAsync(
                                   sql: StoredProcedureResources.sp_ConocimientosEgresado_Insertar,
                                   transaction: transaction,
                                   param: parameters,
                                   commandTimeout: DatabaseHelper.TIMEOUT,
                                   commandType: CommandType.StoredProcedure);
                            }
                            result.successConocimientos = true;
                        }
                        if (request.ListExperienciaLaboralNuevas.Count > 0)
                        {
                            result.successExperiencias = true;
                            foreach (var nuevaExperiencia in request.ListExperienciaLaboralNuevas)
                            {
                                parameters = new DynamicParameters(); //Añadir nuevas experiencias
                                parameters.Add(StoredProcedureResources.Empresa, nuevaExperiencia.empresa);
                                parameters.Add(StoredProcedureResources.Cargo, nuevaExperiencia.cargo);
                                parameters.Add(StoredProcedureResources.Salario, nuevaExperiencia.salario);
                                parameters.Add(StoredProcedureResources.Periodo, nuevaExperiencia.periodo);
                                parameters.Add(StoredProcedureResources.idUsuarioEgresado, nuevaExperiencia.idUsuarioEgresado);
                                parameters.Add(StoredProcedureResources.idNuevaExperiencia, direction:ParameterDirection.Output);
                                await dbConnection.ExecuteAsync(
                                   sql: StoredProcedureResources.sp_Egresado_ExLa_Insertar,
                                   transaction: transaction,
                                   param: parameters,
                                   commandTimeout: DatabaseHelper.TIMEOUT,
                                   commandType: CommandType.StoredProcedure);
                                var idNuevaExperiencia = parameters.Get<int>(StoredProcedureResources.idNuevaExperiencia);
                                if (idNuevaExperiencia < 1)
                                    result.successExperiencias = false;
                            }
                            
                        }
                        if (request.ListHabilidadesBorrar.Count > 0)
                        {
                            foreach (var borrarHabilidad in request.ListHabilidadesBorrar)
                            {
                                parameters = new DynamicParameters(); //Borrar habilidades
                                parameters.Add(StoredProcedureResources.idUsuarioEgresado, borrarHabilidad.idUsuarioEgresado);
                                parameters.Add(StoredProcedureResources.idHabilidad, borrarHabilidad.idHabilidad);
                                await dbConnection.ExecuteAsync(
                                   sql: StoredProcedureResources.sp_HabilidadesEgresado_Eliminar,
                                   transaction: transaction,
                                   param: parameters,
                                   commandTimeout: DatabaseHelper.TIMEOUT,
                                   commandType: CommandType.StoredProcedure);
                            }
                            result.successDeleteHabilidades = true;
                        }
                        if (request.ListConocimientosNuevos.Count > 0)
                        {
                            foreach (var borrarConocimiento in request.ListConocimientosBorrar)
                            {
                                parameters = new DynamicParameters(); //Borrar conocimientos
                                parameters.Add(StoredProcedureResources.idUsuarioEgresado, borrarConocimiento.idUsuarioEgresado);
                                parameters.Add(StoredProcedureResources.idConocimiento, borrarConocimiento.idConocimiento);
                                await dbConnection.ExecuteAsync(
                                   sql: StoredProcedureResources.sp_ConocimientosEgresado_Eliminar,
                                   transaction: transaction,
                                   param: parameters,
                                   commandTimeout: DatabaseHelper.TIMEOUT,
                                   commandType: CommandType.StoredProcedure);
                            }
                            result.successDeleteConocimientos = true;
                        }
                        if(request.ListExperienciaLaboralBorrar.Count > 0)
                        {
                            foreach (var borrarExperiencia in request.ListExperienciaLaboralBorrar)
                            {
                                parameters = new DynamicParameters(); //Borrar Experiencia Laboral
                                parameters.Add(StoredProcedureResources.idExperiencia,borrarExperiencia.idExperiencia);
                                await dbConnection.ExecuteAsync(
                                   sql: StoredProcedureResources.sp_Egresado_ExLa_Eliminar,
                                   transaction: transaction,
                                   param: parameters,
                                   commandTimeout: DatabaseHelper.TIMEOUT,
                                   commandType: CommandType.StoredProcedure);
                            }
                            result.successDeleteExperienciaLaboral = true;
                        }

                        transaction.Commit();
                    }
                    catch (Exception s)
                    {
                        transaction.Rollback();
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
                dbConnection?.Close();
            }
        }

        public async Task<bool> updateUltimoAccesoSistema(int idUsuario)
        {
            try
            {
                dbConnection.Open();
                var parameters = new DynamicParameters();
                parameters.Add(StoredProcedureResources.idUsuario, idUsuario);
                parameters.Add(StoredProcedureResources.Fecha, MexicoDateHelper.obtainDate());

                var result = await dbConnection.ExecuteAsync(
                           sql: StoredProcedureResources.sp_Egresados_UltimoAcceso_Actualizar,
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
                dbConnection?.Close();
            }
        }
    }
}
