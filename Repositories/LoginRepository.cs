using Dapper;
using Intersel_Practica.Dto;
using Intersel_Practica.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace Intersel_Practica.Repositories
{
    public class LoginRepository
    {
        InterselEntities context = new InterselEntities();
        public async Task<LoginDto> Login(ApplicationUser model)
        {
            try
            {
                var dto = new LoginDto();
                using (var cn = new SqlConnection(context.Database.Connection.ConnectionString))
                {
                    var p = new DynamicParameters();
                    p.Add("userName", model.UserName);
                    p.Add("passwordP", model.Password);
                    p.Add("Error", 0, DbType.Int32, direction: ParameterDirection.InputOutput);
                    p.Add("DescError", "", DbType.String, direction: ParameterDirection.InputOutput);
                    dto.User= await cn.QuerySingleOrDefaultAsync<ApplicationUser>("spLogin", p, commandType: CommandType.StoredProcedure);
                    if (dto!=null)
                    {
                        dto.DescError= p.Get<string>("DescError");
                        dto.Error= p.Get<int>("Error");
                    }
                    return dto;
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
