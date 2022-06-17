using Dapper;
using Intersel_Practica.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace Intersel_Practica.Repositories
{
    public class RoleRepository
    {
        InterselEntities context = new InterselEntities();
        public async Task<IEnumerable<Role>> GetRoles(int userId)
        {
            try
            {
                var p = new DynamicParameters();
                p.Add("userId", userId);
                p.Add("Error", 0, DbType.Int32, direction: ParameterDirection.InputOutput);
                p.Add("DescError", "", DbType.String, direction: ParameterDirection.InputOutput);
                using (var cn = new SqlConnection(context.Database.Connection.ConnectionString))
                {
                    var result = await cn.QueryAsync<Role>("spGetRoles", p, commandType: CommandType.StoredProcedure);
                    return result;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }

    }
}