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
    [Route("api/project")]
    [ApiController]
    public class ProjectController : Controller
    {
        public readonly ProjectService _projectService;
        public readonly IProjectRepository _projectRepository;
        private readonly IMapper _mapper;
        public ProjectController(ProjectService projectService, IProjectRepository projectRepository,
            IMapper mapper)
        {
            _projectService = projectService;
            _projectRepository = projectRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var project = _projectService.GetAll();
            var results = _mapper.Map<IEnumerable<ProjectDTO>>(project);

            return Ok(results);
        }



        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var project = _projectRepository.FindById(id);

            if (project.HasNoValue)
            {
                return BadRequest();
            }



            var projectResult = new ProjectDTO()
            {
                ProjectNames = project.Value.ProjectNames.ToString(),
                
                Description= project.Value.Client.ToString()


            };

            return Ok(projectResult);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteClient(int id)
        {
            var Result = _projectService.Delete(id);
            if (Result.IsFailure)
            {
                return BadRequest();
            }
            return Ok();
        }

    }
}
