using CSharpFunctionalExtensions;
using System;
using System.Collections.Generic;
using System.Text;
using TimeSheet.Core.Entities.ValueObjects;

namespace TimeSheet.Core.Entities
{
    
   public class TimeSheet
    {
        public int Id { get; }
        public DateTime Calender { get; }
        public Category Category { get; }
        public Project Project { get; }
        public Client Client { get; }
        public Name Description { get; }
        public Hours Time { get; }
        public Hours OverTime { get; }
        public TeamMember TeamMember { get; }


        public TimeSheet(int id, Category category, Project project, Client client, TeamMember teamMember, Name description, Hours time, Hours overTime)
        {
            Id = id;
            TeamMember = teamMember;
            Category = category;
            Project = project;
            Client = client;
            Description = description;
            Time = time;
            OverTime = overTime;
        }

        public static Result<TimeSheet> Create(int id, Category category, Project project, Client client, TeamMember teamMember, string description, int time, int overTime)
        {

            Result<Name> TimeSheetResult4 = Name.Create(description);
            Result<Hours> TimeSheetResult3 = Hours.Create(time);
            Result<Hours> TimeSheetResult2 = Hours.Create(overTime);
            var result = Result.Combine(TimeSheetResult4, TimeSheetResult3,TimeSheetResult2); ;
            if (result.IsFailure)
            {
                return Result.Failure<TimeSheet>("Client name can not be empty");
            }
            return Result.Success(new TimeSheet(id, category, project, client, teamMember, TimeSheetResult4.Value, TimeSheetResult3.Value, TimeSheetResult2.Value));
        }


    }
}
