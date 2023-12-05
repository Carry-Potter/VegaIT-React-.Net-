using CSharpFunctionalExtensions;
using System;
using System.Collections.Generic;
using System.Text;
using TimeSheet.Core.Entities;
using TimeSheet.Core.Repository;

namespace TimeSheet.Core.Services
{
    public class TeamMemberService
    {
        private readonly ITeamMemberRepository _teamMemberRepository;

        public TeamMemberService(ITeamMemberRepository teamMember)
        {
            _teamMemberRepository = teamMember;
        }
        public Result Delete(int id)
        {
            if (_teamMemberRepository.FindById(id).HasNoValue)
            {
                return Result.Failure("no id!");
            }
            _teamMemberRepository.Delete(id);
            return Result.Success();


        }
        public IEnumerable<TeamMember> GetAll()
        {

            return _teamMemberRepository.FindALL();
        }

        public Result Update(TeamMember teamMember)
        {
            if (_teamMemberRepository.FindById(teamMember.Id).HasNoValue)
            {
                return Result.Failure("no id!");
            }
            _teamMemberRepository.Update(teamMember);
            return Result.Success();
        }
        public Result FindById(TeamMember teamMember)
        {
            if (_teamMemberRepository.FindById(teamMember.Id).HasNoValue)
            {
                return Result.Failure("no id!");
            }
            _teamMemberRepository.Update(teamMember);
            return Result.Success();
        }
    }
}