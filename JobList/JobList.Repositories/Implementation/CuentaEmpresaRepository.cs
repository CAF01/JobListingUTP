namespace JobList.Repositories.Implementation 
{
    using Dapper;
    using JobList.Entities.Helpers;
    using JobList.Entities.Models;
    using JobList.Entities.Requests;
    using JobList.Resources;
    using System.Data;
    using JobList.Repositories.Service;
    using JobList.Entities.Responses;
    using System.Collections.Generic;

    public class CuentaEmpresaRepository : ICuentaEmpresaRepository
    {
        private readonly Dictionary<string, IDbConnection> connections;
        private readonly IDbConnection dbConnection;

        // Constructor
        public CuentaEmpresaRepository(Dictionary<string, IDbConnection> connections)
        {
            this.connections = connections;
            this.dbConnection = connections[ConfigResources.DefaultConnection];
        }

        // Encontrar la cuenta de usuario de una empresa
        public async Task<EmpresaInfo> findEmpresa(LoginEmpresaRequest userLogin)
        {
            try
            {
                dbConnection.Open();
                var parameters = new DynamicParameters();
                parameters.Add(StoredProcedureResources.Usuario, userLogin.usuario);
                parameters.Add(StoredProcedureResources.Password, userLogin.password);

                return await dbConnection.QueryFirstAsync<EmpresaInfo>(
                    sql: StoredProcedureResources.sp_LoginEmpresa,
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

        public async Task<bool> deleteOfertaFallida(int idOferta)
        {
            try
            {
                dbConnection.Open();
                var parameters = new DynamicParameters();
                parameters.Add(StoredProcedureResources.idOferta, idOferta);

                var result = await dbConnection.QueryFirstAsync(
                    sql: StoredProcedureResources.sp_OfertasTrabajo_EmpresaFallo_Eliminar,
                    param: parameters,
                    transaction: null,
                    commandTimeout: DatabaseHelper.TIMEOUT,
                    commandType: CommandType.StoredProcedure);


                return result > 0 ;
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

        public async Task<InsertOfertaTrabajoResponse> insertOfertaTrabajo(InsertOfertaTrabajoRequest request)
        {
            try
            {
                var idOferta = 0;
                var response = new InsertOfertaTrabajoResponse();

                dbConnection.Open();
                using (var transaction = dbConnection.BeginTransaction())
                {
                    try
                    {
                        var parameters = new DynamicParameters();
                        parameters.Add(StoredProcedureResources.DescripcionPuesto, request.descripcionPuesto);
                        parameters.Add(StoredProcedureResources.idArea, request.idArea);
                        parameters.Add(StoredProcedureResources.PeriodoContrato, request.periodoContrato);
                        parameters.Add(StoredProcedureResources.Modalidad, request.modalidad);
                        parameters.Add(StoredProcedureResources.HorarioTrabajo, request.horarioTrabajo);
                        parameters.Add(StoredProcedureResources.SueldoMinEstimado, request.sueldoMinEstimado);
                        parameters.Add(StoredProcedureResources.SueldoMaxEstimado, request.suelodMaxEstimado);
                        parameters.Add(StoredProcedureResources.Lugar, request.lugar);
                        parameters.Add(StoredProcedureResources.FechaCreacion, request.fechaCreacion);


                        parameters.Add(StoredProcedureResources.idNuevaOferta, direction:ParameterDirection.Output);

                        await dbConnection.ExecuteAsync(
                                           sql: StoredProcedureResources.sp_OfertasTrabajo_Crear,
                                           transaction: transaction,
                                           param: parameters,
                                           commandTimeout: DatabaseHelper.TIMEOUT,
                                           commandType: CommandType.StoredProcedure);

                        idOferta= parameters.Get<int>(StoredProcedureResources.idNuevaOferta);
                        if(idOferta>0)
                        {
                            if(request.conocimientos.ToList().Count>0)//fluent No nulo
                            {
                                foreach (var conocimiento in request.conocimientos)
                                {
                                    parameters = new DynamicParameters();
                                    parameters.Add(StoredProcedureResources.idOferta, idOferta);
                                    parameters.Add(StoredProcedureResources.idConocimiento, conocimiento.idConocimiento);

                                    await dbConnection.ExecuteAsync(
                                           sql: StoredProcedureResources.sp_ConocimientosOferta_Insertar,
                                           transaction: transaction,
                                           param: parameters,
                                           commandTimeout: DatabaseHelper.TIMEOUT,
                                           commandType: CommandType.StoredProcedure);
                                }
                            }
                            if (request.habilidades.ToList().Count > 0)//fluent No nulo
                            {
                                foreach (var habilidad in request.habilidades)
                                {
                                    parameters = new DynamicParameters();
                                    parameters.Add(StoredProcedureResources.idOferta, idOferta);
                                    parameters.Add(StoredProcedureResources.idHabilidad, habilidad.idHabilidad);
                                    
                                    await dbConnection.ExecuteAsync(
                                           sql: StoredProcedureResources.sp_HabilidadesOferta_Insertar,
                                           transaction: transaction,
                                           param: parameters,
                                           commandTimeout: DatabaseHelper.TIMEOUT,
                                           commandType: CommandType.StoredProcedure);
                                }
                            }
                            if (request.responsabilidades.ToList().Count > 0)
                            {
                                foreach (var responsabilidad in request.responsabilidades)
                                {
                                    parameters = new DynamicParameters();
                                    parameters.Add(StoredProcedureResources.idOferta, idOferta);
                                    parameters.Add(StoredProcedureResources.Descripcion, responsabilidad.descripcion);
                                    parameters.Add(StoredProcedureResources.idNuevaResponsabilidad, direction:ParameterDirection.Output);
                                    
                                    await dbConnection.ExecuteAsync(
                                           sql: StoredProcedureResources.sp_ResponsabilidadesOferta_Insertar,
                                           transaction: transaction,
                                           param: parameters,
                                           commandTimeout: DatabaseHelper.TIMEOUT,
                                           commandType: CommandType.StoredProcedure);
                                    var nuevaResponsabilidad = parameters.Get<int>(StoredProcedureResources.idNuevaResponsabilidad);
                                    if(nuevaResponsabilidad> 0)
                                        continue;
                                }
                            }
                            if (request.beneficios.ToList().Count > 0)
                            {
                                foreach (var beneficio in request.beneficios)
                                {
                                    var campoBeneficiosActualizado = false;
                                    parameters = new DynamicParameters();
                                    parameters.Add(StoredProcedureResources.idOferta, idOferta);
                                    parameters.Add(StoredProcedureResources.Descripcion, beneficio.descripcion);
                                    parameters.Add(StoredProcedureResources.idNuevoBeneficio, direction: ParameterDirection.Output);

                                    await dbConnection.ExecuteAsync(
                                           sql: StoredProcedureResources.sp_BeneficiosOferta_Insertar,
                                           transaction: transaction,
                                           param: parameters,
                                           commandTimeout: DatabaseHelper.TIMEOUT,
                                           commandType: CommandType.StoredProcedure);
                                    var nuevoBeneficio = parameters.Get<int>(StoredProcedureResources.idNuevoBeneficio);

                                    if (!campoBeneficiosActualizado && nuevoBeneficio > 0)
                                    {
                                        parameters = new DynamicParameters();
                                        parameters.Add(StoredProcedureResources.idOferta, idOferta);
                                        parameters.Add(StoredProcedureResources.Status, true);
                                        await dbConnection.ExecuteAsync(
                                           sql: StoredProcedureResources.sp_OfertaTrabajo_BanderaBeneficios_Actualizar,
                                           transaction: transaction,
                                           param: parameters,
                                           commandTimeout: DatabaseHelper.TIMEOUT,
                                           commandType: CommandType.StoredProcedure);
                                        campoBeneficiosActualizado= true;
                                    }
                                }
                            }

                            //Datos Contacto
                            parameters = new DynamicParameters();
                            parameters.Add(StoredProcedureResources.idUsuarioEmpresa, request.idUsuarioEmpresa);
                            parameters.Add(StoredProcedureResources.idOferta, idOferta);
                            parameters.Add(StoredProcedureResources.idDatoContacto, direction:ParameterDirection.Output);

                            await dbConnection.ExecuteAsync(
                                           sql: StoredProcedureResources.sp_Empresa_DatosContacto_Insertar,
                                           transaction: transaction,
                                           param: parameters,
                                           commandTimeout: DatabaseHelper.TIMEOUT,
                                           commandType: CommandType.StoredProcedure);

                            var idDatoContacto = parameters.Get<int>(StoredProcedureResources.idDatoContacto);
                            if(idDatoContacto>0)
                            {
                                parameters = new DynamicParameters();
                                parameters.Add(StoredProcedureResources.idUsuario, request.idUsuarioEmpresa);
                                parameters.Add(StoredProcedureResources.idDatoContacto, idDatoContacto);
                                parameters.Add(StoredProcedureResources.idDetalleContacto, direction: ParameterDirection.Output);

                                await dbConnection.ExecuteAsync(
                                           sql: StoredProcedureResources.sp_OfertaTrabajo_DetallesContactoEmpresa_Insertar,
                                           transaction: transaction,
                                           param: parameters,
                                           commandTimeout: DatabaseHelper.TIMEOUT,
                                           commandType: CommandType.StoredProcedure);
                                var idDetalleContacto = parameters.Get<int>(StoredProcedureResources.idDetalleContacto);
                            }

                            response.idOferta = idOferta;
                            transaction.Commit();
                        }
                        else
                            transaction.Rollback();
                    }
                    catch (Exception s)
                    {
                        //Función para ver que no se haya insertado algo
                        //En ese caso borrarlo
                        if (idOferta>0)
                        {
                            await this.deleteOfertaFallida(idOferta);
                            response.idOferta= -1;
                        }
                        transaction.Rollback();
                    }
                }
                return response;
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

        public async Task<InsertEmpresaResponse> insertCuentaEmpresa(InsertEmpresaRequest request)
        {
            try
            {
                dbConnection.Open();
                var response = new InsertEmpresaResponse();

                using (var transaction = dbConnection.BeginTransaction())
                {
                    try
                    {
                        var parameters = new DynamicParameters();
                        parameters.Add(StoredProcedureResources.idTipoBuscado, 4);//Enumerador en SP esta definido 4 para empresa
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
                            parameters.Add(StoredProcedureResources.NombreResponsable, request.nombreResponsable);
                            parameters.Add(StoredProcedureResources.NombreEmpresa,request.nombreEmpresa);
                            parameters.Add(StoredProcedureResources.idEmpresa, direction: ParameterDirection.Output);


                            await dbConnection.ExecuteAsync(
                               sql: StoredProcedureResources.sp_Empresa_crearCuenta,
                               transaction: transaction,
                               param: parameters,
                               commandTimeout: DatabaseHelper.TIMEOUT,
                               commandType: CommandType.StoredProcedure);
                            response.idEmpresa = parameters.Get<int>(StoredProcedureResources.idEmpresa);
                        }

                        transaction.Commit();
                    }
                    catch (Exception s)
                    {
                        transaction.Rollback();
                    }
                }
                return response;
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

        public async Task<UpdateEmpresaDatosResponse> updateDatosEmpresa(UpdateEmpresaDatosRequest request)
        {
            try
            {
                var response = new UpdateEmpresaDatosResponse();

                dbConnection.Open();
                var parameters = new DynamicParameters();
                parameters.Add(StoredProcedureResources.idUsuario, request.idUsuario);
                parameters.Add(StoredProcedureResources.NombreEmpresa, request.nombreEmpresa);
                parameters.Add(StoredProcedureResources.NombreResponsable, request.nombreResponsable);
                parameters.Add(StoredProcedureResources.RFC, request.RFC);
                parameters.Add(StoredProcedureResources.Tamano, request.tamano);
                parameters.Add(StoredProcedureResources.Tipo, request.tipoEmpresa);
                parameters.Add(StoredProcedureResources.Giro, request.giroEmpresa);
                parameters.Add(StoredProcedureResources.ActividadPrincipal, request.actividadPrincipal);
                parameters.Add(StoredProcedureResources.DomicilioFiscal, request.domicilio);
                parameters.Add(StoredProcedureResources.CP, request.CP);
                parameters.Add(StoredProcedureResources.Telefonos, request.telefonos);
                parameters.Add(StoredProcedureResources.CorreoEmpresa, request.correoElectronico);
                parameters.Add(StoredProcedureResources.TelefonoResponsable, request.telefonoResponsable);
                parameters.Add(StoredProcedureResources.CorreoResponsable, request.correoElectronicoResponsable);
                parameters.Add(StoredProcedureResources.DescripcionEmpresa, request.acercaEmpresa);
                parameters.Add(StoredProcedureResources.ImgUrl, request.imgUrl);


                var result = await dbConnection.ExecuteAsync(
                           sql: StoredProcedureResources.sp_Empresa_ActualizarInfo,
                           param: parameters,
                           transaction: null,
                           commandTimeout: DatabaseHelper.TIMEOUT,
                           commandType: CommandType.StoredProcedure
                        );
                response.success = result > 0;
                return response;
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

        public async Task<IEnumerable<GetEmpresaListaOfertasActivasResponse>> getOfertasActivasEmpresa(GetEmpresaListaOfertasActivasRequest request)
        {
            try
            {
                IEnumerable<GetEmpresaListaOfertasActivasResponse> result = null;

                dbConnection.Open();
                using (var transaction = dbConnection.BeginTransaction())
                {
                    try
                    {
                        var parameters = new DynamicParameters();
                        parameters.Add(StoredProcedureResources.idUsuario, request.idUsuario);

                        result = await dbConnection.QueryAsync<GetEmpresaListaOfertasActivasResponse>(
                            sql: StoredProcedureResources.sp_OfertasTrabajo_ActivasEmpresa_Consultar,
                            transaction: transaction,
                            param: parameters,
                            commandTimeout: DatabaseHelper.TIMEOUT,
                            commandType: CommandType.StoredProcedure
                            );

                        if (result != null && result.ToList().Count > 0)
                        {
                            foreach (var ofertaActiva in result)
                            {
                                if (ofertaActiva.postulantes > 0)
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

        public async Task<bool> SetStatusOfertaActivaBorrar(DeleteOfertaTrabajoActivaRequest request)
        {
            try
            {
                var response = new UpdateEmpresaDatosResponse();

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
                dbConnection?.Close();
            }
        }

        public async Task<IEnumerable<GetEmpresaOfertasRevisionResponse>> getOfertasRevisionEmpresa(GetEmpresaOfertasRevisionRequest request)
        {
            try
            {
                IEnumerable<GetEmpresaOfertasRevisionResponse> result = null;

                dbConnection.Open();

                var parameters = new DynamicParameters();
                parameters.Add(StoredProcedureResources.idUsuario, request.idUsuario);

                result = await dbConnection.QueryAsync<GetEmpresaOfertasRevisionResponse>(
                    sql: StoredProcedureResources.sp_OfertasTrabajo_EnRevisionEmpresa_Consultar,
                    transaction: null,
                    param: parameters,
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
                dbConnection?.Close();
            }
        }

        public async Task<IEnumerable<GetEmpresaOfertasHistorialResponse>> getOfertasHistorialEmpresa(GetEmpresaOfertasHistorialRequest request)
        {
            try
            {
                IEnumerable<GetEmpresaOfertasHistorialResponse> result = null;

                dbConnection.Open();

                var parameters = new DynamicParameters();
                parameters.Add(StoredProcedureResources.idUsuario, request.idUsuario);

                result = await dbConnection.QueryAsync<GetEmpresaOfertasHistorialResponse>(
                    sql: StoredProcedureResources.sp_OfertasTrabajo_HistorialEmpresa_Consultar,
                    transaction: null,
                    param: parameters,
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
                dbConnection?.Close();
            }
        }

        public async Task<GetOfertasTrabajoDetalleResponse> GetDetallesOferta(GetOfertasTrabajoDetalleRequest request)
        {
            try
            {
                GetOfertasTrabajoDetalleResponse result = null;

                dbConnection.Open();
                using (var transaction = dbConnection.BeginTransaction())
                {
                    try
                    {
                        var parameters = new DynamicParameters();
                        parameters.Add(StoredProcedureResources.idOferta, request.idOferta);

                        result = await dbConnection.QueryFirstAsync<GetOfertasTrabajoDetalleResponse>(
                            sql: StoredProcedureResources.sp_OfertasTrabajo_Detalles_Consultar,
                            transaction: transaction,
                            param: parameters,
                            commandTimeout: DatabaseHelper.TIMEOUT,
                            commandType: CommandType.StoredProcedure
                            );

                        if (result != null)
                        {
                            if(result.beneficiosRegistrados)
                            {
                                result.beneficiosOferta = await dbConnection.QueryAsync<BeneficiosOferta>(
                                    sql: StoredProcedureResources.sp_BeneficiosOferta_Consultar,
                                    transaction: transaction,
                                    param: parameters,
                                    commandTimeout: DatabaseHelper.TIMEOUT,
                                    commandType: CommandType.StoredProcedure
                                    );
                            }
                            result.habilidadesOferta = await dbConnection.QueryAsync<HabilidadesOferta>(
                                    sql: StoredProcedureResources.sp_HabilidadesOferta_Consultar,
                                    transaction: transaction,
                                    param: parameters,
                                    commandTimeout: DatabaseHelper.TIMEOUT,
                                    commandType: CommandType.StoredProcedure
                                    );
                            result.conocimientosOferta = await dbConnection.QueryAsync<ConocimientosOferta>(
                                    sql: StoredProcedureResources.sp_ConocimientosOferta_Consultar,
                                    transaction: transaction,
                                    param: parameters,
                                    commandTimeout: DatabaseHelper.TIMEOUT,
                                    commandType: CommandType.StoredProcedure
                                    );

                            result.responsabilidadesOferta = await dbConnection.QueryAsync<ResponsabilidadesOferta>(
                                    sql: StoredProcedureResources.sp_ResponsabilidadesOferta_Consultar,
                                    transaction: transaction,
                                    param: parameters,
                                    commandTimeout: DatabaseHelper.TIMEOUT,
                                    commandType: CommandType.StoredProcedure
                                    );
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
    }
}
