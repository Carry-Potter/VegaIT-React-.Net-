using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Time.Sheet.Web.DTO;
using TimeSheet.Core.Repository;
using TimeSheet.Core.Services;

namespace Time.Sheet.Web.Controlers
{
    [Route("api/teammember")]
    [ApiController]
    public class TeamMemberController : Controller
    {

        public readonly TeamMemberService _teamMemberService;
        public readonly ITeamMemberRepository _teamMemberRepository;
        private readonly IMapper _mapper;
        public TeamMemberController(TeamMemberService teamMemberService, ITeamMemberRepository teamMemberRepository,
            IMapper mapper)
        {
            _teamMemberService = teamMemberService;
            _teamMemberRepository = teamMemberRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var teamMember = _teamMemberService.GetAll();
            var results = _mapper.Map<IEnumerable<TeamMemberDTO>>(teamMember);

            return Ok(results);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var teamMember = _teamMemberRepository.FindById(id);

            if (teamMember.HasNoValue)
            {
                return BadRequest();
            }

            var vrednost = teamMember.Value.Name.ToString();

            var teamMemberResult = new TeamMemberDTO()
            {
                Id = teamMember.Value.Id,
                Hours = teamMember.Value.Hours.ToString(),
                Name = teamMember.Value.Name.ToString(),
                Email= teamMember.Value.Email.ToString(),
                
                


            };

            return Ok(teamMemberResult);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteClient(int id)
        {
            var Result = _teamMemberService.Delete(id);
            if (Result.IsFailure)
            {
                return BadRequest();
            }
            return Ok();
        }

    }
}
