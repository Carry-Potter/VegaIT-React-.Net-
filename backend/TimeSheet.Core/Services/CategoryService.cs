using CSharpFunctionalExtensions;
using System;
using System.Collections.Generic;
using System.Text;
using TimeSheet.Core.Entities;
using TimeSheet.Core.Repository;

namespace TimeSheet.Core.Services
{
    public class CategoryService
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryService(ICategoryRepository category)
        {
            _categoryRepository = category;
        }
        public Result Delete(int id)
        {
            if (_categoryRepository.FindById(id).HasNoValue)
            {
                return Result.Failure("no id!");
            }
            _categoryRepository.Delete(id);
            return Result.Success();


        }
        public IEnumerable<Category> GetAll()
        {
            return _categoryRepository.FindALL();
        }

        public Result Update(Category category)
        {
            if (_categoryRepository.FindById(category.Id).HasNoValue)
            {
                return Result.Failure("no id!");
            }
            _categoryRepository.Update(category);
            return Result.Success();
        }
        public Result FindById(int id)
        {
            var vrednost = _categoryRepository.FindById(id);

            if (_categoryRepository.FindById(id).HasNoValue)
            {
                return Result.Failure("no id!");
            }
            return Result.Success(vrednost);
        }
    }
}
