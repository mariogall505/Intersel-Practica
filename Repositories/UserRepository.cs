using Dapper;
using Intersel_Practica.Dto;
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
    public class UserRepository
    {
        InterselEntities context = new InterselEntities();
        public async Task<IEnumerable<UserDto>> GetUsers()
        {
            try
            {
                var p = new DynamicParameters();
                p.Add("Error", 0, DbType.Int32, direction: ParameterDirection.InputOutput);
                p.Add("DescError", "", DbType.String, direction: ParameterDirection.InputOutput);
                using (var cn = new SqlConnection(context.Database.Connection.ConnectionString))
                {
                    var result = await cn.QueryAsync<UserDto>("spGetUsers", p, commandType: CommandType.StoredProcedure);
                    return result;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }
        public async Task<UserDto> CRUDUser(UserDto dto)
        {
            try
            {
                var userDto = new UserDto();
                var p = new DynamicParameters();
                p.Add("option",dto.Option);
                p.Add("userId", dto.ApplicationUserId);
                p.Add("roleId", dto.RoleId);
                p.Add("userName", dto.UserName);
                p.Add("password", dto.Password);
                p.Add("Error", 0, DbType.Int32, direction: ParameterDirection.InputOutput);
                p.Add("DescError", "", DbType.String, direction: ParameterDirection.InputOutput);
                using (var cn = new SqlConnection(context.Database.Connection.ConnectionString))
                {
                    var result = await cn.ExecuteAsync("spCRUDUser", p, commandType: CommandType.StoredProcedure);
                    userDto.DescError= p.Get<string>("DescError");
                    userDto.Error= p.Get<int>("Error");
                    return userDto;
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