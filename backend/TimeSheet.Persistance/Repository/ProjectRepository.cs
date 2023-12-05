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
    public class ProjectRepository : IProjectRepository
    {
        private readonly SqlConnection _sqlConnection;
        public ProjectRepository(SqlConnection sql)
        {
            _sqlConnection = sql;
        }
       public void Create(Project project)
       
        {
            using SqlCommand command = new SqlCommand("INSERT INTO Project(Id,Name,Client,description,TeamMember,UserStatus,Arhive) VALUES  Id = @id," +
                " Name=@name,Client=@client, Description = @description, TeamMember = @teamMember, ProjectStatus = @projectStatus", _sqlConnection);
            command.Parameters.AddWithValue("@id", project.Id);
            command.Parameters.AddWithValue("@name", project.ProjectNames);
            command.Parameters.AddWithValue("@client", project.Client);
            command.Parameters.AddWithValue("@description", project.Description);
            command.Parameters.AddWithValue("@teamMember", project.TeamMember);
            command.Parameters.AddWithValue("@userStatus", project.ProjectStatus);





        }

        public void Update(Project project)
        {
            using SqlCommand command = new SqlCommand("UPDATE  Project SET  Name=@name Name=@name,Client=@client, Description = @description, TeamMember = @teamMember, ProjectStatus = projectStatus WHERE  Id = @id", _sqlConnection);
            command.Parameters.AddWithValue("@id", project.Id);
            command.Parameters.AddWithValue("@name", project.ProjectNames);
            command.Parameters.AddWithValue("@client", project.Client);
            command.Parameters.AddWithValue("@description", project.Description);
            command.Parameters.AddWithValue("@teamMember", project.TeamMember);
            command.Parameters.AddWithValue("@userStatus", project.ProjectStatus);
           

          

        }

        public IEnumerable<Project> FindALL()
        {


            var listProject = new List<Project>();
            using SqlCommand command = new SqlCommand("SELECT pr.Id, pr.Description AS Description, pr.Name AS Name, pr.Arhive AS Arhive, pr.Status AS Status, "+
                " cl.Id AS Clients_Id,cl.Name AS CName, cl.Address AS Address, cl.City AS City, cl.Country AS Country, " +
                "t.Id AS Team_id, t.Email AS Email, t.Hours AS Hours, t.Name AS tName  FROM Project AS pr " +
               "LEFT JOIN TeamMember AS t ON pr.TeamMember_id = t.Id "+
               "LEFT JOIN Client AS cl ON pr.Client_Id = cl.Id" , _sqlConnection);


            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    var client = Client.Create(reader.GetInt32(reader.GetOrdinal("Clients_Id")),
                    reader.GetString(reader.GetOrdinal("CName")),
                    reader.GetString(reader.GetOrdinal("Address")),
                    reader.GetString(reader.GetOrdinal("City")),
                    reader.GetString(reader.GetOrdinal("Country"))).Value;

                    var teamMember = TeamMember.Create(reader.GetString(reader.GetOrdinal("tName")),
                        reader.GetInt32(reader.GetOrdinal("Team_id")),
                        reader.GetString(reader.GetOrdinal("Email")),
                        reader.GetInt32(reader.GetOrdinal("Hours"))).Value;

                    var Projectstatus = Enum.Parse<ProjectStatus>(reader.GetInt32(reader.GetOrdinal("Status")).ToString());

                    listProject.Add(Project.Create(reader.GetInt32(reader.GetOrdinal("Id")),
                        reader.GetString(reader.GetOrdinal("Name")),
                        client,
                        reader.GetString(reader.GetOrdinal("Description")),
                        teamMember,
                        Projectstatus).Value);
                }
                return listProject;
            }
        }
        public void Delete(int id)
        {
            using SqlCommand command = new SqlCommand("DELETE FROM Project WHERE Id = @id", _sqlConnection);
            command.Parameters.AddWithValue("@id", id);
            command.ExecuteNonQuery();

        }
        public Maybe<Project> FindById(int id)
        {
            using SqlCommand command = new SqlCommand("SELECT pr.Id, pr.Description AS Description, pr.Name AS Name, pr.Arhive AS Arhive, pr.Status AS Status,cl.Id AS Clients_Id,cl.Name AS CName, cl.Address AS Address, cl.City AS City, cl.Country AS Country,t.Id AS Team_id, t.Email AS Email, t.Hours AS Hours, t.Name AS tName  FROM Project AS pr LEFT JOIN TeamMember AS t ON pr.TeamMember_id = t.Id LEFT JOIN Client AS cl ON pr.Client_Id = cl.Id WHERE pr.Id = 1 ", _sqlConnection);
            command.Parameters.AddWithValue("@id", id);

            using (SqlDataReader reader = command.ExecuteReader())
            {
                if (!reader.Read())
                {
                    return Maybe<Project>.None;
                }
                var client = Client.Create(reader.GetInt32(reader.GetOrdinal("Id")),
                    reader.GetString(reader.GetOrdinal("CName")),
                    reader.GetString(reader.GetOrdinal("Address")),
                    reader.GetString(reader.GetOrdinal("City")),
                    reader.GetString(reader.GetOrdinal("Country"))).Value;

                var teamMember = TeamMember.Create(reader.GetString(reader.GetOrdinal("tname")),
                    reader.GetInt32(reader.GetOrdinal("Team_id")),
                    reader.GetString(reader.GetOrdinal("Email")),
                    reader.GetInt32(reader.GetOrdinal("Hours"))).Value;

                var Projectstatus = Enum.Parse<ProjectStatus>(reader.GetInt32(reader.GetOrdinal("Status")).ToString());


              

                return Project.Create(reader.GetInt32(reader.GetOrdinal("Id")),
                    reader.GetString(reader.GetOrdinal("Name")),
                    client,
                    reader.GetString(reader.GetOrdinal("Description")),
                    teamMember,
                    Projectstatus).Value;

            }
        }
    }
}
