using CSharpFunctionalExtensions;
using System;
using System.Collections.Generic;
using System.Text;
using TimeSheet.Core.Entities;

namespace TimeSheet.Core.Repository
{
    public interface ICategoryRepository
    {

        void Delete(int id);
        Maybe<Category> FindById(int id);
        void Update(Category category);
        IEnumerable<Category> FindALL();
        void Create(Category category);
    }
}
