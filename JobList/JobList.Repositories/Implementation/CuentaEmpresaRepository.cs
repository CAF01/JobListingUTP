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
    using System.ComponentModel;

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
                parameters.Add(StoredProcedureResources.idOferta);

                var result = await dbConnection.QueryFirstAsync(
                    sql: StoredProcedureResources.sp_LoginEmpresa,
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
    }
}
