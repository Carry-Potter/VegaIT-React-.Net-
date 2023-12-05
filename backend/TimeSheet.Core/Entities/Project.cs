using CSharpFunctionalExtensions;
using System;
using System.Collections.Generic;
using System.Text;
using TimeSheet.Core.Entities.Enums;
using TimeSheet.Core.Entities.ValueObjects;

namespace TimeSheet.Core.Entities
{
    public class Project
    {
        public int Id { get; }
        public ProjectName ProjectNames { get; }
        public string Description { get; }
        public Client Client { get; }
        public TeamMember TeamMember { get; }
        public ProjectStatus ProjectStatus { get; }
        


        public Project( int id, ProjectName projectNames, Client client, string description ,TeamMember teamMember, ProjectStatus projectStatus)
        {
            Id = id;
            ProjectNames = projectNames;
            Client = client;
            Description = description;
            TeamMember = teamMember;
            ProjectStatus = projectStatus;
            
        }



        public static Result<Project> Create(int id, string name, Client client, string description, TeamMember teamMember, ProjectStatus projectStatus)
        {
            Result<ProjectName> ProjectNameResult = ProjectName.Create(name);
          
            
            var result = Result.Combine(ProjectNameResult);
            if (result.IsFailure)
            {
                return Result.Failure<Project>("Client name can not be empty");
            }
            return Result.Success(new Project(id, ProjectNameResult.Value, client,description, teamMember, projectStatus));
        }

    }
}
