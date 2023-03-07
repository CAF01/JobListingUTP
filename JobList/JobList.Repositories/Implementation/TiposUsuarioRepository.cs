using Dapper;
using JobList.Entities.Helpers;
using JobList.Entities.Models;
using JobList.Repositories.Service;
using JobList.Resources;
using MediatR;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobList.Repositories.Implementation
{
    public class TiposUsuarioRepository : ITiposUsuarioRepository
    {
        private readonly IDbConnection dbConnection;

        public TiposUsuarioRepository(IDbConnection connections)
        {
            this.dbConnection = connections;
        }

        // Tarea para devolver lista de tipos de usuario
        public async Task<IEnumerable<ReadTiposUsuarioResponse>> readTiposUsuario()
        {
            try
            {
                dbConnection.Open();
                var parameters = new DynamicParameters();

                var result = await dbConnection.QueryAsync<ReadTiposUsuarioResponse>(
                           sql: StoredProcedureResources.sp_TiposUsuario_Consultar,
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
