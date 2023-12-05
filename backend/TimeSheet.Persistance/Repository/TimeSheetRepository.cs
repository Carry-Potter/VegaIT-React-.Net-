using CSharpFunctionalExtensions;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using TimeSheet.Core.Entities;
using TimeSheet.Core.Entities.Enums;
using TimeSheet.Core.Repository;

namespace TimeSheet.Persistance.Repository
{
    public class TimeSheetRepository : ITimeSheetRepository
    {
        private readonly SqlConnection _sqlConnection;
        public TimeSheetRepository(SqlConnection sql)
        {
            _sqlConnection = sql;
        }
        public void Delete(int id)
        {
            using SqlCommand command = new SqlCommand("DELETE FROM Client WHERE Id = @id", _sqlConnection);
            command.Parameters.AddWithValue("@id", id);
            command.ExecuteNonQuery();

        }
        public Maybe<Core.Entities.TimeSheet> FindById(int id)
        {
            using SqlCommand command = new SqlCommand("SELECT ts.Id, ts.Description AS descrp, ts.Time AS time, ts.OverTime AS time c.Name AS categoriName," +
                " ts.Category_Id ,p.ProjecName AS projecTname, t.name AS teamMember, cl.Name AS clientName, c.Name AS categoryName, t.Name AS teamMemberName  " +
                "LEFT JOIN Category AS c ON ts.Category_Id = c.Id" +
                "LEFT JOIN Project AS p ON ts.Project_Id = p.Id" +
                "LEFT JOIN TeamMember AS t ON ts.TeamMember_id = t.Id" +
                "LEFT JOIN Client AS cl ON ts.Client_Id = cl.Id FROM TimeSheet AS ts  WHERE Id=@id", _sqlConnection);

            command.Parameters.AddWithValue("@id", id);

            using (SqlDataReader reader = command.ExecuteReader())
            {
                if (!reader.Read())
                {
                    return Maybe<Core.Entities.TimeSheet>.None;
                }
                var category = Category.Create(reader.GetString(reader.GetOrdinal("categoryName")),
                                reader.GetInt32(reader.GetOrdinal("Id"))).Value;




                var client = Client.Create(reader.GetInt32(reader.GetOrdinal("Id")),
                    reader.GetString(reader.GetOrdinal("clientName")),
                    reader.GetString(reader.GetOrdinal("Address")),
                    reader.GetString(reader.GetOrdinal("City")),
                    reader.GetString(reader.GetOrdinal("Country"))).Value;

                var teamMember = TeamMember.Create(reader.GetString(reader.GetOrdinal("teamMemberName")),
                    reader.GetInt32(reader.GetOrdinal("Id")),
                //    reader.GetString(reader.GetOrdinal("Username")),
                    reader.GetString(reader.GetOrdinal("Email")),
                    reader.GetInt32(reader.GetOrdinal("Hours"))).Value;
                var Projectstatus = Enum.Parse<ProjectStatus>(reader.GetInt32(reader.GetOrdinal("Status")).ToString());

                var project = Project.Create(reader.GetInt32(reader.GetOrdinal("Id")),
                    reader.GetString(reader.GetOrdinal("Name")),
                    client,
                    reader.GetString(reader.GetOrdinal("Description")),
                    teamMember,
                    Projectstatus).Value;




                return Core.Entities.TimeSheet.Create(reader.GetInt32(reader.GetOrdinal("Id")),
                                                 category, project, client, teamMember,
                                                 reader.GetString(reader.GetOrdinal("descrp")),
                                                 reader.GetInt32(reader.GetOrdinal("time")),
                                            reader.GetInt32(reader.GetOrdinal("OverTime"))).Value;

            }
        }

