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

    public class CuentaDocenteRepository : ICuentaDocenteRepository
    {
        private readonly ConfigurationPaging configuration;
        private readonly IDbConnection dbConnection;

        // Constructor
        public CuentaDocenteRepository(IDbConnection connections, IOptions<ConfigurationPaging> options)
        {
            this.configuration = options.Value;
            this.dbConnection = connections;
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

        // Insertar una oferta de trabajo
        public async Task<InsertOfertaTrabajoResponse> insertOfertaTrabajo(InsertOfertaTrabajoExternaRequest request)
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
                        parameters.Add(StoredProcedureResources.SueldoMaxEstimado, request.sueldoMaxEstimado);
                        parameters.Add(StoredProcedureResources.Lugar, request.lugar);
                        parameters.Add(StoredProcedureResources.FechaCreacion, request.fechaCreacion);


                        parameters.Add(StoredProcedureResources.idNuevaOferta, direction: ParameterDirection.Output);

                        await dbConnection.ExecuteAsync(
                                           sql: StoredProcedureResources.sp_OfertasTrabajo_Crear,
                                           transaction: transaction,
                                           param: parameters,
                                           commandTimeout: DatabaseHelper.TIMEOUT,
                                           commandType: CommandType.StoredProcedure);

                        idOferta = parameters.Get<int>(StoredProcedureResources.idNuevaOferta);
                        if (idOferta > 0)
                        {
                            if (request.conocimientos.ToList().Count > 0)//fluent No nulo
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
                                    parameters.Add(StoredProcedureResources.idNuevaResponsabilidad, direction: ParameterDirection.Output);

                                    await dbConnection.ExecuteAsync(
                                           sql: StoredProcedureResources.sp_ResponsabilidadesOferta_Insertar,
                                           transaction: transaction,
                                           param: parameters,
                                           commandTimeout: DatabaseHelper.TIMEOUT,
                                           commandType: CommandType.StoredProcedure);
                                    var nuevaResponsabilidad = parameters.Get<int>(StoredProcedureResources.idNuevaResponsabilidad);
                                    if (nuevaResponsabilidad > 0)
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
                                        campoBeneficiosActualizado = true;
                                    }
                                }
                            }

                            //Datos Contacto
                            parameters = new DynamicParameters();
                            parameters.Add(StoredProcedureResources.idUsuarioDocente, request.idUsuario);
                            parameters.Add(StoredProcedureResources.idUsuarioEgresado, 0);
                            parameters.Add(StoredProcedureResources.idOferta, idOferta);
                            parameters.Add(StoredProcedureResources.idDatoContacto, direction: ParameterDirection.Output);

                            await dbConnection.ExecuteAsync(
                                           sql: StoredProcedureResources.sp_DatosContacto_Insertar,
                                           transaction: transaction,
                                           param: parameters,
                                           commandTimeout: DatabaseHelper.TIMEOUT,
                                           commandType: CommandType.StoredProcedure);

                            var idDatoContacto = parameters.Get<int>(StoredProcedureResources.idDatoContacto);

                            if (idDatoContacto > 0)
                            {
                                parameters = new DynamicParameters();
                                parameters.Add(StoredProcedureResources.Empresa, request.detallesContacto.empresa);
                                parameters.Add(StoredProcedureResources.ActividadEmpresa, request.detallesContacto.actividadEmpresa);
                                parameters.Add(StoredProcedureResources.idDatoContacto, idDatoContacto);
                                parameters.Add(StoredProcedureResources.Domicilio, request.detallesContacto.domicilio);
                                parameters.Add(StoredProcedureResources.CP, request.detallesContacto.CP);
                                parameters.Add(StoredProcedureResources.Telefonos, request.detallesContacto.telefonos);
                                parameters.Add(StoredProcedureResources.CorreoEmpresa, request.detallesContacto.correoEmpresa);
                                parameters.Add(StoredProcedureResources.DescripcionEmpresa, request.detallesContacto.descripcionEmpresa);
                                parameters.Add(StoredProcedureResources.NombreResponsable, request.detallesContacto.nombreResponsable);
                                parameters.Add(StoredProcedureResources.TelefonoResponsable, request.detallesContacto.telefonoResponsable);
                                parameters.Add(StoredProcedureResources.CorreoResponsable, request.detallesContacto.correoResponsable);
                                parameters.Add(StoredProcedureResources.ImgUrl, request.detallesContacto.imgUrl);
                                
                                parameters.Add(StoredProcedureResources.idDetalleContacto, direction: ParameterDirection.Output);

                                await dbConnection.ExecuteAsync(
                                           sql: StoredProcedureResources.sp_DetallesContacto_Insertar,
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
                        if (idOferta > 0)
                        {
                            await this.deleteOfertaFallida(idOferta);
                            response.idOferta = -1;
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

        // Historial de ofertas de un docente
        public async Task<PaginationListResponse<ReadHistorialOfertasDocenteResponse>> readHistorialOfertasDocente(ReadHistorialOfertasDocenteRequest request)
        {
            try
            {
                dbConnection.Open();
                var parameters = new DynamicParameters();
                parameters.Add(StoredProcedureResources.idUsuarioDocente, request.idUsuarioDocente);
                parameters.Add(StoredProcedureResources.Skip, request.Skip);
                parameters.Add(StoredProcedureResources.Take, request.Take);

                var result = await dbConnection.QueryMultipleAsync(
                           sql: StoredProcedureResources.sp_OfertasTrabajo_HistorialDocente_Consultar,
                           param: parameters,
                           transaction: null,
                           commandTimeout: DatabaseHelper.TIMEOUT,
                           commandType: CommandType.StoredProcedure
                        );

                var dynamicResult = result.Read<ReadHistorialOfertasDocenteResponse>();

                return new PaginationListResponse<ReadHistorialOfertasDocenteResponse>(dynamicResult,dynamicResult.Count(),configuration.PageSize);
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
        public async Task<PaginationListResponse<ReadOfertasActivasDocenteResponse>> readOfertasActivasDocente(ReadOfertasActivasDocenteRequest request)
        {
            try
            {
                PaginationListResponse<ReadOfertasActivasDocenteResponse> pagination = null;
                dbConnection.Open();
                using (var transaction = dbConnection.BeginTransaction())
                {
                    try
                    {
                        var parameters = new DynamicParameters();
                        parameters.Add(StoredProcedureResources.idUsuarioDocente, request.idUsuarioDocente);
                        parameters.Add(StoredProcedureResources.Skip, request.Skip);
                        parameters.Add(StoredProcedureResources.Take, request.Take);

                        var result = await dbConnection.QueryMultipleAsync(
                                   sql: StoredProcedureResources.sp_OfertasTrabajo_ActivasDocente_Consultar,
                                   param: parameters,
                                   transaction: null,
                                   commandTimeout: DatabaseHelper.TIMEOUT,
                                   commandType: CommandType.StoredProcedure
                                );

                        var dynamicResult = result.Read<ReadOfertasActivasDocenteResponse>();

                        pagination = new PaginationListResponse<ReadOfertasActivasDocenteResponse>(dynamicResult, dynamicResult.Count(), configuration.PageSize);

                        if (result != null && pagination.Data!=null && pagination.Data.Count() > 0)
                        {
                            foreach (var ofertaActiva in pagination.Data)
                            {
                                if (ofertaActiva.numeroPostulantes >= 1)
                                    ofertaActiva.semaforo = "amarillo";
                                if (ofertaActiva.numeroPostulantes == 0)
                                    ofertaActiva.semaforo = "verde";
                                if (ofertaActiva.numeroPostulantes > 0)
                                {
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

        // Listado de ofertas en revisión de un docente
        public async Task<PaginationListResponse<ReadOfertasRevisionDocenteResponse>> readOfertasRevisionDocente(ReadOfertasRevisionDocenteRequest request)
        {
            try
            {
                dbConnection.Open();
                var parameters = new DynamicParameters();
                parameters.Add(StoredProcedureResources.idUsuarioDocente, request.idUsuarioDocente);
                parameters.Add(StoredProcedureResources.Skip, request.Skip);
                parameters.Add(StoredProcedureResources.Take, request.Take);

                var result = await dbConnection.QueryMultipleAsync(
                           sql: StoredProcedureResources.sp_OfertasTrabajo_EnRevisionDocente_Consultar,
                           param: parameters,
                           transaction: null,
                           commandTimeout: DatabaseHelper.TIMEOUT,
                           commandType: CommandType.StoredProcedure
                        );

                var dynamicResult = result.Read<ReadOfertasRevisionDocenteResponse>();
                return new PaginationListResponse<ReadOfertasRevisionDocenteResponse>(dynamicResult,dynamicResult.Count(),configuration.PageSize); 
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

        public async Task<bool> updateUltimoAccesoSistema(int idUsuario)
        {
            try
            {
                dbConnection.Open();
                var parameters = new DynamicParameters();
                parameters.Add(StoredProcedureResources.idUsuario, idUsuario);
                parameters.Add(StoredProcedureResources.Fecha, MexicoDateHelper.obtainDate());

                var result = await dbConnection.ExecuteAsync(
                           sql: StoredProcedureResources.sp_Docentes_UltimoAcceso_Actualizar,
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
