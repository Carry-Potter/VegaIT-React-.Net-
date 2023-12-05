using CSharpFunctionalExtensions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using TimeSheet.Core.Entities;
using TimeSheet.Core.Repository;

namespace TimeSheet.Persistance.Repository 
{
    public class ClientRepository : IClientRepository
    {
        private readonly SqlConnection _sqlConnection;
        public ClientRepository(SqlConnection sql)
        {
            _sqlConnection = sql;
        }
        public void Create(Client client)
        {
            using SqlCommand command = new SqlCommand("INSERT INTO Client(Id,Name,Address,City,Country) VALUES  Id = @id," +
                " Name=@name, Address=@address, City=@city, Country=@country", _sqlConnection);
          
            command.Parameters.AddWithValue("@id", client.Id);
            command.Parameters.AddWithValue("@Name", client.Name);
            command.Parameters.AddWithValue("@Address", client.Address);
            command.Parameters.AddWithValue("@City", client.City);
            command.Parameters.AddWithValue("@Country", client.Country);
            command.ExecuteNonQuery();

        }
        
        public void Update(Client client)
        {

            using SqlCommand command = new SqlCommand("UPDATE  Client SET  Name=@name, Address=@address, City=@city, Country=@country  WHERE  Id = @id", _sqlConnection);
            command.Parameters.AddWithValue("@id", client.Id);
            command.Parameters.AddWithValue("@Name", client.Name);
            command.Parameters.AddWithValue("@Address", client.Address);
            command.Parameters.AddWithValue("@City", client.City);
            command.Parameters.AddWithValue("@Country", client.Country);
            command.ExecuteNonQuery();
        }
        public IEnumerable<Client> FindALL(int currentPage, int pageSize = 5)
        {
            var listClient = new List<Client>();

            int strana = pageSize * (currentPage - 1);

            using SqlCommand command = new SqlCommand("SELECT * FROM Client Order By Id OFFSET @strana ROWS FETCH NEXT @pageSize ROWS ONLY", _sqlConnection);

            command.Parameters.Add("@strana", SqlDbType.Int);
            command.Parameters["@strana"].Value = strana;

            command.Parameters.Add("@pageSize", SqlDbType.Int);
            command.Parameters["@pageSize"].Value = pageSize;

            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    listClient.Add(Client.Create(reader.GetInt32(reader.GetOrdinal("Id")),
                    reader.GetString(reader.GetOrdinal("Name")),
                    reader.GetString(reader.GetOrdinal("Address")),
                    reader.GetString(reader.GetOrdinal("City")),
                    reader.GetString(reader.GetOrdinal("Country"))).Value);
                }
                return listClient;

            }
        }
        public void Delete(int id)
        {
            using SqlCommand command = new SqlCommand("DELETE FROM Client WHERE Id = @id", _sqlConnection);
            command.Parameters.AddWithValue("@id",id);
            command.ExecuteNonQuery();
                
        }
        public Maybe<Client> FindById(int id)
        {
            using SqlCommand command = new SqlCommand("SELECT * FROM Client WHERE Id=@id", _sqlConnection);
            command.Parameters.AddWithValue("@id", id);

            using (SqlDataReader reader = command.ExecuteReader()) {
                if (!reader.Read())
                {
                    return Maybe<Client>.None;
                }
                return Client.Create(reader.GetInt32(reader.GetOrdinal("Id")),
                    reader.GetString(reader.GetOrdinal("Name")),
                    reader.GetString(reader.GetOrdinal("Address")),
                    reader.GetString(reader.GetOrdinal("City")),
                    reader.GetString(reader.GetOrdinal("Country"))).Value;
            
            }
        }
    }
}
