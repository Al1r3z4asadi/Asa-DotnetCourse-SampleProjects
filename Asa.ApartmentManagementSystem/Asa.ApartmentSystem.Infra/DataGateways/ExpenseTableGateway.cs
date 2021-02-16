using ASa.ApartmentManagement.Core.BaseInfo.DataGateways;
using ASa.ApartmentManagement.Core.BaseInfo.DTOs;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace Asa.ApartmentSystem.Infra.DataGateways
{
    public class BuildingTableGateway : IBuildingTableGateway
    {
        string _connectionString;
        public BuildingTableGateway(string connectionStrin)
        {
            _connectionString = connectionStrin;
        }

        public async Task<int> InsertExpenseAsync(ExpenseDTO expense)
        {
            int id = 0;
            using (var connection = new SqlConnection(_connectionString))
            {
                using (var cmd = new SqlCommand())
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandText = "[dbo].[expense_create]";
                    cmd.Parameters.AddWithValue("@title", expense.title);
                    cmd.Parameters.AddWithValue("@category_id", expense.category_id);
                    cmd.Parameters.AddWithValue("@from", expense.from);
                    cmd.Parameters.AddWithValue("@to", expense.to);
                    cmd.Parameters.AddWithValue("@cost", expense.cost);
                    cmd.Connection = connection;
                    cmd.Connection.Open();
                    var result = await cmd.ExecuteScalarAsync();
                    id = Convert.ToInt32(result);
                }
            }
            return id;
        }
    }
}
