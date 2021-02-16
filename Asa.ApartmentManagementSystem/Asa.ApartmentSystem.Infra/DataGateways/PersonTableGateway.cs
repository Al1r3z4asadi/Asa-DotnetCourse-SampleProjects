using ASa.ApartmentManagement.Core.BaseInfo.DataGateways;
using ASa.ApartmentManagement.Core.BaseInfo.DTOs;
using System;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace Asa.ApartmentSystem.Infra.DataGateways
{
    internal class PersonTableGateway : IPersonTableGateway
    {
        private string _connectionString;

        public PersonTableGateway(string connectionString)
        {
            _connectionString = connectionString;
        }



        public async Task<int> InsertPersonAsync(PersonDTO personDTO)
        {
            int id = 0;
            using (var connection = new SqlConnection(_connectionString))
            {
                using (var cmd = new SqlCommand())
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandText = "[dbo].[buildings_create]";
                    cmd.Parameters.AddWithValue("@full_name", personDTO.FullName);
                    cmd.Parameters.AddWithValue("@phone_number", personDTO.PhoneNumber);
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
