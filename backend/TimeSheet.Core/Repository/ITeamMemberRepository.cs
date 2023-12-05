using CSharpFunctionalExtensions;
using System;
using System.Collections.Generic;
using System.Text;
using TimeSheet.Core.Entities;

namespace TimeSheet.Core.Repository
{
    public interface ITeamMemberRepository
    {
        void Delete(int id);
        Maybe<TeamMember> FindById(int id);
        void Create(TeamMember teamMember);
        void Update(TeamMember teamMember);
        IEnumerable<TeamMember> FindALL();
    }
}
