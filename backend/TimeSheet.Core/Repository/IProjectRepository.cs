using CSharpFunctionalExtensions;
using System;
using System.Collections.Generic;
using System.Text;
using TimeSheet.Core.Entities;
using TimeSheet.Core.Entities.Enums;

namespace TimeSheet.Core.Repository
{
    public interface IProjectRepository
    {

        void Delete(int id);
        Maybe<Project> FindById(int id);
        void Update(Project project);
        void Create(Project project);
        IEnumerable<Project> FindALL();


    }
}