             public IEnumerable<Core.Entities.TimeSheet> FindALL()
            {

                var listTimesheet = new List<Core.Entities.TimeSheet>();
                using SqlCommand command = new SqlCommand("SELECT  ts.id, ts.Description AS Description, ts.Time AS Time, ts.OverTime AS OverTime,c.Id AS Category_id, c.Name AS Names,p.Id AS Project_Id, p.Description AS Description, p.Name AS Name, p.Arhive AS Arhive, p.Status AS Status,cl.Id AS Clients_Id, cl.Name AS ClName, cl.Address AS Address, cl.City AS City, cl.Country AS Country,t.Id AS Team_id, t.Email AS Email, t.Hours AS Hours, t.Name AS TName  FROM TimeSheet AS ts LEFT JOIN Category AS c ON ts.Category_Id = c.Id LEFT JOIN Project AS p ON ts.Project_Id = p.Id LEFT JOIN Client AS cl ON ts.Client_Id = cl.Id LEFT JOIN TeamMember AS t ON ts.TeamMember_id = t.Id " , _sqlConnection);

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var category = Category.Create(reader.GetString(reader.GetOrdinal("Names")),
                                        reader.GetInt32(reader.GetOrdinal("Category_id"))).Value;


                        var client = Client.Create(reader.GetInt32(reader.GetOrdinal("Clients_Id")),
                         reader.GetString(reader.GetOrdinal("ClName")),
                         reader.GetString(reader.GetOrdinal("Address")),
                         reader.GetString(reader.GetOrdinal("City")),
                         reader.GetString(reader.GetOrdinal("Country"))).Value;

                        var teamMember = TeamMember.Create(reader.GetString(reader.GetOrdinal("TName")),
                            reader.GetInt32(reader.GetOrdinal("Team_id")),
                          
                            reader.GetString(reader.GetOrdinal("Email")),
                            reader.GetInt32(reader.GetOrdinal("Hours"))).Value;
                        var Projectstatus = Enum.Parse<ProjectStatus>(reader.GetInt32(reader.GetOrdinal("Status")).ToString());

                        var project = Project.Create(reader.GetInt32(reader.GetOrdinal("Project_Id")),
                            reader.GetString(reader.GetOrdinal("Name")),
                            client,
                            reader.GetString(reader.GetOrdinal("Description")),
                            teamMember,
                            Projectstatus).Value;



                        listTimesheet.Add(Core.Entities.TimeSheet.Create(reader.GetInt32(reader.GetOrdinal("Id")),
                                                 category, project, client, teamMember,
                                                 reader.GetString(reader.GetOrdinal("Description")),
                                                 reader.GetInt32(reader.GetOrdinal("Time")),
                                                 reader.GetInt32(reader.GetOrdinal("OverTime"))).Value);
                    }
                    return listTimesheet;
                }
             }

             public void Update(Core.Entities.TimeSheet timeSheet)
              {
                using SqlCommand command = new SqlCommand("UPDATE  Project SET  TeamMember=@teamMember Category=@category,Project=@project, Client = @client, Description = @description, Time = time, OverTime = overTime WHERE  Id = @id", _sqlConnection);
                command.Parameters.AddWithValue("@id", timeSheet.Id);
                command.Parameters.AddWithValue("@teamMember", timeSheet.TeamMember);
                command.Parameters.AddWithValue("@category", timeSheet.Category);
                command.Parameters.AddWithValue("@project", timeSheet.Project);
                command.Parameters.AddWithValue("@client", timeSheet.Client);
                command.Parameters.AddWithValue("@description", timeSheet.Description);
                command.Parameters.AddWithValue("@time", timeSheet.Time);
                command.Parameters.AddWithValue("@overTime", timeSheet.OverTime);
                command.ExecuteNonQuery();



             }

             public void Create(Core.Entities.TimeSheet timeSheet)
             {
                    using SqlCommand command = new SqlCommand("INSERT INTO TimeSheet(Id,TeamMember,Category,Project,Client,Description,Time,OverTime) VALUES  Id = @id," +
                        "TeamMember=@teamMember Category=@category,Project=@project, Client = @client, Description = @description, Time = time, OverTime = overTime WHERE  Id = @id", _sqlConnection);
                    command.Parameters.AddWithValue("@id", timeSheet.Id);
                    command.Parameters.AddWithValue("@teamMember", timeSheet.TeamMember);
                    command.Parameters.AddWithValue("@category", timeSheet.Category);
                    command.Parameters.AddWithValue("@project", timeSheet.Project);
                    command.Parameters.AddWithValue("@client", timeSheet.Client);
                    command.Parameters.AddWithValue("@description", timeSheet.Description);
                    command.Parameters.AddWithValue("@time", timeSheet.Time);
                    command.Parameters.AddWithValue("@overTime", timeSheet.OverTime);
                    command.ExecuteNonQuery();
              }








        
    }
}
