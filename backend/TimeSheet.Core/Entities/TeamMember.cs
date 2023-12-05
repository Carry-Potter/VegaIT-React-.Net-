using CSharpFunctionalExtensions;
using System;
using System.Collections.Generic;
using System.Text;
using TimeSheet.Core.Entities.Enums;
using TimeSheet.Core.Entities.ValueObjects;

namespace TimeSheet.Core.Entities
{
    public class TeamMember
    {
        public int Id { get; }
        public MemberName Name { get; }
        public Name Username { get; }
        public Email Email { get; }
        public Hours Hours { get; }
        public UserStatus Status { get; }
        public WorkStatus Workstatus { get; }


        public TeamMember(MemberName name, int id, Email email, Hours hours)
        {
            Id = id;
            Name = name;     
            Email = email;
            Hours = hours;
        }



        public static Result<TeamMember> Create(string name, int id,  string email, int hours)
        {
            Result<MemberName> TeamMemberResult = MemberName.Create(name);
           // Result<Name> TeamMemberResult2 = ValueObjects.Name.Create(username);
            Result<Email> TeamMemberResult3 = Email.Create(email);
            Result<Hours> TeamMemberResult4 = Hours.Create(hours);
            var result = Result.Combine(TeamMemberResult,  TeamMemberResult3, TeamMemberResult4); ;
            if (result.IsFailure)
            {
                return Result.Failure<TeamMember>("Client name can not be empty");
            }
            return Result.Success(new TeamMember(TeamMemberResult.Value, id,  TeamMemberResult3.Value, TeamMemberResult4.Value));
        }


    }
}


