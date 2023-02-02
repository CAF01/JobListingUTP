using Dapper;
using JobList.Entities.Helpers;
using JobList.Entities.Models;
using JobList.Entities.Requests;
using JobList.Resources;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JobList.Repositories.Service;

namespace JobList.Repositories.Implementation 
{
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
    }
}
