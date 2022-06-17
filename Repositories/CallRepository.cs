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
    public class CallRepository
    {
        InterselEntities context = new InterselEntities();
        public async Task<IEnumerable<CellLine>> GetCellLines()
        {
            try
            {
                var p = new DynamicParameters();
                p.Add("Error", 0, DbType.Int32, direction: ParameterDirection.InputOutput);
                p.Add("DescError", "", DbType.String, direction: ParameterDirection.InputOutput);
                using (var cn = new SqlConnection(context.Database.Connection.ConnectionString))
                {
                    var result= await cn.QueryAsync<CellLine>("spGetCellLines", p, commandType: CommandType.StoredProcedure);
                    return result;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }

        public async Task<IEnumerable<CallDetailDto>> GetCallDetailByMobileLine(CellLine model)
        {
            try
            {
                var p = new DynamicParameters();
                p.Add("MobileLine", model.MobileLine);
                p.Add("Error", 0, DbType.Int32, direction: ParameterDirection.InputOutput);
                p.Add("DescError", "", DbType.String, direction: ParameterDirection.InputOutput);
                using (var cn = new SqlConnection(context.Database.Connection.ConnectionString))
                {
                    var result = await cn.QueryAsync<CallDetailDto>("spGetCallDetail", p, commandType: CommandType.StoredProcedure);
                    foreach (var item in result)
                    {
                        item.Description=model.Description;
                        item.Hour=Convert.ToDateTime(item.DateTime).ToString("hh:mm:ss");
                        item.DateTime=Convert.ToDateTime(item.DateTime).ToString("dd/MM/yyyy");
                    }
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