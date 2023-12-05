using CSharpFunctionalExtensions;
using System;
using System.Collections.Generic;
using System.Text;
using TimeSheet.Core.Entities;
using TimeSheet.Core.Repository;

namespace TimeSheet.Core.Services
{
    public class ProjectService
    {
        private readonly IProjectRepository _projectRepository;

        public ProjectService(IProjectRepository project)
        {
            _projectRepository = project;
        }

        public Result Delete(int id)
        {
            if (_projectRepository.FindById(id).HasNoValue)
            {
                return Result.Failure("no id!");
            }
            _projectRepository.Delete(id);
            return Result.Success();


        }
        public IEnumerable<Project> GetAll()
        {
            return _projectRepository.FindALL();
        }

        public Result Update(Project project)
        {
            if (_projectRepository.FindById(project.Id).HasNoValue)
            {
                return Result.Failure("no id!");
            }
            _projectRepository.Update(project);
            return Result.Success();
        }
        public Result FindById(Project project)
        {
            if (_projectRepository.FindById(project.Id).HasNoValue)
            {
                return Result.Failure("no id!");
            }
            _projectRepository.Update(project);
            return Result.Success();
        }
    }
}
