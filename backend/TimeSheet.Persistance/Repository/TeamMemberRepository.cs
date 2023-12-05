using CSharpFunctionalExtensions;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using TimeSheet.Core.Entities;
using TimeSheet.Core.Repository;

namespace TimeSheet.Persistance.Repository
{
    public class TeamMemberRepository : ITeamMemberRepository
    {
        private readonly SqlConnection _sqlConnection;
        public TeamMemberRepository(SqlConnection sql)
        {
            _sqlConnection = sql;
        }
        public void Delete(int id)
        {
            using SqlCommand command = new SqlCommand("DELETE FROM TeamMember WHERE Id = @id", _sqlConnection);
            command.Parameters.AddWithValue("@id", id);
            command.ExecuteNonQuery();

        }
        public Maybe<TeamMember> FindById(int id)
        {
            using SqlCommand command = new SqlCommand("SELECT * FROM TeamMember WHERE Id=@id", _sqlConnection);
            command.Parameters.AddWithValue("@id", id);

            using (SqlDataReader reader = command.ExecuteReader())
            {
                if (!reader.Read())
                {
                    return Maybe<TeamMember>.None;
                }
                return TeamMember.Create(reader.GetString(reader.GetOrdinal("Name")),
                    reader.GetInt32(reader.GetOrdinal("Id")),
                    reader.GetString(reader.GetOrdinal("Email")),
                    reader.GetInt32(reader.GetOrdinal("Hours"))).Value;
                   
                    

            }
        }

        public void Create(TeamMember teamMember)
        {
            using SqlCommand command = new SqlCommand("INSERT INTO TeamMember(Id, Username, Email, Hours) VALUES  Id = @id," +
             " Username = @username, Email = @email, Hours = @hours ", _sqlConnection);
            command.Parameters.AddWithValue("@id", teamMember.Id);
           // command.Parameters.AddWithValue("@Username", teamMember.Name);
            command.Parameters.AddWithValue("@Email", teamMember.Email);
            command.Parameters.AddWithValue("@Hours", teamMember.Hours);
            command.ExecuteNonQuery();



        }

        public void Update(TeamMember teamMember)
        {
            using SqlCommand command = new SqlCommand("UPDATE  TeamMember SET  Username=@username, Email=@email, Hours=@hours WHERE  Id = @id", _sqlConnection);
            command.Parameters.AddWithValue("@id", teamMember.Id);
          //  command.Parameters.AddWithValue("@Username", teamMember.Name);
            command.Parameters.AddWithValue("@Email", teamMember.Email);
            command.Parameters.AddWithValue("@Hours", teamMember.Hours);
            command.ExecuteNonQuery();

        }
        public IEnumerable<TeamMember> FindALL()
        {
            var listTeamMember = new List<TeamMember>();
            using SqlCommand command = new SqlCommand("SELECT * FROM TeamMember", _sqlConnection);
     
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {

                        listTeamMember.Add(TeamMember.Create(reader.GetString(reader.GetOrdinal("Name")),
                                reader.GetInt32(reader.GetOrdinal("Id")),
                              //  reader.GetString(reader.GetOrdinal("Name")),
                                reader.GetString(reader.GetOrdinal("Email")),
                                   reader.GetInt32(reader.GetOrdinal("Hours"))).Value);
                    }

                    return listTeamMember;
                }

        }



    }
}
